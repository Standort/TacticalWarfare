using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCFindNearest : MonoBehaviour
{
    IGMovment movmentScript;
   // Transform[] ArrayOfEnemies = new Transform[x];
    // Start is called before the first frame update
    void Start()
    {
        movmentScript = gameObject.GetComponent<IGMovment>();
     Transform[]  ArrayOfEnemies = FindAllEnemies();

    }

    // Update is called once per frame
    void Update()
    {
      Transform[]  ArrayOfEnemies = FindAllEnemies();







       
            if (ArrayOfEnemies.Length != 0)
            {
                var lastChild
                    = GetClosestEnemy(ArrayOfEnemies);
                movmentScript.getTarget(lastChild);
            }

        // print(gameObject.transform.GetChild(2).name + "closest " + lastChild.GetChild(lastChild.childCount - 1) + " child positon: " + lastChild.position);







    }
    public Transform[] FindAllEnemies()//on round start
    {
       
        GameObject[] allChar = GameObject.FindGameObjectsWithTag("Unit");
        // int i = 0;
       // Transform[] GOtrans;
         List<Transform> GOTrans = new List<Transform>();
       
        for (int i= 0; i< allChar.Length; i++)
        {
            if(gameObject.GetComponent<IsTargetable>().IsItTargetable(allChar[i].transform))
            {
                GOTrans.Add( allChar[i].transform);
            }
        }
       Transform[] GOTrans2 = GOTrans.ToArray();
        return GOTrans2;
    }
   public Transform GetClosestEnemy(Transform[] enemies)
    {
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (Transform t in enemies)
        {
            if(t.position != currentPos)
            {
                float dist = Vector3.Distance(t.position, currentPos);
                if (dist < minDist)
                {

                    tMin = t;
                    minDist = dist;


                }
            }
            
        }
        if (tMin != null)
            return tMin;
        else
            return transform;
    }
}
