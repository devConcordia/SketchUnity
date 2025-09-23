using UnityEngine;
using UnityEngine.SceneManagement;

public class Clean : MonoBehaviour, IInteractable
{
    
    virtual public void interact() {
		
		SceneManager.LoadScene("HouseCombatScene");
		
	}
	
}
