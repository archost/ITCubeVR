using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCheck : MonoBehaviour
{
    public GameObject targetObject; // Ссылка на объект, с которым нужно проверить столкновение

    void OnCollisionEnter(Collision collision)
    {
        // Проверяем, является ли объект столкновения тем, который нам нужен
        if (collision.gameObject == targetObject)
        {
            Debug.Log("Collided with the target object: " + targetObject.name);
        }
    }

    void OnTriggerEnter(Collider other)
    {

        // Проверяем, является ли объект триггера тем, который нам нужен
        if (other.gameObject == targetObject)
        {
            Debug.Log("Triggered by the target object: " + targetObject.name);
        }
    }

}
