using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour,IInteractable
{
    [SerializeField] Canvas tutorialcanvas_1;
    [SerializeField] Canvas tutorialcanvas_2;
    [SerializeField] Button exitButton_1;
    [SerializeField] Button exitButton_2;
    [SerializeField] Button nextButton;
    public void Interact()
    {   
        tutorialcanvas_1.gameObject.SetActive(true);
        exitButton_1.onClick.AddListener(ClosePanel);
        exitButton_2.onClick.AddListener(ClosePanel);
        nextButton.onClick.AddListener(NextPage);
    }

    private void NextPage()
    {
        tutorialcanvas_1.gameObject.SetActive(false);
        tutorialcanvas_2.gameObject.SetActive(true);
        nextButton.onClick.RemoveAllListeners();
    }

    private void ClosePanel()
    {
        tutorialcanvas_1.gameObject.SetActive(false);
        tutorialcanvas_2.gameObject.SetActive(false);
        exitButton_1.onClick.RemoveAllListeners();
        exitButton_2.onClick.RemoveAllListeners();
    }
    
}
