
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
    public void StartGame() => StartGame(GameSaves.Instance.currentLevel.value);
    public void StartGame(int level)
    {
        LoadScene(Scenes.GameScene, onComplete: () =>
        {
            Object.FindObjectOfType<GameView>().CreateLevel(level);
        });
    }
    public void CompleteLevel(LevelModel model)
    {
        var saves = GameSaves.Instance;
        if (model.starCount >= 1) saves.currentLevel.value++;

        int modelIdx = saves.levelModels.FindIndex(savedModel => savedModel.levelName == model.levelName);
        if (modelIdx == -1) saves.levelModels.Add(model);
        else saves.levelModels[modelIdx] = model;

        LoadScene(Scenes.MenuScene);
    }
    private void LoadScene(Scenes scene, System.Action onComplete = null)
    {
        WindowManager.Instance.CloseAll();
        var operation = SceneManager.LoadSceneAsync(scene.ToString());
        if (operation == null)
        {
            Debug.LogError("Scene not exist in build");
            return;
        }
        operation.completed += o => onComplete.Invoke();
    }
}
