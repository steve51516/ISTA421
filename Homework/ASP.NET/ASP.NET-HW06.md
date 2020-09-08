# ASP.NET Core 3 Homework 06

1. What is unit testing as defined by the book?
  - Tests the behavior of the application
2. What is the convention for creating unit tests in ASP.NET Core applications?
  - The convention is to name the unit test project <ApplicationName>.Tests
3. Name three unit test project tools used for ASP.NET Core applications.
  - **mstest** This template creates a project configured for the MS Test framework, which is produced by Microsoft.
  - **nunit** This template creates a project configured for the NUnit framework.
  - **xunit** This template creates a project configured for the XUnit framework.
4. What is the convention for naming unit tests in ASP.NET Core applications?
  - the name of the test methods describes what the test does
5. What is the convention for naming the test classes in ASP.NET Core? What is the convention for naming the methods in the test classes?
  - the name of the class describes what is being tested.
  - the name of the test methods describes what the test does.
6. What is the purpose of the Fact attribute in Xunit? (not in book) What is the purpose of the Theory attribute in Xunit?
  - Every method annotated with Fact will be marked as a test and run by xUnit.net:
  - expects one or more DataAttribute instances to supply the values for a Parameterized Test's method arguments.
7. Describe the different elements of the AAA testing pattern.
  - **Arrange**: refers to setting up the conditions for the test
  - **Act**: refers to performing the test
  - **Assert**: refers to verifying that the result was the one that was expected.
8. Describe the use of the methods in the Assert class. Describe the purpose, parameters, and return value of the Assert.Equals() method.
  - `Equal(expected, result)` This method asserts that the result is equal to the expected outcome. There are overloaded versions of this method for comparing different types and for comparing collections. There is also a version of this method that accepts an additional argument of an object that implements the IEqualityComparer<T> interface for comparing objects.
9. What is the key to isolating a component for testing?
  - The key to isolating components is to use C# interfaces
10. What is a mocking package? What does it do?
  - mocking package, which makes it easy to create fake—or mock—objects for tests
  - allowed me to remove the fake implementation of the IDataSource interface and replace it with a few lines of code.
11. (not in book) What is the difference between the Setup() and the SetupGet() methods of Moq?
  - `Setup()` can be used for mocking a method or a property.
  - `SetupGet()` is specifically for mocking the getter of a property.