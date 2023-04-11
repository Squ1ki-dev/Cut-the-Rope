using System.Collections;
using System.Collections.Generic;
using TMPro;
using Tools;
using UnityEngine;
using UnityEngine.UI;

public class LevelScreen : WindowBase
{
    [SerializeField] private TextMeshProUGUI levelNumber;
    [SerializeField] private Button replayBtn;
    [SerializeField] private RectTransform starsContainer, starPrefab;
    private SimplePresenter<RectTransform> presenter = new();
    public void Show(LevelModel model)
    {
        replayBtn.OnClick(() =>
        {
            GameSession.Instance.StartGame();
        });
        levelNumber.text = "Level: " + (model.levelIdx + 1);
        model.starCountReactive.SubscribeAndInvoke(value => presenter.Present(value, starPrefab, starsContainer));
    }
}
