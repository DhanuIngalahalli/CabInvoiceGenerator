using NUnit.Framework;
using CabInvoiceGenerator;

namespace CabInvoicerTest
{
    public class Tests
    {
        InvoiceGenerator invoiceGenerator = null;


        [Test]
        public void GivenDistanceAndTimeShouldReturnTotalFare()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double distance = 2.0;
            int time = 5;

            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 25;
            Assert.AreEqual(expected, fare);
        }
        [Test]
        public void GivenMultipleRides_WhenUsingInvoiceSummaryClass_ShouldReturnInvoiceSummary()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 30.0);
            Assert.AreEqual(expectedSummary, summary);
        }
        [Test]
        public void GivenInvoiceGenerator_WhenUsingInvoiceSummaryClass_ShouldReturnInvoiceSummary()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 30.0, 15);
            Assert.AreEqual(expectedSummary, summary);
        }
        [Test]
        public void GivenUserId_WhenInvoivceService_ShouldReturnInvoice()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };
            invoiceGenerator.ADDRides("101", rides);
            InvoiceSummary summary = invoiceGenerator.GetInvoiceSummary("101");
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 30.0, "101");
            Assert.AreEqual(expectedSummary, summary);
        }
        [Test]
        public void GivenRides_ForPremiumUser_ShouldReturnTotalFare()
        {
            invoiceGenerator = new InvoiceGenerator(RideType.PREMIUM);
            double distance = 3.0;
            int time = 10;
            //calculating fares
            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 65;
            //Assert
            Assert.AreEqual(expected, fare);
        }
    }
}
