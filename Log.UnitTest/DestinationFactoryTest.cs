using System;
using System.Linq;
using Log.Application.Factory;
using Log.Interface;
using NUnit.Framework;

namespace Log.UnitTest
{
    public class DestinationFactoryTest
    {
        [Test]
        public void FactoryShouldReturnDestinationImplementation()
        {
            foreach (var implementation in 
                from DestinationFactoryOption option in 
                    Enum.GetValues(typeof(DestinationFactoryOption)) 
                select DestinationFactory.Make(option))
            {
                Assert.IsInstanceOf<IDestination>(implementation);
            }
        }
    }
}