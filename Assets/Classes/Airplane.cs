using System;
using System.Collections.Generic;
using AirBattle.Classes.Slots;

namespace AirBattle.Classes
{
    public class AirplaneConsts
    {
        public const String HEALTH = "health";
        public const String SHIELD = "shield";
        public const String RESTORING_SHIELD = "restoringShield";
        public const String RELOADING_TIME = "reloadingTime";
        private AirplaneConsts() { }
    }
    public class Airplane
    {
        private string name;
        private int healthPoints;
        private int shieldPoints;
        private int restoringShiledPerSecond;
        private int maxWeaponSlotsNumber;
        private int maxModuleSlotNumber;
        private List<Weapon> weapons;
        private List<Module> modules;

        public Airplane(string name, int health, int shield, int restoringShied, int weaponSlots, int moduleSlots)
        {
            this.name = name;
            healthPoints = health;
            shieldPoints = shield;
            restoringShiledPerSecond = restoringShied;
            maxWeaponSlotsNumber = weaponSlots;
            maxModuleSlotNumber = moduleSlots;
            weapons = new List<Weapon>();
            modules = new List<Module>();
        }

        public void useModules()
        {
            State state = makeState();

            foreach (Module module in modules)
            {
                state = module.doBonus(state);
                if (state == null)
                {
                    throw new Exception("The State was missed!");
                }
            }

            applyState(state);

        }

        public void addModule(Module module)
        {
            if (modules.Count < maxModuleSlotNumber)
            {
                modules.Add(module);
            }
            else
            {
                throw new Exception("Module slots overflow");
            }
        }

        public void addWeapon(Weapon weapon)
        {
            if (weapons.Count < maxWeaponSlotsNumber)
            {
                weapons.Add(weapon);
            }
            else
            {
                throw new Exception("Weapon slots overflow");
            }
        }

        private State makeState()
        {
            State state = new State();

            state.addParameter(AirplaneConsts.HEALTH, healthPoints);
            state.addParameter(AirplaneConsts.SHIELD, shieldPoints);
            state.addParameter(AirplaneConsts.RESTORING_SHIELD, restoringShiledPerSecond);

            List<int> weaponsReloadingTime = new List<int>();
            foreach (Weapon weapon in weapons)
            {
                weaponsReloadingTime.Add(weapon.getTime());

            }
            state.addParameter(AirplaneConsts.RELOADING_TIME, weaponsReloadingTime);

            return state;
        }

        private void applyState(State state)
        {
            healthPoints = (int)state.getParameter(AirplaneConsts.HEALTH);
            shieldPoints = (int)state.getParameter(AirplaneConsts.SHIELD);
            restoringShiledPerSecond = (int)state.getParameter(AirplaneConsts.RESTORING_SHIELD);

            List<int> updatedReloadingTime = (List<int>)state.getParameter(AirplaneConsts.RELOADING_TIME);
            if (updatedReloadingTime.Count != weapons.Count)
            {
                throw new Exception("State contains illegal number of parameters for the weapons.");
            }
            for (int i = 0; i < weapons.Count; i++)
            {
                weapons[i].setTime(updatedReloadingTime[i]);
            }
        }

        public String getName()
        {
            return name;
        }

        public int getHealthPoints()
        {
            return healthPoints;
        }

        public int getShieldPoints()
        {
            return shieldPoints;
        }

        public int getRestoringShieldSpeed()
        {
            return restoringShiledPerSecond;
        }

        // For testing only!!!
        public List<int> getReloadingWeaponsTime()
        {
            List<int> result = new List<int>(weapons.Count);
            foreach (Weapon weapon in weapons)
            {
                result.Add(weapon.getTime());
            }
            return result;
        }
    }

    public class AirplaneFactory
    {
        public static Airplane makeAirplaneTypeA(string name)
        {
            return new Airplane(name, 100, 80, 1, 2, 2);
        }

        public static Airplane makeAirplaneTypeB(string name)
        {
            return new Airplane(name, 60, 120, 1, 2, 3);
        }

        private AirplaneFactory() {}
    }
}
