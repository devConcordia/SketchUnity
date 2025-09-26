using UnityEngine;

public class DrainController : MonoBehaviour
{
	
	[SerializeField] private int aggressiveness = 10;
	private int counterToDamage = 0;
	
	private void OnTriggerStay2D( Collider2D collider ) {
		
		PlayerController target = collider.GetComponent<PlayerController>();
		
		if( target != null && counterToDamage++ > aggressiveness ) { 
			counterToDamage = 0;
			target.takeDamage();
		}
		
	}
	
}
