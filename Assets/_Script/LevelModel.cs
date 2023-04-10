using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelModel
{
    public LevelModel(string levelName)
    {
        this.levelName = levelName;
    }
    public int starCount;
    public string levelName;
}
