using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCostume", menuName = "Player/Costume")]
public class CostumeData : ScriptableObject
{
    public Sprite sprite;
    public RuntimeAnimatorController animatorController;
    public GameObject modelPrefab;
}
