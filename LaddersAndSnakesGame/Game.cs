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
        private readonly IDictionary<object, int> _playersPosition = new Dictionary<object, int>();
        private int _currentPlayerIndex;
        
        public Game(int numberOfCells, List<object> players, IDice dice, List<BoardShortcut> boardShortcuts)
        {
            _numberOfCells = numberOfCells;
            _players = players;
            _currentPlayerIndex = 0;
            _dice = dice;
            _boardShortcuts = boardShortcuts;
            InitializePlayersPosition();
        }

        private void InitializePlayersPosition()
        {
            _players.ForEach(player => _playersPosition.Add(player, 1));
        }

        public int PositionOf(object aPlayer)
        {
            return _playersPosition[aPlayer];
        }

        public void Play()
        {
            AssertIsNotOver();

            CalculateCurrentPlayerNewPosition();
            CalculateNextPlayer();
        }

        private void CalculateCurrentPlayerNewPosition()
        {
            var currentPlayer = _players[_currentPlayerIndex];
            _playersPosition[currentPlayer] = MoveThroughShortcut(NewPositionAfterRollingDice(currentPlayer));
        }

        private int MoveThroughShortcut(int position)
        {
            var foundShortcut = _boardShortcuts.FirstOrDefault(shortcut => shortcut.StartsOn(position));
            if (foundShortcut != null)
                position = foundShortcut.To();
            
            return position;
        }

        private int NewPositionAfterRollingDice(object currentPlayer)
        {
            var newPosition = _playersPosition[currentPlayer] + _dice.Roll();
            if (newPosition > _numberOfCells)
                newPosition = _playersPosition[currentPlayer];
            return newPosition;
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