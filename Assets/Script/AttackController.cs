using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    
	///
	[SerializeField] public float timeToDestroy = 5f;
	[SerializeField] public int damage = 1;
	
    void Start() {
		
        StartCoroutine(KillAfterTime());
		
    }
	
    IEnumerator KillAfterTime() {
		
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(gameObject);
		
    }
	
	private void OnTriggerEnter2D( Collider2D collision ) {
		
        EnemyMonoBehaviour target = collision.GetComponent<EnemyMonoBehaviour>();
		
        if( target != null )
            target.takeDamage( damage );
		
		Destroy(gameObject);
		
	}
	
}
