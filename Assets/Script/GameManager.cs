using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
	
	[SerializeField] public GameObject canvasHud;
	[SerializeField] private TMP_Text dialogText;
	
    private void Awake() {
        if( instance == null ) {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        } else {
            Destroy(this);
        }
		
    }
	
	public void setDialog( string message ) {
		
		dialogText.text = message;
		
		StopAllCoroutines();
        StartCoroutine(ClearDialogAfterTime());
		
	}
	
	private IEnumerator ClearDialogAfterTime() {
		
        yield return new WaitForSeconds(5f);
        dialogText.text = "";
    
	}
	
	
    public void GameOver() {
        
        Time.timeScale = .0001f;
		
    }

    public void Restart() {
		
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
		
    }
	
}
