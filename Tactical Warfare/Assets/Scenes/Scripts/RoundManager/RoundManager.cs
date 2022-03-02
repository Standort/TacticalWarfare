using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundManager : MonoBehaviour
{
  
    [SerializeField] Text round;
    public bool combat;
    int rounds = 1;
   public TimerS timeScript;
    // Start is called before the first frame update
    void Start()
    {
        
        round.text = "Round " + rounds.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        combat = timeScript.IsCombatTime();
        //print(combat);
            
            if (timeScript.IsCombatOver())
            {
                rounds++;
                OnNewRound();
            }
        
            
        
        
    }
    private void OnNewRound()
    {
        round.text = "Round " + rounds.ToString();
    }
    public bool CombatPhase()
    {
        return combat;
    }
}
