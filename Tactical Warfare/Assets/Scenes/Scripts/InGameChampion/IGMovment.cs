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
    private IGState state;
    // Start is called before the first frame update
    void Start()
    {

        state = GetComponent<IGState>();
    }

    // Update is called once per frame
    void Update()
    {
        if (state.CanMove())
        {


            if (currentTarget != null)
            {
                if (gameObject.GetComponent<IsTargetable>().IsItTargetable(currentTarget))
                    Move(currentTarget.position);
            }
        }
        else
        {
            isMoving = false;
            targetReached = false;
        }
    }
    public void getTarget(Transform x)
    {
        currentTarget = x;
    }
    public bool isTargetSet()
    {
        if (currentTarget != null)
            return true;
        else
            return false;
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
        if(state.CanMove())
        {

        
        if (!isInRange(distance))
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
    }
    public bool isInRange(float distance)
    {
        if (gameObject.GetComponent<CharacterStats>().range.baseValue < distance)
            return false;
        else
            return true;
    }
    public bool getMovment()
    {
        return isMoving;
    }
    public bool getTargetReached()
    {
        return targetReached;
    }
}
