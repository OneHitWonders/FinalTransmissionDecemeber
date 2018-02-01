using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ResourceManager : MonoBehaviour {

    public int Food;
    public Text foodText;

    public int Water;
    public Text waterText;

    public int Wood;
    public Text woodText;

    public int Metal;
    public Text metalText;

    public int Medicine;
    public Text medicineText;

    public int Happiness;
    public Text happinessText;

    public int Ammo;
    public Text ammoText;

    public int Money;
    public Text moneyText;





    // Use this for initialization
    void Start () {
        foodText = GameObject.Find("FoodText").GetComponent<Text>();
        waterText = GameObject.Find("WaterText").GetComponent<Text>();
        woodText = GameObject.Find("WoodText").GetComponent<Text>();
        metalText = GameObject.Find("MetalText").GetComponent<Text>();
        medicineText = GameObject.Find("MedicineText").GetComponent<Text>();
        happinessText = GameObject.Find("HappinessText").GetComponent<Text>();
        ammoText = GameObject.Find("AmmoText").GetComponent<Text>();
        moneyText = GameObject.Find("MoneyText").GetComponent<Text>();


    }

    // Update is called once per frame
    void Update () {
		
	}
}
