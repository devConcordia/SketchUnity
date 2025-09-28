using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseManager : MonoBehaviour {
    
	[SerializeField] private HudController hud;
	[SerializeField] private GameObject dirtObjects;
	[SerializeField] private GameObject dirtObjects2;
	
	[SerializeField] private AudioClip alarmAudioClip;
	[SerializeField] private AudioClip phoneAudioClip;
	
	[SerializeField] private GameObject player;
	[SerializeField] private GameObject sleepPlayer;
	
	void Start() {
		
		AudioManager audioCtx = AudioManager.GetContext();
		audioCtx.playLoop();
		
		hud.fadeIn();
		
		if( !GameData.alarm ) {
			GameData.alarm = true;
			TempSound.Play( alarmAudioClip );
		}
		
		if( !GameData.wakeup ) {
			StartCoroutine( wakeup() );
		}
		
		if( GameData.houseCleaned ) {
			
			dirtObjects.SetActive( false );
			
		}
		
		///
		switch( GameData.day ) {
			case 1: dayOne(); break;
			case 2: dayTwo(); break;
			
			default: dayThreeOrMore(); break;
		}
		
	}
	
	private IEnumerator wakeup() {
		
		float speed = .6f;
		float delay = 1.5f;
		
		if( GameData.day > 2 ) {
			
			speed = .2f;
			
		} else if( GameData.day > 1 ) {
			
			speed = .4f;
			
		}
		
		sleepPlayer.GetComponent<Animator>().speed = speed;
		
		player.SetActive( false );
		sleepPlayer.SetActive( true );
		
		yield return new WaitForSeconds( delay / speed );
		
		sleepPlayer.SetActive( false );
		player.SetActive( true );
		
		GameData.wakeup = true;
		
	}
		
	void dayOne() {
		
		if( GameData.tutorial == false ) {
				
			hud.writeDialog("Use WASD para se mover.", "Fechar (Space)");
			hud.writeDialog("Use E para interagir com os objetos.", "Fechar (Space)");
			
			GameData.tutorial = true;
			
		}
		
		if( !GameData.phone )
			StartCoroutine(DelayPhone(15f));
		
	}
	
	void dayTwo() {
		
		if( !GameData.houseCleaned )
			dirtObjects2.SetActive( true );
		
		if( !GameData.phone )
			StartCoroutine(DelayPhone(15f));
		
	}
	
	void dayThreeOrMore() {
		
		GoToWorkController.StopCountdown();
		
		if( GameData.bossPhone )
			StartCoroutine(DelayPhone(15f));
		
		if( !GameData.houseCleaned )
			dirtObjects2.SetActive( true );
		
	}
	
	private IEnumerator DelayPhone( float delay ) {
		
		yield return new WaitForSeconds( delay );
		
		if( !GameData.phone ) {
			TempSound.Play( phoneAudioClip );
			/// espera e toca novamente
			StartCoroutine(DelayPhone(20f));
		}
		
	}
	
}
