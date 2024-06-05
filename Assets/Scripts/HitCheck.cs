using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCheck : MonoBehaviour
{
    public GameObject toDestroy;

    private int health = 100;

    public AudioSource oi_blyat;

    void OnTriggerEnter(Collider other)
    {
        Bullet bullet = other.GetComponent<Bullet>();

        if (bullet != null)
        {
            oi_blyat.Play();
            health -= bullet.damage;
        }
        else
        {
            oi_blyat.Play();
            health -= 5;
        }

    }

    void Update()
    {
        if (health <= 0)
        {
            Destroy(toDestroy);
            Destroy(gameObject);
        }
    }

}