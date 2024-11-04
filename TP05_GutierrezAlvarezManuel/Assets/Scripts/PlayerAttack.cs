
using UnityEngine;

public class PlayerAtack : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    private Animator animator;
    private PlayerMovement playerMovement;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject fireBall;

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
        fireBall.transform.position = firePoint.position;
        fireBall.GetComponent<FireBall>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

}
