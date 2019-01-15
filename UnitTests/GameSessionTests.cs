using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TikTacToe.Model;

namespace UnitTests
{
    [TestClass]
    public class GameSessionTests
    {
        [TestMethod]
        [ExcludeFromCodeCoverage]
        public void Constructor_InitField()
        {
            var gameSession = new GameSession();
            Assert.IsNotNull(gameSession.CurrentGameField());
        }

        [TestMethod]
        public void Constructor_XStart()
        {
            var gameSession = new GameSession();
            Assert.AreEqual(GameMark.X, gameSession.CurrentMark());
        }

        [TestMethod]
        public void Next_ChangeCurrentMark()
        {
            var gameSession = new GameSession();
            gameSession.Next();
            Assert.AreEqual(GameMark.O, gameSession.CurrentMark());

        }

        [TestMethod]
        public void Next_InvokeGameEvent()
        {
            var gameSession = new GameSession();
            var invoked = false;
            gameSession.GameEvent += (sender, args) => { invoked = true; };
            gameSession.Next();
            Assert.IsTrue(invoked);

        }

        [TestMethod]
        public void Restart_UpdateFiled()
        {
            var gameSession = new GameSession();
            var field = gameSession.CurrentGameField();
            gameSession.Restart();
            Assert.AreNotEqual(field, gameSession.CurrentGameField());
        }

        [TestMethod]
        public void Restart_InvokeGameRestarted()
        {
            var gameSession = new GameSession();
            var invoked = false;
            gameSession.GameRestarted += (sender, args) => { invoked = true; };
            gameSession.Restart();
            Assert.IsTrue(invoked);
        }
    }
}
