using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurvivorCameraFollow : MonoBehaviour {


    public SurvivorController controller;
    public GameObject targetToFollow;

    [SerializeField]
    private float Offset_X;
    [SerializeField]
    private float Offset_Y;
    [SerializeField]
    private float Offset_Z;



    // Use this for initialization
    void Awake () {
        controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<SurvivorController>();
	}

    void Start()
    {
        targetToFollow = controller.selectedSurvivor;
    }
    // Update is called once per frame
    void Update ()
    {
        if (targetToFollow != null)
        {
            targetToFollow = controller.selectedSurvivor;

        }
        //updates when you change character selected
        if (targetToFollow != controller.selectedSurvivor)
        {
            targetToFollow = controller.selectedSurvivor;

        }

    }

    void FixedUpdate()
    {
        gameObject.transform.position = new Vector3(targetToFollow.transform.position.x + Offset_X, targetToFollow.transform.position.y + Offset_Y, targetToFollow.transform.position.z + Offset_Z);

    }


}//end class
