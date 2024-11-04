
using UnityEngine;

public class PlayerAtack : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    private Animator animator;
    private PlayerMovement playerMovement;
    //[SerializeField] private float cooldownTimmer= 100000000f;
    //[SerializeField] private float attackCooldown = 0f;
    [SerializeField] private KeyCode keyAttack = KeyCode.W;
    

    private void Awake()
    {

        playerMovement = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(keyAttack)) 
        {
            Attack();
            
        }
    }
    private void Attack()
    {
        animator.SetTrigger("Attack");
        
    }

}
