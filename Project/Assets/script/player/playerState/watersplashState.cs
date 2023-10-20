public class watersplashState
{
    public static bool WaterSplashEnable=false;
    public static bool WaterSplashcooldowning=false;
    public static float WaterSplashdamage=30;
    public static float WaterSplashDotdamage=10;
    public static float WaterSplashcastspeed=1f;
    public static void restart(){
        WaterSplashEnable=false;
        WaterSplashcooldowning=false;
        WaterSplashdamage=30;
        WaterSplashDotdamage=10;
        WaterSplashcastspeed=1f;
    }
}
