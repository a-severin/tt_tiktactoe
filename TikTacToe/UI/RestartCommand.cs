using System;
using System.Windows.Input;
using TikTacToe.Model;

namespace TikTacToe.UI
{
    public sealed class RestartCommand : ICommand
    {
        private readonly GameSession _gameSession;

        public RestartCommand(GameSession gameSession)
        {
            _gameSession = gameSession;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _gameSession.Restart();
        }

        public event EventHandler CanExecuteChanged;
    }
}