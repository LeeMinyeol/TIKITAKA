using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool isPlayer1Goal;
    private OldGameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<OldGameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name.Equals("Ball"))
        {
            if(isPlayer1Goal)
            {
                Debug.Log("Player 2 Scored");
                gameManager.Player2Scored();
            }
            else
            {
                Debug.Log("Player 1 Scored");
                gameManager.Player1Scored();
            }
        }
    }
}
