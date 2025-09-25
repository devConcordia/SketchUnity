using UnityEngine;

public class TownManager : MonoBehaviour
{
    
	[SerializeField] private HudController hud;
	[SerializeField] private GameObject bordersDayTwo;
	
	void Start() {
		
		hud.fadeIn();
		AudioManager audioCtx = AudioManager.GetContext();
		audioCtx.playLoop();
		
		///
		switch( GameData.day ) {
			case 1: dayOne(); break;
			case 2: dayTwo(); break;
			
			default: dayThreeOrMore(); break;
		}
		
    }
	
	void dayOne() {
		
	}
	
	void dayTwo() {
		
	}
	
	void dayThreeOrMore() {
		
	}
	
}
