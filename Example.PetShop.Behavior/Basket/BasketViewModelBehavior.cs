﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Example.PetShop.Basket;
using Example.PetShop.Domain;
using Example.PetShop.Utils;
using Moq;
using NUnit.Framework;

namespace Example.PetShop.Behavior.Basket
{
    [TestFixture]
    public class BasketViewModelBehavior
    {
        private Mock<ILookAfterPets> _petRepository;
        private Mock<ILookAfterAccessories> _accessoryRepository;
        private BasketViewModel _basketModel;
        private Mock<IHandleMessages> _messenger;
        private Pet _blackie;
        private Pet _sandy;

        private EventHandler<AccessoryEventArgs> _accessoriesSelected = delegate { };
        private EventHandler<AccessoryEventArgs> _accessoriesUnselected = delegate { };

            [SetUp]
        public void CreateBasket()
        {
            // Given there are two pets available for sale
            _blackie = new Pet { Name = "Blackie" };
            _sandy = new Pet { Name = "Sandy" };
            _petRepository = new Mock<ILookAfterPets>();
            _petRepository.SetupGet(p => p.UnsoldPets).Returns(new ObservableCollection<Pet> { _blackie, _sandy });

            // Given we can respond to accessories being selected and deselected
            _accessoryRepository = new Mock<ILookAfterAccessories>();
            _accessoryRepository.Setup(ar => ar.OnAccessorySelected(It.IsAny<EventHandler<AccessoryEventArgs>>()))
                .Callback<EventHandler<AccessoryEventArgs>>(eh => _accessoriesSelected += eh);
            _accessoryRepository.Setup(ar => ar.OnAccessoryUnselected(It.IsAny<EventHandler<AccessoryEventArgs>>()))
                .Callback<EventHandler<AccessoryEventArgs>>(eh => _accessoriesUnselected += eh);

            // Given we can respond to messages
            _messenger = new Mock<IHandleMessages>();
                
            // Given a basket model
            _basketModel = new BasketViewModel(_petRepository.Object, _accessoryRepository.Object, _messenger.Object);

        }

        [Test]
        public void ShouldLetUsPurchasePetsByMovingThemFromAvailablePetsToTheBasket()
        {
            // When we start
            // Then we should have all available pets

            Assert.AreEqual(new []{_blackie, _sandy}, _basketModel.AllAvailablePets);

            // When we purchase a pet
            _basketModel.PetSelectedForPurchase = _sandy;

            // Then the pet should be in the basket and not in the list of available pets
            Assert.AreEqual(1, _basketModel.Basket.Length);
            Assert.AreEqual(_sandy.Name, _basketModel.Basket[0].Item);
            Assert.AreEqual(new[]{_blackie}, _basketModel.AllAvailablePets);
        }

        [Test]
        public void ShouldInformThePetRepositoryOfAnyPetsSold()
        {
            // Given the basket has one of the available pets in
            _basketModel.PetSelectedForPurchase = _sandy;

            // When we sell the pet
            _basketModel.Pay.Execute(null);

            // Then we should tell the repository that the pet's been sold
            _petRepository.Verify(p => p.PetWasSold(_sandy));
        }

        [Test]
        public void ShouldClearTheBasketOfAnyPetsSold()
        {
            // Given the basket has one of the available pets in
            _basketModel.PetSelectedForPurchase = _blackie;

            // When we sell the pet
            _basketModel.Pay.Execute(null);

            // Then we should have an empty basket
            Assert.AreEqual(0, _basketModel.Basket.Length);
        }

        [Test]
        public void ShouldClearTheBasketWhenItIsResetWithoutTellingThePetRepository()
        {
            // Given the basket has one of the available pets in
            _basketModel.PetSelectedForPurchase = _blackie;

            // Given we will confirm any reset
            _messenger.Setup(m => m.Show(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

            // When we reset the basket
            _basketModel.Reset.Execute(null);

            // Then we should have an empty basket
            Assert.AreEqual(0, _basketModel.Basket.Length);

            // And we should not have told the repository about anything, because not much changed
            _petRepository.Verify(p => p.PetWasSold(It.IsAny<Pet>()), Times.Never());
        }

        [Test]
        public void ShouldStopUsFromClearingTheBasketByAccident()
        {
            // Given the basket has one of the available pets in
            _basketModel.PetSelectedForPurchase = _blackie;

            // Given we will say "Oops!" when we hit reset
            _messenger.Setup(m => m.Show(It.IsAny<string>(), It.IsAny<string>())).Returns(false);

            // When we reset the basket
            _basketModel.Reset.Execute(null);

            // Then the pet should still be in it
            Assert.AreEqual(1, _basketModel.Basket.Length);
            Assert.AreEqual(_blackie.Name, _basketModel.Basket[0].Item);
        }

        [Test]
        public void ShouldAddAnyAccessoriesSelectedToTheBasket()
        {
            // Given we have an accessory available for purchase
            var collar = new Accessory {Name = "Large Collar"};

            // When we select an accessory
            _accessoriesSelected(this, new AccessoryEventArgs(new List<Accessory>{collar}));

            // Then it should appear in the basket
            Assert.AreEqual(1, _basketModel.Basket.Length);
            Assert.AreEqual(collar.Name, _basketModel.Basket[0].Item);

            // When we deselect the accessory
            _accessoriesUnselected(this, new AccessoryEventArgs(new List<Accessory>{collar}));

            // Then the basket should be empty again
            Assert.AreEqual(0, _basketModel.Basket.Length);
        }
    }
}