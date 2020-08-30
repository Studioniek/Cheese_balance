using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopKnife_at_Collision : MonoBehaviour
{


		//public PlayerMovement movement;
		//public GameManager;

		void OnCollisionEnter (Collision collisionInfo)
		{
			//als bal eind raakt
			if (collisionInfo.collider.tag == "Finish")
			{
				//movement.enabled = false;
			FindObjectOfType<GameManager>().Finish();
			}
			//als bal door gat valt
		if (collisionInfo.collider.tag == "Respawn")
			{
				//movement.enabled = false;
			FindObjectOfType<GameManager>().Respawn();
			}

		}
	// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

