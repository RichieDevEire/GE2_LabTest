using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour 
{
	public float mass = 1f;
	public Vector3 force = Vector3.zero;
	public Vector3 accelerate = Vector3.zero; 
	public Vector3 vel = Vector3.zero;
	public float maxSpeed = 10f;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 myAcceleration = force/mass;

		float smooth = Mathf.Clamp(5f * Time.deltaTime, 0.1f, 0.5f) / 2f;
		accelerate = Vector3.Lerp(accelerate, myAcceleration, smooth);
		vel += accelerate * Time.deltaTime;
		vel = Vector3.ClampMagnitude(vel, maxSpeed);

		if(vel.magnitude > 0.00001f)
		{
			transform.LookAt(transform.position + vel, Vector3.up);
			vel *= 0.99f;
		}
		transform.position += vel * Time.deltaTime;
	}

	public Vector3 Seek(Vector3 targ)
	{
		Vector3 desired = targ - transform.position;
		desired.Normalize();
		desired *= maxSpeed;
		return desired - vel;
	}


}
