using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBody : MonoBehaviour {

    public GravityAttractor attractor;
    private Transform myTransform;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        myTransform = transform;
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (attractor)
        {
            attractor.Attract(myTransform);
        }
             
	}
}
