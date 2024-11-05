using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickable : MonoBehaviour
{
    [SerializeField] private float healthValue;
    [SerializeField] private AudioSource soundHeart;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            soundHeart.Play();
            collision.GetComponent<Health>().AddHealth(healthValue);
            gameObject.SetActive(false);
        }
    }
}