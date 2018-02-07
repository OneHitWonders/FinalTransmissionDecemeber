using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchBuilding : MonoBehaviour {

    private ResourceCollector resourceCollector;

    private SurvivorController survController;
    private GameObject survivorOutside;

    [SerializeField]
    private int BuildingSize =1 ;


    //Variables for Searching
    private bool canSearch = false;
    private bool beingSearched = false;
    private DayTime dayTime;
    private float HrFinishSearch = 0;

    private bool BeenSearched = false;


	// Use this for initialization
	void Start () {
        survController = GameObject.FindGameObjectWithTag("GameController").GetComponent<SurvivorController>();
        dayTime = GameObject.FindGameObjectWithTag("GameController").GetComponent<DayTime>();
        resourceCollector = GameObject.FindGameObjectWithTag("GameController").GetComponent<ResourceCollector>();



    }
	
	// Update is called once per frame
	void Update () {
        if ((canSearch == true) && BeenSearched == false)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                BeginBuildingSearch();
            }
        }

        //When Search Timer Ends
        if (beingSearched == true)
        {
            if (HrFinishSearch == dayTime.hour)
            {
                FinishedSearch();
            }
        }
	}


    public void BeginBuildingSearch()
    {
        survivorOutside.SetActive(false);
        beingSearched = true;
        HrFinishSearch = dayTime.hour + 2;
        Debug.Log(HrFinishSearch.ToString());
    }

    private void FinishedSearch()
    {
        beingSearched = false;
        BeenSearched = true; // prevents re-searching
        survivorOutside.SetActive(true);
        GenerateResourcesGathered();


    }

    public void GenerateResourcesGathered()
    {
        //Food
        if (Random.Range(0,10) <= 7)
        {
            resourceCollector.foodCollected += (4 * BuildingSize) + 2;

        }
        //Water
        if (Random.Range(0, 10) <= 8)
        {
            resourceCollector.waterCollected += (3 * BuildingSize) + 2;

        }
        //Wood
        if (Random.Range(0, 10) <= 6)
        {
            resourceCollector.woodCollected += (3 * BuildingSize) + 2;

        }
        //Metal
        if (Random.Range(0, 10) <= 4)
        {
            resourceCollector.metalCollected += (2 * BuildingSize) + 2;

        }
        //Ammo
        if (Random.Range(0, 10) <= 3)
        {
            resourceCollector.ammoCollected += (2 * BuildingSize) + 2;

        }
        //Money
        if (Random.Range(0, 10) <= 4)
        {
            resourceCollector.moneyCollected += (2 * BuildingSize) + 2;

        }
        Debug.Log("ResourceGenerationCalled");
    }




    private void OnTriggerEnter(Collider other)
    {
        if (BeenSearched == false)
        {
            if ((other.gameObject.tag == "Survivor") && beingSearched == false)
            {
                survivorOutside = other.gameObject;
                canSearch = true;
                Debug.Log("Can search");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
       
            if (other.tag == "Survivor")
            {

                survivorOutside = null;
                canSearch = false;
            Debug.Log("TriggerLeave");
            }
        

    }






}
