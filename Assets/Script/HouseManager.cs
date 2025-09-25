using UnityEngine;

public class HouseManager : MonoBehaviour {
    
	[SerializeField] private HudController hud;
	[SerializeField] private GameObject dirtObjects;
	
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
			case 3: dayThree(); break;
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
		
	}
	
	void dayThree() {
		
	}
	
}
