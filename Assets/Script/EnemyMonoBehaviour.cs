using UnityEngine;

public class EnemyMonoBehaviour : MonoBehaviour {
    
	public GameObject player;
	
	
	[SerializeField] private int HP = 3;
	private int counterToDamage = 0;
	
	
	public virtual void onTakeDamage() {
		/// TODO
	}
	
	public virtual void onDestroy() {
		/// TODO
	}
	
	public void takeDamage( int points = 1 ) {
		
		HP -= points;
		
		onTakeDamage();
		
		if( HP <= 0 ) 
			onDestroy();
		
	}
	
//	private void OnTriggerEnter2D( Collider2D collider ) {
	private void OnTriggerStay2D( Collider2D collider ) {
		
		PlayerController target = collider.GetComponent<PlayerController>();
		
		if( target != null && counterToDamage++ > 10 ) { 
			counterToDamage = 0;
			target.takeDamage();
		}
		
	}
	
}
