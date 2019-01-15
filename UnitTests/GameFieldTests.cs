using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TikTacToe.Model;

namespace UnitTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class GameFieldTests
    {
        [TestMethod]
        public void LeftMoves_IsNine_AtStart()
        {
            var gameField = new GameField();

            Assert.AreEqual(9, gameField.LeftMoves());
        }

        [TestMethod]
        public void LeftMoves_Decrease_AfterMove()
        {
            var gameField = new GameField();

            gameField.Move(0, 0, GameMark.O);
            Assert.AreEqual(8, gameField.LeftMoves());
        }

        [TestMethod]
        public void State_Continue_OnStart()
        {
            var gameField = new GameField();

            Assert.AreEqual(gameField.State(), GameState.Continue);
        }

        [TestMethod]
        public void LeftMoves_ChangeState_SomeOneWin()
        {
            var gameField = new GameField();

            gameField.Move(0, 0, GameMark.O);
            Assert.AreEqual(GameState.Continue, gameField.State());

            gameField.Move(1, 0, GameMark.X);
            Assert.AreEqual(GameState.Continue, gameField.State());

            gameField.Move(0, 1, GameMark.O);
            Assert.AreEqual(GameState.Continue, gameField.State());

            gameField.Move(1, 1, GameMark.X);
            Assert.AreEqual(GameState.Continue, gameField.State());

            gameField.Move(0, 2, GameMark.O);
            Assert.AreEqual(GameState.WinO, gameField.State());
        }

        [TestMethod]
        public void Move_ThrowException_OnTheFilledFiled()
        {
            var gameField = new GameField();
            gameField.Move(0, 0, GameMark.O);
            Assert.ThrowsException<FilledFieldException>(() => gameField.Move(0, 0, GameMark.O));
        }
    }
}