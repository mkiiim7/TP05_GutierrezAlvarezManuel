using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private EnemyData enemyData;
    private float cooldownTimer = Mathf.Infinity;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float range;
    [SerializeField] private int damage;
    private Animator animator;
    private Health playerHealth;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;
        if(PlayerInSight())
        {
         if ( cooldownTimer >= enemyData.attackcooldown )
            {
                cooldownTimer = 0;
                animator.SetTrigger("MeeleAttack");
            }
        }
    }
    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x, 
            new Vector3 (boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z), 0, Vector2.left, 0, playerLayer);

        if(hit.collider != null )
        {
            playerHealth = hit.collider.GetComponent<Health>();
        }

        return hit.collider != null;
    }
        
    private void DamagePlayer()
    {
        if (PlayerInSight())
        {
            if (health.invulnerable == false)
            {
                playerHealth.TakeDamage(damage);
            }
        }

    }



}

