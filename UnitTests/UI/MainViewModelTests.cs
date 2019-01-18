using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
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

        [TestMethod]
        public void Move_ChangeCurrent()
        {
            var vm = new MainViewModel();

            var firstText = vm.CurrentPresentation.Text;

            vm.FieldPresenters.First().Move.Execute(null);

            var secondText = vm.CurrentPresentation.Text;

            vm.FieldPresenters.Skip(1).First().Move.Execute(null);

            var thirdText = vm.CurrentPresentation.Text;

            Assert.IsTrue(firstText != secondText);
            Assert.IsTrue(secondText != thirdText);
        }
    }
}