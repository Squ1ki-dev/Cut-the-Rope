using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;

public class ProjectRunner : MonoBehaviour
{
    private void Awake()
    {
        // WindowManager.Instance.Show<MainMenuScreen>().Show();
        GameSession.Instance.StartGame();
    }
}
