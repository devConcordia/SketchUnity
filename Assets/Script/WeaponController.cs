using UnityEngine;

public class WeaponController : MonoBehaviour
{
	
	private Animator animator;
	
    void Start() {
		
        animator = GetComponent<Animator>();
		
		/// 
		animator.SetFloat("x", 0f);
        animator.SetFloat("y", 1f);
		
    }

	public void broomAttack( float x, float y ) {
		
		transform.localPosition = new Vector3( x * .2f, 0, 0 );
		
		animator.SetFloat("x", x);
		animator.SetFloat("y", y);
		animator.SetTrigger("attack");
		
	}
	
}
