using UnityEngine;
using UnityEngine.SceneManagement;

public class Clean : MonoBehaviour, IInteractable
{
    
    virtual public void interact() {
		
		//GameManager.instance.setDialog("Limpar?");
		SceneManager.LoadScene("HouseCombatScene");
		
	}
	
}
