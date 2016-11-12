using UnityEngine;
using System.Collections;

public class PlayerMovementScript : MonoBehaviour {
	Rigidbody2D RB;
	public float speedMax = 0;
	float currentSpeed = 0;
	InputScript IS;
	float deadSize = .15f;
	bool canMove = true;
	//PlayerStateMachine state;
	FacingDirection facing;
	//SpriteAnimator spriteAnimator;
	// Use this for initialization
	void Awake () {
		//spriteAnimator = GetComponent<SpriteAnimator> ();
		//state = GetComponent<PlayerStateMachine> ();
		IS = GetComponent<InputScript> ();
		RB = GetComponent<Rigidbody2D> ();
	//	state = GetComponent<PlayerStateMachine> ();
		IS.SetThumbstick (ProcessMovement);
		ResetSpeed ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void ProcessMovement(float x,  float y){
		if (canMove) {
			if (x < deadSize && x > -deadSize) {
				x = 0;
			}
			if (y < deadSize && y > -deadSize) {
				y = 0;
			}
			RB.velocity = new Vector2 (x * currentSpeed, y * currentSpeed);
			CalculateFacing (x, y);
		}

	}
	public void SetSpeed(float newSpeed = 0){
		currentSpeed = newSpeed;
	}
	public void ResetSpeed(){
		currentSpeed = speedMax;
	}
	public void Charge(float speed,Vector2 direction, float duration){
		StartCoroutine (ChargeNumer (speed, direction, duration));
	}
	IEnumerator ChargeNumer(float speed, Vector2 direction, float duration){
		canMove = false;
		RB.velocity = direction * speed;
		while (duration > 0){
			yield return null;
			duration -= .0167f;

		}
		canMove = true;
		
	}
	public void StopMovement(){
		RB.velocity = Vector2.zero;
	}
	void CalculateFacing(float x, float y){
		if (x > deadSize && x > y) {
			facing = FacingDirection.right;
			//spriteAnimator.PlayMoveRight ();				

		} else if (x <- deadSize && x < y) {
			facing = FacingDirection.left;
			//spriteAnimator.PlayMoveLeft ();

		} else if (y > deadSize) {
			facing = FacingDirection.up;
			//spriteAnimator.PlayMoveUp ();

		} else if (y < -deadSize) {
			facing = FacingDirection.down;
			//spriteAnimator.PlayMoveDown ();						

		}


		if (RB.velocity == Vector2.zero) {
			if (facing == FacingDirection.left) {
				//spriteAnimator.PlayfaceLeft ();				
			}else if (facing == FacingDirection.right) {
				//spriteAnimator.PlayfaceRight ();				
			}else if (facing == FacingDirection.up) {
				//spriteAnimator.PlayfaceUp ();				
			}else if (facing == FacingDirection.down) {
				//spriteAnimator.PlayfaceDown ();
			}
		}
	}
	public float getFacingDegree (){
		if (facing == FacingDirection.right) {
			return 0;		
		}else if (facing == FacingDirection.up) {
			return 90;					
		}else if (facing == FacingDirection.left) {
			return 180;			
		}else{
			return 270;		
		}
	}

	public void DisableMovement( float delay){
		StartCoroutine(ResetMovement(delay));
	}
	IEnumerator ResetMovement(float delay){
		canMove = false;
		yield return new WaitForSeconds (delay);
		canMove = true;
	}
}
	
enum FacingDirection{
	up,
	down,
	left,
	right
}
