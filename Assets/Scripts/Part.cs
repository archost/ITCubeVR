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

    public void Install(GameObject jointPoint)
    {
        rigidBody.isKinematic = true;
        grabInteractable.enabled = false;
        transform.SetParent(jointPoint.transform);
        gameObject.transform.position = jointPoint.transform.position;
        state = PartState.Installed;
    }

}
public enum PartState
{
    Idle,
    Fixed,
    Installed,
    Await
}