using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour
{
    public Text standingPinsText;

    private GameManager gameManager;

    private bool ballOutOfPlay = false;
    private float lastChangeTime;
    private int lastSettledCount = 10;
    private int lastStandingCount = -1;

    // Use this for initialization
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }
	
    // Update is called once per frame
    void Update()
    {
        standingPinsText.text = CountStanding().ToString();

        if (ballOutOfPlay)
        {
            UpdateStandingCountAndSettle();
            standingPinsText.color = Color.red;
        }
    }

    public void Reset()
    {
        lastSettledCount = 10;
    }

    void PinsHaveSettled()
    {   
        int standing = CountStanding();
        int pinFall = lastSettledCount - standing;

        lastSettledCount = standing;

        gameManager.Bowl(pinFall);

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

    void OnTriggerExit(Collider collider)
    {
        if (collider.GetComponent<Ball>())
        {
            ballOutOfPlay = true;
        }
    }
}
