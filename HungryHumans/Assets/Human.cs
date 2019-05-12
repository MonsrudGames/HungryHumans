using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    public GameObject HumanObject;
    public string Name;
    public string Gender;
    public float Age;
    public Job ActiveJob;

    void Update()
    {
        Age += 1 * Time.deltaTime / 15;
    }
}