using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using Entitas;
using UnityEngine.Networking;
public class minusScoreButton : MonoBehaviour
{
    public ButtonUI scoreScript;
    public Button button;
    private void Start()
    {
        OnClickButton();
    }
    public void OnClickButton()
    {
        button.onClick.AddListener(MinusScore);
    }
    public async void MinusScore()
    {
        var process = processScore();
        var result = await process;
        Debug.Log(result);
    }
    public async UniTask<int> processScore()
    {
        var gameContext = Contexts.sharedInstance.game;
        gameContext.ReplaceScore(gameContext.score.value - 1);
        await UniTask.Yield();
        return gameContext.score.value;

    }


}
