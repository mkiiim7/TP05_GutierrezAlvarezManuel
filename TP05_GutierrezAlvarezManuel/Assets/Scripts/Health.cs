using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    private Animator animator;
    public float currentHealth;
    private bool dead;


    private void Awake()
    {
        currentHealth = playerData.startingHealth;
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage,0, playerData.startingHealth);

        if (currentHealth > 0 ) 
        {
            animator.SetTrigger("Hurt");
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
    

}
