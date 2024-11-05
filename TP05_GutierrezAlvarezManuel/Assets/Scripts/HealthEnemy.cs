using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEnemy : MonoBehaviour
{
    [SerializeField] private EnemyData enemyData;
    private Animator animator;
    public float currentHealth;
    private bool dead;
    [SerializeField] private float invulnerabilityDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        currentHealth = enemyData.startingHealth;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, enemyData.startingHealth);

        if (currentHealth > 0)
        {
            
            animator.SetTrigger("Hurt");
            StartInvulnerability();
        }
        else
        {
            if (dead == false)
            {
                
                
                animator.SetTrigger("Die");
                GetComponent<PlayerMovement>().enabled = false;
                dead = true;
                
            }
        }

    }
    public void StartInvulnerability()
    {

        StartCoroutine(Invulnerability());
    }
    public IEnumerator Invulnerability()
    {
        Physics2D.IgnoreLayerCollision(14, 16, true);  //14 es el layer "Player" y 16 el Layer "Enemy"
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRenderer.color = new Color(1, 0, 0, 0.8f);
            yield return new WaitForSeconds(invulnerabilityDuration / (numberOfFlashes * 3));
            spriteRenderer.color = Color.white;
            yield return new WaitForSeconds(1);

        }

        Physics2D.IgnoreLayerCollision(14, 16, false);

    }
}
