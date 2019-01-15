using System.Collections.Generic;

namespace TikTacToe.Model
{
    public class GameField
    {
        private readonly Dictionary<(int, int), GameMark> _field = new Dictionary<(int, int), GameMark>();

        private readonly List<List<(int, int)>> _rows = new List<List<(int, int)>>
        {
            new List<(int, int)> {(0, 0), (0, 1), (0, 2)},
            new List<(int, int)> {(1, 0), (1, 1), (1, 2)},
            new List<(int, int)> {(2, 0), (2, 1), (2, 2)},

            new List<(int, int)> {(0, 0), (1, 0), (2, 0)},
            new List<(int, int)> {(0, 1), (1, 1), (2, 1)},
            new List<(int, int)> {(0, 2), (1, 2), (2, 2)},

            new List<(int, int)> {(0, 0), (1, 1), (2, 2)},
            new List<(int, int)> {(0, 2), (1, 1), (2, 0)}
        };

        public int LeftMoves()
        {
            return 9 - _field.Count;
        }

        public void Move(int x, int y, GameMark mark)
        {
            if (_field.ContainsKey((x, y))) throw new FilledFieldException();
            _field[(x, y)] = mark;
        }

        public GameState State()
        {
            var state = GameState.Continue;

            foreach (var row in _rows)
            {
                if (!_field.TryGetValue(row[0], out var mark1)) continue;

                if (!_field.TryGetValue(row[1], out var mark2)) continue;

                if (!_field.TryGetValue(row[2], out var mark3)) continue;

                if (mark1 == mark2 && mark2 == mark3)
                {
                    state = mark3.ToState();
                    break;
                }
            }

            if (LeftMoves() == 0) state = GameState.WinNoOne;

            return state;
        }
    }
}