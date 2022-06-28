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

            game.Play();
            
            Assert.AreEqual(2,game.PositionOf("Player1"));
            Assert.AreEqual(1,game.PositionOf("Player2"));
        }
        
        [Test]
        public void Test03()
        {
            var players = new List<object> {"Player1", "Player2"};
            var simulatedDice = new SimulatedDice(new List<int> { 1, 3 });
            var game = new Game(10,players,simulatedDice);

            game.Play();
            game.Play();

            Assert.AreEqual(2,game.PositionOf("Player1"));
            Assert.AreEqual(4,game.PositionOf("Player2"));
        }
        
        
        [Test]
        public void Test04()
        {
            var players = new List<object> {"Player1", "Player2"};
            var simulatedDice = new SimulatedDice(new List<int> { 1, 3, 4 });
            var game = new Game(10,players,simulatedDice);

            game.Play();
            game.Play();
            game.Play();

            Assert.AreEqual(6,game.PositionOf("Player1"));
            Assert.AreEqual(4,game.PositionOf("Player2"));
        }
        
        [Test]
        public void Test05()
        {
            var players = new List<object> {"Player1", "Player2"};
            var simulatedDice = new SimulatedDice(new List<int> { 6, 1, 3 });
            var game = new Game(10,players,simulatedDice);

            game.Play();
            game.Play();
            game.Play();

            Assert.AreEqual(10,game.PositionOf("Player1"));
            Assert.AreEqual(2,game.PositionOf("Player2"));
            Assert.IsTrue(game.IsOver());
            Assert.AreEqual("Player1",game.Winner());
        }
        
        [Test]
        public void Test06()
        {
            var players = new List<object> {"Player1", "Player2"};
            var simulatedDice = new SimulatedDice(new List<int> { 1, 6, 1, 3 });
            var game = new Game(10,players,simulatedDice);

            game.Play();
            game.Play();
            game.Play();
            game.Play();

            Assert.AreEqual(3,game.PositionOf("Player1"));
            Assert.AreEqual(10,game.PositionOf("Player2"));
            Assert.IsTrue(game.IsOver());
            Assert.AreEqual("Player2",game.Winner());
        }
    }
}