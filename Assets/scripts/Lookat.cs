using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lookat : MonoBehaviour
{

	public Transform target;
	// Start is called before the first frame update
    void Start()
    {
		//this.transform.LookAt(new Vector3 (0f,0f,0f));
    }

    // Update is called once per frame
   // void Update()
    //{
		//this.transform .RotateAround(new Vector3(0f,0f,0f),new Vector3(0f,1f,0f), 90f*Time.deltaTime)

			//public AudioSource audiorolbal;


			// Use this for initialization
			//void Start () 
			//{

	//Vector3 targetPostition = new Vector3( target.position.x, 
		//this.transform.position.y, 
		//target.position.z ) ;
		//	}

			// Update is called once per frame
			void Update () 
			{
			transform.LookAt(target);
		//transform.LookAt(Vector3.zero);

	
	}
}
