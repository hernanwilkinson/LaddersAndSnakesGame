﻿using System;
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
        private const string PLAYER_1 = "Player1";
        private const string PLAYER_2 = "Player2";

        [Test]
        public void Test01()
        {
            var players = new List<object> {PLAYER_1, PLAYER_2};
            var simulatedDice = new SimulatedDice(new List<int> { 1 });
            var game = new Game(10,players,simulatedDice, new List<Stair>());

            Assert.AreEqual(1,game.PositionOf(PLAYER_1));
            Assert.AreEqual(1,game.PositionOf(PLAYER_2));
        }
        
        [Test]
        public void Test02()
        {
            var players = new List<object> {PLAYER_1, PLAYER_2};
            var simulatedDice = new SimulatedDice(new List<int> { 1 });
            var game = new Game(10,players,simulatedDice, new List<Stair>());

            game.Play();
            
            Assert.AreEqual(2,game.PositionOf(PLAYER_1));
            Assert.AreEqual(1,game.PositionOf(PLAYER_2));
        }
        
        [Test]
        public void Test03()
        {
            var players = new List<object> {PLAYER_1, PLAYER_2};
            var simulatedDice = new SimulatedDice(new List<int> { 1, 3 });
            var game = new Game(10,players,simulatedDice, new List<Stair>());

            game.Play();
            game.Play();

            Assert.AreEqual(2,game.PositionOf(PLAYER_1));
            Assert.AreEqual(4,game.PositionOf(PLAYER_2));
        }
        
        
        [Test]
        public void Test04()
        {
            var players = new List<object> {PLAYER_1, PLAYER_2};
            var simulatedDice = new SimulatedDice(new List<int> { 1, 3, 4 });
            var game = new Game(10,players,simulatedDice, new List<Stair>());

            game.Play();
            game.Play();
            game.Play();

            Assert.AreEqual(6,game.PositionOf(PLAYER_1));
            Assert.AreEqual(4,game.PositionOf(PLAYER_2));
        }
        
        [Test]
        public void Test05()
        {
            var players = new List<object> {PLAYER_1, PLAYER_2};
            var simulatedDice = new SimulatedDice(new List<int> { 6, 1, 3 });
            var game = new Game(10,players,simulatedDice, new List<Stair>());

            game.Play();
            game.Play();
            game.Play();

            Assert.AreEqual(10,game.PositionOf(PLAYER_1));
            Assert.AreEqual(2,game.PositionOf(PLAYER_2));
            Assert.IsTrue(game.IsOver());
            Assert.AreEqual(PLAYER_1,game.Winner());
        }
        
        [Test]
        public void Test06()
        {
            var players = new List<object> {PLAYER_1, PLAYER_2};
            var simulatedDice = new SimulatedDice(new List<int> { 1, 6, 1, 3 });
            var game = new Game(10,players,simulatedDice, new List<Stair>());

            game.Play();
            game.Play();
            game.Play();
            game.Play();

            Assert.AreEqual(3,game.PositionOf(PLAYER_1));
            Assert.AreEqual(10,game.PositionOf(PLAYER_2));
            Assert.IsTrue(game.IsOver());
            Assert.AreEqual(PLAYER_2,game.Winner());
        }
        [Test]
        public void Test07()
        {
            var players = new List<object> {PLAYER_1, PLAYER_2};
            var simulatedDice = new SimulatedDice(new List<int> ());
            var game = new Game(10,players,simulatedDice, new List<Stair>());
            
            Assert.IsFalse(game.IsOver());
        }
        
        [Test]
        public void Test08()
        {
            var players = new List<object> {PLAYER_1, PLAYER_2};
            var simulatedDice = new SimulatedDice(new List<int> { 6, 1, 3 });
            var game = new Game(10,players,simulatedDice, new List<Stair>());

            game.Play();
            game.Play();
            game.Play();

            var exception = Assert.Throws<Exception>(() => game.Play());
            Assert.AreEqual(Game.GAME_IS_OVER,exception.Message);
            Assert.AreEqual(2,game.PositionOf(PLAYER_2));
        }
        
        [Test]
        public void Test09()
        {
            var players = new List<object> {PLAYER_1, PLAYER_2};
            var simulatedDice = new SimulatedDice(new List<int> { 6, 1, 6 });
            var game = new Game(10,players,simulatedDice, new List<Stair>());

            game.Play();
            game.Play();
            game.Play();

            Assert.AreEqual(7,game.PositionOf(PLAYER_1));
            
        }
        
        [Test]
        public void Test10()
        {
            var players = new List<object> {PLAYER_1, PLAYER_2};
            var simulatedDice = new SimulatedDice(new List<int> { 1 });
            var stairs = new List<Stair>{ new Stair(2,38)};
            var game = new Game(100,players,simulatedDice, stairs);

            game.Play();

            Assert.AreEqual(38,game.PositionOf(PLAYER_1));
            
        }
    }

     public class Stair
     {
         private readonly int _from;
         private readonly int _to;

         public Stair(int from, int to)
         {
             _from = from;
             _to = to;
         }

         public bool StartsOn(int position)
         {
             return _from.Equals(position);
         }

         public int To()
         {
             return _to;
         }
     }
}