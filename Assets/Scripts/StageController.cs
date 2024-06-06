using System.Collections;
using System.Collections.Generic;
using System.Security;
using System.Transactions;
using Unity.VisualScripting;
using UnityEngine;

public class StageController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> jointPoints = new List<GameObject>();

    private SoundController soundController;

    public GameObject mainLight;

    public GameObject redLight;

    public GameObject igrek;

    private bool doomMode = false;

    private int currentStage = 0;

    void Start()
    {
        soundController.BackGround(true);
    }

    void Update()
    {
        int stagesCount = jointPoints.Count;

        if (igrek.IsDestroyed() && !doomMode)
        {
            doomMode = true;
            DoomMode();
        }

        if (!doomMode && currentStage < stagesCount && !jointPoints[currentStage].activeSelf)
        {
            soundController.StageSound(currentStage);
            
            if (currentStage < stagesCount)
                SetJointPoint();

            if (currentStage == stagesCount)
                soundController.BackGround(false);

            currentStage += 1;
        } 
    }

    void SetJointPoint()
    {
        jointPoints[currentStage].SetActive(true);
    }

    void DoomMode()
    {
        soundController.Death();
        soundController.BackGround(false);
        mainLight.SetActive(false);
        redLight.SetActive(true);
    }
}
