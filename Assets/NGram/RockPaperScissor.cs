using System;
using UnityEngine;

public enum Action
{
    NONE,
    ROCK,
    PAPER,
    SCISSOR
}

/// <summary>
/// RPS Gameplay
/// - Input R P or S to play
/// - The AI will select the action
/// - We log the result
/// </summary>

public class RockPaperScissor : MonoBehaviour
{
    public int maxGames;
    #region

    int nGames = 0;
    int nWon = 0;
    int nLost = 0;
    int nDraw = 0;


    #endregion


    public AIPlayer player1;
    public AIPlayer player2;

    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Action p1Action = Action.NONE;

        if (nGames < maxGames)
        {
            p1Action = player1.GetAction();
            // You Choose
            Debug.Log("You Chose : " + p1Action);

            // AI chooses
            Action p2Action = player2.GetAction();
            // AI Choose
            Debug.Log("AI Chose : " + p2Action);

            // Inform th AIs of the 
            player1.ReceiveOpponentAction(p2Action);
            player2.ReceiveOpponentAction(p1Action);

            int diff = ((int)p1Action - (int)p2Action);
            if(diff == 1 || diff == -2)
            {
                nWon++;
                Debug.Log("YOU WIN!!!!");
            }
            else if (diff == -1 || diff == 2)
            {
                nLost++;
                Debug.Log("YOU LOSE!!!!");
            }
            else 
            {
                nDraw++;
                Debug.Log("DRAW!!!!");
            }
            nGames++;

            float myWinRate = nWon * 100 / (float) nGames;
            float aiWinRate = nLost * 100 / (float)nGames;
            Debug.Log("MY WIN RATE: " + myWinRate.ToString("0.00") + "%"
                + " AI win rate : " + aiWinRate.ToString("0.00") + "%"
                + "\nnGames: " + nGames + ", nWon: " + nWon + ", nLost: " + nLost + ", nDraw: "+nDraw);
        }
    }

    private bool GetInput(out Action chosenAction)
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            chosenAction = Action.ROCK;
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            chosenAction = Action.PAPER;
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            chosenAction = Action.SCISSOR;
        }
        else
        {
            chosenAction = Action.NONE;
        }

        if(chosenAction != Action.NONE)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
