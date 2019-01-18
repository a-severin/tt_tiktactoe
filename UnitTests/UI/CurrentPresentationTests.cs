using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TikTacToe.Model;
using TikTacToe.UI;

namespace UnitTests.UI
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class CurrentPresentationTests
    {
        [TestMethod]
        public void Constructor_Init()
        {
            var presentation = new CurrentPresentation(new GameSession());

            Assert.IsFalse(string.IsNullOrEmpty(presentation.Text));
        }

        [TestMethod]
        public void Text_Changed_AfterMove()
        {
            var gameSession = new GameSession();
            var presentation = new CurrentPresentation(gameSession);

            var firstText = presentation.Text;

            gameSession.CurrentGameField().Move(0, 0, gameSession.CurrentMark());

            var secondText = presentation.Text;

            gameSession.CurrentGameField().Move(1, 1, gameSession.CurrentMark());

            var thirdText = presentation.Text;

            Assert.IsTrue(firstText != secondText);
            Assert.IsTrue(secondText != thirdText);
        }
    }
}