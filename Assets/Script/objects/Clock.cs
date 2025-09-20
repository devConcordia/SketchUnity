using UnityEngine;

public class Clock : MonoBehaviour, IInteractable
{
	public void interact() {
		
		Debug.Log("clock");
		GameManager.instance.setDialog("Interação com o relogio");
		
	}
}
