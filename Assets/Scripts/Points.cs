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
    public int highScore;
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

            for (int i = 0; i < highScores.Length; i++)
        {
                highScoreKey = "Points" + (i + 1).ToString();
            highScores[i] = PlayerPrefs.GetInt(highScoreKey, 0);
        }
        
    }

    void Update()
    {
        /// teste
        SCORE.text = " " + highScores[4].ToString();
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
            //novasso
            if (num > highScores[4])
            {
                PlayerPrefs.SetInt(highScoreKey, num);
                PlayerPrefs.Save();
                //Devassa
            }
        }
    }
}
