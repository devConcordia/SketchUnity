using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Clean : MonoBehaviour, IInteractable
{
    
	[SerializeField] private HudController hud;
	
	private InputAction action;
	private bool waitingAnswer = false;
	
    virtual public void interact() {
		
		waitingAnswer = true;
		hud.writeDialog("A casa está realmente suja ... \nAperte 'E' para limpar a casa. \nOu 'Space' para ignorar.");
		
	}
	
	private void OnKeyPressed(InputAction.CallbackContext context) {
        
		if( context.control.displayName == "Space" ) {
			
			waitingAnswer = false;
			
		} else if( waitingAnswer && context.control.displayName == "E" ) {
			
			SceneManager.LoadScene("HouseCombatScene");
			
		}
			
    }
	
	private void OnEnable() {
        
        action = new InputAction( type: InputActionType.Button );

        // 
        action.AddBinding("<Keyboard>/space");
        action.AddBinding("<Keyboard>/e");
		
        action.performed += OnKeyPressed;
        action.Enable();
    
	}

    private void OnDisable() {
		
        action.performed -= OnKeyPressed;
        action.Disable();
		
    }
	
	
}
