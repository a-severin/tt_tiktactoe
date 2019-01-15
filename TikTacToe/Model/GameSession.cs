using System;

namespace TikTacToe.Model
{
    public class GameSession
    {
        private GameField _gameField;
        private GameMark _currentMark;

        public GameSession()
        {
            _gameField = new GameField();
            _currentMark = GameMark.X;
        }

        public void Restart()
        {
            _gameField = new GameField();
            _currentMark = GameMark.X;
            GameRestarted?.Invoke(this, EventArgs.Empty);
        }

        public GameMark CurrentMark()
        {
            return _currentMark;
        }

        public void Next()
        {
            switch (_currentMark)
            {
                case GameMark.X:
                    _currentMark = GameMark.O;
                    break;
                case GameMark.O:
                    _currentMark = GameMark.X;
                    break;
            }
            GameEvent?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler GameEvent;
        public event EventHandler GameRestarted;

        public GameField CurrentGameField()
        {
            return _gameField;
        }
    }
}