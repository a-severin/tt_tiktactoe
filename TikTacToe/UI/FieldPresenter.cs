using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TikTacToe.Annotations;
using TikTacToe.Model;

namespace TikTacToe.UI
{
    public sealed class FieldPresenter: INotifyPropertyChanged
    {
        private string _mark;

        public FieldPresenter(GameSession gameSession, int x, int y)
        {
            Move = new MoveCommand(gameSession, this, x, y);
            gameSession.GameRestarted += (sender, args) => { Mark = string.Empty; };
        }

        public string Mark
        {
            get => _mark;
            set
            {
                _mark = value;
                OnPropertyChanged();
            }
        }

        public ICommand Move { get; }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}