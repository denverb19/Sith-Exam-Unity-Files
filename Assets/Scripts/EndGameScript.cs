using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndGameScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI finalScoreText;
    ScoreScript thisScore;
    void Awake()
    {
        thisScore = FindObjectOfType<ScoreScript>();
    }
    public void ShowFinalScore()
    {
        finalScoreText.text = "You have completed the exam\nYour final score was: " + thisScore.getCurrentScore() + "%";     
    }
}
