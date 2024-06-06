using System.Collections;
using System.Collections.Generic;
using System.Security;
using System.Transactions;
using Unity.VisualScripting;
using UnityEngine;

public class StageController : MonoBehaviour
{
    public List<GameObject> lamps = new List<GameObject>();

    public GameObject mainLight;
    public GameObject redLight;

    public GameObject igrek;

    private bool doomMode = false;

    [SerializeField]
    private List<GameObject> jointPoints = new List<GameObject>();

    private int currentStage = 0;

    public List<AudioSource> sounds;

    public AudioSource bgMusic;

    public AudioSource onDeath;

    public AudioSource scaryMusic;

    void Start()
    {
        jointPoints[0].SetActive(true);
        bgMusic.Play();
    }


    void Update()
    {
        if (igrek.IsDestroyed() && !doomMode)
        {
            onDeath.Play();
            doomMode = true;
            DoomMode();
        }

        if (currentStage < 4 && jointPoints[currentStage].IsDestroyed() && !doomMode)
        {
            lamps[currentStage].SetActive(true);
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

    void DoomMode()
    {
        bgMusic.Stop();
        mainLight.SetActive(false);
        redLight.SetActive(true);
        scaryMusic.Play();
    }
}
