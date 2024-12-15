using Microsoft.VisualStudio.TestTools.UnitTesting;
using HumidityAndPM.Function;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace HumidityAndPM.Function.Tests
{
    [TestClass()]
    public class CallHumidityAndPMDataTests
    {
        [TestMethod()]
        public async Task GetCallHumidityAndPMTestAsync()
        {
            var Pm = new CallHumidityAndPMData();
            var test = await Pm.GetCallHumidityAndPM(1000);


            Assert.Fail();
        }
    }
}