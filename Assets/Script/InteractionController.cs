using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractionController : MonoBehaviour {
    
	///
	[SerializeField] public float timeToDestroy = 5f;
	
    void Start() {
		
        StartCoroutine(KillAfterTime());
		
    }
	
    IEnumerator KillAfterTime() {
		
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(gameObject);
		
    }
	
	private void OnTriggerEnter2D( Collider2D collision ) {
		
        IInteractable interactable = collision.GetComponent<IInteractable>();

        if( interactable != null )
            interactable.interact();
		
		
		Destroy(gameObject);
		
	}
	
}
