using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour 
{
	
	[SerializeField] private GameObject beholder;
	
	private Animator animator;
	
    void Start()
    {
        
        animator = beholder.GetComponent<Animator>();
		
		StartCoroutine( ShowBeholder( Random.Range(4f,10f) ) );
		
    }
	
	
	private IEnumerator ShowBeholder( float delay ) {
		
        yield return new WaitForSeconds( delay );
		
		beholder.SetActive(true);
		animator.SetTrigger("start");
		
        yield return new WaitForSeconds( 1.4f );
		
		beholder.SetActive(false);
		
		/// proximo
		StartCoroutine( ShowBeholder( Random.Range(8f,16f) ) );
		
	}

}
