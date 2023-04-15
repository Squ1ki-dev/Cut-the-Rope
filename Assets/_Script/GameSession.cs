
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    private int currentLevel = -1;
    public void StartGame() => StartGame(GameSaves.Instance.currentLevel.value);
    public void StartGame(int level)
    {
        Time.timeScale = 1.5f;
        currentLevel = level;
        LoadScene(Scenes.GameScene, onComplete: () =>
        {
            Object.FindObjectOfType<GameView>().CreateLevel(level);
        });
    }
    public void CompleteLevel(LevelModel model)
    {
        Time.timeScale = 1;
        currentLevel = -1;
        var saves = GameSaves.Instance;
        if (model.starCountReactive.value >= 1) saves.currentLevel.value++;

        if (!saves.levelModels.HasIndex(model.levelIdx)) saves.levelModels.Add(model);
        else saves.levelModels[model.levelIdx] = model;

        // LoadScene(Scenes.MenuScene);
    }
    public void ReloadLevel()
    {
        StartGame(currentLevel);
    }
    public void LoadScene(Scenes scene, System.Action onComplete = null)
    {
        WindowManager.Instance.CloseAll();
        var operation = SceneManager.LoadSceneAsync(scene.ToString());
        if (operation == null)
        {
            Debug.LogError("Scene not exist in build");
            return;
        }
        operation.completed += o => onComplete?.Invoke();
    }
}
