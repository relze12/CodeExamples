// ********RoostGPT********
/*
Test generated by RoostGPT for test test using AI Type Open AI and AI Model gpt-4

ROOST_METHOD_HASH=Register_2d12bfcaed
ROOST_METHOD_SIG_HASH=Register_56d1dea17d

   ########## Test-Scenarios ##########  

Scenario 1: Registering a Valid Service

Details:
  TestName: RegisterValidService.
  Description: This test is meant to check that the Register method can properly store a valid service in the services dictionary.
Execution:
  Arrange: Create an instance of SimpleServiceLocator and a mock service of any type (e.g., IService).
  Act: Invoke the Register method with the mock service as the parameter.
  Assert: Use NUnit assertions to check if the service was added to the services dictionary.
Validation:
  The assertion verifies that the service is successfully registered in the services dictionary. This is crucial for the proper functioning of the service locator, as it must be able to store and retrieve services.

Scenario 2: Registering a Null Service

Details:
  TestName: RegisterNullService.
  Description: This test is meant to check how the Register method handles null services.
Execution:
  Arrange: Create an instance of SimpleServiceLocator.
  Act: Invoke the Register method with null as the parameter.
  Assert: Use NUnit assertions to check if an appropriate exception is thrown.
Validation:
  The assertion verifies that an appropriate exception is thrown when trying to register a null service. This is important because a null service can't be used and should not be added to the services dictionary.

Scenario 3: Overwriting Existing Service

Details:
  TestName: OverwriteExistingService.
  Description: This test is meant to check if the Register method can overwrite a service that already exists in the services dictionary.
Execution:
  Arrange: Create an instance of SimpleServiceLocator and a mock service of any type. Register the mock service.
  Act: Invoke the Register method with another service of the same type.
  Assert: Use NUnit assertions to check if the original service was replaced with the new one in the services dictionary.
Validation:
  The assertion verifies that the Register method can overwrite an existing service. This is important because it allows updating the services in the service locator.

Scenario 4: Registering Different Types of Services

Details:
  TestName: RegisterDifferentTypesOfServices.
  Description: This test is meant to check if the Register method can store different types of services in the services dictionary.
Execution:
  Arrange: Create an instance of SimpleServiceLocator and mock services of different types.
  Act: Invoke the Register method with each of the mock services.
  Assert: Use NUnit assertions to check if all types of services were added to the services dictionary.
Validation:
  The assertion verifies that the Register method can store different types of services. This is crucial for the versatility of the service locator, as it needs to be able to handle any type of service.


*/

// ********RoostGPT********
using NUnit.Framework;
using Moq;
using SimpleConsoleApp;
using System;

namespace SimpleConsoleApp.Test
{
    [TestFixture]
    public class RegisterTest
    {
        [Test]
        public void RegisterValidService()
        {
            // Arrange
            var serviceLocator = new SimpleServiceLocator();
            var mockService = new Mock<IService>();

            // Act
            serviceLocator.Register(mockService.Object);

            // Assert
            Assert.AreEqual(mockService.Object, serviceLocator.DoGetInstance(typeof(IService), null));
        }

        [Test]
        public void RegisterNullService()
        {
            // Arrange
            var serviceLocator = new SimpleServiceLocator();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => serviceLocator.Register<IService>(null));
        }

        [Test]
        public void OverwriteExistingService()
        {
            // Arrange
            var serviceLocator = new SimpleServiceLocator();
            var mockService1 = new Mock<IService>();
            var mockService2 = new Mock<IService>();
            serviceLocator.Register(mockService1.Object);

            // Act
            serviceLocator.Register(mockService2.Object);

            // Assert
            Assert.AreEqual(mockService2.Object, serviceLocator.DoGetInstance(typeof(IService), null));
        }

        [Test]
        public void RegisterDifferentTypesOfServices()
        {
            // Arrange
            var serviceLocator = new SimpleServiceLocator();
            var mockService1 = new Mock<IService>();
            var mockService2 = new Mock<IAnotherService>();

            // Act
            serviceLocator.Register(mockService1.Object);
            serviceLocator.Register(mockService2.Object);

            // Assert
            Assert.AreEqual(mockService1.Object, serviceLocator.DoGetInstance(typeof(IService), null));
            Assert.AreEqual(mockService2.Object, serviceLocator.DoGetInstance(typeof(IAnotherService), null));
        }
    }
}
