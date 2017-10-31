using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain : MonoBehaviour {

    public float tickDelay = 1;
    public DecidionMaker decisionMaker;

	// Use this for initialization
	void Start () {
        InvokeRepeating("TickBrain", tickDelay, tickDelay);	
	}
	
    void TickBrain()
    {
        decisionMaker.MakeDecision();
    }
}

public abstract class DecidionMaker : MonoBehaviour
{
    public abstract void MakeDecision();
}