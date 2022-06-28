using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace LaddersAndSnakesGame
{
    [TestFixture]
     public class LaddersAndSnakesGamesTest
    {
       [Test]
        public void Test01()
        {
            var players = new List<object> {"Player1", "Player2"};
            var simulatedDice = new SimulatedDice(new List<int> { 1 });
            var game = new Game(10,players,simulatedDice);

            Assert.AreEqual(1,game.PositionOf("Player1"));
            Assert.AreEqual(1,game.PositionOf("Player2"));
        }
        
        [Test]
        public void Test02()
        {
            var players = new List<object> {"Player1", "Player2"};
            var simulatedDice = new SimulatedDice(new List<int> { 1 });
            var game = new Game(10,players,simulatedDice);

            game.play();
            
            Assert.AreEqual(2,game.PositionOf("Player1"));
            Assert.AreEqual(1,game.PositionOf("Player2"));
        }
        
        [Test]
        public void Test03()
        {
            var players = new List<object> {"Player1", "Player2"};
            var simulatedDice = new SimulatedDice(new List<int> { 1, 3 });
            var game = new Game(10,players,simulatedDice);

            game.play();
            game.play();

            Assert.AreEqual(2,game.PositionOf("Player1"));
            Assert.AreEqual(4,game.PositionOf("Player2"));
        }
    }

     public class SimulatedDice
     {
         private readonly List<int> _rolls;
         private int _currentRoll = 0;
         public SimulatedDice(List<int> rolls)
         {
             _rolls = rolls;
         }

         public int roll()
         {
             return _rolls[_currentRoll++];
         }
     }

     public class Game
     {
         private readonly List<object> _players;
         private readonly SimulatedDice _dice;
         private IDictionary<object, int> _positionByPlayer = new Dictionary<object, int>();
         private int _currentPlayerIndex;

         public Game(int numberOfCells, List<object> players, SimulatedDice dice)
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

         public void play()
         {
             var rolledNumber = _dice.roll();
             var currentPlayer = _players[_currentPlayerIndex++];
             _positionByPlayer[currentPlayer] += rolledNumber;
         }
     }
}