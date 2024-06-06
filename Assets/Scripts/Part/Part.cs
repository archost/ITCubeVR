using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit;

public class Part : MonoBehaviour
{
    [SerializeField]
    private PartData data;

    private Rigidbody rb;

    private Collider col;

    private XRGrabInteractable grabInteractable;

    public PartState state;

    public int PartID { get; private set; }

    void Start()
    {
        PartID = data.ID;
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
        grabInteractable = GetComponent<XRGrabInteractable>();
        state = PartState.Idle;
        UpdateState(state);
    }

    
    void Update()
    {
        
    }

    public void Install(Vector3 position, Quaternion rotation)
    {
        state = PartState.Installed;
        UpdateState(state);
        gameObject.transform.position = position;
        gameObject.transform.rotation = rotation;
    }

    public void UpdateState(PartState newState)
    {
        switch (newState)
        {
            case PartState.Idle:
                col.isTrigger = false;
                rb.isKinematic = false;
                if (grabInteractable != null) grabInteractable.enabled = true;
                break;
            case PartState.Fixed:
                break;
            case PartState.Installed:
                col.isTrigger = false;
                rb.isKinematic = true;
                if (grabInteractable != null) grabInteractable.enabled = false;
                break;
            case PartState.Await:
                break;
            default:
                break;
        }
    }

}

public enum PartState
{
    Idle,
    Fixed,
    Installed,
    Await
}