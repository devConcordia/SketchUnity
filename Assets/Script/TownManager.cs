using UnityEngine;

public class TownManager : MonoBehaviour
{
    
	[SerializeField] private HudController hud;
	
	void Start() {
		
		AudioManager audioCtx = AudioManager.GetContext();
		audioCtx.playLoop();
		hud.fadeIn();
		
    }
	
	
	void dayOne() {
		
	}
	
	void dayTwo() {
		
	}
	
	void dayThree() {
		
	}
	
}
