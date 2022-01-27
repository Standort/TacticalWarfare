using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEntity : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public int baseDamge = 1;
    public int baseHealth = 1;
    public int range = 1;

    public float attacSpeed = 1f;
    public float movmentSpeed = 1f;
    protected Node currentNode;
    protected Team myTeam;
    public void Setup(Team team, Node spawnNode)
    {
        myTeam = team;
        if(myTeam == Team.Team2 )
        {
            spriteRenderer.flipX = true;
        }
        this.currentNode = spawnNode;
    }
}
