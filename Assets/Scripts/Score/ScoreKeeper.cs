using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField] private int _totalScore;

    public int TotalScore { get => _totalScore; }

    public UnityEvent<float> onScoreChange;

    public void AddScore(int score)
    {
        _totalScore += score;
        onScoreChange.Invoke(_totalScore);
    }

    public void RemoveScore(int score)
    {
        _totalScore -= score;
        onScoreChange.Invoke(_totalScore);
    }

    private void Start()
    {
        onScoreChange.Invoke(_totalScore);
    }
}
