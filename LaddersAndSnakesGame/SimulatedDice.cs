using System;
using System.Collections.Generic;
using System.Linq;

namespace LaddersAndSnakesGame
{
    public class SimulatedDice : IDice
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