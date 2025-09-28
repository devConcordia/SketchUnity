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
	
	private AudioManager audioCtx;
	
	void Start() {
		
		hud.fadeIn();
		audioCtx = AudioManager.GetContext();
		
		///
		switch( GameData.day ) {
			case 1: dayOne(); break;
			case 2: dayTwo(); break;
			
			default: dayThreeOrMore(); break;
		}
		
    }
	
	void dayOne() {
		
		audioCtx.playLoop();
		
	}
	
	void dayTwo() {
		
		hud.showRain();
		
		bordersDayTwo.SetActive(true);
		player.GetComponent<PlayerController>().attack = "guarda_chuva";
		
		StartCoroutine(spawner());
		
	}
	
	void dayThreeOrMore() {
		
		audioCtx.playRain();
		
		player.GetComponent<PlayerController>().attack = "guarda_chuva";
		bordersDayThree.SetActive(true);
		
		StartCoroutine(spawner());
		
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
