using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoard : MonoBehaviour,IInteractable
{
    [SerializeField] Canvas leaderBoardCanvas;
    [SerializeField] Button exitButton;
    [SerializeField] TextMeshProUGUI highScore;
    [SerializeField] TextMeshProUGUI highCombo;
    
    public void Interact()
    {
        int highS = PlayerPrefs.GetInt("HighScore", 0);
        int highC = PlayerPrefs.GetInt("HighCombo", 0);
        highScore.text=highS.ToString();
        highCombo.text=highC.ToString();
        leaderBoardCanvas.gameObject.SetActive(true);
        exitButton.onClick.AddListener(CloseLeaderBoard);
    }

    private void CloseLeaderBoard()
    {
        leaderBoardCanvas.gameObject.SetActive(false);
        exitButton.onClick.RemoveListener(CloseLeaderBoard);
    }

    
}
