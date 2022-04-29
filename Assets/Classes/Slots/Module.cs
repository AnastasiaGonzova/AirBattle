using System;

namespace AirBattle.Classes.Slots
{
    public abstract class Module
    {
        protected int bonus;

        public Module()
        {
            bonus = 0;
        }

        public Module(int bonus)
        {
            this.bonus = bonus;
        }

        /*
         * If everything is ok then returns updated state parameter,
         * otherwise - returns null.
        */
        internal abstract State doBonus(State state);

    }
    public class DefaultModules
    {
        // Type A
        public static readonly Module ShieldModule50 = new ShieldModule(50);
        // Type B
        public static readonly Module HealthModule50 = new HealthModule(50);
        // Type C
        public static readonly Module ReloadingWeapon20 = new ReloadingWeaponModule(20);
        // Type D
        public static readonly Module RestoringShield20 = new RestoringShieldModule(20);
    }
}
