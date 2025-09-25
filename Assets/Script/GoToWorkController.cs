using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GoToWorkController : MonoBehaviour
{
	
	private PlayerController player;
	private HudController hud;
	
	public static GoToWorkController instance;
	
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        
		player = GameObject.Find("Player").GetComponent<PlayerController>();
		hud = GameObject.Find("HUD").GetComponent<HudController>();
		
    }
	
	/// torna o objeto indestrutivel quando mudar de cenas
	public void startCountdown() {
		
		DontDestroyOnLoad( gameObject );
		
		StartCoroutine( Countdown() );
		
	}
	
	private IEnumerator Countdown() {
		
		for( int i = 0; i < 15; i++ )
			yield return new WaitForSeconds( 1f );
		
		///
		player.endDay();
		
	}
	
}
