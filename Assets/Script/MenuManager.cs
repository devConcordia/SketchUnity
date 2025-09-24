using UnityEngine;
using UnityEngine.SceneManagement;

/* 
 *	
 */
public class MenuManager : MonoBehaviour {
	
	public void startGame() {
		
		GameData.reset();
		SceneManager.LoadScene("HouseScene");
		
	}
	
	public void creditsScene() {
		
		SceneManager.LoadScene("CreditsScene");
		
	}
	
}
