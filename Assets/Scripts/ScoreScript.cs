using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    private int correctAnswersByPlayer = 0;
    private int questionsSeen = 0;
    public int getCorrectAnswersByPlayer()
    {
        return correctAnswersByPlayer;
    }
    public int getQuestionsSeen()
    {
        return questionsSeen;
    }
    public void setCorrectAnswersByPlayer(int newCount)
    {
        correctAnswersByPlayer = newCount;
        return;
    }
    public void setQuestionsSeen(int newCount)
    {
        questionsSeen = newCount;
    }
    public int getCurrentScore()
    {
        return Mathf.RoundToInt((float)100.0 * (float)correctAnswersByPlayer / (float)questionsSeen);
    }
}
