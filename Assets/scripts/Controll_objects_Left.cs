using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Controll_objects_Left : MonoBehaviour
{
	public float moveSpeed = 30;
	public float moveSpeed_side = 2;
	// Start is called before the first frame update
    void Start()
    {

		//print(Input.GetAxis("Vertical"));
		//moveSpeed = 30;

	}

    // Update is called once per frame
    void Update()
    {
		//print(Input.GetAxis("Vertical"));
		transform.Translate(0f,moveSpeed*Input.GetAxis("Vertical")*Time.deltaTime,0f);  
		//transform.Translate(moveSpeed_side*Input.GetAxis("Horizontalextra")*Time.deltaTime,moveSpeed*Input.GetAxis("Horizontalextra")*Time.deltaTime,0f);  
			//transform.Translate(0f,(moveSpeedright*Input.GetAxis("Fire2")*Time.deltaTime,0f));    

    }
}
