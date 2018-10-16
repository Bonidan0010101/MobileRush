using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveScore : MonoBehaviour {

    public int[] highScores = new int[5];
    string highScoreKey = "";

    void Start()
    {
        for (int i = 0; i < highScores.Length; i++)
        {
            highScoreKey = "Points" + (i + 1).ToString();
            highScores[i] = PlayerPrefs.GetInt(highScoreKey, 0);
            //use these values in whatever shows the leaderboard(s).
        }

    }

}
