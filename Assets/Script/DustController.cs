using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustController : EnemyMonoBehaviour
{
   
	private Animator animator;
	
    void Start() {
		
        animator = GetComponent<Animator>();
		
    }
	
	public override void onDestroy() {
		
        StartCoroutine(AnimateDie());
		
	}
	
	private IEnumerator AnimateDie() {
		
		animator.SetTrigger("die");
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);
		
		Destroy( gameObject );
		
	}
	
}
