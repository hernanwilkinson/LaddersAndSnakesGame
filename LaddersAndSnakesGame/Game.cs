using System;
using System.Collections.Generic;
using System.Linq;

namespace LaddersAndSnakesGame
{
    public class Game
    {
        public const string GAME_IS_OVER = "Game is over";
        private readonly int _numberOfCells;
        private readonly List<object> _players;
        private readonly IDice _dice;
        private readonly List<BoardShortcut> _boardShortcuts;
        private IDictionary<object, int> _positionByPlayer = new Dictionary<object, int>();
        private int _currentPlayerIndex;

        public Game(int numberOfCells, List<object> players, IDice dice, List<BoardShortcut> boardShortcuts)
        {
            _numberOfCells = numberOfCells;
            _players = players;
            _currentPlayerIndex = 0;
            _dice = dice;
            _boardShortcuts = boardShortcuts;
            players.ForEach(player => _positionByPlayer.Add(player,1));
        }

        public int PositionOf(object aPlayer)
        {
            return _positionByPlayer[aPlayer];
        }

        public void Play()
        {
            AssertIsNotOver();
            
            var rolledNumber = _dice.Roll();
            var currentPlayer = _players[_currentPlayerIndex];
            var newPosition = _positionByPlayer[currentPlayer] + rolledNumber;
            if (newPosition > _numberOfCells)
                newPosition = _positionByPlayer[currentPlayer];

            var foundShortcut = _boardShortcuts.Find(shortcut => shortcut.StartsOn(newPosition));
            if (foundShortcut != null)
                newPosition = foundShortcut.To();

            _positionByPlayer[currentPlayer] = newPosition;
            
            CalculateNextPlayer();
        }

        private void CalculateNextPlayer()
        {
            _currentPlayerIndex = (_currentPlayerIndex + 1) % _players.Count;
        }

        private void AssertIsNotOver()
        {
            if (IsOver()) throw new Exception(GAME_IS_OVER);
        }

        public bool IsOver()
        {
            return Winner()!=null;
        }

        public object Winner()
        {
            return _players.Find(player => PositionOf(player) == _numberOfCells);
        }
    }
}