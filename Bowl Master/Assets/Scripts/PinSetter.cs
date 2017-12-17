using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class PinSetter : MonoBehaviour
{
    public GameObject pinSet;

    private Animator animator;
    private PinCounter pinCounter;

    void Start()
    {
        animator = GetComponent<Animator>();
        pinCounter = GameObject.FindObjectOfType<PinCounter>();
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

    public void PerformAction(ActionMaster.Action action)
    {
        if (action == ActionMaster.Action.Tidy)
        {
            animator.SetTrigger("TidyTrigger");
        }
        else if (action == ActionMaster.Action.EndTurn)
        {
            animator.SetTrigger("ResetTrigger");
            pinCounter.Reset();
        }
        else if (action == ActionMaster.Action.Reset)
        {
            animator.SetTrigger("ResetTrigger");
            pinCounter.Reset();
        }
        else if (action == ActionMaster.Action.EndGame)
        {
            throw new UnityException("No End Game action!");
        }
    }
   
}
