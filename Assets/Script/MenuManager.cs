using UnityEngine;
using UnityEngine.SceneManagement;

/* 
 *	
 */
public class MenuManager : MonoBehaviour {
	
	void Start() {
		
		AudioManager audioCtx = AudioManager.GetContext();
		audioCtx.playMenu();
		
	}
	
	public void startGame() {
		
		GameData.reset();
		SceneManager.LoadScene("HouseScene");
		
	}
	
	public void creditsScene() {
		
		SceneManager.LoadScene("CreditsScene");
		
	}
	
}
