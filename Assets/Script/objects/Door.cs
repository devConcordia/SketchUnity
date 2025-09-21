using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour, IInteractable
{
    public void interact() {
		
		SceneManager.LoadScene("TownScene");
		
	}
}
