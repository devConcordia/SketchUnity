using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseManager : MonoBehaviour {
    
	[SerializeField] private HudController hud;
	[SerializeField] private GameObject dirtObjects;
	[SerializeField] private GameObject dirtObjects2;
	
	[SerializeField] private AudioClip alarmAudioClip;
	[SerializeField] private AudioClip phoneAudioClip;
	
	void Start() {
		
		AudioManager audioCtx = AudioManager.GetContext();
		audioCtx.playLoop();
		
		hud.fadeIn();
		
		if( !GameData.alarm ) {
			GameData.alarm = true;
			TempSound.Play( alarmAudioClip );
		}
		
		if( GameData.houseCleaned )
			dirtObjects.SetActive( false );
		
		///
		switch( GameData.day ) {
			case 1: dayOne(); break;
			case 2: dayTwo(); break;
			
			default: dayThreeOrMore(); break;
		}
		
	}
	
	void dayOne() {
		
		if( GameData.tutorial == false ) {
				
			hud.writeDialog("Use WASD para se mover.");
			hud.writeDialog("Use E para interagir com os objetos.");
			
			GameData.tutorial = true;
			
		}
		
		if( !GameData.phone )
			StartCoroutine(DelayPhone(15f));
		
	}
	
	void dayTwo() {
		
		//hud.writeDialog("... Hoje é minha folga.");
		
		if( !GameData.houseCleaned )
			dirtObjects2.SetActive( true );
		
		if( !GameData.phone )
			StartCoroutine(DelayPhone(15f));
		
	}
	
	void dayThreeOrMore() {
		
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
