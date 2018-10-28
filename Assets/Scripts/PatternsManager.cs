using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternsManager : MonoBehaviour {


    public bool desaparece = false;
    public float speed;
    private float plusSpeed;
    public bool canDestroy;

    private Points p;

    void Start()
    {
        p = GameObject.FindGameObjectWithTag("Points").GetComponent<Points>();

        if(p.num >= 2000 && p.num < 4000)
        {
            plusSpeed = 2f;
            speed = speed + plusSpeed;
        }
        else if (p.num >= 4000 && p.num < 6000)
        {
            plusSpeed = 4f;
            speed = speed + plusSpeed;
        }
        else if (p.num >= 6000 & p.num < 8000)
        {
            plusSpeed = 6f;
            speed = speed + plusSpeed;
        }
        else if (p.num >= 8000 & p.num < 10000)
        {
            plusSpeed = 8f;
            speed = speed + plusSpeed;
        }
        else if(p.num >= 10000 & p.num < 12000)
        {
            plusSpeed = 10f;
            speed = speed + plusSpeed;
        }
        else if(p.num >= 12000 & p.num < 14000)
        {
			plusSpeed = 12f;
			speed = speed + plusSpeed;
        }
    }

    void Update()
    {
        StartCoroutine(Patterns());
        if (desaparece == true)
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
            if (transform.position.x < Camera.main.transform.position.x - 22)
            {
                Destroy(gameObject);
            }
        }

        //print(speed);
    }
    IEnumerator Patterns()
    {
        yield return new WaitForSeconds(4);
        desaparece = true;
        StopCoroutine(Patterns());
    }
}
