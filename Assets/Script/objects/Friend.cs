using UnityEngine;
using UnityEngine.InputSystem;

/**
 *	
 */
public class Friend : MonoBehaviour, IInteractable {
	
	
	//[SerializeField] private HudController hud;
	private HudController hud;
	
	private InputAction action;
	
	
	/* 
	 *	precisamos identificar quando as mensagens terminam
	 *	para isso, vamos contar as mensagens
	 */
	private bool spoke = false;
	private int count = 0;
	
	void Start() {
		
		if( !hud )
			hud = GameObject.Find("HUD").GetComponent<HudController>();
		
	}
	
    virtual public void interact() {
		
		spoke = true;
		
		hud.writeDialog("Finalmente saiu de casa ... faz bastante tempo que não vejo você.", "Continuar (Space)");
		hud.writeDialog("Alguns amigos meus estão num barzinho aqui perto.", "Continuar (Space)");
		hud.writeDialog("O pessoal é legal. Vamos lá tomar alguma coisa", "Fechar (Space)");
		
		///
		GameData.targetMap = GameData.PUB;
		
		
	}
	
	
	
	
	
	private void OnKeyPressed(InputAction.CallbackContext context) {
        
		if( spoke && context.control.displayName == "Space" ) {
			if( count++ > 1 ) {
			//	Destroy( gameObject );
				
				PlayerController player = GameObject.Find("Player").GetComponent<PlayerController>();
				player.changeScene("PubScene");
				
			}
		}
			
    }
	
	private void OnEnable() {
        
        action = new InputAction( type: InputActionType.Button );

        action.AddBinding("<Keyboard>/space");
		
        action.performed += OnKeyPressed;
        action.Enable();
    
	}

    private void OnDisable() {
		
        action.performed -= OnKeyPressed;
        action.Disable();
		
    }
	
	
}
