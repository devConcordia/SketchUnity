using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;

/**	
 *	
 */
public class HudController : MonoBehaviour {
    
	///
	[SerializeField] private TMP_Text helperText;
	[SerializeField] private TMP_Text healthText;
	[SerializeField] private TMP_Text dialogText;
	[SerializeField] private TMP_Text confirmText;
	[SerializeField] private TMP_Text closeText;
	[SerializeField] private TMP_Text countdownText;
	
	///
	[SerializeField] private SpriteRenderer maskLayer;
    
	private InputAction action;
	private Queue<string[]> messages = new Queue<string[]>(); 
	
	/// lockDialog
	/// para evitar misturar dialagos e repetir mesmos eventos
	/// sempre muda para false quando termina a exibição de uma fila de mensagens
	private bool dialogLocked = false;
	
	private bool writing = false;
	private string writingText = "";
	private Coroutine writingRoutine;
	
	
	public void FixedUpdate() {
		
		if( maskLayer != null && Camera.main != null ) {
			
            Vector3 camera = Camera.main.transform.position;

            maskLayer.transform.position = new Vector3(camera.x, camera.y, maskLayer.transform.position.z);
        
		}
		
	}
	
	
	public void setHealth( int value ) {
		
		healthText.text = "Health: "+ value +"%";
		
	}
	
	public void setHelper( string text ) {
		
		helperText.text = text;
		
	}
	
	public void setCountdown( int value ) {
		
		if( !countdownText.gameObject.activeInHierarchy )
			countdownText.transform.parent.gameObject.SetActive( true );
		
		countdownText.text = value +" seg";
		
	}
	
	/** 
	 *	
	 *	não add novos textos a messages
	 *	
	 */
	public void lockDialog() {
		
		dialogLocked = true;
		
	}
	
	public void writeDialog( string message, string closeString = "", string confirmString = "" ) {
		
		/// adiciona a mensagem a fila, se estiver escrevendo na tela
		if( writing ) {
			
			if( !dialogLocked )
				messages.Enqueue(new string[] { message, closeString, confirmString });
			
		} else {
		
			dialogText.transform.parent.gameObject.SetActive(true);
			dialogText.text = "";
			
			writingText = message;
			/// mecanismo para parar a mensagem quando apertar space, e escrever ela toda
			writingRoutine = StartCoroutine( writeDialogText( message, closeString, confirmString ) );
			
		}
		
	}
	
    private IEnumerator writeDialogText( string message, string closeString, string confirmString ) {
		
		closeText.text = closeString;
		confirmText.text = confirmString;
		
		writing = true;
		
        foreach( char m in message.ToCharArray() ) {
            dialogText.text += m;
            yield return new WaitForSeconds(0.01f);
        }
		
		writing = false;
		
    }
	
	
    private void OnKeyPressed(InputAction.CallbackContext context) {
        
		if( context.control.displayName == "Space" ) {
			
			/// verifica se ainda esta sendo escrito na tela
			/// caso sim, para a coroutine e exibe o texto inteiro
			if( writing == true ) {
				
				writing = false;
				
				/// para exibição atual
				StopCoroutine( writingRoutine );
				
				/// escreve mensagem inteira
				dialogText.text = writingText;
				
			} else {
				if( dialogText.text != "" ) {
					
					/// apaga ultimo dialago
					dialogText.text = "";
					
					/// verifica se há mensagem na fila para ser exibidas
					if( messages.Count > 0 ) {
						
						string[] texts = messages.Dequeue();
						writeDialog( texts[0], texts[1], texts[2] );
						
					} else {
						
						/// encerra dialago
						dialogLocked = false;
						dialogText.transform.parent.gameObject.SetActive(false);
					
					}
				}
			}
			
		}
			
    }
	
	private void OnEnable() {
        
        action = new InputAction( type: InputActionType.Button );

        ///
        action.AddBinding("<Keyboard>/space");
        //action.AddBinding("<Keyboard>/e");
		
        action.performed += OnKeyPressed;
        action.Enable();
    
	}

    private void OnDisable() {
		
        action.performed -= OnKeyPressed;
        action.Disable();
		
    }
	
	
	
	
	
	public void fadeIn() {
		
		maskLayer.color = new Color(0f,0f,0f,1f);
		maskLayer.gameObject.SetActive( true );
		StartCoroutine( fade( 1f, 0f, true ) );
		
	}
	
	public void fadeOut() {
		
		maskLayer.color = new Color(0f,0f,0f,0f);
		maskLayer.gameObject.SetActive( true );
		StartCoroutine( fade( 0f, 1f ) );
		
	}
	
	private IEnumerator fade( float a, float b, bool disable = false ) {
		
		float step = (b - a) / 10f;
		
		for( int i = 0; i < 10; i++ ) {
			
			Color color = maskLayer.color;
			color.a += step;
			maskLayer.color = color;
			
            yield return new WaitForSeconds(0.1f);
			
		}
		
		if( disable )
			maskLayer.gameObject.SetActive( false );
		
	}
	
	
}
