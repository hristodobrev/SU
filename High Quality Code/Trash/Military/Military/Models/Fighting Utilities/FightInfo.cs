namespace Military.Models.Fighting_Utilities
{
    using Interfaces;

    public class FightInfo
    {
        public FightInfo(IBattleUnit attacker, IBattleUnit defender, int initialDamage, int reducedDamage)
        {
            this.Attacker = attacker;
            this.Defender = defender;
            this.InitialDamage = initialDamage;
            this.ReducedDamage = reducedDamage;
        }

        public IBattleUnit Attacker { get; private set; }

        public IBattleUnit Defender { get; private set; }

        public int InitialDamage { get; private set; }

        public int ReducedDamage { get; private set; }

        public int AbsorbedDamage
        {
            get
            {
                return this.InitialDamage - this.ReducedDamage;
            }
        }
    }
}
