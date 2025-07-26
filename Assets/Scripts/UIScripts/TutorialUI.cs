using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialUI : BaseUI
{
    [SerializeField] Button startbutton;
    protected override UIState GetUIState()
    {
        return UIState.Tutorial;
    }


}
