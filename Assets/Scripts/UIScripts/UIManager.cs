using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum UIState
{
    Home,
    Game,
    Score,
    Tutorial
}

public class UIManager : MonoBehaviour
{
    static UIManager instance;
    public static UIManager Instance
    { get { return instance; } }

    UIState currentState = UIState.Home;
    [SerializeField] HomeUI homeUI = null;
    [SerializeField] GameUI gameUI = null;
    [SerializeField] ScoreUI scoreUI = null;
    [SerializeField] TutorialUI tutorialUI = null;
    
    BlockController blockController = null;
    int playCount = 0;





    private void Awake()
    {
        instance = this;
        

        blockController = FindObjectOfType<BlockController>();

        homeUI?.Init(this);
        gameUI?.Init(this);
        scoreUI?.Init(this);
        tutorialUI?.Init(this);


        ChangeState(UIState.Home);

    }

    public void ChangeState(UIState state)
    {
        currentState = state;
        homeUI?.SetActive(currentState);
        gameUI?.SetActive(currentState);
        scoreUI?.SetActive(currentState);
        tutorialUI?.SetActive(currentState);
    }

    public void OnClickStart()
    {
        if(playCount == 0)
        {
            ChangeState(UIState.Tutorial);
            playCount++;
            return;
        }
        blockController.ReStartGame();
        
        ChangeState(UIState.Game);
    }

    public void OnClickExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void UpdateScore()
    {
        gameUI.SetUI(blockController.Score, blockController.Combo);

    }

    public void SetScoreUI()
    {
        
        scoreUI.SetUI(blockController.Score,  blockController.Combo, blockController.HighScore, blockController.HighCombo);
        
        ChangeState(UIState.Score);
    }
}





