using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using System.Threading;
using System;
using Entitas;
public class ButtonUI : MonoBehaviour
{
    public Button button;
    public Button cancelButton;

    void Start()
    {
        
        OnClick();
    }
    public void OnClick()
    {
        button.onClick.AddListener(OnClickButton);
    }
    public void OnCancel()
    {
        
    }
    private async void OnClickButton()
    {
        
        var result = await AddScore();
        Debug.Log(result);
        
        
    }
    private async UniTask<int> AddScore()
    {
        var cts = new CancellationTokenSource();
        var canceleed = await UniTask.Delay(5000,cancellationToken: cts.Token).SuppressCancellationThrow();
        if (canceleed)
        {
            Debug.Log("dicancel");
            return 0;
        }
        var gameContexts = Contexts.sharedInstance.game;
        gameContexts.ReplaceScore(gameContexts.score.value + 1);
        return gameContexts.score.value;

    }

}
