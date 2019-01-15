using System;
using System.Diagnostics;
using System.Windows.Input;
using TikTacToe.Model;

namespace TikTacToe.UI
{
    public sealed class MoveCommand : ICommand
    {
        private readonly FieldPresenter _fieldPresenter;
        private readonly GameSession _gameSession;
        private readonly int _x;
        private readonly int _y;
        private bool _active = true;
        private bool _move;

        public MoveCommand(GameSession gameSession, FieldPresenter fieldPresenter, int x, int y)
        {
            _gameSession = gameSession;
            _fieldPresenter = fieldPresenter;
            _x = x;
            _y = y;
            gameSession.GameEvent += (sender, args) =>
            {
                _active = gameSession.CurrentGameField().State() == GameState.Continue;
                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            };
            gameSession.GameRestarted += (sender, args) =>
            {
                _active = true;
                _move = false;
                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            };
        }

        public bool CanExecute(object parameter)
        {
            return _active && !_move;
        }

        public void Execute(object parameter)
        {
            Debug.WriteLine($"Move {_gameSession.CurrentMark()} to ({_x},{_y})");

            _gameSession.CurrentGameField().Move(_x, _y, _gameSession.CurrentMark());
            _move = !_move;
            _fieldPresenter.Mark = _gameSession.CurrentMark().ToString();
            _gameSession.Next();
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler CanExecuteChanged;
    }
}