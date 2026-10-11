using DeepDive11.Models;
using DeepDive11.Persistence;
using DeepDive11API.Contollers;
using DeepDive11API.DTOs;
using Microsoft.AspNetCore.Mvc;


namespace DeepDive11.Tests
{
    public class UnitTest1
    {
        // Tester at slutdato ikke må være før startdatoen.
        [Fact]
        public void BookingDateTest()
        {
            // Arrange
            var product = new CreateBookingProductRequest
            {
                ProductId = 1,
                StartDate = new DateTime(2026, 11, 15),
                EndDate = new DateTime(2026, 11, 10),
                Quantity = 1
            };

            // Act
            var endDateIsAfterStartDate = product.EndDate.Date > product.StartDate.Date;

            // Assert
            Assert.False(endDateIsAfterStartDate);
        }

        // Tester beregningen af den samlede pris på en booking.
        [Fact]
        public void BookingTotalPriceTest()
        {
            // Arrange
            var product = new Products
            {
                ProductId = 1,
                Brand = "Scubapro",
                PricePerDay = 125,
                ProductCategoryId = 1
            };

            var bookingProduct = new BookingProduct
            {
                ProductId = product.ProductId,
                Product = product,
                StartDate = new DateTime(2026, 11, 10),
                EndDate = new DateTime(2026, 11, 13),
                Quantity = 2
            };

            // Act
            var numberOfDays = (bookingProduct.EndDate.Date - bookingProduct.StartDate.Date).Days;
            bookingProduct.TotalPrice = numberOfDays * product.PricePerDay * bookingProduct.Quantity;

            // Assert
            Assert.Equal(3, numberOfDays);
            Assert.Equal(750m, bookingProduct.TotalPrice);
        }
    }
}
