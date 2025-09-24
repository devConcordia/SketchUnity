using UnityEngine;

public class PingMarker : MonoBehaviour
{
    public float cycleDuration = 1.5f;
    private SpriteRenderer sprite;
    private Vector3 initialScale;
	
	
    void Start() {
		
		switch( GameData.targetMap ) {
			
			/// praça
			case GameData.FRIEND:
				transform.position = new Vector3( .5f, 0f, 0f );
				break;
			
			/// bar
			case GameData.PUB:
				transform.position = new Vector3( -3f, 0.5f, 0f );
				break;
			
			/// trabalho
			case GameData.WORK:
				transform.position = new Vector3( -3f, 2.3f, 0f );
				break;
			
			/// encerra, se não tiver alvo
			default:
				Destroy( gameObject );
				return;
			
		}
		
		///
        sprite = GetComponent<SpriteRenderer>();
        initialScale = transform.localScale;
		
    }

    void Update() {
		
        float t = (Time.time % cycleDuration) / cycleDuration;

        transform.localScale = initialScale * (1f + Mathf.Sin(t * Mathf.PI) * 0.3f);

        Color c = sprite.color;
        c.a = Mathf.Sin( t * Mathf.PI );
        sprite.color = c;
		
    }
	
	
}
