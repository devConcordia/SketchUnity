
public static class GameData {
	
	///
	public static int health = 100;
	
	/// referencia dos alvos para exibir no mapa
	public const int FRIEND = 1;
	public const int PUB = 2;
	public const int WORK = 3;
	
	/// alvo atual
	public static int targetMap = 0;
	
	///
	public static bool tutorial = false;
	public static bool tutorialCombate = false;
	
	public static int day = 1;
	
	public static bool tvWatched = false;
	public static bool houseCleaned = false;
	
	
	public static void nextDay() {
		
		///
		day++;
		
		/// health volta sempre menor
		health = (int) (100f * day/10f);
		
	}
	
	public static void reset() {
		
		health = 100;
		targetMap = 0;
		
		tutorial = false;
		tutorialCombate = false;
		
		day = 1;
		
		tvWatched = false;
		houseCleaned = false;
		
	}
	
}
