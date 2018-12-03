using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUPManager : MonoBehaviour {

    private bool desaparece = false;

    private float speed = 7;

    void Update()
    {
        StartCoroutine(PowerUP());
        if (desaparece == true)
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
            if (transform.position.x < Camera.main.transform.position.x - 22)
            {
                Destroy(gameObject);
            }
        }
    }
    IEnumerator PowerUP()
    {
        yield return new WaitForSeconds(4);
        desaparece = true;
        StopCoroutine(PowerUP());
    }
}
