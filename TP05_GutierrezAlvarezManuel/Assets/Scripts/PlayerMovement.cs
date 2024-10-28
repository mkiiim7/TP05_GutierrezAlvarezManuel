using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float jumpTime = 1f;
    [SerializeField] private KeyCode keyLeft = KeyCode.LeftArrow;
    [SerializeField] private KeyCode keyRight = KeyCode.RightArrow;
    [SerializeField] private KeyCode space = KeyCode.Space;
    private void Awake()
    {

        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

   
    void Update()
    {

        if (Input.GetKey(space))
        {
            jumpTime = speed * Time.deltaTime * 1000;
            if (jumpTime > 1 )
            {
                jumpTime = 1 * Time.deltaTime;
            }
           
            rb.AddForce(Vector2.up * speed * Time.deltaTime * 1000);

        }


        if (Input.GetKey(keyLeft))
        {
            rb.AddForce(Vector2.left * speed * Time.deltaTime * 1000);
        }

        if (Input.GetKey(keyRight))
        {
            rb.AddForce(Vector2.right * speed * Time.deltaTime * 1000);
        }
    }
}
