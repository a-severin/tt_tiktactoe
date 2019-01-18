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

      
    }
}