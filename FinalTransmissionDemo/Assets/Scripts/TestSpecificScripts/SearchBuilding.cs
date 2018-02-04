using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchBuilding : MonoBehaviour {

    private bool canSearch = false;
    private SurvivorController survController;
    private GameObject survivorOutside;

	// Use this for initialization
	void Start () {
        survController = GameObject.FindGameObjectWithTag("GameController").GetComponent<SurvivorController>();
	}
	
	// Update is called once per frame
	void Update () {
        if ((canSearch == true) && survController.selectedSurvivor)
        {

        }
	}


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == survController.selectedSurvivor)
        {
            canSearch = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Survivor")
        {
            canSearch = false;

        }
    }

}
