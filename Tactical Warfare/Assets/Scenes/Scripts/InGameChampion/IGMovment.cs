using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class IGMovment : MonoBehaviour
{
    NavMeshAgent agent;
    public float rotateSpeedMovment = 0.1f;
    public float rotateVelocity;
    public bool isMoving;
    public bool targetReached = false;
    public Transform currentTarget;
    // Start is called before the first frame update
    void Start()
    {
        
        agent = gameObject.transform.GetChild(gameObject.transform.childCount - 1).GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentTarget!= null)
        {
            Move(currentTarget.position);
        }
    }
    public void getTarget(Transform x)
    {
        currentTarget = x;
    }
    public void Move(Vector3 target)
    {
        //print(target);
       // agent.SetDestination(target);
        Quaternion rotationToLookAt = Quaternion.LookRotation(target - transform.GetChild(gameObject.transform.childCount - 1).position);
        float rotationY = Mathf.SmoothDampAngle(transform.GetChild(gameObject.transform.childCount - 1).eulerAngles.y,
            rotationToLookAt.eulerAngles.y,
            ref rotateVelocity,
            rotateSpeedMovment * (Time.deltaTime * 5));

        transform.GetChild(gameObject.transform.childCount - 1).eulerAngles = new Vector3(0, rotationY, 0);
        
        float distance = Vector3.Distance(transform.position, target);
        if (gameObject.GetComponent<CharacterStats>().range.baseValue < distance)
        {
            transform.position += transform.GetChild(gameObject.transform.childCount - 1).forward * gameObject.GetComponent<CharacterStats>().MoveSpeed.baseValue * Time.deltaTime;
            targetReached = false;
            isMoving = true;
        }
        else
        {
            targetReached = true;
            isMoving = false;
        }
           
       
    }
    public bool getMovment()
    {
        return isMoving;
    }
 
}
