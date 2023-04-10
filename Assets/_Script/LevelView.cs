using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelView : MonoBehaviour
{
    [SerializeField] private List<StarView> stars;
    [SerializeField] private EndPointView endPoint;
    public void Init(int levelIdx)
    {
        LevelModel model = new(levelIdx);
        stars.ForEach(s => s.onCatchCallback = () => model.starCount++);
        endPoint.onCatchCallback = () =>
        {
            model.starCount++;
            GameSession.Instance.CompleteLevel(model);
        };
    }
}
