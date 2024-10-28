using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BackgroundParallax : MonoBehaviour
{
    private float startPos;
    private float length;
    [SerializeField] public GameObject cam;
    [SerializeField] public float parallaxSpeed;

    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

   
    void Update()
    {
        float distance = cam.transform.position.x * parallaxSpeed ;

        float movement = cam.transform.position.x * (1- parallaxSpeed);

        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);

        if (movement > startPos + length ) 
        {
            startPos += length;  
        }
        else if (movement < startPos - length)
        {
            startPos -= length;
        }
    }
}
