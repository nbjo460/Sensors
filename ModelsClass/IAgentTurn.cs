namespace Sensors.BaseModels
{
    public interface IAgentTurn
    {
        void SpecialPower(bool _attached);
        void PlaysTurn(bool _attached);
        int SpecialPowerPossibility { get; set; }
        int MaxCounterAttackByRank { get; set; }
        int CounterTurns { get; set; }
    }
}