using System.Collections;
using System.Collections.Generic;
using Tools;
using Tools.Reactive;
using UnityEngine;

public class GameSaves : Singleton<GameSaves>
{
    public GameSaves()
    {
        currentLevel.ConnectToSaver(nameof(currentLevel));
    }
    readonly public Reactive<int> currentLevel = new Reactive<int>();
}
