using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviousLocation : MonoBehaviour
{
    RoundManager myObject;
    CharacterStats statScript;
    RoundManager managerScript;
    IGChampion championScript;
    public GameObject currentTile;
    TimerS timeObject;
     TimerS timeScript;
    Quaternion currentRotation;
    // Start is called before the first frame update
    void Start()
    {
        RoundManager myObject = FindObjectOfType<RoundManager>();
        managerScript = myObject.GetComponent<RoundManager>();
        timeObject = FindObjectOfType<TimerS>();
        timeScript = timeObject.GetComponent<TimerS>();
        championScript = gameObject.GetComponent<IGChampion>();
       
        currentTile = championScript.CurrentTile;
    }

    // Update is called once per frame
    void Update()
    {
        if (!managerScript.CombatPhase())
        {
            currentTile = championScript.CurrentTile;
            Quaternion currentRotation = gameObject.transform.GetChild(gameObject.transform.childCount-1).rotation;
        }
        if (timeScript.IsCombatOver())
        {
            championScript.CurrentTile = currentTile;
            gameObject.transform.position = currentTile.transform.position;
            gameObject.transform.GetChild(gameObject.transform.childCount - 1).rotation = currentRotation;
        }
    }
    public GameObject FindClosestTile(GameObject obj)
    {

        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Tile");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - obj.transform.position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }

       
        //print(closest.gameObject.name);
        // print(closest.GetComponent<BenchTileScript>().occupied);
        return closest;
    }
}
