using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCheck : MonoBehaviour
{
    private int health = 100;

    public AudioSource hitSound;

    void OnTriggerEnter(Collider other)
    {
        Bullet bullet = other.GetComponent<Bullet>();

        if (bullet != null)
        {
            hitSound.Play();
            health -= bullet.damage;
        }
    }

    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

}