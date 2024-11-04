using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    private Animator animator;
    private BoxCollider2D boxCollider;
    [SerializeField] private bool hit;
    [SerializeField] private float direction;
    private void Awake()
    {

       
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (hit) return;
         {
            float movementspeed = playerData.speedFireBall * direction * Time.deltaTime;
            transform.Translate(movementspeed,0,0);
         }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        boxCollider.enabled = false;
        animator.SetTrigger("Explode");
    }

    public void SetDirection (float _direction)
    {
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;
        
        float localScalex = transform.localScale.x;

        if(Mathf.Sign(localScalex) != _direction)
        {
          localScalex = -localScalex;
          transform.localScale = new Vector3(localScalex, Mathf.Abs(transform.localScale.y), transform.localScale.z);
        }
    }

    private void Deactivate()
    { 
        gameObject.SetActive(false); 
    }   
}
