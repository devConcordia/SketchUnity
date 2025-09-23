using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	
	[SerializeField] private int HP = 5;
	[SerializeField] private int Energy = 5;
	[SerializeField] private string attack = "vassourada";
	
	
	
    private Vector2 input;
    private Vector2 direction = new Vector2();
	
	[SerializeField] private GameObject InteractionPrefab;
	[SerializeField] private GameObject AttackPrefab;
	
	[SerializeField] private float speed = 5;
	
	private SpriteRenderer spriteRenderer;
	private Animator animator;
    private Rigidbody2D body;
	
    void Start() {
		
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		
		/// 
		animator.SetFloat("x", -1f);
        animator.SetFloat("y", -1f);
		
	//	Time.timeScale = .5f;
		
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
		
		if( Input.GetKeyDown(KeyCode.Space) && attack != "" ) {
			
			animator.SetTrigger( attack );
		
			Vector3 pos = transform.position + 2f * new Vector3( direction.x, direction.y, 0f );
			
			Instantiate( AttackPrefab, pos, Quaternion.identity );
			
		//	GameObject attackGameObject = Instantiate( AttackPrefab, pos, Quaternion.identity);
		//	AttackController AtkCtrl = attackGameObject.GetComponent<AttackController>();
		//	AtkCtrl.damage = 1;
			
		} else if( Input.GetKeyDown(KeyCode.E) ) {
			
			Vector3 pos = transform.position + 2f * new Vector3( direction.x, direction.y, 0f );
			
			Instantiate( InteractionPrefab, pos, Quaternion.identity);
			
		}
		
    }

    void FixedUpdate() {
		
        body.linearVelocity = input.normalized * speed;
		spriteRenderer.sortingOrder = Mathf.RoundToInt( -transform.position.y * 10 );
		
    }

}
