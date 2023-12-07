using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Score Handler", menuName = "ScriptableObjects/Data/Score Handler", order = 1)]
public class ScoreHandler : ScriptableObject
{
    [SerializeField] private List<Score> recentScores;

    public Func<Score> OnEndGame;

    public void EndLevel()
    {
        Score newData = (Score)(OnEndGame?.Invoke());

        if(recentScores.Count < 4)
        {
            recentScores.Add(newData);
        }
    }
}
