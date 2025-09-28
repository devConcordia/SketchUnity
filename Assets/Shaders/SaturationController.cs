using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class SaturationController : MonoBehaviour
{
	
	public Volume volume; // Arraste seu Volume aqui no inspector
    private ColorAdjustments colorAdjustments;
	
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        
        // Tenta pegar o ColorAdjustments do VolumeProfile
        if( !volume.profile.TryGet<ColorAdjustments>(out colorAdjustments) ) {
            Debug.LogError("ColorAdjustments não encontrado no VolumeProfile!");
        }
		
		UpdateSaturation();
		
    }
	
	public void UpdateSaturation() {
		
		///
		colorAdjustments.saturation.value = GameData.saturation;
		
	}
	
}
