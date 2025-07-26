using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour,IInteractable
{
    [SerializeField] Canvas tutorialcanvas;
    [SerializeField] Button exitButton;
    public void Interact()
    {   
        tutorialcanvas.gameObject.SetActive(true);
        exitButton.onClick.AddListener(ClosePanel);
    }

    private void ClosePanel()
    {
        tutorialcanvas.gameObject.SetActive(false);
        exitButton.onClick.RemoveAllListeners();
    }
    
}
