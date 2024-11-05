
using UnityEngine;

public class PlayerAtack : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private UIMainMENU uiMainMenu;
    private Animator animator;
    private PlayerMovement playerMovement;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject fireBall;
    [SerializeField] private AudioSource soundFire;

    [SerializeField] private KeyCode keyAttack = KeyCode.W;
    

    private void Awake()
    {

        playerMovement = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(keyAttack) && uiMainMenu.pausa ==false) 
        {
            Attack();
            
        }
    }
    private void Attack()
    {
        soundFire.Play();
        animator.SetTrigger("Attack");
        fireBall.transform.position = firePoint.position;
        fireBall.GetComponent<FireBall>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

}
