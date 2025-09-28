using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;


public class GoToWorkController : MonoBehaviour
{
	
	//private PlayerController player;
	private HudController hud;
	
	public static GoToWorkController instance;
	
	public static void StartCountdown() {
		
		GameObject prefab = Resources.Load<GameObject>("GoToWork");
		
		Instantiate( prefab, new Vector3(0,0,0), Quaternion.identity);
		
	}
	
	public static void StopCountdown() {
		
		if( instance != null ) {
			Destroy( instance.gameObject );
			instance = null;
		}
		
	}
	
	private void Awake() {
		
        if( instance == null ) {
			
            instance = this;
            DontDestroyOnLoad( gameObject );
        
		} else {
            
			Destroy( gameObject );
        
		}
		
    }
	
    void Start() {
        
	//	player = GameObject.Find("Player").GetComponent<PlayerController>();
		hud = GameObject.Find("HUD").GetComponent<HudController>();
		
		StartCoroutine( Countdown() );
		
    }
	
	private IEnumerator Countdown() {
		
		for( int i = 30; i > 0; i-- ) {
			/// perde a referencia quando mudar de cena
			if( hud == null )
				hud = GameObject.Find("HUD").GetComponent<HudController>();
			hud.setCountdown( i );
			yield return new WaitForSeconds( 1f );
		}
		
		GameData.bossPhone = true;
		
		GameData.nextDay();
		SceneManager.LoadScene( "HouseScene" );
		
		///
		Destroy( gameObject );
		
		
	//	waitClick = true;
	//	countSpaceClick = 0;
	//	
	//	hud.fadeOut();
	//	hud.writeDialog("Caramba, sempre que VOCÊ precisou de ajuda a empresa te ajudou, nunca atrasou salário, tem vale refeição, e quando VOCÊ precisou cuidar da sua mãe a gente até adiantou suas férias ...");
	//	hud.writeDialog("... e quando a empresa precisa VOCÊ NÃO PODE AJUDAR, e ainda fala que estava vindo. É como dizem existe colaborador e existe funcionário e VOCÊ não está colaborando com a empresa.");
		
	}
	
	
/*	private InputAction action;
	private bool waitClick = false;
	private int countSpaceClick = 0;
	
	
    private void OnKeyPressed(InputAction.CallbackContext context) {
        
		if( waitClick && context.control.displayName == "Space" ) {
			
			if( countSpaceClick++ > 0 ) {
				
				GameData.nextDay();
				SceneManager.LoadScene( "HouseScene" );
				
				///
				Destroy( gameObject );
				
			}
			
		}
		
	}
	
	
	private void OnEnable() {
        
        action = new InputAction( type: InputActionType.Button );

        ///
        action.AddBinding("<Keyboard>/space");
		
        action.performed += OnKeyPressed;
        action.Enable();
    
	}

    private void OnDisable() {
		
        action.performed -= OnKeyPressed;
        action.Disable();
		
    }
/**/	
	
}
