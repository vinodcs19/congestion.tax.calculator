using System;
using System.Threading.Tasks;
using congestion.calculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace congestion_tax_calculator_net_core_test
{
    [TestClass]
     public  class CongestionTaxCalculatorTest
    {

        CongestionTaxCalculator  _congestionTaxCalculator;

        [TestInitialize]
         public  void Before()
        {
             _congestionTaxCalculator = new CongestionTaxCalculator();
        }

        [TestMethod]
        public async Task Input_provided_by_my_colleagues_which_found_on_desk()
        {
            Assert.AreEqual(0, await _congestionTaxCalculator.GetTax(new Car(), new DateTime[] { new DateTime(2013, 1, 14, 21, 0, 0) }));
            Assert.AreEqual(0, await _congestionTaxCalculator.GetTax(new Car(), new DateTime[] { new DateTime(2013, 1, 15, 21, 0, 0) }));
            Assert.AreEqual(8, await _congestionTaxCalculator.GetTax(new Car(), new DateTime[] { new DateTime(2013, 2, 7, 6, 23, 27) }));
            Assert.AreEqual(13, await _congestionTaxCalculator.GetTax(new Car(), new DateTime[] { new DateTime(2013, 2, 7, 15, 27, 0) }));
            Assert.AreEqual(8, await _congestionTaxCalculator.GetTax(new Car(), new DateTime[] { new DateTime(2013, 2, 8, 6, 27, 0) }));
            Assert.AreEqual(8, await _congestionTaxCalculator.GetTax(new Car(), new DateTime[] { new DateTime(2013, 2, 8, 6, 20, 27) }));
            Assert.AreEqual(8, await _congestionTaxCalculator.GetTax(new Car(), new DateTime[] { new DateTime(2013, 2, 8, 14, 35, 0) }));
            Assert.AreEqual(13, await _congestionTaxCalculator.GetTax(new Car(), new DateTime[] { new DateTime(2013, 2, 8, 15, 29, 0) }));
            Assert.AreEqual(18, await _congestionTaxCalculator.GetTax(new Car(), new DateTime[] { new DateTime(2013, 2, 8, 15, 47, 0) }));
            Assert.AreEqual(18, await _congestionTaxCalculator.GetTax(new Car(), new DateTime[] { new DateTime(2013, 2, 8, 16, 01, 0) }));
            Assert.AreEqual(18, await _congestionTaxCalculator.GetTax(new Car(), new DateTime[] { new DateTime(2013, 2, 8, 16, 48, 0) }));
            Assert.AreEqual(13, await _congestionTaxCalculator.GetTax(new Car(), new DateTime[] { new DateTime(2013, 2, 8, 17, 49, 0) }));
            Assert.AreEqual(8, await _congestionTaxCalculator.GetTax(new Car(), new DateTime[] { new DateTime(2013, 2, 8, 18, 29, 0) }));
            Assert.AreEqual(0, await _congestionTaxCalculator.GetTax(new Car(), new DateTime[] { new DateTime(2013, 2, 8, 18, 35, 0) }));
            Assert.AreEqual(8, await _congestionTaxCalculator.GetTax(new Car(), new DateTime[] { new DateTime(2013, 3, 26, 14, 25, 0) }));
            Assert.AreEqual(0, await _congestionTaxCalculator.GetTax(new Car(), new DateTime[] { new DateTime(2013, 12, 26, 14, 07, 27) }));// public holiday
        }

        [TestMethod]
         public  async Task It_should_return_max_amount_8sek_between_timeinterval_6_00am_to_6_29amAsync()
        {
            Assert.AreEqual(8, await _congestionTaxCalculator.GetTax(new Car(), new DateTime[] {
                new DateTime(2013, 2, 1, 6, 00, 0),
                new DateTime(2013, 2, 1, 6, 15, 0),
                new DateTime(2013, 2, 1, 6, 29, 0)}));
        }

        [TestMethod]
         public  async Task It_should_return_max_amount_13sek_between_timeinterval_6_30am_to_6_59amAsync()
        {
            Assert.AreEqual(13,  await _congestionTaxCalculator.GetTax(new Car(), new DateTime[] {
                new DateTime(2013, 2, 1, 6, 30, 0),
                new DateTime(2013, 2, 1, 6, 45, 0),
                new DateTime(2013, 2, 1, 6, 59, 0)}));
        }

        [TestMethod]
         public  async Task It_should_return_max_amount_18sek_between_timeinterval_7_00am_to_7_59amAsync()
        {
            Assert.AreEqual(18, await _congestionTaxCalculator.GetTax(new Car(), new DateTime[] {
                new DateTime(2013, 2, 1, 7, 00, 0),
                new DateTime(2013, 2, 1, 7, 15, 0),
                new DateTime(2013, 2, 1, 7, 59, 0)}));
        }

        [TestMethod]
         public  async Task It_should_return_max_amount_13sek_between_timeinterval_8_00am_to_8_29amAsync()
        {
            Assert.AreEqual(13, await  _congestionTaxCalculator.GetTax(new Car(), new DateTime[] {
                new DateTime(2013, 2, 1, 8, 00, 0),
                new DateTime(2013, 2, 1, 8, 15, 0),
                new DateTime(2013, 2, 1, 8, 29, 0)}));
        }

        [TestMethod]
         public async Task It_should_return_max_amount_8sek_between_timeinterval_8_30am_to_09_29am()
        {
            Assert.AreEqual(8, await  _congestionTaxCalculator.GetTax(new Car(), new DateTime[] {
                new DateTime(2013, 2, 1, 8, 30, 0),
                new DateTime(2013, 2, 1, 8, 45, 0),
                new DateTime(2013, 2, 1, 9, 29, 0)}));
        }

        [TestMethod]
         public async Task It_should_return_max_amount_8sek_between_timeinterval_9_30am_to_10_29am()
        {
            Assert.AreEqual(8, await  _congestionTaxCalculator.GetTax(new Car(), new DateTime[] {
                new DateTime(2013, 2, 1, 9, 30, 0),
                new DateTime(2013, 2, 1, 9, 45, 0),
                new DateTime(2013, 2, 1, 10, 29, 0)}));
        }

        [TestMethod]
         public async Task It_should_return_max_amount_8sek_between_timeinterval_10_30am_to_11_29am()
        {
            Assert.AreEqual(8, await  _congestionTaxCalculator.GetTax(new Car(), new DateTime[] {
                new DateTime(2013, 2, 1, 10, 30, 0),
                new DateTime(2013, 2, 1, 10, 45, 0),
                new DateTime(2013, 2, 1, 11, 29, 0)}));
        }

        [TestMethod]
         public async Task It_should_return_max_amount_8sek_between_timeinterval_11_30am_to_12_29am()
        {
            Assert.AreEqual(8, await  _congestionTaxCalculator.GetTax(new Car(), new DateTime[] {
                new DateTime(2013, 2, 1, 11, 30, 0),
                new DateTime(2013, 2, 1, 11, 45, 0),
                new DateTime(2013, 2, 1, 12, 29, 0)}));
        }

        [TestMethod]
         public async Task It_should_return_max_amount_8sek_between_timeinterval_12_30am_to_13_29am()
        {
            Assert.AreEqual(8, await  _congestionTaxCalculator.GetTax(new Car(), new DateTime[] {
                new DateTime(2013, 2, 1, 12, 30, 0),
                new DateTime(2013, 2, 1, 12, 45, 0),
                new DateTime(2013, 2, 1, 13, 29, 0)}));
        }

        [TestMethod]
         public async Task It_should_return_max_amount_8sek_between_timeinterval_13_30am_to_14_29am()
        {
            Assert.AreEqual(8, await  _congestionTaxCalculator.GetTax(new Car(), new DateTime[] {
                new DateTime(2013, 2, 1, 13, 30, 0),
                new DateTime(2013, 2, 1, 13, 45, 0),
                new DateTime(2013, 2, 1, 14, 29, 0)}));
        }

        [TestMethod]
         public async Task It_should_return_max_amount_8sek_between_timeinterval_14_30am_to_14_59am()
        {
            Assert.AreEqual(8, await  _congestionTaxCalculator.GetTax(new Car(), new DateTime[] {
                new DateTime(2013, 2, 1, 14, 30, 0),
                new DateTime(2013, 2, 1, 14, 45, 0),
                new DateTime(2013, 2, 1, 14, 59, 0)}));
        }
      
        [TestMethod]
         public async Task It_should_return_max_amount_56sek_between_timeinterval_8_30am_to_14_59am()
        {
            Assert.AreEqual(56, await  _congestionTaxCalculator.GetTax(new Car(), new DateTime[] {
                new DateTime(2013, 2, 1, 8, 30, 0),
                new DateTime(2013, 2, 1, 8, 40, 0),
                new DateTime(2013, 2, 1, 8, 45, 0),
                new DateTime(2013, 2, 1, 9, 31, 0),
                new DateTime(2013, 2, 1, 10, 32, 0),
                new DateTime(2013, 2, 1, 11, 33, 0),
                new DateTime(2013, 2, 1, 12, 34, 0),
                new DateTime(2013, 2, 1, 13, 35, 0),
                new DateTime(2013, 2, 1, 14, 59, 0)}));
        }

        [TestMethod]
         public async Task It_should_return_max_amount_13sek_between_timeinterval_15_00am_to_15_29am()
        {
            Assert.AreEqual(13, await  _congestionTaxCalculator.GetTax(new Car(), new DateTime[] {
                new DateTime(2013, 2, 1, 15, 00, 0),
                new DateTime(2013, 2, 1, 15, 15, 0),
                new DateTime(2013, 2, 1, 15, 29, 0)}));
        }

        [TestMethod]
         public async Task It_should_return_max_amount_18sek_between_timeinterval_15_30am_to_16_59am()
        {
            Assert.AreEqual(18, await  _congestionTaxCalculator.GetTax(new Car(), new DateTime[] {
                new DateTime(2013, 2, 1, 15, 30, 0),
                new DateTime(2013, 2, 1, 15, 45, 0),
                new DateTime(2013, 2, 1, 16, 30, 0)}));
        }

        [TestMethod]
         public async Task It_should_return_max_amount_36sek_between_timeinterval_15_30am_to_16_59am()
        {
            Assert.AreEqual(36, await  _congestionTaxCalculator.GetTax(new Car(), new DateTime[] {
                new DateTime(2013, 2, 1, 15, 30, 0),
                new DateTime(2013, 2, 1, 15, 45, 0),
                new DateTime(2013, 2, 1, 16, 30, 0),
                new DateTime(2013, 2, 1, 16, 59, 0)}));
        }

        [TestMethod]
         public async Task It_should_return_max_amount_13sek_between_timeinterval_17_00am_to_17_59am()
        {
            Assert.AreEqual(13, await  _congestionTaxCalculator.GetTax(new Car(), new DateTime[] {
                new DateTime(2013, 2, 1, 17, 00, 0),
                new DateTime(2013, 2, 1, 17, 15, 0),
                new DateTime(2013, 2, 1, 17, 45, 0),
                new DateTime(2013, 2, 1, 17, 59, 0)}));
        }

        [TestMethod]
         public async Task It_should_return_max_amount_8sek_between_timeinterval_18_00am_to_18_29am()
        {
            Assert.AreEqual(8, await  _congestionTaxCalculator.GetTax(new Car(), new DateTime[] {
                new DateTime(2013, 2, 1, 18, 00, 0),
                new DateTime(2013, 2, 1, 18, 15, 0),
                new DateTime(2013, 2, 1, 18, 29, 0)}));
        }

        [TestMethod]
         public async Task It_should_return_max_amount_0sek_between_timeinterval_18_30am_to_05_59am()
        {
            Assert.AreEqual(0, await _congestionTaxCalculator.GetTax(new Car(), new DateTime[] {
                new DateTime(2013, 2, 1, 00, 45, 0),
                new DateTime(2013, 2, 1, 18, 30, 0),
                new DateTime(2013, 2, 1, 18, 45, 0),
                new DateTime(2013, 2, 1, 19, 45, 0),
                new DateTime(2013, 2, 1, 20, 45, 0),
                new DateTime(2013, 2, 1, 21, 45, 0),
                new DateTime(2013, 2, 1, 22, 45, 0),
                new DateTime(2013, 2, 1, 23, 45, 0),
                new DateTime(2013, 2, 1, 01, 45, 0),
                new DateTime(2013, 2, 1, 02, 45, 0),
                new DateTime(2013, 2, 1, 03, 45, 0),
                new DateTime(2013, 2, 1, 04, 45, 0),
                new DateTime(2013, 2, 1, 05, 45, 0),
                new DateTime(2013, 2, 1, 18, 45, 0),
                new DateTime(2013, 2, 1, 05, 59, 0)}));
        }

        [TestMethod]
         public  async Task It_should_return_max_amount_13_between_timeinterval_6_00am_to_6_59amAsync()
        {
            Assert.AreEqual(13, await  _congestionTaxCalculator.GetTax(new Car(), new DateTime[] {
                new DateTime(2013, 2, 1, 6, 00, 0),
                new DateTime(2013, 2, 1, 6, 15, 0),
                new DateTime(2013, 2, 1, 6, 30, 0),
                new DateTime(2013, 2, 1, 6, 45, 0),
                new DateTime(2013, 2, 1, 6, 59, 0) }));
        }

        [TestMethod]
         public async Task It_should_return_max_amount_18_between_timeinterval_6am_to_7am()
        {
            Assert.AreEqual(18, await  _congestionTaxCalculator.GetTax(new Car(), new DateTime[] {
                new DateTime(2013, 2, 1, 6, 00, 0),
                new DateTime(2013, 2, 1, 6, 15, 0),
                new DateTime(2013, 2, 1, 6, 30, 0),
                new DateTime(2013, 2, 1, 6, 45, 0),
                new DateTime(2013, 2, 1, 7, 00, 0) }));
        }

        [TestMethod]
         public async Task It_should_return_max_amount_31_between_timeinterval_6am_to_7_01am()
        {
            Assert.AreEqual(31, await  _congestionTaxCalculator.GetTax(new Car(), new DateTime[] {
                new DateTime(2013, 2, 1, 6, 00, 0),
                new DateTime(2013, 2, 1, 6, 15, 0),
                new DateTime(2013, 2, 1, 6, 30, 0),
                new DateTime(2013, 2, 1, 6, 45, 0),
                new DateTime(2013, 2, 1, 7, 01, 0) }));
        }

        [TestMethod]
         public async Task It_should_return_max_amount_31_between_timeinterval_6am_to_7_01am_even_in_different_time_sequence()
        {
            Assert.AreEqual(31, await  _congestionTaxCalculator.GetTax(new Car(), new DateTime[] {
                new DateTime(2013, 2, 1, 7, 01, 0),
                new DateTime(2013, 2, 1, 6, 00, 0),
                new DateTime(2013, 2, 1, 7, 05, 0),
                new DateTime(2013, 2, 1, 6, 15, 0),
                new DateTime(2013, 2, 1, 7, 08, 0),
                new DateTime(2013, 2, 1, 6, 30, 0),
                new DateTime(2013, 2, 1, 6, 45, 0),
                 }));
        }

        [TestMethod]
         public async Task It_should_return_tax_amount_0sek_when_it_is_public_holiday()
        {
            Assert.AreEqual(0, await  _congestionTaxCalculator.GetTax(new Car(), new DateTime[] { new DateTime(2013, 1, 1, 6, 0, 0) }));
            Assert.AreEqual(0, await  _congestionTaxCalculator.GetTax(new Car(), new DateTime[] { new DateTime(2013, 3, 28, 6, 0, 0) }));
            Assert.AreEqual(0, await  _congestionTaxCalculator.GetTax(new Car(), new DateTime[] { new DateTime(2013, 3, 29, 6, 30, 0) }));
            Assert.AreEqual(0, await  _congestionTaxCalculator.GetTax(new Car(), new DateTime[] { new DateTime(2013, 4, 1, 7, 30, 0) }));
            Assert.AreEqual(0, await  _congestionTaxCalculator.GetTax(new Car(), new DateTime[] { new DateTime(2013, 4, 30, 8, 0, 0) }));
            Assert.AreEqual(0, await  _congestionTaxCalculator.GetTax(new Car(), new DateTime[] { new DateTime(2013, 5, 1, 8, 30, 0) }));
            Assert.AreEqual(0, await  _congestionTaxCalculator.GetTax(new Car(), new DateTime[] { new DateTime(2013, 5, 8, 9, 30, 0) }));
            Assert.AreEqual(0, await  _congestionTaxCalculator.GetTax(new Car(), new DateTime[] { new DateTime(2013, 5, 9, 12, 30, 0) }));
            Assert.AreEqual(0, await  _congestionTaxCalculator.GetTax(new Car(), new DateTime[] { new DateTime(2013, 6, 5, 15, 0, 0) }));
            Assert.AreEqual(0, await  _congestionTaxCalculator.GetTax(new Car(), new DateTime[] { new DateTime(2013, 6, 6, 15, 30, 0) }));
            Assert.AreEqual(0, await  _congestionTaxCalculator.GetTax(new Car(), new DateTime[] { new DateTime(2013, 6, 21, 16, 30, 0) }));
            Assert.AreEqual(0, await  _congestionTaxCalculator.GetTax(new Car(), new DateTime[] { new DateTime(2013, 7, 1, 17, 30, 0) }));
            Assert.AreEqual(0, await  _congestionTaxCalculator.GetTax(new Car(), new DateTime[] { new DateTime(2013, 11, 1, 18, 30, 0) }));
            Assert.AreEqual(0, await  _congestionTaxCalculator.GetTax(new Car(), new DateTime[] { new DateTime(2013, 12, 24, 13, 30, 0) }));
            Assert.AreEqual(0, await  _congestionTaxCalculator.GetTax(new Car(), new DateTime[] { new DateTime(2013, 12, 25, 13, 30, 0) }));
            Assert.AreEqual(0, await  _congestionTaxCalculator.GetTax(new Car(), new DateTime[] { new DateTime(2013, 12, 26, 13, 30, 0) }));
            Assert.AreEqual(0, await  _congestionTaxCalculator.GetTax(new Car(), new DateTime[] { new DateTime(2013, 12, 31, 13, 30, 0) }));
        }

        [TestMethod]
         public async Task It_should_return_tax_amount_0sek_day_before_public_holiday()
        {
            Assert.AreEqual(0, await  _congestionTaxCalculator.GetTax(new Car(), new DateTime[] { new DateTime(2013, 3, 27, 6, 0, 0) }));
            Assert.AreEqual(0, await  _congestionTaxCalculator.GetTax(new Car(), new DateTime[] { new DateTime(2013, 3, 28, 6, 30, 0) }));
            Assert.AreEqual(0, await  _congestionTaxCalculator.GetTax(new Car(), new DateTime[] { new DateTime(2013, 3, 31, 7, 30, 0) }));
            Assert.AreEqual(0, await  _congestionTaxCalculator.GetTax(new Car(), new DateTime[] { new DateTime(2013, 4, 29, 8, 0, 0) }));
            Assert.AreEqual(0, await  _congestionTaxCalculator.GetTax(new Car(), new DateTime[] { new DateTime(2013, 5, 1, 8, 30, 0) }));
            Assert.AreEqual(0, await  _congestionTaxCalculator.GetTax(new Car(), new DateTime[] { new DateTime(2013, 5, 7, 9, 30, 0) }));
            Assert.AreEqual(0, await  _congestionTaxCalculator.GetTax(new Car(), new DateTime[] { new DateTime(2013, 5, 8, 12, 30, 0) }));
            Assert.AreEqual(0, await  _congestionTaxCalculator.GetTax(new Car(), new DateTime[] { new DateTime(2013, 6, 4, 15, 0, 0) }));
            Assert.AreEqual(0, await  _congestionTaxCalculator.GetTax(new Car(), new DateTime[] { new DateTime(2013, 6, 5, 15, 30, 0) }));
            Assert.AreEqual(0, await  _congestionTaxCalculator.GetTax(new Car(), new DateTime[] { new DateTime(2013, 6, 20, 16, 30, 0) }));
            Assert.AreEqual(0, await  _congestionTaxCalculator.GetTax(new Car(), new DateTime[] { new DateTime(2013, 7, 1, 17, 30, 0) }));
            Assert.AreEqual(0, await  _congestionTaxCalculator.GetTax(new Car(), new DateTime[] { new DateTime(2013, 11, 1, 17, 30, 0) }));
            Assert.AreEqual(0, await _congestionTaxCalculator.GetTax(new Car(), new DateTime[] { new DateTime(2013, 12, 23, 13, 30, 0) }));
            Assert.AreEqual(0, await  _congestionTaxCalculator.GetTax(new Car(), new DateTime[] { new DateTime(2013, 12, 24, 13, 30, 0) }));
            Assert.AreEqual(0, await  _congestionTaxCalculator.GetTax(new Car(), new DateTime[] { new DateTime(2013, 12, 25, 13, 30, 0) }));
            Assert.AreEqual(0, await  _congestionTaxCalculator.GetTax(new Car(), new DateTime[] { new DateTime(2013, 12, 30, 13, 30, 0) }));
        }
        [TestMethod]
         public async Task It_should_return_tax_amount_0sek_in_the_month_of_july()
        {
            for (int i = 1; i <= 31; i++)
            {
                Assert.AreEqual(0, await  _congestionTaxCalculator.GetTax(new Car(), new DateTime[] {
                new DateTime(2013, 7, i, 6, 30, 0)
                 }));

            }
           
        }

        [TestMethod]
         public async Task It_should_return_max_toll_fee_60sek_in_a_day()
        {
            Assert.AreEqual(60, await  _congestionTaxCalculator.GetTax(new Car(), new DateTime[] {
                new DateTime(2013, 2, 1, 6, 0, 0),
                new DateTime(2013, 2, 1, 7, 0, 0),
                new DateTime(2013, 2, 1, 8, 0, 0),
                new DateTime(2013, 2, 1, 9, 0, 0),
                new DateTime(2013, 2, 1, 11, 0, 0),
                new DateTime(2013, 2, 1, 13, 0, 0),
                new DateTime(2013, 2, 1, 15, 0, 0),
                new DateTime(2013, 2, 1, 16, 0, 0),
                new DateTime(2013, 2, 1, 17, 0, 0),
                new DateTime(2013, 2, 1, 18, 0, 0) }));
        }

        [TestMethod]
         public async Task It_should_return_valid_tax_at_given_time_interval()
        {
            Assert.AreEqual(0,  await  _congestionTaxCalculator.GetTollFee( new DateTime (2013, 8, 1, 5, 0, 0) , new Car()));
            Assert.AreEqual(8,  await  _congestionTaxCalculator.GetTollFee(new DateTime(2013, 8, 1, 6, 0, 0), new Car()));
            Assert.AreEqual(13, await _congestionTaxCalculator.GetTollFee( new DateTime(2013, 8, 1, 6, 30, 0), new Car()));
            Assert.AreEqual(18, await _congestionTaxCalculator.GetTollFee( new DateTime(2013, 8, 1, 7, 30, 0) ,new Car()));
            Assert.AreEqual(13, await _congestionTaxCalculator.GetTollFee( new DateTime(2013, 8, 1, 8, 0, 0)  ,new Car()));
            Assert.AreEqual(8,  await  _congestionTaxCalculator.GetTollFee( new DateTime(2013, 8, 1, 8, 30, 0) ,new Car()));
            Assert.AreEqual(8,  await  _congestionTaxCalculator.GetTollFee( new DateTime(2013, 8, 1, 9, 30, 0) ,new Car()));
            Assert.AreEqual(8,  await  _congestionTaxCalculator.GetTollFee( new DateTime(2013, 8, 1, 12, 30, 0),new Car()));
            Assert.AreEqual(13, await _congestionTaxCalculator.GetTollFee( new DateTime(2013, 8, 1, 15, 0, 0) ,new Car()));
            Assert.AreEqual(18, await _congestionTaxCalculator.GetTollFee( new DateTime(2013, 8, 1, 15, 30, 0),new Car()));
            Assert.AreEqual(18, await _congestionTaxCalculator.GetTollFee( new DateTime(2013, 8, 1, 16, 30, 0),new Car()));
            Assert.AreEqual(13, await _congestionTaxCalculator.GetTollFee( new DateTime(2013, 8, 1, 17, 30, 0),new Car()));
            Assert.AreEqual(8,  await  _congestionTaxCalculator.GetTollFee( new DateTime(2013, 8, 1, 18, 0, 0) ,new Car()));
            Assert.AreEqual(0,  await  _congestionTaxCalculator.GetTollFee( new DateTime(2013, 8, 1, 18, 30, 0), new Car()));
        }

        [TestMethod]
         public async Task It_should_return_tax_0_when_it_is_weekends()
        {
            Assert.AreEqual(0, await _congestionTaxCalculator.GetTax(new Car(), new DateTime[] { new DateTime(2013, 5, 4, 12, 0, 0) }));//saturday
            Assert.AreEqual(0, await _congestionTaxCalculator.GetTax(new Car(), new DateTime[] { new DateTime(2013, 5, 5, 12, 0, 0) }));//sunday
        }

        [TestMethod]
         public async Task It_should_return_tax_0_when_it_is_a_tax_exempt_vehicles()
        {
            Assert.AreEqual(0, await _congestionTaxCalculator.GetTax(new Motorcycles(), new DateTime[] { new DateTime(2013, 2, 1, 12, 0, 0) }));
        }

        [TestMethod]
        public async Task It_should_return_true_when_it_is_a_tax_exempt_vehicles()
        {
            Assert.AreEqual(true, await _congestionTaxCalculator.IsTollFreeVehicle(new Motorcycles()));
        }
        [TestMethod]
        public async Task It_should_return_false_when_it_is_not_a_tax_exempt_vehicles()
        {
            Assert.AreEqual(false, await _congestionTaxCalculator.IsTollFreeVehicle(new Car()));
        }

        [TestMethod]
        public async Task It_should_return_true_when_it_is_not_a_tax_exempt_vehicles()
        {
            Assert.AreEqual(false, await _congestionTaxCalculator.IsTollFreeVehicle(new Car()));
        }
    }

}
