using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeerController : EnemyMonoBehaviour
{
	// deve ser informado quando instanciar
	//public GameObject player;
   
	///
//	[SerializeField] private GameObject[] beerStylesPrefab;
	[SerializeField] private Sprite[] balloonSprites;
	[SerializeField] private GameObject balloon;
	[SerializeField] private RuntimeAnimatorController[] animators;
	private SpriteRenderer balloonSpriteRenderer;
	
	
	private Animator animator;
	private Rigidbody2D body;
	
	private float knockTimer = 0f;
	
    void Start() {
		
		/// se a referencia ao jogador não for dada, destrua o objeto
		if( player == null )
			Destroy( gameObject );
		
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        balloonSpriteRenderer = balloon.GetComponent<SpriteRenderer>();
		
		int randomStyleIndex = Random.Range( 0, animators.Length );
		
		animator.runtimeAnimatorController = animators[ randomStyleIndex ];
		
    }
	
	void FixedUpdate() {
		
		/// verifica se foi empurrado
		if( knockTimer > 0f ) {
			knockTimer -= Time.fixedDeltaTime;
			return;
		}
		
		
		///
		Vector3 dir = (player.transform.position - transform.position).normalized;
		
		if( dir.magnitude > .1f ) 
			body.linearVelocity = new Vector2( dir.x, dir.y );
			
		
	}
	
	public override void onTakeDamage() {
		
		Vector3 dir = (transform.position - player.transform.position).normalized;
		
		body.linearVelocity = 3f * new Vector2( dir.x, dir.y );
		
		knockTimer = 2f;
		
		if( Random.Range(0f,1f) < .20f ) 
			StartCoroutine( ShowBallon() );
		
	}
	
	private IEnumerator ShowBallon() {
		
		balloon.SetActive(true);
		
		if( Random.Range(0f,1f) < .5f ) {
			balloonSpriteRenderer.sprite = balloonSprites[0];
		} else {
			balloonSpriteRenderer.sprite = balloonSprites[1];
		}
		
        yield return new WaitForSeconds( 3f );
		
		balloon.SetActive(false);
		
	}
	
	
	public override void onDestroy() {
		
        StartCoroutine(AnimateDie());
		
	}
	
	private IEnumerator AnimateDie() {
		
	//	animator.SetTrigger("die");
        yield return new WaitForSeconds( 1f );
		
		Destroy( gameObject );
		
	}
	
	/*
	private void OnTriggerEnter2D( Collider2D collider ) {
		
		PlayerController target = collider.GetComponent<PlayerController>();
		
		if( target != null ) 
			target.takeDamage();
		
	}
	/**/
}
