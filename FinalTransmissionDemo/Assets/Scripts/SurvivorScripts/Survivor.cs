using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Survivor : MonoBehaviour {

    [SerializeField]
    private GameObject survivorPrefab;
    public string SurvivorName;
    public string SurvivorAge;
    public int SurvivorID;

    [HideInInspector]
    public SurvivorStats Stats;
    public List<Trait> SurvivorTraits = new List<Trait>();

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public int health = 100;
    public int ammoCount = 20;


    // Use this for initialization
    void Awake()
    {
        //Stats.Traits = SurvivorTraits;
        NewSurvivorGenerated();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (ammoCount >= 1)
            {
                Fire();
                ammoCount--;
            }

        }
    }

    public void Fire()
    {
        // Will create the bullet
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);

        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 100;

        // Destroys the bullet after two seconds
        Destroy(bullet, 2.0f);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "EnemyShell")
        {
            health = health - 10;
        }

        if (other.gameObject.tag == "Enemy")
        {        
            health = health - (Random.Range(3, 9));
        }
    }

    public void NewSurvivorGenerated()
    {
        double test = Random.Range(0, 1);

        if (test > 0.5)
        {
            Debug.Log("Has traits"); // place trait generation here
        }

        //Stats.GenerateStats();
    }

}//end class
public class SurvivorStats : MonoBehaviour
{
    public float Health = 100;
    public float Stamina = 100;
    public float Strength = 100;
    public float Accuracy = 100;
    public float FoodConsumptionAmount = 10;

    public List<Trait> Traits = new List<Trait>();

    public void GenerateStats()
    {
        foreach (Trait trait in Traits)
        {
            string tempName = trait.traitname.ToString();
            switch (tempName)
            {
                case "Health":
                    Health = CalculateStat(Health, trait);
                    break;

                case "Stamina":
                    Stamina = CalculateStat(Stamina, trait);
                    break;

                case "Strength":
                    Strength = CalculateStat(Strength, trait);
                    break;

                case "Accuracy":
                    Accuracy = CalculateStat(Accuracy, trait);
                    break;

                case "FoodConsumptionAmount":
                    FoodConsumptionAmount = CalculateStat(FoodConsumptionAmount, trait);
                    break;


            }

        }

    }

    public float CalculateStat(float statToChange, Trait checkTrait)
    {
        float tempFloat = statToChange - checkTrait.traitEffectAmount;


        return tempFloat;
    }

}// end SurvivorStats

public class Trait : MonoBehaviour
{
    public string traitName;
    public float traitEffectAmount;

    public enum TraitName { Gluttonous, Blind, Weak };
    public enum StatName { Health, Stamina, Accuracy, Strength, FoodConsumptionAmount };

    public TraitName traitname;
    public StatName statName;

    //private string healthName = "Health";
    //private string staminaName = "Stamina";
    //private string accuracyName = "Accuracy";
    //private string strengthName = "Strength";
    //private string consumptionName = "FoodConsumptionAmount";
    public void EffectedStat()
    {
        string statToAlter = traitName.ToString();
    }

    public Trait(TraitName name)
    {

    }


}
