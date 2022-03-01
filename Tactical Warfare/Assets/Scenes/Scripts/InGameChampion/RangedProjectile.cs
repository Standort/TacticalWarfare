using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedProjectile : MonoBehaviour
{
    public float damage;
    public Transform target;
    public bool targetSet;
    public string targetType;
    public float velocity = 5;
    public bool stopProjectile;
    IGCombat combatScript;
    // Update is called once per frame
    void Update()
    {
        

        
      //  print("Project script " + target);
        if (target)
        {

      
        
            if (target == null)
            {
                Destroy(gameObject);

            }
        transform.position = Vector3.MoveTowards(transform.position, target.position, velocity * Time.deltaTime);
        if(!stopProjectile)
        {
            if(Vector3.Distance(transform.position, target.position) < 0.5f)
            {
                target.GetComponentInParent<CharacterStats>().TakePDamage(damage);
                stopProjectile = true;
                Destroy(gameObject);
                    
            }
        }
        

        }
    }
}
