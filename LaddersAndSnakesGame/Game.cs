using System.Collections.Generic;

namespace LaddersAndSnakesGame
{
    public class Game
    {
        private readonly List<object> _players;
        private readonly IDice _dice;
        private IDictionary<object, int> _positionByPlayer = new Dictionary<object, int>();
        private int _currentPlayerIndex;

        public Game(int numberOfCells, List<object> players, IDice dice)
        {
            _players = players;
            _currentPlayerIndex = 0;
            _dice = dice;
            players.ForEach(player => _positionByPlayer.Add(player,1));
        }

        public int PositionOf(object aPlayer)
        {
            return _positionByPlayer[aPlayer];
        }

        public void Play()
        {
            var rolledNumber = _dice.Roll();
            var currentPlayer = _players[_currentPlayerIndex];
            _currentPlayerIndex = (_currentPlayerIndex + 1) % _players.Count;
            _positionByPlayer[currentPlayer] += rolledNumber;
        }

        public bool IsOver()
        {
            return true;
        }

        public object Winner()
        {
            return _players[0];
        }
    }
}