using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] private int _totalScore;

    public int TotalScore { get => _totalScore; }

    public void AddScore(int score)
    {
        _totalScore += score;
    }

    public void RemoveScore(int score)
    {
        _totalScore -= score;
    }
}
