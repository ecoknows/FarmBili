using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public GameObject Cycle;
    public GameObject Night;
    public GameObject Day;
    public int gameDayLengthMins;
    private int gameDayLengthSec;

    private bool isRunning = true;
    private bool night = false;

    private bool Transit = false;
    private int delay = 0;
    private int currentGameTime;

    void OnEnable() 
    {
       
        gameDayLengthSec = gameDayLengthMins * 60; 
        StartCoroutine(GameClock());   
    }

    private IEnumerator GameClock()
    {   
        while(isRunning)
        {
            currentGameTime++;

            if((!night) && (currentGameTime >= gameDayLengthSec))
            {
                Night.SetActive(true);
                Transit = true;
                while(Transit)
                {
                    delay++;
                    if(delay >= 5)
                    {
                    night = true;
                    Cycle.SetActive(true);
              
                    currentGameTime = 0;
                    Night.SetActive(false);
                    delay = 0;
                    break;
                    }
                    yield return new WaitForSeconds(1f);
                }
            }
            if((night) && (currentGameTime >= gameDayLengthSec))
            {
                night = false;
                Day.SetActive(true);
                Cycle.SetActive(false);
                
                Transit = true;
                while(Transit)
                {
                    delay++;
                    if(delay >= 5)
                    {
                        Day.SetActive(false);
                        delay = 0;
                        break;
                    }
                    yield return new WaitForSeconds(1f);
                }
              
                currentGameTime = 0;
            }
            yield return new WaitForSeconds(1f);
        }
    }

}
