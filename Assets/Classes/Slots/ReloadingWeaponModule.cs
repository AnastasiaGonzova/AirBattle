using System;
using System.Collections.Generic;

namespace AirBattle.Classes.Slots
{
    public class ReloadingWeaponModule : Module
    {
        private double coeff = 0.0;
        public ReloadingWeaponModule() : base()
        {

        }

        public ReloadingWeaponModule(int bonus) : base(bonus)
        {
            coeff = ((double)(100 - bonus)) / 100;
        }

        internal override State doBonus(State state)
        {
            if (state.containsKey(AirplaneConsts.RELOADING_TIME))
            {
                List<int> timesList = (List<int>)state.getParameter(AirplaneConsts.RELOADING_TIME);

                for (int i = 0; i < timesList.Count; i++) {

                    timesList[i] = (int)(timesList[i] * coeff);
                }

                state.addParameter(AirplaneConsts.RELOADING_TIME, timesList);
                return state;
            }
            else
            {
                return null;
            }
        }
    }
}
