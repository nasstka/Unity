using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class PinSetter : MonoBehaviour
{
    #region public variables

    public GameObject pinSet;
    public Text standingPinsText;

    public bool ballOutOfPlay = false;

    #endregion

    #region private variables

    private ActionMaster actionMaster;
    private Animator animator;
    private Ball ball;

    private float lastChangeTime;
    private int lastSettledCount = 10;
    private int lastStandingCount = -1;



    #endregion

    void Start()
    {
        animator = GetComponent<Animator>();
        ball = GameObject.FindObjectOfType<Ball>();
    }

    void Update()
    {
        standingPinsText.text = CountStanding().ToString();

        if (ballOutOfPlay)
        {
            UpdateStandingCountAndSettle();
            standingPinsText.color = Color.red;
        }
    }

    void UpdateStandingCountAndSettle()
    {
        int currentStanding = CountStanding();

        if (currentStanding != lastStandingCount)
        {
            lastChangeTime = Time.time;
            lastStandingCount = currentStanding;
            return;
        }

        float settleTime = 3f; // How long to wait to consder pins settled

        if ((Time.time - lastChangeTime) > settleTime)
        { // If last change > 3s ago
            PinsHaveSettled();
        }
    }

    public void RaisePins()
    {
        Pin[] pinArray = FindObjectsOfType<Pin>();
        foreach (Pin pin in pinArray)
        {	
            pin.Raise();
        }
    }

    public void LowerPins()
    {	
        Pin[] pinArray = FindObjectsOfType<Pin>();
        foreach (Pin pin in pinArray)
        {	
            pin.Lower();
        }
    }

    public void RenewPins()
    {
        GameObject newPins = Instantiate(pinSet);
        newPins.transform.position = new Vector3(0, 10, 1829);
    }

    void PinsHaveSettled()
    {	
        actionMaster = new ActionMaster();

        int standing = CountStanding();
        int pinFall = lastSettledCount - standing;

        lastSettledCount = standing;

        ActionMaster.Action action = actionMaster.Bowl(pinFall);

        if (action == ActionMaster.Action.Tidy)
        {
            animator.SetTrigger("TidyTrigger");
        }
        else if (action == ActionMaster.Action.EndTurn)
        {
            animator.SetTrigger("ResetTrigger");
            lastSettledCount = 10;
        }
        else if (action == ActionMaster.Action.Reset)
        {
            animator.SetTrigger("ResetTrigger");
            lastSettledCount = 10;
        }
        else if (action == ActionMaster.Action.EndGame)
        {
            throw new UnityException("No End Game action!");
        }

        ball.Reset();
        lastStandingCount = -1; // indicates pin have settled, and ball not back in play box
        ballOutOfPlay = false;
        standingPinsText.color = Color.green;
    }

    int CountStanding()
    {
        int standingPinsCount = 0;

        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            if (pin.IsStanding())
            {
                standingPinsCount++;
            }
        }

        return standingPinsCount;
    }
}
