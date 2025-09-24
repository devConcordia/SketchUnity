using UnityEngine;

public class Phone : MonoBehaviour, IInteractable {
	
	[SerializeField] private HudController hud;
	
	private bool answed = false;
	
    virtual public void interact() {
		
		///
		switch( GameData.day ) {
			case 1: dayOne(); break;
			case 2: dayTwo(); break;
			case 3: dayThree(); break;
		}
		
	}
	
	void dayOne() {
		
		if( !answed ) {
			
			answed = true;
			
			hud.writeDialog("Oi amigo, faz tempo que não nos vemos ...");
			hud.writeDialog("Eu estou aqui no parque próximo a sua casa, você não quer dar um pulinho aqui pra conversarmos?");
			hud.writeDialog("Faz tempo que você não sai de casa. Te espero lá.");
			
			GameData.targetMap = GameData.FRIEND;
			
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
			
		}
		
	}
	
	void dayThree() {
		
	}
	
	
}
