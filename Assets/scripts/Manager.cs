using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public int score = 0, pinsLeft = 10, shotsLeft = 2;
    public Text scoreUI, pinsUI, shotsUI;

    // Update is called once per frame
    void Update()
    {
        scoreUI.text = "Score - " + score;
        pinsUI.text = "Pins Left - " + pinsLeft;
        shotsUI.text = "Shots Left - " + shotsLeft;
    }
    public void ResetGame()
    {
        StartCoroutine(gameReset());
        /*
        score = 0;
        pinsLeft = 10; 
        shotsLeft = 2;
        FindObjectOfType<Pins>().ResetPins();
        */
    }
    IEnumerator gameReset()
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene(0);   
    }
}
