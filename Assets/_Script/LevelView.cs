using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;

public class LevelView : MonoBehaviour
{
    [SerializeField] private List<StarView> stars;
    [SerializeField] private EndPointView endPoint;
    [SerializeField] private Weight player;
    private LevelModel model;
    private bool isTryingCompleteLevel = false;
    public void Init(int levelIdx)
    {
        model = new(levelIdx);
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
    private void FixedUpdate()
    {
        if (!OnScreen(player.transform.position))
        {
            if (!isTryingCompleteLevel)
            {
                isTryingCompleteLevel = true;
                Invoke(nameof(TryCompleteLevel), 1);
            }
        }
    }
    private void TryCompleteLevel()
    {
        GameSession.Instance.CompleteLevel(model);
        isTryingCompleteLevel = false;
    }
    private bool OnScreen(Vector3 position)
    {
        var screenPos = Camera.main.WorldToScreenPoint(position);
        var cameraPos = Camera.main.WorldToScreenPoint(Camera.main.transform.position);

        return screenPos.y > 0;
    }
}
