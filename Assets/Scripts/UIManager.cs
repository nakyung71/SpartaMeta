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
    
        BlockController blockController = null;
    

    private void Awake()
        {
            instance = this;
            Screen.SetResolution(480, 640, true);

            blockController=FindObjectOfType<BlockController>();
            homeUI?.Init(this);
            gameUI?.Init(this);
            scoreUI?.Init(this);

            ChangeState(UIState.Home);

        }

        public void ChangeState(UIState state)
        {
            currentState = state;
            homeUI?.SetActive(currentState);
            gameUI?.SetActive(currentState);

            scoreUI?.SetActive(currentState);
        }

        public void OnClickStart()
        {
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
        gameUI.SetUI(theStack.Score, theStack.Combo, theStack.MaxCombo);
    }

    public void SetScoreUI()
    {
        Debug.Log($"scoreUI is null? {scoreUI == null} / blockController is null? {blockController == null}");
        scoreUI.SetUI(blockController.Score,  blockController.Combo, blockController.HighScore, blockController.HighCombo);
        
        ChangeState(UIState.Score);
    }
}





