using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IGCombat : MonoBehaviour
{
    public enum HeroAttackType { Melee, Ranged };
    public HeroAttackType heroAttackType;

    public Transform targetedEnemy;
    public float attackRange;
    public float rotateSpeedForAttack;
    public float ASpeed;
    private IGMovment moveScript;
    private CharacterStats statsScript;
    private Animator anim;
    private PCFindNearest find;

    public bool basicAtkIdle = false;
    public bool isHeroAlive;
    public bool performMeleeAttack = true;

    [Header("Ranged Varialbes")]
    public bool performRangedAttack = true;
    public GameObject projPrefab;
    public Transform projSpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        moveScript = GetComponent<IGMovment>();
        statsScript = GetComponent<CharacterStats>();
        anim = gameObject.GetComponentInChildren<Animator>();
        find = GetComponent<PCFindNearest>();
    }

    // Update is called once per frame
    void Update()
    {
        targetedEnemy = moveScript.currentTarget;
        if (targetedEnemy != null)
        {
            ASpeed = statsScript.AS.baseValue;
            anim.speed = ASpeed;
            if(moveScript.targetReached)
            {
                //MELEE CHARACTRER
                if (statsScript.range.baseValue <= 1)
                {
                 
                    if (performMeleeAttack)
                    {
                      //  Debug.Log("Attack The Minion");

                        //Start Coroutine To Attack
                        StartCoroutine(MeleeAttackInterval());
                    }
                }

                //RANGED CHARACTER
                else 
                {
                 

                    if (performRangedAttack)
                    {
                        Debug.Log("Attack The Minion");

                        //Start Coroutine To Attack
                        StartCoroutine(RangedAttackInterval());
                    }
                }

            }
        }

    }
    public void getTarget(Transform x)
    {
        targetedEnemy = x;
    }
    IEnumerator MeleeAttackInterval()
    {
        performMeleeAttack = false;
        anim.SetBool("Basic Attack", true);
        
        yield return new WaitForSeconds(1/ASpeed);
        MeleeAttack();
        if (targetedEnemy == null)
        {
            anim.SetBool("Basic Attack", false);
            performMeleeAttack = true;
           
        }
    }

    IEnumerator RangedAttackInterval()
    {
        performRangedAttack = false;
        anim.SetBool("Basic Attack", true);

        yield return new WaitForSeconds(statsScript.AttackTime / ((100 + statsScript.AttackTime) * 0.01f));

        if (targetedEnemy == null)
        {
            anim.SetBool("Basic Attack", false);
            performRangedAttack = true;
        }
    }

    public void MeleeAttack()
    {
        if (targetedEnemy != null)
        {
            //print("Attacked");
            targetedEnemy.GetComponentInParent<CharacterStats>().TakePDamage(statsScript.gameObject.GetComponent<CharacterStats>().AD.baseValue);
            
        }

        performMeleeAttack = true;
    }

    public void RangedAttack()
    {
        if (targetedEnemy != null)
        {
            
               // SpawnRangedProj("Minion", targetedEnemy);
           
        }

        performRangedAttack = true;
    }

    //void SpawnRangedProj(string typeOfEnemy, GameObject targetedEnemyObj)
    //{
    //    float dmg = statsScript.gameObject.GetComponent<CharacterStats>().AD.baseValue;

    //    Instantiate(projPrefab, projSpawnPoint.transform.position, Quaternion.identity);

    //    if (typeOfEnemy == "Minion")
    //    {
    //        projPrefab.GetComponent<RangedProjectile>().targetType = typeOfEnemy;

    //        projPrefab.GetComponent<RangedProjectile>().target = targetedEnemyObj;
    //        projPrefab.GetComponent<RangedProjectile>().targetSet = true;
    //    }
    //}
}