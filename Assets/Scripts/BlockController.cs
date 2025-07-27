using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    private const float blockSize = 7f;
    float BlockMovingSpeed = 3f;
    float errorMargin = 0.2f;
    Vector2 previousPosition = new Vector2(0, -2.5f);
    int stackCount = -1;
    int comboCount = -1;
    Color previousColor;
  

    public int HighScore { get { return highScore; } }
    int highScore;

    public int HighCombo { get { return highCombo; } }
    int highCombo;

    public int Score { get { return score; } }
    int score;

    public int Combo { get { return combo; } }
    int combo;
        

    private Vector2 blockBounds = new Vector2(blockSize, 1);

    public GameObject originBlock;
    GameObject lastBlock=null;
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
            SetScore();
            UIManager.Instance.UpdateScore();

        }

    }
    public void SpawnBlock()
    {
        if (originBlock == null)
        {
            Debug.Log("no originblock");
        }
        GameObject newBlock = null;
        
        newBlock = Instantiate(originBlock,transform);
        newBlock.transform.localPosition = previousPosition + Vector2.up;
        newBlock.transform.localScale = new Vector2(blockBounds.x, blockBounds.y);
        
        newBlock.GetComponent<SpriteRenderer>().color = ChangeColor();
        previousColor = newBlock.GetComponent<SpriteRenderer>().color;
        this.transform.position=Vector2.down*stackCount;

        blockTransition = 0f;


        lastBlock = newBlock;
        isMoving = true;
        
    }
    
    void MoveBlock()
    {
        blockTransition += Time.deltaTime * BlockMovingSpeed;
        float movePosition = Mathf.PingPong(blockTransition, blockSize) - blockSize / 2;
        lastBlock.transform.localPosition=new Vector2(movePosition,lastBlock.transform.localPosition.y);
    }


    public void PlaceBlock()
    {
       
        isMoving = false;
        Vector2 currentpos = lastBlock.transform.localPosition;
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
                combo++;
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
        lastBlock.transform.localScale=new Vector2(blockBounds.x,blockBounds.y);
        lastBlock.transform.localPosition = new Vector2(previousPosition.x - deltaX / 2, currentpos.y);
        previousPosition = lastBlock.transform.localPosition; // 
        stackCount++;
        SpawnBlock(); // 
    }

    void ComboCount()
    {
        comboCount++;
       
    }
    void SetScore()
    {
        score = stackCount + combo * 5;
        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
        }
        if (combo>highCombo)
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
        combo = 0;
        
        SpawnBlock();
        PlaceBlock();
    }

    Color ChangeColor()
    {

        if (previousColor == Color.red)
        {
            return Color.yellow;
        }
        else if (previousColor == Color.yellow)
        {
            return Color.green;
        }
        else if (previousColor == Color.green)
        {
            return Color.blue;
        }
        else
        {
            return Color.red;
        }
    }

}
