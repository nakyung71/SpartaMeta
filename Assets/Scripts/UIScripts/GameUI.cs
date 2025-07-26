using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUI : BaseUI
{
    [SerializeField] TextMeshProUGUI gameScoreText;
    [SerializeField] TextMeshProUGUI comboScoreText;
    
    
    protected override UIState GetUIState()
    {
        return UIState.Game;
    }
    public void SetUI(int score,int combo)
    {
        gameScoreText.text = score.ToString();
        comboScoreText.text = combo.ToString();
    }
}
