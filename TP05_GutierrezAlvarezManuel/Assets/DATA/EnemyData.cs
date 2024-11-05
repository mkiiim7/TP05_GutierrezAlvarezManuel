using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "EnemyData", menuName = "Enemy/Data", order = 2)]
public class EnemyData : ScriptableObject
{
    [Header("Atack")]
    public float attackcooldown;

    [Header("Health")]
    public float startingHealth;



}
