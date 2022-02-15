using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ANIM : MonoBehaviour
{
    public Animator anim;
    
    void Start()
    {
        anim = gameObject.GetComponentInChildren<Animator>();
        

    }
    private void Update()
    {
        Animate("Die");
    }
    public void Animate(string s)
    {
        if (anim != null)
        {
            anim.Play(s);
        }
    }
}
