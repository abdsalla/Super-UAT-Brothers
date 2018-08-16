using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    private PlayerMovement pMovementRef;
    private Vector3 offset;


    void Awake()
    {
        pMovementRef = GetComponent<PlayerMovement>();
    }

    void Start ()
    {
        offset = transform.position - pMovementRef.GetComponent<PlayerMovement>().transform.position;
        //this.gameObject.transform.position = pMovementRef.transform.position;
	}
	
	void Update () {
        transform.position = pMovementRef.GetComponent<PlayerMovement>().transform.position + offset;
    }
}
