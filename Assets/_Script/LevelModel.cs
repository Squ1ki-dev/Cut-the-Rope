using System.Collections;
using System.Collections.Generic;
using Tools.Reactive;
using UnityEngine;

[System.Serializable]
public class LevelModel
{
    public LevelModel(int levelIdx)
    {
        this.levelIdx = levelIdx;
        starCountReactive.SubscribeAndInvoke(value => StarCount = value);
    }
    public Reactive<int> starCountReactive = new Reactive<int>();
    [field: SerializeField] public int StarCount {get; private set; }
    public int levelIdx;
}
