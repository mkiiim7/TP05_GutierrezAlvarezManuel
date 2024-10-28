using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{
                     private float startPos;
    [SerializeField] public GameObject cam;
    [SerializeField] public float parallaxSpeed;

    void Start()
    {
        startPos = transform.position.x;
    }

   
    void Update()
    {
        float distance = cam.transform.position.x * parallaxSpeed ;
        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);
    }
}
