using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit;

public class Part : MonoBehaviour
{
    public int partId;
    public Rigidbody rigidBody;
    public XRGrabInteractable grabInteractable;
    public PartState state = PartState.Idle;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void Install(GameObject jointPoint, Vector3 fixedPosition)
    {
        grabInteractable.enabled = false;
        gameObject.transform.position = jointPoint.transform.position + fixedPosition;
        gameObject.transform.rotation = jointPoint.transform.rotation;
        state = PartState.Installed;
        Destroy(jointPoint);
        rigidBody.isKinematic = true;
    }
}
public enum PartState
{
    Idle,
    Fixed,
    Installed,
    Await
}