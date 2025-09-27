using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TownManager : MonoBehaviour
{
    
	[SerializeField] private HudController hud;
	[SerializeField] private GameObject bordersDayTwo;
	[SerializeField] private GameObject bordersDayThree;
	
	[SerializeField] private GameObject player;
	
	[SerializeField] private GameObject[] EnemyPrefab;
	
	[SerializeField] private float initialInterval = 5f;
	
	void Start() {
		
		hud.fadeIn();
		AudioManager audioCtx = AudioManager.GetContext();
		audioCtx.playLoop();
		
		///
		switch( GameData.day ) {
			case 1: dayOne(); break;
			case 2: dayTwo(); break;
			
			default: dayThreeOrMore(); break;
		}
		
    }
	
	void dayOne() {
		
	}
	
	void dayTwo() {
		
		bordersDayTwo.SetActive(true);
		player.GetComponent<PlayerController>().attack = "vassourada";
		StartCoroutine(spawner());
		
	}
	
	void dayThreeOrMore() {
		
		bordersDayThree.SetActive(true);
		
	}
	
	private IEnumerator spawner() {
		
		for( int i = 0; i < 100; i++ ) {
			
			int randomEnemy = Random.Range(0, EnemyPrefab.Length);
			
			Vector3 p = player.transform.position + Random.insideUnitSphere * 10f;
			
			GameObject enemy = Instantiate( EnemyPrefab[ randomEnemy ], p, Quaternion.identity);
			EnemyMonoBehaviour enemyCtrl = enemy.GetComponent<EnemyMonoBehaviour>();
			enemyCtrl.player = player;
			
			yield return new WaitForSeconds( Random.Range(3f, initialInterval) );
			
		}
		
	}
}
