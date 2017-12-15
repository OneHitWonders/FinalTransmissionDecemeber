using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivorController : MonoBehaviour {

    static Animator anim;
    public LinkedList<GameObject> listOfSurvivors = new LinkedList<GameObject>();
    public GameObject selectedSurvivor;
    private SurvivorMovement selectedMotor; // Used to move the current select
    private string IsWalking;


    [SerializeField]
    private GameObject survivorPrefabTemp;
    [SerializeField]
    private GameObject spawnPoint;

   

    private Quaternion screenMovementSpace;
    private Vector3 screenMovementForward;
    private Vector3 screenMovementRight;
    private string Axis_Y = "Vertical";
    private string Axis_X = "Horizontal";


    // Use this for initialization
    void Awake () {

        
        foreach (GameObject item in GameObject.FindGameObjectsWithTag("Survivor"))
        {
            AddSurvivor(item);
            if (selectedSurvivor == null)
            {
                selectedSurvivor = item;
                selectedMotor = selectedSurvivor.GetComponent<SurvivorMovement>();

            }

        }
        
	}

    void Start()
    {
        anim = GetComponent<Animator>();

        // will rotate in relation to the camera's y axis, used to rotate player
        screenMovementSpace = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);

        //Moving forwards or backwards on the z axis
       
        screenMovementForward = screenMovementSpace * Vector3.forward;
      

        //moving left or right on the x axis
        screenMovementRight = screenMovementSpace * Vector3.right;

    }


    // Update is called once per frame
    void Update () {
       
        //for testing to ensure survivors are added to list
        if (Input.GetKeyDown(KeyCode.K))
        {
            foreach (GameObject go in listOfSurvivors)
            {
                Debug.Log(go.name);
            }
        }
        if (Input.GetKeyDown(KeyCode.Y)) // for test purpose
        {
            GenerateNewSurvivor();
        }


        //MouseClick For selecting Survivor
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray,out hit, 1000))
            {
                if (hit.collider.tag == "Survivor")
                {
                    selectedSurvivor = hit.transform.gameObject; // gets the hit Gameobject and sets as selected
                    selectedMotor = selectedSurvivor.GetComponent<SurvivorMovement>();
                    selectedSurvivor.GetComponent<SurvivorMovement>().isSelected = true;
                    Debug.Log("select");
                }
            }
        }


        if (selectedSurvivor != null)
        {
            selectedMotor.movementDirection = Input.GetAxis("Horizontal") * screenMovementRight
                + Input.GetAxis("Vertical") * screenMovementForward;

            if (Input.GetAxis(Axis_X) != 0 || Input.GetAxis(Axis_Y) != 0)
            {
                anim.SetBool("IsWalking", true);
            }
            else
            {
                anim.SetBool("IsWalking", false);

            }
           

        }
      


    }

    public void GenerateNewSurvivor()
    {
        GameObject tempGO = survivorPrefabTemp; 
        Instantiate(tempGO, spawnPoint.transform.position,spawnPoint.transform.rotation);
        AddSurvivor(tempGO);

    }

    
    public void AddSurvivor(GameObject survivorToAdd)
    {
        listOfSurvivors.AddLast(survivorToAdd);

        //Adjust UI and Data
    }

    public void RemoveSurvivor(GameObject survivorToRemove)
    {
        listOfSurvivors.Remove(survivorToRemove);

        //adjust Ui and Data
    }

    public void SurvivorMovement()
    {

    }

}//end class
