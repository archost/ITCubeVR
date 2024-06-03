using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class JointPoint : MonoBehaviour
{
    [SerializeField]
    private Part _part;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _part.gameObject && _part.state != PartState.Installed)
        {
            Debug.Log("Triggered by the target object: " + _part.partId);
            _part.Install(this.gameObject);
        }
    }
}
