using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private PlayerData playerData;
   
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
           rb.velocity = new Vector2(rb.velocity.x, playerData.speed * Time.deltaTime * 10000);

        }


        if (Input.GetKey(keyLeft))
        {
            transform.localScale = new Vector3(-1, 1, 1);
            rb.AddForce(Vector2.left * playerData.speed * Time.deltaTime * 10000);
            
        }

        if (Input.GetKey(keyRight))
        {
            transform.localScale = new Vector3(1, 1, 1);
            rb.AddForce(Vector2.right * playerData.speed * Time.deltaTime * 10000);
            
        }
    }
}
