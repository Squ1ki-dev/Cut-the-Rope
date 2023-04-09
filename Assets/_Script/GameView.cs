using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;

public class GameView : MonoBehaviour
{
    private List<LevelConfig> levels => GameConfigs.Instance.levelConfigs.levels;
    // private void Awake()
    // {
    //     CreateLevel(0);
    // }
    public void CreateLevel(int levelIdx)
    {
        if (!levels.HasIndex(levelIdx))
        {
            levelIdx = levels.Count - 1;
            if(levelIdx == -1) 
            {
                Debug.LogError("Levels not exist");
                return;
            }
        }
        Instantiate(levels[levelIdx].levelView);
    }

}
