using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementTest : MonoBehaviour {

    public float moveSpeed = 5.5f;
    private Vector3 moveDir;
    public float jumpSpeed = 5f;
    public float characterHeight = 2f;
    float jumpRestRemaining;
    float jumpRest = 0.05f;
    private Transform myTransform;
    public GravityAttractor _GravityAtrtractor;

    RaycastHit hit;
    private float distToGround;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().useGravity = false;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        myTransform = transform;
	}
	
	// Update is called once per frame
	void Update () {
        moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0).normalized;
        jumpRestRemaining -= Time.deltaTime;

        if(moveDir.magnitude > 1)
        {
            moveDir = moveDir.normalized;
        }

        if(Physics.Raycast(transform.position, -transform.up, out hit))
        {
            distToGround = hit.distance;
            Debug.DrawLine(transform.position, hit.point, Color.yellow);
        }

        if(Input.GetMouseButton(0) && distToGround < (characterHeight * .5f) && jumpRestRemaining < 0)
        {
            jumpRestRemaining = jumpRest;
            GetComponent<Rigidbody>().AddRelativeForce(Vector3.up * jumpSpeed * 100);
        }
	}

    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(moveDir) * moveSpeed * Time.deltaTime);
        if (_GravityAtrtractor)
        {
            _GravityAtrtractor.Attract(myTransform);
        }
    }
}
