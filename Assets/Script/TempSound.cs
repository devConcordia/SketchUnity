using UnityEngine;

public class TempSound : MonoBehaviour
{
    
	public static void Play( AudioClip clip, float volume = 1.0f, float pitch = 1.0f ) {
		
		GameObject target = new GameObject("TempSound");
		AudioSource source = target.AddComponent<AudioSource>();
		
		source.clip = clip;
        source.volume = volume;
        source.pitch = pitch;
		source.Play();
		
		Destroy(target, clip.length / Mathf.Abs(pitch));
		
    }
	
}
