using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    VillageManager VM;

    void Start()
    {
        VM = GetComponent<VillageManager>();
    }

    void Update()
    {
        TextMeshPro StorageText = VM.StorageObject.GetComponentInChildren<TextMeshPro>();

        StorageText.text = "Wood: " + VM.WoodStorage + "\n Stone: " + VM.StoneStorage + " \n Metal: " + VM.MetalStorage;
    }
}
