using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCFindNearest : MonoBehaviour
{
    IGMovment movmentScript;
    
    // Start is called before the first frame update
    void Start()
    {
        movmentScript = gameObject.GetComponent<IGMovment>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.GetComponent<CharacterStats>().team == 1)
        {

       
        int team = gameObject.GetComponent<CharacterStats>().team;
        GameObject[] allChar = GameObject.FindGameObjectsWithTag("Unit");
        int NumOfUnits = allChar.Length;
        Transform[] GOtrans;
        GOtrans = new Transform[NumOfUnits];

        for (int i = 0; i < NumOfUnits; i++)
        {
            GOtrans[i] = allChar[i].transform;
        }
        var lastChild = GetClosestEnemy(GOtrans);
        print(gameObject.transform.GetChild(2).name + "closest " + lastChild.GetChild(lastChild.childCount - 1) + " child positon: " + lastChild.position);

            Vector3 T = lastChild.position;
      

           movmentScript.Move(T);
        }
    }
    Transform GetClosestEnemy(Transform[] enemies)
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
