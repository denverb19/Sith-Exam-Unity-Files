using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Quiz thisQuiz;
    public bool showedScore = false;
    EndGameScript thisEndGameScript;
    void Awake()
    {
        thisQuiz = FindObjectOfType<Quiz>();
        thisEndGameScript = FindObjectOfType<EndGameScript>();
    }
    void Start()
    {
        thisQuiz.gameObject.SetActive(true);
        thisEndGameScript.gameObject.SetActive(false);
    }
    void Update()
    {
        if (!showedScore)
            {
            if (thisQuiz.isComplete)
            {
                thisEndGameScript.gameObject.SetActive(true);
                thisEndGameScript.ShowFinalScore();
                thisQuiz.gameObject.SetActive(false);
                showedScore = true;
            }  
        }
    }
    public void OnReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
