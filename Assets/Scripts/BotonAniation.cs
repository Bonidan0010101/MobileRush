using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BotonAniation : MonoBehaviour {
    Animator animator;
    string Scena;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
    }
   /*public void Transiçao()
    {
        if (GameObject.FindGameObjectWithTag("Play"))
        {
            StartCoroutine(AnimationTrasitorStart());
        }
        if (GameObject.FindGameObjectWithTag("Menu"))
        {
            StartCoroutine(AnimationTrasitorMenu());
        }
        if (GameObject.FindGameObjectWithTag("HowtoPlay"))
        {
            StartCoroutine(HowtoPlay());
        }
        if (GameObject.FindGameObjectWithTag("Creditos"))
        {
            StartCoroutine(Credits());
        }

    }*/
    public void Quit()
    {
        if (GameObject.FindGameObjectWithTag("Exit"))
        {
            StartCoroutine(QuitAimation());
        }
    }
    public void Creditos()
    {
        if (GameObject.FindGameObjectWithTag("Creditos"))
        {
            StartCoroutine(Credits());
        }
    }
    public void Play()
    {
        if (GameObject.FindGameObjectWithTag("Play"))
        {
            StartCoroutine(AnimationTrasitorStart());
        }
    }
    public void Menu()
    {
        if (GameObject.FindGameObjectWithTag("Menu"))
        {
            StartCoroutine(AnimationTrasitorMenu());
        }
    }
    public void HowtoPlayY()
    {
        if (GameObject.FindGameObjectWithTag("HowtoPlay"))
        {
            StartCoroutine(HowtoPlay());
        }
    }
    public IEnumerator Credits()
    {
        animator.SetBool("Transição", true);
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("Credits");
        StopCoroutine(Credits());
    }

    public IEnumerator HowtoPlay()
    {
        animator.SetBool("Transição", true);
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("HowtoPLay");
        StopCoroutine(HowtoPlay());
    }

    public IEnumerator AnimationTrasitorMenu()
    {
        animator.SetBool("Transição", true);
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("MainMenu");
        StopCoroutine(AnimationTrasitorMenu());
    }
    public IEnumerator AnimationTrasitorStart()
    {
        animator.SetBool("Transição", true);
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("SampleScene");
        StopCoroutine(AnimationTrasitorStart());
    }

    public IEnumerator QuitAimation()
    {
        animator.SetBool("Transição", true);
        yield return new WaitForSeconds(2.0f);
        Application.Quit();
        StopCoroutine(QuitAimation());
    }

    public void RestartBoton()
    {
      if(GetComponent<ActPlayer>() == null)
        {
            SceneManager.LoadScene(1);
        }
    }

    public void ClearHighScore()
    {
        PlayerPrefs.DeleteAll();
    }
}
