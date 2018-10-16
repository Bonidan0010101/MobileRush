using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour {


    /// <summary>
    /// Pontos, so atualizar, mais tarde usar JSON ou Player.Prefs
    /// </summary>

    public int num;
    public Text text;

    public int[] highScores = new int[5];

    public int score = 0;
    public int highScore = 0;
    string highScoreKey = "Points";
    public Text SCORE;

    private GameObject player;
    private GameObject ground;
    private GameObject background;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ground = GameObject.FindGameObjectWithTag("Ground");
        background = GameObject.FindGameObjectWithTag("Background");
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
       
    }

    void Update()
    {
        /// teste
        SCORE.text = " " + highScore.ToString();
        num++;
        text.text = num.ToString();
        SavePoints();
    }
    void OnDisable()
    {
       
    }
    void SavePoints()
    {
        if (player == null)
        {
            num--;
            /* if (num > highScore)
             {
                 int temp = highScore;
                 PlayerPrefs.SetInt(highScoreKey, num);
                 num = temp;
                 PlayerPrefs.Save();
             }*/

            //novasso
            for (int i = 0; i < highScores.Length; i++)
            {
                highScoreKey = "Points" + (i + 1).ToString();
                highScores[i] = PlayerPrefs.GetInt(highScoreKey, num);
            }

            if (num > highScore)
            { 
                PlayerPrefs.SetInt(highScoreKey, num);
                PlayerPrefs.Save();
                num = highScore;
                //Devassa
            }
        }
    }
}
