using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int scoreValue = 0;
    public static bool death = false;
    Text score;
    void Start()
    {
        score = GetComponent<Text>();
    }
    void Update()
    {
        score.text = "Press A or D to move\nPress P to shoot\nScore: " + scoreValue
                      + "\nHealth: " + PlayerMovement.health;   
        if(death){
            score.text = "GAME OVER\n Score: " + scoreValue + "\n press Q to Exit";  
        }

        if(Input.GetKey(KeyCode.Q)){
            Application.Quit();
            Debug.Log("quitting");
        }

    }
}
