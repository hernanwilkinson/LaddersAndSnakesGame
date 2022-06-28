using System.Collections.Generic;

namespace LaddersAndSnakesGame
{
    public class SimulatedDice
    {
        private readonly List<int> _rolls;
        private int _currentRoll = 0;
        public SimulatedDice(List<int> rolls)
        {
            _rolls = rolls;
        }

        public int Roll()
        {
            return _rolls[_currentRoll++];
        }
    }
}