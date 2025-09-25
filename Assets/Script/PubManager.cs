using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PubManager : MonoBehaviour
{
    
	[SerializeField] private GameObject player;
	[SerializeField] private HudController hud;
	
	[SerializeField] private GameObject EnemyPrefab;
   //private List<GameObject> enemies = new List<GameObject>();
	
	[SerializeField] private float initialInterval = 7f;
	
	
	private Vector3[] enemyPositions = {
		new Vector3(-8f,2f,0f),
		new Vector3(-1.5f, 3.5f,0f),
		new Vector3(12f,3f,0f),
		new Vector3(14f,-1f,0f),
		new Vector3(-4f,-4f,0f)
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
	
/*	void FixedUpdate() {
		
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
				
				hud.fadeOut();
				SceneManager.LoadScene("HouseScene");
			
			}
			
		}
        
	}
*/
	
	private IEnumerator spawner() {
		
	//	for( int i = 0; i < quantity; i++ ) {
		
		while( true ) {
			
			int randomPositionIndex = Random.Range(0, enemyPositions.Length);
			
			GameObject enemy = Instantiate( EnemyPrefab, enemyPositions[ randomPositionIndex ], Quaternion.identity);
			BeerController enemyCtrl = enemy.GetComponent<BeerController>();
			enemyCtrl.player = player;
			
		//	enemies.Add( enemy );
			
			yield return new WaitForSeconds( Random.Range(1f, initialInterval) );
			
		}
			
	//	}
		
	}
	
	
}
