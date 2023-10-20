public class LightningStrikeState
{
    public static bool LightningStrikeEnable=false;
    public static bool LightningStrikecooldowning=false;
    public static float LightningStrikedamage=15;
    public static float LightningStrikecastspeed=0.5f;
    public static void restart(){
        LightningStrikeEnable=false;
        LightningStrikecooldowning=false;
        LightningStrikedamage=15;
        LightningStrikecastspeed=0.5f;
    }
}
