using System;

namespace AirBattle.Classes.Slots
{
    public class ShieldModule : Module
    {
        public ShieldModule() : base() { }
        public ShieldModule(int bonus) : base(bonus) { }
        internal override State doBonus(State state)
        {
            if (state.containsKey(AirplaneConsts.SHIELD))
            {
                int value = (int)state.getParameter(AirplaneConsts.SHIELD);
                value += bonus;
                state.addParameter(AirplaneConsts.SHIELD, value);

                return state;
            }
            else
            {
                return null;
            }
        }
    }
}