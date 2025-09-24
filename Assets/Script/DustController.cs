using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustController : EnemyMonoBehaviour
{
   
	
	//[SerializeField] 
	public GameObject player;
	
	private Animator animator;
	private Rigidbody2D body;
	
	private float knockTimer = 0f;
	
    void Start() {
		
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
		
		/// se a referencia ao jogador não for dada, destrua o objeto
		if( player == null )
			Destroy( gameObject );
		
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
		
	}
	
	public override void onDestroy() {
		
        StartCoroutine(AnimateDie());
		
	}
	
	private IEnumerator AnimateDie() {
		
		animator.SetTrigger("die");
        yield return new WaitForSeconds( 1.1f );
		
		Destroy( gameObject );
		
	}
	
	
	private void OnTriggerEnter2D( Collider2D collider ) {
		
		PlayerController target = collider.GetComponent<PlayerController>();
		
		if( target != null ) 
			target.takeDamage();
		
	}
	
}
