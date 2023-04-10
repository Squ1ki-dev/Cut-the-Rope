using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "LevelsConfig", menuName = "Configs/LevelConfig")]
public class LevelConfigs : ScriptableObject
{
    public List<LevelConfig> levels;
}
[System.Serializable]
public class LevelConfig
{
    public LevelView levelView;
}