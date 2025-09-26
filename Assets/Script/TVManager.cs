using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class TVManager : MonoBehaviour
{
    
	[SerializeField] private HudController hud;
	
	private InputAction action;
	
    void Start() {
		
		GameData.tvWatched = true;
		
		///
		hud.writeDialog("[Precisone Space para sair]");
		
    }
	
    private void OnKeyPressed(InputAction.CallbackContext context) {
        
		if( context.control.displayName == "Space" ) {
			
			SceneManager.LoadScene("HouseScene");
			
		}
			
    }
	
	private void OnEnable() {
        
        action = new InputAction( type: InputActionType.Button );

        //
        action.AddBinding("<Keyboard>/space");
        //action.AddBinding("<Keyboard>/e");
		
        action.performed += OnKeyPressed;
        action.Enable();
    
	}

    private void OnDisable() {
		
        action.performed -= OnKeyPressed;
        action.Disable();
		
    }
	
	
}
