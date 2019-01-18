using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TikTacToe.Model;
using TikTacToe.UI;

namespace UnitTests.UI
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class FieldPresenterTests
    {

        [TestMethod]
        public void Constructor_Init()
        {
            var presenter = new FieldPresenter(new GameSession(), 0, 0);

            Assert.IsTrue(presenter.Move.CanExecute(null));
        }

        [TestMethod]
        public void Move_Execute()
        {
            var presenter = new FieldPresenter(new GameSession(), 0,0);

            presenter.Move.Execute(null);

            Assert.IsFalse(string.IsNullOrEmpty(presenter.Mark));
        }

        [TestMethod]
        public void Move_Execute_AllowOneTime()
        {
            var presenter = new FieldPresenter(new GameSession(), 0, 0);

            presenter.Move.Execute(null);

            Assert.IsFalse(presenter.Move.CanExecute(null));
        }

        [TestMethod]
        public void Reset_CleanPresenter()
        {
            var gameSession = new GameSession();
            var presenter = new FieldPresenter(gameSession, 0, 0);

            presenter.Move.Execute(null);
            gameSession.Restart();

            Assert.IsTrue(presenter.Move.CanExecute(null));
            Assert.IsTrue(string.IsNullOrEmpty(presenter.Mark));
        }
    }
}