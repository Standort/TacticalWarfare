using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IGState : MonoBehaviour
{
   public bool isDead = false;
    public bool isStunned = false;
    public bool isRooted = false;
    public bool sameTeam = false;
    public bool isDraggable = true;
    CharacterStats statScript;


    // Start is called before the first frame update
    void Start()
    {
        statScript = GetComponent<CharacterStats>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Died()
    {
        isDead = true;

    }
    public void Revied()
    {
        isDead = false;
    }
    public void NotDrag()
    {
        isDraggable = false;
    }
    
}
