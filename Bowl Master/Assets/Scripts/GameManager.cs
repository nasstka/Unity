﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private List <int> rolls = new List<int>();

    private Ball ball;
    private PinSetter pinSetter;
    private ScoreDisplay scoreDisplay;

    void Start()
    {
        pinSetter = GameObject.FindObjectOfType<PinSetter>();
        ball = GameObject.FindObjectOfType<Ball>();
        scoreDisplay = GameObject.FindObjectOfType<ScoreDisplay>();
    }

    public void Bowl(int pinFall)
    {
        try
        {
            rolls.Add(pinFall);
            ball.Reset();
            
            ActionMaster.Action nextAction = ActionMaster.NextAction(rolls);
            pinSetter.PerformAction(nextAction);
        }
        catch
        {
            Debug.LogWarning("Somthing went wrong in Bowl()");
        }

        try
        {
            scoreDisplay.FillRolls(rolls);
            scoreDisplay.FillFrames(ScoreMaster.ScoreCumulative(rolls));
        }
        catch
        {
            Debug.LogWarning("FillRollCard() failed");
        }
    }
}
