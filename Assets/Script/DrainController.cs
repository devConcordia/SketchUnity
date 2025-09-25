using UnityEngine;

public class DrainController : MonoBehaviour
{
	
	private int counterToDamage = 0;
	
	private void OnTriggerStay2D( Collider2D collider ) {
		
		PlayerController target = collider.GetComponent<PlayerController>();
		
		if( target != null && counterToDamage++ > 10 ) { 
			counterToDamage = 0;
			target.takeDamage();
		}
		
	}
	
}
