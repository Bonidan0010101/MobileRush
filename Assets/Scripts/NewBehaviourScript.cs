using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour {

    public int score;
    public int highScore = 0;
    string highScoreKey = "Points";
    public Text guiText;

    void Start()
    {
        //Get the highScore from player prefs if it is there, 0 otherwise.
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
    }

    void Update()
    {
        guiText.text = "Score:" + score.ToString();
        score = GetComponent<Points>().num++;
    }

    void OnDisable()
    {

        //If our scoree is greter than highscore, set new higscore and save.
        if (score > highScore)
        {
            PlayerPrefs.SetInt(highScoreKey, score);
            PlayerPrefs.Save();
        }
    }
}
