using UnityEngine;

public class PlayerCollision : MonoBehaviour
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
		//	Debug.Log ("Finish");
		}
		//als bal door gat valt
		if (collisionInfo.collider.tag == "Respawn")
		{
			//movement.enabled = false;
			FindObjectOfType<GameManager>().Respawn();
		//	Debug.Log ("gameover");
		}
		if (collisionInfo.collider.tag == "EndGame")
		{
			//movement.enabled = false;
			FindObjectOfType<GameManager>().EndGame();
		
			Debug.Log ("gameover");
		}
	
	}
}
