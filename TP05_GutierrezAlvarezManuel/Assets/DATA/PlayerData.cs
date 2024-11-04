using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerData", menuName = "Player/Data", order = 1)]
public class PlayerData : ScriptableObject
{
    [Header("Movement/Jump")]
    public float speed = 1f;
    public float speedSalto = 1f;
    public bool grounded = false;


    [Header("Atack")]
    
    public float attackCooldown = 1f;
    public float speedFireBall = 6f;

}
