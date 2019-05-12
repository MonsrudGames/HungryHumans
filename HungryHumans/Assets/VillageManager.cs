using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillageManager : MonoBehaviour
{
    public List<Human> Villagers;
    public List<Job> jobs;

    public GameObject StorageObject;
    public GameObject StorageTargetObj;
    public float WoodStorage, StoneStorage, MetalStorage;
}
