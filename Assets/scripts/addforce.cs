using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//-9.81 gravity op y
public class addforce : MonoBehaviour
{
	public float thrust = 1.0f;
	public Rigidbody rb;
	public float SideForce = 50;
	public float forceAmount = 1;
	void Start()
	{
		//rb = GetComponent<Rigidbody>();
		rb = GetComponent<Rigidbody>();

	}

	void FixedUpdate()
	{
		//rb.AddForce(thrust, 0, 0, ForceMode.Impulse);
		//rb.AddForce(transform.forward * thrust);
		//rb.AddForce(rigidbody.velocity.normalized * Time.deltaTime * forceAmount);
		if (Input.GetKey("w"))
		{
			rb.AddForce(SideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
		}      
		if (Input.GetKey("s"))
		{
		rb.AddForce(-SideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
		}
		//(KeyCode.UpArrow) 
		if (Input.GetKey("up"))
		{
			rb.AddForce(-SideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
		}      
		if (Input.GetKey("down"))
		{
			rb.AddForce(SideForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
		}
	}
}
