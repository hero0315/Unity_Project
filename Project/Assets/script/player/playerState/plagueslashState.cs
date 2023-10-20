static public class plagueslashState
{
    public static bool PlagueSlashEnable=false;
    public static bool PlagueSlashiscooldowning=false;
    public static float PlagueSlashDamage=30;
    public static int PlagueSlashRange=1;
    static public float PlagueSlashcooldown = 2f;
    public static void restart(){
        PlagueSlashEnable=false;
        PlagueSlashiscooldowning=false;
        PlagueSlashDamage=30;
        PlagueSlashRange=1;
        PlagueSlashcooldown = 2f;
    }
}
