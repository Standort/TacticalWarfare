using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IGState : MonoBehaviour
{
    [SerializeField] public GameObject manager;
    public bool isDead = false;
    public bool isStunned = false;
    public bool isRooted = false;
    public bool sameTeam = false;
    public bool isDraggable = true;
    RoundManager myObject;
    CharacterStats statScript;
     RoundManager managerScript;

    // Start is called before the first frame update
    void Start()
    {
        statScript = GetComponent<CharacterStats>();
        
        RoundManager myObject = FindObjectOfType<RoundManager>();
        managerScript = myObject.GetComponent<RoundManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (managerScript.CombatPhase())
        {
            isDraggable = false;
        }
        else
            isDraggable = true;
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
    public bool CanFight()
    {
        if(!isDead && !isStunned && managerScript.CombatPhase())
        {
            return true;
        }
        return false;
    }
    public bool CanMove()
    {
        if(!isDead && !isRooted && !isStunned && managerScript.CombatPhase())
        {
         //   print("yes");
            return true;

        }
        return false;
    }
}
