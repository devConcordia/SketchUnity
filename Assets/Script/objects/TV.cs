using UnityEngine;
using UnityEngine.SceneManagement;

public class TV : MonoBehaviour, IInteractable {
	
    virtual public void interact() {
		
		GameManager.instance.setDialog("Interação com o TV");
		SceneManager.LoadScene("TVScene");
		
	}
}
