using UnityEngine;
using UnityEngine.SceneManagement;

public class TVManager : MonoBehaviour
{
    
    void Update() {
		
		if( Input.GetKeyDown(KeyCode.E) ) 
			SceneManager.LoadScene("HouseScene");
		
    }
	
}
