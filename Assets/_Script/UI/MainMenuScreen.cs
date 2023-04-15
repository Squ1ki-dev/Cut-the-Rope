using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScreen : WindowBase
{
    public Button startBtn;
    public void Show()
    {
        startBtn.OnClick(() => GameSession.Instance.StartGame());
    }
}
