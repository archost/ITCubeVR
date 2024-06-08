using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public List<AudioSource> stagesSounds;

    public AudioSource bgMusic;

    public AudioSource onDeath;

    public AudioSource scaryMusic;

    public AudioSource backRoomsMusic;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void BackGround(bool play)
    {
        if (bgMusic != null)
        {
            if (play)
                bgMusic.Play();
            else
                bgMusic.Stop();
        }
    }

    public void StageSound(int stageId)
    {
        stagesSounds[stageId].Play();
    }

    public void Death()
    {
        onDeath.Play();
        scaryMusic.Play();
    }

    public void BackRooms()
    {
        scaryMusic.Stop();
        backRoomsMusic.Play();
    }

}
