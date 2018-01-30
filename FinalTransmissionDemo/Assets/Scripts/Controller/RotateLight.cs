using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLight : MonoBehaviour {



    public Vector3 defaultPosition;
    public Quaternion defaultRotation;
	// Use this for initialization
	void Awake () {
        GameObject controller = GameObject.FindGameObjectWithTag("GameController");
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.RotateAround(Vector3.zero, Vector3.forward, 0.001388888889f);
        gameObject.transform.LookAt(Vector3.zero);
	}
}
