using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayTime : MonoBehaviour {

    private Text DayCount;
    private float lastChange;
    private float day = 1;
    private float hour = 7;
    private int enableValue = 0;

    private string ampm = "am";

    public float timeChange = 150; //  seconds before hour changes
    public Text timeText;

    public bool baseAttack = false;
    public bool baseTrader = false;


	// Use this for initialization
	void Start () {
        timeText.text = "Day: " + day.ToString() + "  " + hour.ToString() + " " + ampm;
    }

    // Update is called once per frame
    void Update () {

        //Calculates Time
        if ((Time.time - lastChange) > timeChange)
        {
            hour++;


            CheckForHourEvent();
           
            // prevents it from repeating
            if (hour == 12)
            {
                ampm = "PM";
            }
            if (hour == 24)
            {
                day++;
                hour = 0;
                ampm = "AM";
            }
            timeText.text = "Day: " + day.ToString() + "  " + hour.ToString() + " " + ampm;

            lastChange = Time.time;
        }//end if

        if (hour == 6 && enableValue == 0)
        {
            NewDay();
        }
        if (hour == 7)
        {
            enableValue = 0;

        }



    }


    void NewDay()
    {
        enableValue = 1;

    }

    public void CheckForHourEvent()
    {
        //Calculate Events and enable them
        if (baseAttack == true)
        {


            baseAttack = false;
        }

        if (baseTrader == true)
        {
            //Call Create Trader Method


            baseTrader = false;
        }

    }


}//endclass
