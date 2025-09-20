using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 input;
    private Vector2 direction = new Vector2();
	
	[SerializeField] private GameObject InteractionPrefab;
	
	[SerializeField] private float speed = 5;
	
	private Animator animator;
    private Rigidbody2D body;
	
    void Start() {
		
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
		
    }

    void Update() {
		
        GetInput();
		
    }

    void GetInput() {
		
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
		
		if( input.x != 0 || input.y != 0 ) {
			animator.SetBool("walking", true);
			direction = input;
		} else {
			animator.SetBool("walking", false);
		}
		
        animator.SetFloat("x", direction.x);
        animator.SetFloat("y", direction.y);
		
		
		if( Input.GetKeyDown(KeyCode.E) ) {
			
			Vector3 pos = transform.position + 2f * new Vector3( direction.x, direction.y, 0f );
		
			Instantiate( InteractionPrefab, pos, Quaternion.identity);
			
		}
		
    }

    void FixedUpdate() {
		
        body.linearVelocity = input.normalized * speed;
		
    }

}
