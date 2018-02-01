using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayTime : MonoBehaviour {

    //Note this script requires AttackBase Script


    [SerializeField]
    private BaseEvents baseevents;


    public Text DayText;
    public Text HourText;


    private float lastChange;
    public float day = 1;
    public float hour = 7;
    private int enableValue = 0;

    private string ampm = "AM";

    public float timeChange = 30; //  seconds before hour changes
    public Text timeText;

    public bool baseAttack = false;
    public bool baseTrader = false;


	// Use this for initialization
	void Start () {
        //      timeText.text = "Day: " + day.ToString() + "  " + hour.ToString() + " " + ampm;
        DayText.text = "Day: " + day.ToString();
        HourText.text = hour.ToString() +ampm;
    }

    // Update is called once per frame
    void Update () {

        //Calculates Time
        if ((Time.time - lastChange) > timeChange)
        {
            hour++;
            // changes to PM
            if (hour == 12)
            {
                ampm = "PM";
            }

            //Changes to Am and resets clock
            if (hour == 24)
            {
                day++;
                hour = 0;
                ampm = "AM";
                DayText.text = "Day: " + day.ToString();
            }
            lastChange = Time.time; // Updated each frame, current time
        }//end if


        //Used to determine if a new day or not
        if (hour == 6 && enableValue == 0)
        {
            NewDay();
        }
        if (hour == 7)
        {
            enableValue = 0; // reset method call so it can be recalled the folow day
        }
        HourText.text = hour.ToString() + ampm;

    }//end Update


    void NewDay()
    {
        enableValue = 1; // quickly resets to stop constant Method Calling
        baseevents.AttackChance += 5;
        baseevents.GenerateChanceOfEvent(); // Determines if attack happens that day
        Debug.Log("New Day");

        //deducte resources

    }

    


}//endclass
