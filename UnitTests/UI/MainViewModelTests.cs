using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TikTacToe.UI;

namespace UnitTests.UI
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class MainViewModelTests
    {
        [TestMethod]
        public void Constructor_Init()
        {
            var vm = new MainViewModel();

            Assert.AreEqual(9, vm.FieldPresenters.Count);
            Assert.IsNotNull(vm.CurrentPresentation);
            Assert.IsNotNull(vm.Restart);
        }
    }
}
