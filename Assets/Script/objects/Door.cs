using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public void interact() {
		
		Debug.Log("door");
		GameManager.instance.setDialog("Interação com a porta");
		
	}
}
