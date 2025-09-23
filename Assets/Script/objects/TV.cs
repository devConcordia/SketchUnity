using UnityEngine;
using UnityEngine.SceneManagement;

public class TV : MonoBehaviour, IInteractable {
	
    virtual public void interact() {
		
		SceneManager.LoadScene("TVScene");
		
	}
}
