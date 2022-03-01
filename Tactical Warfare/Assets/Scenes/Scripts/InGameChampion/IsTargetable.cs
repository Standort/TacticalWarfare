using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsTargetable : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool IsItTargetable(Transform target )
    {
        if ((gameObject.GetComponent<CharacterStats>().team == target.gameObject.GetComponent<CharacterStats>().team) || (target.gameObject.GetComponent<IGState>().isDead )       )
        {
            return false;
        }
        else
        {
         //   print("it is targetable");
            
            return true;
        }

            
    }
}
