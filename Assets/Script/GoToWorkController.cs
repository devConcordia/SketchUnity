using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GoToWorkController : MonoBehaviour
{
	
	//private PlayerController player;
	private HudController hud;
	
	public static GoToWorkController instance;
	
	public static void StartCountdown() {
		
		GameObject prefab = Resources.Load<GameObject>("GoToWork");
		
		Instantiate( prefab, new Vector3(0,0,0), Quaternion.identity);
		
	}
	
	public static void StopCountdown() {
		
		if( instance != null ) {
			Destroy( instance.gameObject );
			instance = null;
		}
		
	}
	
	private void Awake() {
		
        if( instance == null ) {
			
            instance = this;
            DontDestroyOnLoad( gameObject );
        
		} else {
            
			Destroy( gameObject );
        
		}
		
    }
	
    void Start() {
        
	//	player = GameObject.Find("Player").GetComponent<PlayerController>();
		hud = GameObject.Find("HUD").GetComponent<HudController>();
		
		StartCoroutine( Countdown() );
		
    }
	
	private IEnumerator Countdown() {
		
		for( int i = 60; i > 0; i-- ) {
			/// perde a referencia quando mudar de cena
			if( hud == null ) {
				hud = GameObject.Find("HUD").GetComponent<HudController>();
			//	player = GameObject.Find("Player").GetComponent<PlayerController>();
			}
			hud.setCountdown( i );
			yield return new WaitForSeconds( 1f );
		}
		
		/*
		///
		while( GameData.health > 0 ) {
			/// na cena da tv, perde a referencia do player
			/// então encerramos a animação do vida
			if( player ) {
				GameData.nextDay();
				break;
			}
			player.takeDamage( 1 );
			yield return new WaitForSeconds( .1f );
		}*/
		
		
		GameData.nextDay();
		///
		Destroy( gameObject );
		
	}
	
}
