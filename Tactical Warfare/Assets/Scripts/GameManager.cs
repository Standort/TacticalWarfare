using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<BaseEntity> allEntitiesPrefab;
    Dictionary<Team, List<BaseEntity>> entityByTeam = new Dictionary<Team, List<BaseEntity>>();
    int unitsPerTeam = 1;
    // Start is called before the first frame update
    void Start()
    {
        InstantiateUnits();
    }


    private void InstantiateUnits()
    {
        entityByTeam.Add(Team.Team1, new List<BaseEntity>());
        entityByTeam.Add(Team.Team2, new List<BaseEntity>());
        for(int i = 0; i< unitsPerTeam; i++ )
        {
            //new unit for team 1 
            int randomIndex = UnityEngine.Random.Range(0, allEntitiesPrefab.Count - 1);
            BaseEntity newEntity = Instantiate(allEntitiesPrefab[randomIndex]);
            entityByTeam[Team.Team1].Add(newEntity);
        }
    }
public enum Team
{
    Team1;
    Team2;
}



}