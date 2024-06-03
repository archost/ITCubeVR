using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitCheck : MonoBehaviour
{
    public GameObject targetObject; // ������ �� ������, � ������� ����� ��������� ������������

    void OnCollisionEnter(Collision collision)
    {
        // ���������, �������� �� ������ ������������ ���, ������� ��� �����
        if (collision.gameObject == targetObject)
        {
            Debug.Log("Collided with the target object: " + targetObject.name);
        }
    }

    void OnTriggerEnter(Collider other)
    {

        // ���������, �������� �� ������ �������� ���, ������� ��� �����
        if (other.gameObject == targetObject)
        {
            Debug.Log("Triggered by the target object: " + targetObject.name);
        }
    }

}
