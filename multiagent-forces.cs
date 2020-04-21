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
	
	public Material[] material;
	Renderer rend;



	// Use this for initialization
	void Start () {
		//MAterial

		rend = GetComponent<Renderer>();
		rend.enabled=true;
		rend.sharedMaterial=material[0];


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
		
		distance = transform.position - target.position;		
        
        if (distance.magnitude<20) {
            print("In range");
			rend.sharedMaterial=material[0];

            float step = Leader.GetComponent<Rigidbody>().velocity.magnitude * Time.deltaTime;
            
            transform.position = transform.position + new Vector3(xpos,0,xpos);
            
        }
        else {
            
            print("Not in range");
			float forceAmount=1000f;
			rend.sharedMaterial=material[1];

            rb.AddForce((target.position - transform.position).normalized * forceAmount * Time.smoothDeltaTime);
        }
            

	}
}
