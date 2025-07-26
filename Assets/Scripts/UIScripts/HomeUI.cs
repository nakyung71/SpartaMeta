using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeUI : BaseUI
{
    [SerializeField] Button startbutton;
    [SerializeField] Button exitbutton;

    protected override UIState GetUIState()
    {
        return UIState.Home;
    }
}
