using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private PlayerData playerData;
    private Animator animator;

    [SerializeField] private KeyCode keyLeft = KeyCode.LeftArrow;
    [SerializeField] private KeyCode keyRight = KeyCode.RightArrow;
    [SerializeField] private KeyCode keyjump = KeyCode.Space;
    private void Awake()
    {

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

   
    void Update()
    {

        if (Input.GetKey(keyjump) && playerData.grounded)
        {
            Jump();

        }


        if (Input.GetKey(keyLeft))
        {
            transform.localScale = new Vector3(-1, 1, 1);
            rb.AddForce(Vector2.left * playerData.speed * Time.deltaTime * 10000);
            animator.SetBool("Run", true);

        }
        if (Input.GetKeyUp(keyLeft))
        {
           
            animator.SetBool("Run", false);

        }

        if (Input.GetKey(keyRight))
        {
            transform.localScale = new Vector3(1, 1, 1);
            rb.AddForce(Vector2.right * playerData.speed * Time.deltaTime * 10000);
            animator.SetBool("Run", true);

        }
        if (Input.GetKeyUp(keyRight))
        {

            animator.SetBool("Run", false);

        }


    }
    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, playerData.speedSalto * Time.deltaTime * 10000);
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
