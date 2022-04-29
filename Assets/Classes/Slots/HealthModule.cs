using System;

namespace AirBattle.Classes.Slots
{
    public class HealthModule : Module
    {
        public HealthModule() : base()
        {

        }

        public HealthModule(int bonus) : base(bonus)
        {

        }

        internal override State doBonus(State state)
        {
            // don't use hardcode strings - use public consts
            if (state.containsKey(AirplaneConsts.HEALTH))
            {
                int value = (int)state.getParameter(AirplaneConsts.HEALTH);
                value += bonus;
                state.addParameter(AirplaneConsts.HEALTH, value);

                return state;
            }
            else
            {
                return null;
            }
        }
    }
}
