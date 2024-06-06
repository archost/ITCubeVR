using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[CreateAssetMenu(fileName = "Assets/Parts/NewPart", menuName = "Part")]
public class PartData : ScriptableObject
{
    public int ID;

    public string PartName;

    public string Description;

}