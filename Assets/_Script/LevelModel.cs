using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelModel
{
    public LevelModel(int levelName)
    {
        this.levelIdx = levelName;
    }
    public int starCount;
    public int levelIdx;
}
