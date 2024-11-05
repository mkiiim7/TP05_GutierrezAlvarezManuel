using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private PlayerData playerData;
    [SerializeField] private UIMainMENU uiMainMenu;
    private Animator animator;
    public AudioSource soundJump;
    

    [SerializeField] private KeyCode keyLeft = KeyCode.LeftArrow;
    [SerializeField] private KeyCode keyRight = KeyCode.RightArrow;
    [SerializeField] private KeyCode keyjump = KeyCode.Space;
    private void Awake()
    {

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        uiMainMenu.pausa = false;
        

    }
    void Start()
    {
        
    }

   
    void Update()
    {

        transform.rotation = Quaternion.identity;

        if (Input.GetKeyDown(keyjump) && playerData.grounded && uiMainMenu.pausa == false)
        {
            Jump();

        }


        if (Input.GetKey(keyLeft) && uiMainMenu.pausa == false)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            rb.AddForce(Vector2.left * playerData.speed * Time.deltaTime * 10000);
            animator.SetBool("Run", true);

        }
        if (Input.GetKeyUp(keyLeft) && uiMainMenu.pausa == false)
        {
           
            animator.SetBool("Run", false);

        }

        if (Input.GetKey(keyRight) && uiMainMenu.pausa == false)
        {
            transform.localScale = new Vector3(1, 1, 1);
            rb.AddForce(Vector2.right * playerData.speed * Time.deltaTime * 10000);
            animator.SetBool("Run", true);

        }
        if (Input.GetKeyUp(keyRight) && uiMainMenu.pausa == false)
        {

            animator.SetBool("Run", false);

        }


    }
    private void Jump()
    {
        soundJump.Play() ;
        rb.velocity = new Vector2(rb.velocity.x, playerData.speedSalto );
        playerData.grounded = false;
        animator.SetBool("Grounded", false);
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            playerData.grounded = true;
            animator.SetBool("Grounded", true);
        }
    }


}
