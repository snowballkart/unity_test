using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public float speed= 1f;
	private SpriteRenderer sprite;
	private Animator anim;
	// Use this for initialization
	void Start () {
		sprite = GetComponent<SpriteRenderer>();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 dir = Vector2.zero;

		if (Input.GetKey(KeyCode.W)) {
	 		dir += Vector2.up; // same as new Vector2(0, 1);
	 	}
	 	if (Input.GetKey(KeyCode.S)) {
		 	dir += Vector2.down; // same as new Vector2(0, -1);
		}
		if (Input.GetKey(KeyCode.A)) {
 			dir += Vector2.left; // same as new Vector2(-1, 0);
 			sprite.flipX = true;
		}
		if (Input.GetKey(KeyCode.D)) {
 			dir += Vector2.right; // same as new Vector2(1, 0);
 			sprite.flipX = false;
		}

 		dir = dir.normalized; // ensure direction is a normal vector

 		if(dir == Vector2.zero){
 			anim.SetBool("isMoving", false);
 		}
 		else {
 			anim.SetBool("isMoving", true);
 		}

 		Vector2 dist = dir * speed * Time.deltaTime;
 		transform.Translate(dist);
	}
}