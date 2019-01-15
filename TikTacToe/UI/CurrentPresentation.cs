using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TikTacToe.Annotations;
using TikTacToe.Model;

namespace TikTacToe.UI
{
    public sealed class CurrentPresentation : INotifyPropertyChanged
    {
        public CurrentPresentation(GameSession gameSession)
        {
            Text = Present(gameSession);
            gameSession.GameEvent += (sender, args) => { Text = Present(gameSession); };
        }

        public string Present(GameSession gameSession)
        {
            switch (gameSession.CurrentGameField().State())
            {
                case GameState.Continue:
                    return $"{gameSession.CurrentMark()} move";
                case GameState.WinX:
                    return "Grants X with WIN!!!";
                case GameState.WinO:
                    return "Grants O with WIN!!!";
                case GameState.WinNoOne:
                    return "No one win. Try again!";
                default:
                    throw new ApplicationException("Unexpected application state");
            }
        }

        private string _text;

        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}