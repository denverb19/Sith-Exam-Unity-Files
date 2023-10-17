using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Exam Question", fileName = "New Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2, 6)]
    [SerializeField] string question = "Enter new question text";
    [SerializeField] string[] answerBank = new string[4];
    [SerializeField] int correctAnswerIndex;
    public string GetQuestion()
    {
        return question;
    }
    public string[] GetAnswerBank()
    {
        return answerBank;
    }
    public int GetCorrectAnswerIndex()
    {
        return correctAnswerIndex;
    }
    public string GetCorrectAnswer(int thisIndex)
    {
        return answerBank[thisIndex];
    }
}