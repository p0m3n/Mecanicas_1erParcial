using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealtBar : MonoBehaviour
{
    public float timeToWait = 5f;
    //public MovementPlayer Player;
    public Coroutine currentRutine;

    public Image fillImage;

    private void Start()
    {
        //currentRutine = StartCoroutine(RoutineWait());
    }

   /* private void Update()
    {
        if (Player == null) return;

        float porcentajeVida = Player.vida / Player.VidaMax;
        fillImage.fillAmount = porcentajeVida;
    }
     */

    public void StopRutinesOfThisClass()
    {
        StopCoroutine(currentRutine);
    }
    /*
    public IEnumerator RoutineWait()
    {
        Player.speed = 0;
        yield return new WaitForSeconds(timeToWait);
        Player.speed = 3f;
    }
    */
}
