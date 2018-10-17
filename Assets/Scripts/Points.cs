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
            highScores[i] = PlayerPrefs.GetInt(highScoreKey + (i + 1).ToString(), 0);
        
            Debug.Log(highScores[i]);
        }
        
    }

    void Update()
    {
        if(player != null)
        {
            SCORE.text = " " + highScores[4].ToString();
            num++;
            text.text = num.ToString();            
        }

        SavePoints();

    }
    void OnDisable()
    {
       
    }

    void SavePoints()
    {        
        if (player == null)
        {            
            for (int i = 0; i < highScores.Length; i++)
            {                
                if (num > highScores[i -1])
                {
                    if(i == 0)
                    {
                        highScores[i] = num;
                    }
                    else
                    {
                        highScores[i - 1] = highScores[i];
                        highScores[i] = num;
                        PlayerPrefs.SetInt(highScoreKey + i.ToString(), highScores[i - 1]);
                    }

                    PlayerPrefs.SetInt(highScoreKey + (i + 1).ToString(), highScores[i]);
                    PlayerPrefs.Save();                    
                }
            }
        }
    }
}
