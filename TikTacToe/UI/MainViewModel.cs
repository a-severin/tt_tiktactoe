using System.Collections.Generic;
using System.Windows.Input;
using TikTacToe.Model;

namespace TikTacToe.UI
{
    public sealed class MainViewModel
    {
        public MainViewModel()
        {
            var gameSession = new GameSession();

            CurrentPresentation = new CurrentPresentation(gameSession);

            Restart = new RestartCommand(gameSession);

            var fields = new List<FieldPresenter>();
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    fields.Add(new FieldPresenter(gameSession, x, y));
                }
            }

            FieldPresenters = fields;
        }

        public List<FieldPresenter> FieldPresenters { get; set; }

        public CurrentPresentation CurrentPresentation { get; }

        public ICommand Restart { get; }
    }
}