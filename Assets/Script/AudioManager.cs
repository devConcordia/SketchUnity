using UnityEngine;

public class AudioManager : MonoBehaviour
{
	
    public static AudioManager instance;
	
	public static AudioManager GetContext() {
        if( instance == null ) {
			
            GameObject prefab = Resources.Load<GameObject>("AudioManagerCore");
			
            GameObject go = Instantiate( prefab );
			
			return go.GetComponent<AudioManager>();
			
        } else {
			
			return instance;
			
		}
    }
	
	
	
	[SerializeField] public AudioClip menuAudioClip;
	[SerializeField] public AudioClip combatAudioClip;
	[SerializeField] public AudioClip loopAudioClip;
	[SerializeField] public AudioClip rainAudioClip;

	private AudioSource soundtrackSource;
	
    private void Awake() {
		
        if( instance == null ) {
			
			soundtrackSource = GetComponent<AudioSource>();
		
            instance = this;
            DontDestroyOnLoad( gameObject );
        
		} else {
            
			Destroy( gameObject );
        
		}
		
    }
	
	
    public void playMenu() {
		
        if( soundtrackSource.clip == menuAudioClip ) return;
        
        soundtrackSource.clip = menuAudioClip;
        soundtrackSource.loop = true;
        soundtrackSource.Play();
		
    }
	
    public void playCombat() {
		
        if( soundtrackSource.clip == combatAudioClip ) return;
        
        soundtrackSource.clip = combatAudioClip;
        soundtrackSource.loop = true;
        soundtrackSource.Play();
		
    }
	
    public void playLoop() {
		
        if( soundtrackSource.clip == loopAudioClip ) return;
        
        soundtrackSource.clip = loopAudioClip;
        soundtrackSource.loop = true;
        soundtrackSource.Play();
		
    }
	
    public void playRain() {
		
        if( soundtrackSource.clip == loopAudioClip ) return;
        
        soundtrackSource.clip = rainAudioClip;
        soundtrackSource.loop = true;
        soundtrackSource.Play();
		
    }
	
    public void stopMusic() {
		
        soundtrackSource.Stop();
		
    }
	
}
