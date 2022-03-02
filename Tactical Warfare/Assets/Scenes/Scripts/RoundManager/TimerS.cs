using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimerS : MonoBehaviour
{
    [SerializeField] Text timerText;
    private float StartTime;
    [SerializeField] private int placementTime;
    [SerializeField] private int combatTime;
    private bool Combat = false;
    private bool CombatOver = false;
    float temp = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartTime = Time.time;
       placementTime = 10;
        combatTime = 10;
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - StartTime - temp ;
        string seconds = t.ToString("f0");
        timerText.text = seconds;
       
        if (Combat)
        {
            CombatOver = false;
            timerText.GetComponent<Text>().color = Color.red;
            if (t >= combatTime)
            {
                //if(Are all units dead?


          
                temp += t;
           
                Combat = !Combat;
                CombatOver = true;
            }
        }
        else
        {

            CombatOver = false;
            timerText.GetComponent<Text>().color = Color.green;
            if (t >= placementTime)
            {
                temp += t;
            
                Combat = !Combat; 
            }
        }
      
    }
    public bool IsCombatTime()
    {
        return Combat;
    }
    public bool IsCombatOver()
    {
        return CombatOver;
    }
}
