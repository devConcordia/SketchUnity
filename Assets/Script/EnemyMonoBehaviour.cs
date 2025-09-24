using UnityEngine;

public class EnemyMonoBehaviour : MonoBehaviour
{
    
	[SerializeField] private int HP = 3;
	
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
	
}
