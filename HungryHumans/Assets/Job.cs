using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Job : MonoBehaviour
{
    public GameObject Object;
    public string JobTitle;
    public string JobDetails;
    public int JobId;
    public string TypeOfJob;
    public Vector3 WorkPos;
    public GameObject WorkPosObj;

    void Awake()
    {
        WorkPos = WorkPosObj.transform.position;
    }
}