using UnityEngine;

public class Phone : MonoBehaviour, IInteractable {
	
    virtual public void interact() {
		
		Debug.Log("telefone");
		GameManager.instance.setDialog("Interação com o Telefone");
		
	}
}
