using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class Math : MonoBehaviour
{
    [SerializeField] GameObject deadPanel;
    [SerializeField] GameObject choosePanel;
    [SerializeField] GameObject lvlPanel;
    [SerializeField] int firstNumber;
    [SerializeField] int secondNumber;
    [SerializeField] Text numText;
    [SerializeField] int answer;
    public int inputNum;
    [SerializeField] int ahch;
    [SerializeField] Text ahchText;
    [SerializeField] int neahch;
    [SerializeField] Text neahchText;
    public InputField answerInput;
    [SerializeField] Text ahchRecord;

    public float countdown;
    public static float currentCount;
    public Text timerText;
    public bool stopGame = false;


    private void Start()
    {
        Time.timeScale = 0;
        choosePanel.SetActive(true);
        deadPanel.SetActive(false);
        lvlPanel.SetActive(false);
        timerText.text = countdown.ToString();
        equation();
    }

    public void CountNumStart()
    {
        choosePanel.SetActive(false);
        lvlPanel.SetActive(true);
        countdown = 60;
        Time.timeScale = 1;
    }
    void Update()
    {
        if (countdown > 0)
        {
            countdown -= Time.deltaTime;
            timerText.text = countdown.ToString();
            timerText.text = Mathf.Round(countdown).ToString();
        }
        else
        {
            stopGame = true;
            ahchRecord.text = ahch.ToString();
            deadPanel.SetActive(true);
        }
    }


    public void equation()
    {
        if (stopGame == false)
        {
            firstNumber = UnityEngine.Random.Range(0, 10);
            secondNumber = UnityEngine.Random.Range(0, 10);
            string taskString = firstNumber + "x" + secondNumber;
            numText.text = taskString;
            answer = firstNumber * secondNumber;
        }
    }

    public void CheckAnswer()
    {
        inputNum = Convert.ToInt32(answerInput.text);

        if (inputNum == answer && stopGame == false)
        {
            ahch++;
            ahchText.text = "Правильно" + ahch.ToString();
        }

        else if (inputNum != answer && stopGame == false)
        {
            neahch++;
            ahchText.text = "Правильно" + neahch.ToString();
        }
        equation();

    }
}
