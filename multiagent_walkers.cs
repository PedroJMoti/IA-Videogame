using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/* **********************************************************
	 * 
	 * 					YOU CAN CHANGE THIS
	 * 
	 * You can change this function to modify the behavior regarding Walkers B
	 * ********************************************************** */
public class multiagent_walkers : MonoBehaviour {

	public GameObject Leader;

	private Rigidbody rb;

	private float moveX = 0.5f;
	private float moveY = -0.5f;

	private float speed = 3.0f;

	private Vector3 distance;

	private Transform target;
    private Transform randomTarget;
    public float xpos;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		print("Leader: " + transform.position);
		target = Leader.transform;
		print("Walker: " + target.position);
		// getting distance vector from 
		distance = transform.position - target.position;
		print("Distance: "+ distance.magnitude);

        xpos = Random.Range(-0.05f, 0.05f); // Random value in position format to make agents move
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
		// Vector3 movement = new Vector3(moveX, 0.0f, moveY);

		// // rb.AddForce(movement * 10.0f);
		distance = transform.position - target.position;
        //print("Distance: "+ distance);
        if (distance.magnitude<10) {
            print("In range");
            float step = Leader.GetComponent<Rigidbody>().velocity.magnitude * Time.deltaTime;
		    //transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            //transform.position = Vector3.Lerp(transform.position, randomTarget.position, Time.deltaTime * speed);
            
            transform.position = transform.position + new Vector3(xpos,xpos, 0);
            //transform.position = transform.position + new Vector3(xpos * speed * Time.deltaTime, xpos * speed * Time.deltaTime, 0);
            
        }
        else {
            //transform.position = transform.position + new Vector3(0.2f, 0.2f, 0);
            print("Not in range");
            float step = Leader.GetComponent<Rigidbody>().velocity.magnitude * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            
        }
            

	}
}
