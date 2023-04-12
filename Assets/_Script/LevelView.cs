using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;

public class LevelView : MonoBehaviour
{
    [SerializeField] private List<StarView> stars;
    [SerializeField] private EndPointView endPoint;
    [SerializeField] private Weight player;
    [SerializeField] private Transform ropes;
    private LevelModel model;
    private bool isTryingCompleteLevel = false;
    public void Init(int levelIdx)
    {
        model = new(levelIdx);
        stars.ForEach(s => s.onCatchCallback = () => model.starCountReactive.value++);
        endPoint.onCatchCallback = () =>
        {
            isTryingCompleteLevel = true;
            ropes.SetActive(false);
            this.Wait(3, () => WindowManager.Instance.Show<EndScreen>().Show(model));
        };
        WindowManager.Instance.Show<LevelScreen>().Show(model);
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
        GameSession.Instance.ReloadLevel();
        isTryingCompleteLevel = false;
    }
    private bool OnScreen(Vector3 position)
    {
        var screenPos = Camera.main.WorldToScreenPoint(position);
        var cameraPos = Camera.main.WorldToScreenPoint(Camera.main.transform.position);

        return screenPos.y > 0;
    }
}
