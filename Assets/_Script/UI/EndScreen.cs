using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;
using UnityEngine.UI;

public class EndScreen : AnimatedWindowBase
{
    [SerializeField] private RectTransform starsContainer, starPrefab;
    private SimplePresenter<RectTransform> presenter = new();
    [SerializeField] private Button nextBtn, replayBtn, miniGameBtn;
    [SerializeField] private Image candy;
    public void Show(LevelModel model, Sprite candy)
    {
        this.candy.sprite = candy;
        presenter.Present(model.StarCount, starPrefab, starsContainer);
        nextBtn.OnClick(() =>
        {
            GameSession.Instance.CompleteLevel(model);
            GameSession.Instance.StartGame();
        });
        replayBtn.OnClick(() =>
        {
            GameSession.Instance.StartGame();
        });
        // WindowManager.Instance.Show<ClickCounter>();
        // WindowManager.Instance.Show<ClickToStop>();
        // WindowManager.Instance.Show<GuessName>();
    }
}
