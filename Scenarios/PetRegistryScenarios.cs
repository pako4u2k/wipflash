﻿#region

using System;
using System.Collections.Generic;
using System.Windows.Controls;
using Examples.ExampleUtils;
using NUnit.Framework;
using WiPFlash.Components;
using Button=WiPFlash.Components.Button;
using CheckBox=WiPFlash.Components.CheckBox;
using ComboBox=WiPFlash.Components.ComboBox;
using Label=WiPFlash.Components.Label;
using ListBox=WiPFlash.Components.ListBox;
using RadioButton=WiPFlash.Components.RadioButton;
using RichTextBox=WiPFlash.Components.RichTextBox;
using TextBox=WiPFlash.Components.TextBox;

#endregion

namespace Scenarios
{
    [TestFixture]
    public class PetRegistryScenarios : UIBasedExamples
    {
        [Test]
        public void ICanRegisterAPet()
        {
            Window window = LaunchPetShopWindow();
            window.Find<TextBox>("petNameInput").Text = "Snowdrop";
            window.Find<ComboBox>("petTypeInput").Select("PetType[Rabbit]");
            window.Find<ComboBox>("petFoodInput").Select("PetFood[Carnivorous]");
            window.Find<TextBox>("petPriceInput").Text = "100.00";
            window.Find<ListBox>("petRulesInput").Select("Rule[Dangerous]", "Rule[No Children]");
            window.Find<Button>("petSaveButton").Click();

            window.Find<Tab>("historyTab").Select();

            string expectedHistory = "Snowdrop the Rabbit registered at a price of £100.00. Food: Carnivorous";
            string actualHistory = window.Find<RichTextBox>("historyInput").Text;
            Assert.True(actualHistory.Contains(expectedHistory), 
                "Should have contained \r\n{0}\r\n but was :\r\n{1}", expectedHistory, actualHistory);

            window.Find<ComboBox>("basketInput").Select("Pet[Snowdrop]");
            string actualTotal = window.Find<Label>("totalOutput").Text;
            Assert.AreEqual("100.00", actualTotal);
            window.Find<RadioButton>("cardPaymentInput").Select();
            window.Find<CheckBox>("vatReceiptInput").Toggle();
            window.Find<Button>("purchaseButton").Click();

            string[] basketItems = window.Find<ComboBox>("basketInput").Items;
            Assert.False(new List<string>(basketItems).Contains("Pet[Snowdrop]"));
        }

    }
}
