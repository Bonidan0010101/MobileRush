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
    public int[] highScoresOrdenada = new int[5];
    //public List<int> ighscored;  

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
            SCORE.text = " " + highScores[1].ToString();
            num++;
            text.text = num.ToString();            
        }

        SavePoints();
        PlayerPrefs.Save(); 

    }
    void OnDisable()
    {
       
    }

    void SavePoints()
    {        
        if (player == null)
        {
            /*for (int i = 0; i < ighscored.Count; i++)
            {                
                if (num > ighscored[i])
                {
                    if(i == 0)
                    {
                        ighscored[i] = num;
                    }
                    else
                    {
                        ighscored[i - 1] = ighscored[i];
                        ighscored[i] = num;
                        PlayerPrefs.SetInt(highScoreKey + i.ToString(), ighscored[i]);
                    }

                    PlayerPrefs.SetInt(highScoreKey + (i + 1).ToString(), ighscored[i]);                  
                }

            }*/

            var maxpoints = -1;
            var index = 0;

            for (int a = 0; a < highScores.Length; a++)
            {
                for (int i = 0; i < highScores.Length; i++)
                {
                    if (highScores[i] > maxpoints)
                    {
                        maxpoints = highScores[i];
                        index = i;
                        
                    }
                }
                highScores[index] = -1;
                highScoresOrdenada[a] = maxpoints;
                print(maxpoints);
                maxpoints = -1;
            }

        }
    }
}
