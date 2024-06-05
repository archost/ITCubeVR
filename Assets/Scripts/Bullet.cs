using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public BulletType type = BulletType.bullet5mm;

    public int damage;

    void Start()
    {
        switch (type)
        {
            case BulletType.bullet5mm:
                damage = 20;
                break;
            case BulletType.bullet9mm:
                damage = 50;
                break;
            default:
                break;
        }
    }

    void Update()
    {
        
    }
}

public enum BulletType
{
    bullet5mm,
    bullet9mm,
}