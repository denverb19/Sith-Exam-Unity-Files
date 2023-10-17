using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] TextMeshProUGUI thisQuestionTM;
    [SerializeField] List<QuestionSO> questionList = new List<QuestionSO>();
    QuestionSO thisQuestion;
    [Header("Answers")]
    [SerializeField] GameObject[] thisAnswerButtons;
    [SerializeField] Sprite defaultAnswerSprite;
    [SerializeField] Sprite correctAnswerSprite;
    int correctAnswerIndex;
    public bool answeredEarly = false;
    [Header("Timer")]
    [SerializeField] Image timerImage;
    TimerScript thisTimer;
    [Header("Score")]
    ScoreScript thisScore;
    [SerializeField] TextMeshProUGUI thisScoreTM;
    [Header("Progess")]
    [SerializeField] Slider progressBar;
    public bool isComplete = false;
    void Awake() 
    {
        thisTimer = FindObjectOfType<TimerScript>();
        thisScore = FindObjectOfType<ScoreScript>();
    }
    void Start()
    {
        progressBar.value = 0;
        progressBar.maxValue = questionList.Count;
        GetNextQuestion();
    }
    void Update()
    {
        timerImage.fillAmount = thisTimer.fillFraction;
        if (thisTimer.loadNextQuestion)
        {
            GetNextQuestion();
        }
    }
    public void OnAnswerSelected(int chosenIndex)
    {
        answeredEarly = true;
        DisplayAnswer(chosenIndex);
        thisTimer.CancelTimer();
    }
    private void GetNextQuestion()
    {
        thisTimer.loadNextQuestion = false;
        SetButtonState(true);
        SetDefaultButtonSprites();
        if (questionList.Count >= 1)
        {
            GetRandomQuestion();
        }
        else if (progressBar.value == progressBar.maxValue)
        {
            isComplete = true;
            return;
        }
        DisplayQuestion();
    }
    private void GetRandomQuestion()
    {
        int randomIndex = Random.Range(0, questionList.Count);
        thisQuestion = questionList[randomIndex];
        if (questionList.Contains(thisQuestion))
        {
            questionList.Remove(thisQuestion);
        }
    }
    public void DisplayAnswer(int chosenIndex)
    {
        correctAnswerIndex = thisQuestion.GetCorrectAnswerIndex();
        if (chosenIndex == correctAnswerIndex)
        {
            thisScore.setCorrectAnswersByPlayer(thisScore.getCorrectAnswersByPlayer()+1);
            thisScore.setQuestionsSeen(thisScore.getQuestionsSeen()+1);
            thisScoreTM.text = "Score :" + thisScore.getCurrentScore() + "%";
            thisQuestionTM.text = "Perhaps you are not a complete fool...";
            Image buttonImage = thisAnswerButtons[chosenIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
            buttonImage.color = Color.magenta;
        }
        else
        {
            thisScore.setQuestionsSeen(thisScore.getQuestionsSeen()+1);
            string correctAnswerText = thisQuestion.GetAnswerBank()[correctAnswerIndex];
            thisScoreTM.text = "Score :" + thisScore.getCurrentScore() + "%";
            thisQuestionTM.text = "Your weakness is despicable...\nThe correct response is:\n" + correctAnswerText;
            Image buttonImage = thisAnswerButtons[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
            buttonImage.color = Color.magenta;
        }
        progressBar.value = progressBar.value + 1;
        SetButtonState(false);
    }
    private void DisplayQuestion()
    {
        thisQuestionTM.text = thisQuestion.GetQuestion();
        for (int i = 0; i < thisAnswerButtons.Length; i++)
        {
            TextMeshProUGUI buttonText = thisAnswerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = thisQuestion.GetAnswerBank()[i];
        }
    }
    private void SetButtonState(bool state)
    {
        for (int j = 0; j < thisAnswerButtons.Length; j++)
        {
            Button button = thisAnswerButtons[j].GetComponent<Button>();
            button.interactable = state;
        }
    }
    private void SetDefaultButtonSprites()
    {
        for (int i = 0; i < thisAnswerButtons.Length; i++)
        {
            Image buttonImage = thisAnswerButtons[i].GetComponent<Image>();
            buttonImage.sprite = defaultAnswerSprite;
            buttonImage.color = Color.red;
        }
    }
}