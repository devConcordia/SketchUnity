using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseCombatManager : MonoBehaviour
{
	
	[SerializeField] private GameObject player;
	[SerializeField] private HudController hud;
	
	[SerializeField] private GameObject EnemyPrefab;
    private List<GameObject> enemies = new List<GameObject>();
	
	[SerializeField] private int quantity = 5;
	
	
	private Vector3[] enemyPositions = {
		new Vector3(-4f,-0.5f,0f),
		new Vector3(-1f, 4f,0f),
		new Vector3(9f,4f,0f),
		new Vector3(12f,0f,0f)
	}; 
	
	void Start() {
		
		AudioManager audioCtx = AudioManager.GetContext();
		audioCtx.playCombat();
		
		hud.fadeIn();
		
		if( GameData.tutorialCombate == false ) {
			hud.writeDialog("Use Space para atacar.");
			GameData.tutorialCombate = true;
		}
		
		StartCoroutine(spawner());
		
	}
	
	void FixedUpdate() {
		
		if( enemies.Count == quantity ) {
			
			bool endCombat = true;
			
			for( int i = 0; i < quantity; i++ ) {
				if( enemies[i] != null ) {
					endCombat = false;
					break;
				}
			}
			
			if( endCombat ) {
				
				GameData.houseCleaned = true;
			//	GameData.health = player.health;
				
				if( GameData.quest == "Limpe a casa" )
					GameData.quest = " ... ";
				//hud.setHelper( "Dia "+ GameData.day +" - "+ GameData.quest );
				
				hud.fadeOut();
				SceneManager.LoadScene("HouseScene");
			
			}
			
		}
        
	}
	
	private IEnumerator spawner() {
		
		for( int i = 0; i < quantity; i++ ) {
			
			int randomPositionIndex = Random.Range(0, enemyPositions.Length);
			
			GameObject enemy = Instantiate( EnemyPrefab, enemyPositions[ randomPositionIndex ], Quaternion.identity);
			DustController enemyCtrl = enemy.GetComponent<DustController>();
			enemyCtrl.player = player;
			
			enemies.Add( enemy );
			
			yield return new WaitForSeconds( Random.Range(2f, 7f) );
			
		}
		
	}
	
	
}
