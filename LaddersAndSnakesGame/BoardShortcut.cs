using System;

namespace LaddersAndSnakesGame
{
    public class BoardShortcut
    {
        private readonly int _from;
        private readonly int _to;

        public BoardShortcut(int from, int to)
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