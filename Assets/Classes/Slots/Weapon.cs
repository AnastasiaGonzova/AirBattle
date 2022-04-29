using System;

namespace AirBattle.Classes.Slots
{    

    public class Weapon
    {
        private int damage;
        private int time;

        public Weapon()
        {
            damage = 0;
            time = 0;
        }
        
        public Weapon(int damage, int time)
        {
            this.damage = damage;
            this.time = time;
        }

        public int getTime()
        {
            return time;
        }

        public int getDamage()
        {
            return damage;
        }
        
        public void setTime(int time)
        {
            this.time = time;
        }

        public void setDamage(int damage)
        {
            this.damage = damage;
        }
    }

    public class WeaponFactory
    {

        public static Weapon makeWeaponTypeA()
        {
            return new Weapon(5, 3);
        }

        public static Weapon makeWeaponTypeB()
        {
            return new Weapon(4, 2);
        }

        public static Weapon makeWeaponTypeC()
        {
            return new Weapon(20, 5);
        }

        private WeaponFactory() { }
    }
}
