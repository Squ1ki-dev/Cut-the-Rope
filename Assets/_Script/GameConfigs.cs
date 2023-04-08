using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;

public class GameConfigs : Singleton<GameConfigs>
{
    public GameConfigs()
    {
        levelConfigs = Resources.LoadAll<LevelConfigs>("")[0];
    }
    public LevelConfigs levelConfigs { get; private set; }
}
