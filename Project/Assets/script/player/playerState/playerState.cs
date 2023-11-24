public class playerState
{
    public static string playername;
    public static float playerHealth=100f;
    public static float playerCastspeed=1f;
    public static float playerMovespeed=5f;
    public static float playerDefence=1f;
    public static float exp=0f;
    public static int level=1;
    public static bool canplayermove=true;
    public static bool isrestart=false;
    public static bool canEsc=true;
    public static int coin=0;
    public static int killnumber=0;
    public static void restartplayer(){
        playerHealth=100f;
        playerCastspeed=1f;
        playerMovespeed=5f;
        playerDefence=1f;
        exp=0f;
        level=1;
        canplayermove=true;
        isrestart=true;
        canEsc=true;
        coin=0;
        killnumber=0;
    }
    public static void restartAll(){
        fireballState.restart();
        lightningblastState.restart();
        magicweaponState.restart();
        BloodExplodeState.restart();
        FlameJetState.restart();
        LightningStrikeState.restart();
        plagueslashState.restart();
        watersplashState.restart();
        restartplayer();
    }
}
