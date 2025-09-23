using UnityEngine;

public class StartOrdemLayer : MonoBehaviour
{
    
	[SerializeField] private int zdefault = 0;
	
	void Start() {
		
		SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
		
		if( spriteRenderer )
			spriteRenderer.sortingOrder = zdefault + Mathf.RoundToInt( -transform.position.y * 10 );
		
    }

}
