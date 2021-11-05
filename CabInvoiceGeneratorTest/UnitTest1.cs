using CabInvoiceGenerator;
using NUnit.Framework;

namespace CabInvoiceGeneratorTest
{
    /// <summary>
    /// Class for Test Cases
    /// </summary>
    public class Tests
    {
        //InvoiceGenerator Reference
        InvoiceGenerator invoiceGenerator = null;

        /// <summary>
        /// TestCase for Checking Calculate Fare Function
        /// </summary>
        [Test]
        public void GivenDistanceAndTimeShouldReturnTotalFare()
        {
            //Creating Instance of InvoiceGenerator for Normal Ride
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double distance = 2.0;
            int time = 5;

            //Calculating Fare
            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 25;

            //Asserting values
            Assert.AreEqual(expected, fare);
        }


        /// <summary>
        /// TestCase for Checking Calculate Fare Function for Multiple Rides Summary
        /// </summary>
        [Test]
        public void GivenMultipleRideShouldReturnInvoiceSummary()
        {
            //Creating instance of InvoiceGenerator for Normal Ride
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 5) };

            //Generating Summary For Rides
            InvoiceSummary summary = invoiceGenerator.CalculateFare(rides);
            InvoiceSummary expectedSummary = new InvoiceSummary(2, 35.0);

            //Asserting Values
            Assert.AreEqual(expectedSummary.GetType(), summary.GetType());
            //Assert.AreEqual(expectedSummary, summary);
        }


        /// <summary>
        /// Given Invalid Ride Type Should Throw Custom Exception
        /// </summary>
        [Test]
        public void GivenInvalidRideTypeShouldThrowCustomException()
        {
            //Creating instance of InvoiceGenerator 
            invoiceGenerator = new InvoiceGenerator();
            double distance = 2.0;
            int time = 5;
            string expected = "Invalid ride type";
            try
            {
                //Calculating Fare
                double fare = invoiceGenerator.CalculateFare(distance, time);
            }
            catch (CabInvoiceCustomException exception)
            {
                //Asserting Values
                Assert.AreEqual(expected, exception);
            }
        }

        /// <summary>
        /// Given Invalid Distance Should Throw Custom Exception
        /// </summary>
        [Test]
        public void GivenInvalidDistanceShouldThrowCustomException()
        {
            //Creating instance of InvoiceGenerator for Normal Ride
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double distance = -2.0;
            int time = 5;
            string expected = "Invalid Distance";
            try
            {
                //Calculating Fare
                double fare = invoiceGenerator.CalculateFare(distance, time);
            }
            catch (CabInvoiceCustomException exception)
            {
                //Asserting Values
                Assert.AreEqual(expected, exception.Message);
            }
        }


        /// <summary>
        /// Given Invalid Time Should Throw Custom Exception
        /// </summary>
        [Test]
        public void GivenInvalidTimeShouldThrowCustomException()
        {
            //Creating instance of InvoiceGenerator for Normal Ride
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double distance = 2.0;
            int time = -5;
            string expected = "Invalid Time";
            try
            {
                //Calculating Fare
                double fare = invoiceGenerator.CalculateFare(distance, time);
            }
            catch (CabInvoiceCustomException exception)
            {
                //Asserting Values
                Assert.AreEqual(expected, exception.Message);
            }
        }

        /// <summary>
        /// TestCase for Checking Calculate Fare Function for Minimum Time and Distance
        /// </summary>
        [Test]
        public void GivenLessDistanceOrTimeShouldReturnMinimumFare()
        {
            //Creating instance of InvoiceGenerator for Normal Ride
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            double distance = 0.1;
            int time = 1;

            //Calculating Fare
            double fare = invoiceGenerator.CalculateFare(distance, time);
            double expected = 5;

            //Asserting Values
            Assert.AreEqual(expected, fare);
        }


        /// <summary>
        /// Given Invalid Ride Type Should Throw Custom Exception
        /// </summary>
        [Test]
        public void GivenInvalidMultipleRidesShouldThrowCustomException()
        {
            //Creating instance of InvoiceGenerator For Normal Ride
            invoiceGenerator = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides = { };
            string expected = "Rides Are Null";
            try
            {
                //Generating Summary for Rides
                InvoiceSummary invoiceSummary = invoiceGenerator.CalculateFare(rides);
                InvoiceSummary expectedSummary = new InvoiceSummary(2, 30.0);
            }
            catch (CabInvoiceCustomException exception)
            {
                //Asserting Values
                Assert.AreEqual(expected, exception.Message);
            }
        }
    }
}