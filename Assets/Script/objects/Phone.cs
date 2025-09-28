using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Phone : MonoBehaviour, IInteractable {
	
	[SerializeField] private HudController hud;
	
	private bool answed = false;
	
	void Start() {
		
		if( !hud )
			hud = GameObject.Find("HUD").GetComponent<HudController>();
		
	}
	
    virtual public void interact() {
		
		HouseManager manager = GameObject.Find("SceneManager").GetComponent<HouseManager>();
		
		if( manager ) manager.stopPhoneAudio();
		
		/// não toca mais os audios do telefone durante esse dia
		GameData.phone = true;
		
		///
		switch( GameData.day ) {
			case 1: dayOne(); break;
			case 2: dayTwo(); break;
			case 3: dayThree(); break;
			default: dayFourOrMore(); break;
		}
		
	}
	
	void dayOne() {
		
		if( !answed ) {
			
			answed = true;
			
			hud.writeDialog("Oi amigo, faz tempo que não nos vemos ...", "Continuar (Space)");
			hud.writeDialog("Eu estou aqui no parque próximo a sua casa, você não quer dar um pulinho aqui pra conversarmos?", "Continuar (Space)");
			hud.writeDialog("Faz tempo que você não sai de casa. Te espero lá.", "Fechar (Space)");
			
			GameData.targetMap = GameData.FRIEND;
			GameData.quest = "Encontre seu amigo.";
			hud.setHelper( "Dia "+ GameData.day +" - "+ GameData.quest );
			
			/// forçar ver a televisão novamente, para ver a localização
			/// em caso de ter visto a tv antes do telefone
			GameData.tvWatched = false;
			
		}
		
	}
	
	void dayTwo() {
		
		if( !answed ) {
			
			answed = true;
			
			hud.writeDialog("Bom dia, Fulano não veio hoje.");
			hud.writeDialog("Não consegui ninguém para cobrir, você vem ajudar a empresa");
			
			GameData.targetMap = GameData.WORK;
			GameData.quest = "Vá ao trabalho";
			hud.setHelper( "Dia "+ GameData.day +" - "+ GameData.quest );
			
			///
			/// inicia a contagem regressiva
			///	o objeto criado não será destruido em mudanças de cenas
			///
			GoToWorkController.StartCountdown();
			
		}
		
	}
	
	void dayThree() {
		
		if( !answed && GameData.bossPhone ) {
			
			answed = true;
			GameData.bossPhone = false;
			
			hud.fadeOut();
			hud.writeDialog("Caramba, sempre que VOCÊ precisou de ajuda a empresa te ajudou, nunca atrasou salário, tem vale refeição, e quando VOCÊ precisou cuidar da sua mãe a gente até adiantou suas férias ...");
			hud.writeDialog("... e quando a empresa precisa VOCÊ NÃO PODE AJUDAR, e ainda fala que estava vindo. É como dizem existe colaborador e existe funcionário e VOCÊ não está colaborando com a empresa.");
			
			nextScene = "HouseScene";
			countSpaceClick = 0;
			waitClick = true;
			
		}
		
	}
	
	void dayFourOrMore() {
		
		hud.fadeOut();
		hud.writeDialog("Atendente: Ola, Centro de apoio psicológico, como posso ajudar?");
		hud.writeDialog("Personagem: Estou passando por uns problemas, gostaria de agendar uma consulta ...");
		
		nextScene = "CreditsScene";
		countSpaceClick = 0;
		waitClick = true;
		
	}
	
	
	
	private string nextScene = "HouseScene";
	private InputAction action;
	private bool waitClick = false;
	private int countSpaceClick = 0;
	
	
    private void OnKeyPressed(InputAction.CallbackContext context) {
        
		if( waitClick && context.control.displayName == "Space" ) {
			
			if( countSpaceClick++ > 1 ) {
				
				GameData.nextDay();
				SceneManager.LoadScene( nextScene );
				
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
}
