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
		switch( GameData.day ) {
			case 1: dayOne(); break;
			case 2: dayTwo(); break;
			case 3: dayThree(); break;
		}
		
		hud.writeDialog("[Precisone Space para sair]");
		
    }
	
	
	void dayOne() {
		
	}
	
	void dayTwo() {
		
	}
	
	void dayThree() {
		
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
