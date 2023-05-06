using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;

public class LevelView : MonoBehaviour
{
    [SerializeField] private List<StarView> stars;
    [SerializeField] private EndPointView endPoint;
    [SerializeField] private Candy player;
    [SerializeField] private Transform ropes;
    [SerializeField] private ParticleSystem confeti;
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
            this.Wait(1.3f, () =>
            {
                WindowManager.Instance.Show<EndScreen>().Show(model, endPoint.catched);
                confeti.Play();
            });
        };
        player.onEnter = enteredObj =>
        {
            if (enteredObj.GetComponent<Floor>())
                Invoke(nameof(LoseLevel), 1);
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
                Invoke(nameof(LoseLevel), 1);
            }
        }
    }
    private void LoseLevel()
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
