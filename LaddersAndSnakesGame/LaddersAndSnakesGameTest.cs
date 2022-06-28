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
    }

     public class SimulatedDice
     {
         public SimulatedDice(List<int> rolls)
         {
             
         }
     }

     public class Game
     {
         public Game(int numberOfCells, List<object> players, SimulatedDice dice)
         {
             
         }

         public int PositionOf(object aPlayer)
         {
             return 1;
         }
     }
}