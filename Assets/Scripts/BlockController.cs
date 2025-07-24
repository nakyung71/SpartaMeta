using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    private const float blockSize = 5f;
    float BlockMovingSpeed = 3f;
    float errorMargin = 0.2f;
    Vector2 previousPosition = new Vector2(0, -2.5f);
    int stackCount = -1;
    int comboCount = -1;

    public int HighScore { get { return highScore; } }
    int highScore;

    public int HighCombo { get { return highCombo; } }
    int highCombo;

    public int Score { get { return score; } }
    int score;

    public int Combo { get { return comboCount; } }
        

    private Vector2 blockBounds = new Vector2(blockSize, 1);

    public GameObject originBlock;
    Transform lastBlock = null;
    float blockTransition = 0f;


    private bool isMoving = false;
    
    private void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highCombo = PlayerPrefs.GetInt("HighCombo", 0);
        SpawnBlock();
        PlaceBlock();
    }

    private void Update()
    {
        if(isMoving&&lastBlock != null) 
        {
            MoveBlock();
            if (Input.GetMouseButtonDown(0))
            {
                PlaceBlock();
            }
        }

    }
    public void SpawnBlock()
    {
        if (originBlock == null)
        {
            Debug.Log("no originblock");
        }
        GameObject newBlock = null;
        Transform newtrans= null;

        newBlock = Instantiate(originBlock);
        newtrans=newBlock.transform;
        newtrans.parent=this.transform;
        newtrans.localPosition = previousPosition+Vector2.up;
        newtrans.localScale=new Vector2(blockBounds.x,blockBounds.y);
        
        this.transform.position=Vector2.down*stackCount;

        blockTransition = 0f;

        
        lastBlock=newtrans;
        isMoving = true;
        





    }
    void MoveBlock()
    {
        blockTransition += Time.deltaTime * BlockMovingSpeed;
        float movePosition = Mathf.PingPong(blockTransition, blockSize) - blockSize / 2;
        lastBlock.localPosition=new Vector2(movePosition,lastBlock.localPosition.y);
    }


    public void PlaceBlock()
    {
       
        isMoving = false;
        Vector2 currentpos=lastBlock.localPosition;
        float deltaX= previousPosition.x - currentpos.x;
        float overlap = blockBounds.x - Mathf.Abs(deltaX);
        if (deltaX <= errorMargin)
        {
            ComboCount();
            if (comboCount == 5)
            {
                Debug.Log("Combo!");
                
                overlap = blockBounds.x - Mathf.Abs(deltaX) + 0.4f;
                if(overlap>=blockSize)
                {
                    overlap= blockSize;
                }
                comboCount = 0;
            }
        }
        else
        {
            comboCount = 0;
        }
        

        if (overlap<=0)
        {
            Debug.Log("게임오버");
            isMoving = false;
            SetScore();
            UIManager.Instance.SetScoreUI();

        }
        blockBounds.x= overlap;
        lastBlock.localScale=new Vector2(blockBounds.x,blockBounds.y);
        lastBlock.localPosition = new Vector2(previousPosition.x - deltaX / 2, currentpos.y);
        previousPosition = lastBlock.localPosition; // 
        stackCount++;
        SpawnBlock(); // 
    }

    void ComboCount()
    {
        comboCount++;
       
    }
    void SetScore()
    {
        score = stackCount + comboCount * 5;
        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
        if (comboCount>highCombo)
        {
            PlayerPrefs.SetInt("HighCombo",comboCount);
        }
    }
    public void ReStartGame()
    {
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        previousPosition = new Vector2(0, -2.5f);
        blockBounds = new Vector2(blockSize, 1);
        stackCount = -1;
        comboCount = -1;
        lastBlock = null;
        isMoving = true;
        
        SpawnBlock();
        PlaceBlock();
    }
    

    
}
