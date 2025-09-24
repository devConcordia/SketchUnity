using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	
	private int health = 100;
	
	[SerializeField] private HudController hud;
	
	[SerializeField] private string attack = "vassourada";
	
	
    private Vector2 input;
    private Vector2 direction = new Vector2();
	
	[SerializeField] private GameObject InteractionPrefab;
	[SerializeField] private GameObject AttackPrefab;
	
	[SerializeField] private float speed = 5;
	
	private bool waitingAttack = false;
	
	private SpriteRenderer spriteRenderer;
	private Animator animator;
    private Rigidbody2D body;
	
    void Start() {
		
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		
		/// 
	//	animator.SetFloat("x", -1f);
    //   animator.SetFloat("y", -1f);
		
	//	Time.timeScale = .5f;
		
    }

    void Update() {
		
        GetInput();
		
    }

    void FixedUpdate() {
		
        body.linearVelocity = input.normalized * speed;
		spriteRenderer.sortingOrder = Mathf.RoundToInt( -transform.position.y * 10 );
		
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
		
		Interaction();
		Attack();
		
    }
	
	void Interaction() {
		
		if( Input.GetKeyDown( KeyCode.E ) ) {
			
			Vector3 pos = transform.position + new Vector3( direction.x, direction.y, 0f );
			
			Instantiate( InteractionPrefab, pos, Quaternion.identity);
			
		}
		
	}
	
	void Attack() {
		
		if( !waitingAttack && Input.GetKeyDown(KeyCode.Space) && attack != "" ) {
			
			waitingAttack = true;
			
			animator.SetTrigger( attack );
			
			StartCoroutine(DelayAttack());
		
		}
		
	}
	
	
	private IEnumerator DelayAttack() {
		
		yield return new WaitForSeconds( 0.6f );
		
		Vector3 p = transform.position + new Vector3( direction.x, direction.y, 0f );
		
		Instantiate( AttackPrefab, p, Quaternion.identity );
		
		waitingAttack = false;
		
	}
	
	
	public void takeDamage( int value = 1 ) {
		
		health -= value;
		
		if( health < 1 ) {
			
			Debug.Log("GAME_OVER: Next day?");
			
		} else {
			
			hud.setHealth( health );
			
		}
		
		
	}
	
	
	private void OnCollisionEnter2D(Collision2D collision) {
		
		if( collision.gameObject.CompareTag("TownDoor") ) {
			
			if( GameData.tvWatched ) {
				
				SceneManager.LoadScene("TownScene");
			
			} else {
				
				hud.writeDialog("É melhor verificar o noticiário antes de sair.");
				hud.lockDialog();
				
			}
			
		} else if( collision.gameObject.CompareTag("HouseDoor") ) {
			
			SceneManager.LoadScene("HouseScene");
			
		} else if( collision.gameObject.CompareTag("PubDoor") ) {
			
			hud.writeDialog("Ainda não feito a cena do bar.");
			
		} else if( collision.gameObject.CompareTag("WorkDoor") ) {
			
			
			
		}
		
	}
	
}
