public class playerState
{
    public static float playerHealth=100f;
    public static float playerCastspeed=1f;
    public static float playerMovespeed=5f;
    public static float playerDefence=1f;
    public static float exp=0f;
    public static int level=1;
    public static bool canplayermove=true;
    public static bool isrestart=false;
    public static bool canEsc=true;
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
    }
    public static void restartAll(){
        fireballState.Fireballdamage=0;
        fireballState.Fireballpirece=0;
        fireballState.FireballFireNum=1;
        fireballState.FireballchainNum=0;
        fireballState.Fireballcastspeed=1f;
        lightningblastState.LightningBlastdamage=0;
        lightningblastState.LightningBlastchainNum=2;
        lightningblastState.LightningBlastcastspeed=0.7f;
        lightningblastState.LightningBlastRange=6f;
        lightningblastState.LightningBlastIncreaseRange = 1f;
        lightningblastState.LightningBlastAttaackRange = 1f;
        restartplayer();
    }
}
