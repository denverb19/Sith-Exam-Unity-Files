using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    public bool answerDisplayState = false;
    public bool loadNextQuestion = false;
    public float fillFraction;
    float timerValue;
    Quiz thisQuiz;
    [SerializeField] float timeToAnswer = 25f;
    [SerializeField] float timeToDisplayAnswer = 10f;
    public void CancelTimer()
    {
        timerValue = 0f;
    }
    private void Awake() 
    {
        timerValue = timeToAnswer;
        thisQuiz = FindObjectOfType<Quiz>();
    }
    void Update()
    {
        if (timerValue <= 0f)
        {
            if (!answerDisplayState && thisQuiz.answeredEarly)
            {
                timerValue = timeToDisplayAnswer;
                answerDisplayState = true;
                thisQuiz.answeredEarly = false;
            }
            else if (!answerDisplayState && !thisQuiz.answeredEarly)
            {
                timerValue = timeToDisplayAnswer;
                answerDisplayState = true;
                thisQuiz.DisplayAnswer(-1);
                thisQuiz.answeredEarly = false;
            }
            else if (answerDisplayState)
            {
                timerValue = timeToAnswer;
                answerDisplayState = false;
                loadNextQuestion = true;
            }
        }
        UpdateTimer();
    }
    private void UpdateTimer()
    {
        timerValue -= Time.deltaTime;
        if (!answerDisplayState)
        {
            fillFraction = timerValue/timeToAnswer;           
        }
        else
        {
            fillFraction = timerValue/timeToDisplayAnswer;
        }
    }
}