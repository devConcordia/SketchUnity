
public static class GameData {
	
	///
	public static int health = 100;
	public static float saturation = -25;
	
	/// referencia dos alvos para exibir no mapa
	public const int FRIEND = 1;
	public const int PUB = 2;
	public const int WORK = 3;
	
	/// alvo atual
	public static int targetMap = 0;
	
	///
	public static bool tutorial = false;
	public static bool tutorialCombate = false;
	
	public static int day = 2;
	
	public static int killEnemiesCount = 0;
	
	public static bool alarm = false;
	public static bool phone = false;
	
	public static bool bossPhone = false;
	public static bool wakeup = false;
	public static bool tvWatched = false;
	public static bool houseCleaned = false;
	public static string quest = "Limpe a casa";
	
	
	public static void nextDay() {
		
		///
		day++;
		
		double percent = (day > 2)? .50 : .75;
		
		/// health volta sempre menor
		health = (int) (100f * percent);
		
		wakeup = false;
		alarm = false;
		phone = false;
		houseCleaned = false;
		tvWatched = false;
		targetMap = 0;
		quest = "Limpe a casa";
		
		
		if( day > 2 ) {
			
			saturation = -90f;
			
		} else {
			
			saturation = -60f;
			
		}
		
	}
	
	public static void reset() {
		
		health = 100;
		targetMap = 0;
		
		tutorial = false;
		tutorialCombate = false;
		
		day = 1;
		killEnemiesCount = 1;
		
		tvWatched = false;
		houseCleaned = false;
		bossPhone = false;
		
	}
	
}
