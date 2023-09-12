public class fireballState
{
    public static bool FireEnable=true;
    public static float Fireballdamage=0;
    public static int Fireballpierce=0;
    public static int FireballFireNum=1;
    public static int FireballchainNum=0;
    public static float Fireballcastspeed=1f;
    public static void restart(){
        FireEnable=true;
        Fireballdamage=0;
        Fireballpierce=0;
        FireballFireNum=1;
        FireballchainNum=0;
        Fireballcastspeed=1f;
    }
}