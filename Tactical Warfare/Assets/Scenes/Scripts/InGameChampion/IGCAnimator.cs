using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IGCAnimator : MonoBehaviour
{
   public  Animator anim;
    IGMovment move;
    private void Start()
    {

      //  anim = GetComponent<Animator>();
        move = GetComponent<IGMovment>();
        anim = transform.GetChild(transform.childCount - 1).GetComponent<Animator>();
        // IGMovment move;

    }
    private void Update()
    {

        bool movment = move.getMovment();
        if (movment)
        {
            anim.SetBool("IsMoving", true);
         
        }
        else
        {
            anim.SetBool("IsMoving", false);
        }

    }
}
