using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class JointPoint : MonoBehaviour
{
    public StageController sc = null;

    public PartData suitablePart = null;

    public GameObject ArrowPrefab = null;

    private GameObject currArrow = null;

    private float arrowOffset = 1f;

    [SerializeField]
    private Vector3 fixedPosition = Vector3.zero;

    private void Awake()
    {
        if (ArrowPrefab == null) ArrowPrefab = Resources.Load<GameObject>("Prefabs/Arrow");
        if (suitablePart == null) Debug.LogError("No suitable PartData found!", gameObject);
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
        currArrow.transform.localPosition = new Vector3(0, arrowOffset, 0);
        currArrow.transform.localRotation = Quaternion.identity;
    }

    void Update()
    {
        
    }

    public void ForceAttach(Part part)
    {
        part.Install(gameObject.transform.position + fixedPosition, gameObject.transform.rotation);
        gameObject.SetActive(false);
        if (currArrow != null) Destroy(currArrow);
        sc.currentStage += 1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Part part))
        {
            if (part.PartID == suitablePart.ID)
            {
                ForceAttach(part);
            }
        }
    }

}
