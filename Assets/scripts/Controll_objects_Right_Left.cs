using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
//https://hastebin.com/uratiyiyeg.cpp
public class Controll_objects_Right_Left : MonoBehaviour
{
	public float MoveSpeedMax = 18;
	public float MoveSpeedMin = 0.5f;
	public float MoveSpeedRight;
	public float MoveSpeedLeft;
	public float MaxDistanceLeft = 60f;
	public float MaxDistanceRight = 60f;
	public Transform Left; 
	public Transform Right;
	public GameObject Left_Object;
	public GameObject Right_Object;
	public GameObject BlockerLeft;
	public GameObject BlockerRight;
	public float Distance_Left;
	public float Distance_Right;
	public float afstandtellerright;
	public float afstandtellerleft;
	public float blockerspeed = 0.82f;
	private bool moveLeftUP; // determine if we move op or down leftside
	private bool moveLeftDOWN;

	private bool moveRightUP; // determine if we move op or down rechtsside
	private bool moveRightDOWN;
	private bool dontMoveRightUP;
	private bool dontMoveLeftUP; // determine if we are moving or not

	void Start()
	{
		MoveSpeedRight = MoveSpeedMax;
		MoveSpeedLeft = MoveSpeedMax;
		dontMoveLeftUP = true;	//voorUI
		dontMoveRightUP = true; //voor UI
	}

	void HandleMoving () //moving buttons UI
	{
		if (dontMoveLeftUP) //links ui
		{	StopMovingLeftup();
		}else
		{	if (moveLeftUP)
			{	MOVELEFTUP();
			} 	
		else if (!moveLeftUP)
		{MOVELEFTDOWN();
		}
	}
		if (dontMoveRightUP)// rechst ui
		{	StopMovingRightup();
		}else
		{	if (moveRightUP)
			{	MOVERIGHTUP();
			} 	
		else if (!moveRightUP)
		{	MOVERIGHTDOWN();
		}
	}

	}
	//Links UI
	public void AllowMovementLeftUP( bool movementleftUP)
	{	dontMoveLeftUP = false;
		moveLeftUP = movementleftUP;
	}
	public void DontAllowMovementLeftUP()
	{	dontMoveLeftUP = true;
	}
	public void MOVELEFTUP()
	{	Left_Object.transform.Translate(0f,MoveSpeedLeft*Time.deltaTime,0f);
	}
	public void MOVELEFTDOWN()
	{	Left_Object.transform.Translate(0f,-MoveSpeedLeft*Time.deltaTime,0f);
	}
	public void StopMovingLeftup ()
	{	Left_Object.transform.Translate(0f,0f,0f);
	}

	//RECHTS UI
	public void AllowMovementRightUP( bool movementRightUP)
	{	dontMoveRightUP = false;
		moveRightUP = movementRightUP;
	}
	public void DontAllowMovementRightUP()
	{dontMoveRightUP = true;
	}
	public void MOVERIGHTUP()
	{Right_Object.transform.Translate(0f,MoveSpeedRight*Time.deltaTime,0f);
	}
	public void MOVERIGHTDOWN()
	{Right_Object.transform.Translate(0f,-MoveSpeedRight*Time.deltaTime,0f);
	}
	public void StopMovingRightup ()
	{	Right_Object.transform.Translate(0f,0f,0f);
	}


	void Update()
	{
		{
			HandleMoving(); //moving buttons UI
		}
		Distance_Right = Vector3.Distance(BlockerRight.transform.position, Left_Object.transform.position);
		Distance_Left = Vector3.Distance(BlockerLeft.transform.position, Right_Object.transform.position);
		afstandtellerright = (Distance_Right - MaxDistanceRight) *(MoveSpeedMin / MoveSpeedMax);
		afstandtellerleft = Distance_Left - MaxDistanceLeft;
		if (Distance_Right >MaxDistanceRight)
		{	MoveSpeedRight = (MoveSpeedMax - Mathf.Lerp(MoveSpeedMin, MoveSpeedMax, afstandtellerright));}
		if (Distance_Right<MaxDistanceRight)
		{	MoveSpeedRight = MoveSpeedMax;}	
		if (Distance_Left >MaxDistanceLeft)
		{	MoveSpeedLeft = (MoveSpeedMax - Mathf.Lerp(MoveSpeedMin, MoveSpeedMax, afstandtellerleft));}
		if (Distance_Left<MaxDistanceLeft)
		{	MoveSpeedLeft = MoveSpeedMax;}	
		if (afstandtellerright > blockerspeed)
		{	MoveSpeedRight = MoveSpeedMin;}
		if (afstandtellerleft > blockerspeed)
		{	MoveSpeedLeft = MoveSpeedMin;}

		Right_Object.transform.Translate(0f,MoveSpeedRight*Input.GetAxis("Horizontalextra")*Time.deltaTime,0f);
		Left_Object.transform.Translate(0f,MoveSpeedLeft*Input.GetAxis("Vertical")*Time.deltaTime,0f);


	}


}

