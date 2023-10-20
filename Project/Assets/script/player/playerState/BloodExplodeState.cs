static public class BloodExplodeState
{
    static public bool BloodExplodeEnable=false;
    static public float BloodExplodeDamage= 20f;
    static public float BloodExplodeFloorDamage = 10f;
    static public float BloodExplodeFloorTime = 2f;
    static public float BloodExplodecooldown = 1f;
    static public bool BloodExplodecooldowning=false;
    public static void restart(){
        BloodExplodeEnable=false;
        BloodExplodeDamage= 20f;
        BloodExplodeFloorDamage = 10f;
        BloodExplodeFloorTime = 2f;
        BloodExplodecooldown = 1f;
        BloodExplodecooldowning=false;
    }
}
