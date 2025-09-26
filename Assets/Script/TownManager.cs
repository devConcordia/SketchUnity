using UnityEngine;

public class TownManager : MonoBehaviour
{
    
	[SerializeField] private HudController hud;
	[SerializeField] private GameObject bordersDayTwo;
	[SerializeField] private GameObject bordersDayThree;
	
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
		
		bordersDayTwo.SetActive(true);
		
	}
	
	void dayThreeOrMore() {
		
		bordersDayThree.SetActive(true);
		
	}
	
}
