using UnityEngine;

public class Friend : MonoBehaviour, IInteractable {
	
	[SerializeField] private HudController hud;
	
	void Start() {
		
		if( !hud )
			hud = GameObject.Find("HUD").GetComponent<HudController>();
		
	}
	
    virtual public void interact() {
		
		hud.writeDialog("Finalmente saiu de casa ... faz bastante tempo que não vejo você.");
		hud.writeDialog("Alguns amigos meus estão num barzinho aqui perto.");
		hud.writeDialog("O pessoal é legal. Vamos lá tomar alguma coisa");
		
		///
		GameData.targetMap = GameData.PUB;
		
	}
	
}
