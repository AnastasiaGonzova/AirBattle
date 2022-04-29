using System;

namespace AirBattle.Classes.Slots
{
    public class RestoringShieldModule : Module
    {
        private double coeff = 0.0;
        public RestoringShieldModule() : base()
        {

        }

        public RestoringShieldModule(int bonus) : base(bonus)
        {
            coeff = ((double)(100 + bonus)) / 100;
        }

        internal override State doBonus(State state)
        {
            if (state.containsKey(AirplaneConsts.RESTORING_SHIELD))
            {
                int value = (int)state.getParameter(AirplaneConsts.RESTORING_SHIELD);
                value = (int)(value * coeff);
                state.addParameter(AirplaneConsts.RESTORING_SHIELD, value);

                return state;
            }
            else
            {
                return null;
            }
        }
    }
}
