using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : BaseUI
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI comboText;
    [SerializeField] TextMeshProUGUI bestScoreText;
    [SerializeField] TextMeshProUGUI bestComboText;

    //[SerializeField] Button startButton;
    //[SerializeField] Button exitButton;

    protected override UIState GetUIState()
    {
        return UIState.Score;
    }

    public override void Init(UIManager uiManager)
    {
        base.Init(uiManager);

       
    }
    public void SetUI(int score, int combo, int bestscore, int bestcombo)
    {
        scoreText.text = score.ToString();
        comboText.text= combo.ToString();
        bestScoreText.text= bestscore.ToString();
        bestComboText.text= bestcombo.ToString();
        
    }
}
