using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using Unity.VisualScripting;
using UnityEngine;

public class StageController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> jointPoints = new List<GameObject>();

    private int currentStage = 0;

    public List<AudioSource> sounds;

    public AudioSource bgMusic;

    void Start()
    {
        jointPoints[0].SetActive(true);
        bgMusic.Play();
    }


    void Update()
    {
        if (currentStage < 4 && jointPoints[currentStage].IsDestroyed())
        {
            sounds[currentStage].Play();

            currentStage += 1;
            if (currentStage < 4)
                SetJointPoint();

            if (currentStage == 4)
                bgMusic.Stop();
        } 
    }

    void SetJointPoint()
    {
        jointPoints[currentStage].SetActive(true);
    }
}
