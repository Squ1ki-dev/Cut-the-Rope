using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;

public class LevelView : MonoBehaviour
{
    [SerializeField] private List<StarView> stars;
    [SerializeField] private EndPointView endPoint;

    public void Init(int levelIdx)
    {
        LevelModel model = new(levelIdx);
        stars.ForEach(s => s.onCatchCallback = () => model.starCountReactive.value++);
        endPoint.onCatchCallback = () =>
        {
            model.starCountReactive.value++;
            StartCoroutine(CompleteLevelWithDelay(model));
        };
        WindowManager.Instance.Show<LevelScreen>().Show(model);
    }

    private IEnumerator CompleteLevelWithDelay(LevelModel model)
    {  
        yield return new WaitForSeconds(3f);

        GameSession.Instance.CompleteLevel(model);
    }
}
