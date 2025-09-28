using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
	
	//public int health = 100;
	
	[SerializeField] private HudController hud;
	
	[SerializeField] public string attack = "vassourada";
	
	
    private Vector2 input;
    private Vector2 direction = new Vector2();
	
	[SerializeField] private GameObject InteractionPrefab;
	[SerializeField] private GameObject AttackPrefab;
	
	[SerializeField] private float speed = 5;
	[SerializeField] private float timeChangeScene = 1f;
	
	private bool waitingAttack = false;
	private bool waitingChangeScene = false;
	
	private SpriteRenderer spriteRenderer;
	private Animator animator;
    private Rigidbody2D body;
	
    void Start() {
		
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		
		/// 
		//hud.setHealth( GameData.health );
		//hud.setHelper( "Dia "+ GameData.day );
		
		hud.setHelper( "Dia "+ GameData.day +" - "+ GameData.quest );
		
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
	
	
	public void changeScene( string sceneName ) {
		
		StartCoroutine(DelayChangeScene( sceneName ));
		
	}
	
	private IEnumerator DelayChangeScene( string sceneName ) {
		
		hud.fadeOut();
		yield return new WaitForSeconds( timeChangeScene );
		SceneManager.LoadScene( sceneName );
		
	}
	
	
	
	public void endDay() {
		
		waitingChangeScene = true;
		
		GameData.nextDay();
		changeScene("HouseScene");
		
	}
	
	public void takeDamage( int value = 1 ) {
		
		if( !waitingChangeScene && GameData.health > 0 ) {
			
			GameData.health -= value;
			hud.setHealth( GameData.health );
			
			if( GameData.health < 1 ) {
				
				if( GameData.day == 2 )
					GameData.bossPhone = true;
				
				endDay();
				
			}
			
		}
		
	}
	
	private void OnCollisionEnter2D(Collision2D collision) {
		
		if( collision.gameObject.CompareTag("TownDoor") ) {
			
			if( GameData.tvWatched ) {
				
				changeScene("TownScene");
			
			} else {
				
				hud.writeDialog("É melhor verificar o noticiário antes de sair.", "Fechar (Space)");
				hud.lockDialog();
				
			}
			
		} else if( collision.gameObject.CompareTag("HouseDoor") ) {
			
			changeScene("HouseScene");
			
		} else if( collision.gameObject.CompareTag("PubDoor") ) {
			
			changeScene("PubScene");
			
		} else if( collision.gameObject.CompareTag("WorkDoor") ) {
			
			hud.fadeOut();
			endDay();
			
		}
		
	}
	
}
