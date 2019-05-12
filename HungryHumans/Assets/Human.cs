using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Human : MonoBehaviour
{
    public GameObject HumanObject;
    public string Name;
    public string Gender;
    public float Age;
    public bool CanWork, IsSick, GoHome;
    public Job ActiveJob;
    public int HumanStorageSpace, MaxHumanStorageSpace;
    public NavMeshAgent HumanAI;
    VillageManager VM;
    public House Home;


    void Start(){
        VM = GameObject.Find("GameManager").GetComponent<VillageManager>();
    }

    void FixedUpdate()
    {
        Age += 1 * Time.fixedDeltaTime / 15;

        if(Age > 15f && !IsSick)
        {
            CanWork = true;
        }
        else
        {
            CanWork = false;
        }

        if(GoHome)
        {
            WalkHome();
        }
        else if(CanWork)
        {
            DoJob();

            HumanAI.enabled = true;
            GetComponent<BoxCollider>().enabled = true;
            GetComponentInChildren<SkinnedMeshRenderer>().enabled = true;
        }
    }
    float HumanStorageSpaceTemp;
    void DoJob()
    {
        if(HumanStorageSpace < MaxHumanStorageSpace)
        {
            HumanAI.SetDestination(ActiveJob.WorkPos);

            if(HumanAI.velocity.magnitude < 0.1f && Vector3.Distance(this.transform.position, ActiveJob.WorkPos) > 1f)
            {
                print(this.transform.name + ": Path Is Blocked / i cant move / something is blocking me from walking there!" + Vector3.Distance(this.transform.position, ActiveJob.WorkPos));
                
            }
            else if(Vector3.Distance(this.transform.position, ActiveJob.WorkPos) > 1f)
            {
                HumanAI.SetDestination(ActiveJob.WorkPos);
            }
            else if(Vector3.Distance(this.transform.position, ActiveJob.WorkPos) <= 1f)
            {
                print(this.transform.name + ": Is Working!");
                this.transform.LookAt(new Vector3(ActiveJob.transform.position.x, this.transform.position.y, ActiveJob.transform.position.z));
                HumanStorageSpaceTemp += 1 * Time.deltaTime;
                if(HumanStorageSpaceTemp >= 1f){
                    HumanStorageSpaceTemp -= 1f;
                    HumanStorageSpace += 1;
                }
            }
        }
        else
        {
            if(Vector3.Distance(this.transform.position, VM.StorageTargetObj.transform.position) > 1f)
            {
                HumanAI.SetDestination(VM.StorageTargetObj.transform.position);
            }
            else
            {
                this.transform.LookAt(new Vector3(VM.StorageTargetObj.transform.position.x, this.transform.position.y, VM.StorageTargetObj.transform.position.z));
                VM.WoodStorage += HumanStorageSpace;
                HumanStorageSpace = 0;
            }
        }
    }

    void WalkHome()
    {
        if(Vector3.Distance(this.transform.position, Home.TargetPosObj.transform.position) > 1f)
        {
            HumanAI.SetDestination(Home.TargetPosObj.transform.position);
        }
        else
        {
            HumanAI.enabled = false;
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<MeshRenderer>().enabled = false;
        }
    }
}