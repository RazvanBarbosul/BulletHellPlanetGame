using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBody : MonoBehaviour {

    public GravityAttractor attractor;
    private Transform myTransform;
    public float oreAmount = 1000f;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        myTransform = transform;
        oreAmount = 1000f;
        StartCoroutine(RemoveKinematic());
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (attractor)
        {
            attractor.Attract(myTransform);
        }
             
	}

    IEnumerator RemoveKinematic()
    {
        yield return new WaitForSeconds(5);
        GetComponent<Rigidbody>().isKinematic = true;

    }

    public void DestroyMeteor()
    {
        Destroy(gameObject, 0);
    }
}
