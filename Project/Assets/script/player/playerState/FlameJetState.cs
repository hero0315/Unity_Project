static public class FlameJetState
{
    static public bool FlameJetEnable=false;
    static public float FlameJetDamage=5f;
    static public float FlameJetContinueTime = 5f;
    static public float FlameJetcooldown = 5f;
    static public bool FlameJetcooldowning=false;
    static public bool FlameJetcanmove=true;
    public static void restart(){
        FlameJetEnable=false;
        FlameJetDamage=5f;
        FlameJetContinueTime = 5f;
        FlameJetcooldown = 5f;
        FlameJetcooldowning=false;
        FlameJetcanmove=true;
    }
}
