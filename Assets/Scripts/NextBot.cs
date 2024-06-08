using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.Events;

public class NextBot : MonoBehaviour
{
    public GameObject AnotherBot = null;

    public SoundController SC;

    [SerializeField]
    private GameObject XRRig;
    
    private Transform player = null;

    [SerializeField]
    private float flyingSpeed;

    public Transform spawnPoint;

    public Vector3 YFix;

    //[SerializeField]
    //private UnityEvent collideAction;

    private void OnEnable()
    {
        player = Camera.main.transform;
    }

    private void Update()
    {
        if (player != null)
        {
            Vector3 relativeTo = Quaternion.LookRotation((player.position + Vector3.down * 0.7f) - transform.position).eulerAngles;
            relativeTo.x = 0; relativeTo.z = 0;
            Vector3 current = transform.localRotation.eulerAngles;
            transform.localEulerAngles = Vector3.Slerp(current, relativeTo, Time.deltaTime);
            Vector3 dist = player.position - transform.position;
            float distance = dist.magnitude;
            if (distance > 0.1f)
            {
                dist = dist.normalized;
                dist.y = 0f;
                transform.position = transform.position + flyingSpeed * Time.deltaTime * dist;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Player>(out var p))
        {
            XRRig.transform.position = spawnPoint.position;
            if (SC != null) 
                SC.BackRooms();
            if (AnotherBot != null)
                AnotherBot.SetActive(true);
        }
    }
}