using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StageController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> jointPoints = new List<GameObject>();

    private int currentStage = 0;

    void Start()
    {
        
    }


    void Update()
    {
        if (currentStage < 4 && jointPoints[currentStage].IsDestroyed())
        {
            SetJointPoint();
        } 
    }

    void SetJointPoint()
    {
        currentStage += 1;
        if (currentStage < 4)
            jointPoints[currentStage].SetActive(true);
    }
}
