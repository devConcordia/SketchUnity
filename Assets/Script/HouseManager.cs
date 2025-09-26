using UnityEngine;

public class HouseManager : MonoBehaviour {
    
	[SerializeField] private HudController hud;
	[SerializeField] private GameObject dirtObjects;
	[SerializeField] private GameObject dirtObjects2;
	
	void Start() {
		
		AudioManager audioCtx = AudioManager.GetContext();
		audioCtx.playLoop();
		
		hud.fadeIn();
		
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
	
	void dayOne() {
		
		if( GameData.tutorial == false ) {
				
			hud.writeDialog("Use WASD para se mover.");
			hud.writeDialog("Use E para interagir com os objetos.");
			
			GameData.tutorial = true;
			
		}
		
	}
	
	void dayTwo() {
		
		//hud.writeDialog("... Hoje é minha folga.");
		
		if( !GameData.houseCleaned ) {
			
			dirtObjects2.SetActive( true );
			
		}
		
		
		
	}
	
	void dayThreeOrMore() {
		
	}
	
}
