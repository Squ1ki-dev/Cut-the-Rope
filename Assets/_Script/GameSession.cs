
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tools;
using UnityEngine;
using UnityEngine.SceneManagement;
public enum Scenes
{
    MenuScene,
    GameScene
}

public class GameSession : Singleton<GameSession>
{
    public void StartGame() => StartGame(GameSaves.Instance.currentLevel.value);
    public void StartGame(int level)
    {
        LoadScene(Scenes.GameScene, onComplete: () =>
        {
            Object.FindObjectOfType<GameView>().CreateLevel(level);
        });
    }
    public void CompleteLevel(GameModel model)
    {
        if(model.starCount >= 1) GameSaves.Instance.currentLevel.value++;
        LoadScene(Scenes.MenuScene);
    }
    private void LoadScene(Scenes scene, System.Action onComplete = null)
    {
        WindowManager.Instance.CloseAll();
        var operation = SceneManager.LoadSceneAsync(scene.ToString());
        operation.completed += o => onComplete.Invoke();
        if (operation == null) Debug.LogError("Scene not exist in build");
    }
}
