using System;

namespace LaddersAndSnakesGame
{
    public class Dice: IDice
    {
        public int Roll()
        {
            return new Random().Next(5) + 1;
        }
    }
}