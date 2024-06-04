using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class JointPoint : MonoBehaviour
{
    [SerializeField]
    private Part _suitablePart = null;

    [SerializeField]
    public GameObject ArrowPrefab = null;

    private GameObject currArrow = null;

    private float arrowOffset = 0.5f;

    [SerializeField]
    private Vector3 fixedPosition = Vector3.zero;

    [SerializeField]
    private Quaternion fixedRotation = Quaternion.identity;

    private void Awake()
    {
        if (ArrowPrefab == null) ArrowPrefab = Resources.Load<GameObject>("Prefabs/Arrow");
        if (_suitablePart == null) Debug.LogError("No suitable PartData found!", gameObject);
    }

    void Start()
    {
        if (ArrowPrefab == null) Debug.LogError("No arrow prefab found!");
        Collider col = GetComponent<Collider>();
        if (col.isTrigger == false) Debug.LogError("Collider is not trigger!", gameObject);
        ArrowSetup();
    }

    private void ArrowSetup()
    {
        if (ArrowPrefab == null) return;
        if (currArrow != null) Destroy(currArrow);
        currArrow = Instantiate(ArrowPrefab);

        currArrow.transform.SetParent(gameObject.transform);
        currArrow.transform.localPosition = Vector3.up * 1f;
        currArrow.transform.localRotation = Quaternion.Euler(90f, 0f, 0f);
    }

    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _suitablePart.gameObject && _suitablePart.state != PartState.Installed)
        {
            Debug.Log("Triggered by the target object: " + _suitablePart.partId);
            _suitablePart.Install(this.gameObject);
        }
    }
}
