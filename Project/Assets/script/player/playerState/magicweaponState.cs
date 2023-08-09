public class magicweaponState
{
    public static bool MagicWeaponEnable=false;
    public static float MagicWeaponDamage=0;
    public static int MagicWeaponRange=1;
    public static float MagicWeaponDuration=5f;
    public static void restart(){
        MagicWeaponEnable=false;
        MagicWeaponDamage=0;
        MagicWeaponRange=1;
    }
}
