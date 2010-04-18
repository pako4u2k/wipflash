﻿#region

using System.Windows.Automation;
using Examples.ExampleUtils;
using NUnit.Framework;
using WiPFlash.Components;

#endregion

namespace Examples.Component
{
    [TestFixture]
    public class TabBehaviour : AutomationElementWrapperExamples<Tab>
    {
        [Test]
        public void ShouldAllowTabToBeSelected()
        {
            Tab tab = FindPetShopElement("historyTab");

            Assert.False(tab.HasFocus());

            tab.Select();
            Assert.True(tab.HasFocus());
        }

        [Test]
        public void ShouldWaitForTheTabToGetFocus()
        {
            GivenThisWillHappenAtSomePoint(tab => tab.Select());
            ThenWeShouldBeAbleToWaitFor(tab => tab.HasFocus());
        }

        protected override Tab CreateWrapperWith(AutomationElement element, string name)
        {
            return new Tab(element, name);
        }

        protected override Tab CreateWrapper()
        {
            return FindPetShopElement("historyTab");
        }
    }
}