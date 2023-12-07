using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level Score", menuName = "ScriptableObjects/Data/Level Score", order = 0)]
public class LevelScore : ScriptableObject
{
    [SerializeField] private int pointsLevel;
    [SerializeField] private float timeLevel;

    public void ResetScore()
    {
        pointsLevel = 0;
        timeLevel = 0;
    }

    public Score SaveScore()
    {
        return new Score(pointsLevel, timeLevel);
    }

    public void UpdateTimeLevel(float deltaTime)
    {
        timeLevel += deltaTime;
    }

    public void UpdatePointsLevel(int points)
    {
        pointsLevel += pointsLevel;
    }
}


public struct Score
{
    public int points;
    public float time;

    public Score(int points, float time)
    {
        this.points = points;
        this.time = time;
    }
}