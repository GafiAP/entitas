using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour, IAnyScoreListener
{
    public TextMeshProUGUI text;
    private void Start()
    {
        var listener = Contexts.sharedInstance.game.CreateEntity();
        listener.AddAnyScoreListener(this);
    }
    public void OnAnyScore(GameEntity entity, int value)
    {
        text.text = Contexts.sharedInstance.game.score.value.ToString();
    }

    
    
}
