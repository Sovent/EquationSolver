using EquationSolver;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EquationSolverTests
{
  [TestClass]
  public class QuadraticEquationSolverTests
  {
    [TestMethod]
    public void ParseEquationWithPositiveCoefficients_ShouldReturnPositiveIntegers()
    {
      var equation = "3x^2+4x+1=0";
      var expectedCoefficients = new[] { 3, 4, 1 };

      var actualCoefficients = QuadraticEquationSolver.ParseEquation(equation);

      CollectionAssert.AreEqual(expectedCoefficients, actualCoefficients);
    }

    [TestMethod]
    public void ParseEquationWithNegativeA_ShouldReturnNegativeA()
    {
      var equation = "-3x^2+4x+1=0";
      var expectedCoefficients = new[] { -3, 4, 1 };

      var actualCoefficients = QuadraticEquationSolver.ParseEquation(equation);

      CollectionAssert.AreEqual(expectedCoefficients, actualCoefficients);
    }

    [TestMethod]
    public void ParseEquationWithAEqualZero_ShouldReturnNull()
    {
      var equation = "0x^2+4x+1=0";

      var actualCoefficients = QuadraticEquationSolver.ParseEquation(equation);

      Assert.IsNull(actualCoefficients);
    }

    [TestMethod]
    public void ParseNonQuadraticEquation_ShouldReturnNull()
    {
      var equation = "4x+1=0";

      var actualCoefficients = QuadraticEquationSolver.ParseEquation(equation);

      Assert.IsNull(actualCoefficients);
    }

    [TestMethod]
    public void ParseMisspelledEquation_ShouldReturnNull()
    {
      var equation = "-5x^2+x3-4=0";

      var actualCoefficients = QuadraticEquationSolver.ParseEquation(equation);

      Assert.IsNull(actualCoefficients);
    }

    [TestMethod]
    public void ParseNonFormalEquation_ShouldReturnNull()
    {
      var equation = "2x^2+5x-3=2";

      var actualCoefficients = QuadraticEquationSolver.ParseEquation(equation);

      Assert.IsNull(actualCoefficients);
    }

    [TestMethod]
    public void FindDiscriminantForCoefficients_ShouldCalculateDiscriminant()
    {
      var coefficients = new[] { 1, 4, 2 };
      var expectedDiscriminant = 8;

      var actualDiscriminant = QuadraticEquationSolver.FindDiscriminant(coefficients);

      Assert.AreEqual(expectedDiscriminant, actualDiscriminant);
    }

    [TestMethod]
    public void CountRootsForNegativeDiscriminant_ReturnsZero()
    {
      var discriminant = -5;
      var expectedRootsCount = 0;

      var actualRootsCount = QuadraticEquationSolver.CountRoots(discriminant);

      Assert.AreEqual(expectedRootsCount, actualRootsCount);
    }

    [TestMethod]
    public void CountRootsForZeroDiscriminant_ReturnsOne()
    {
      var discriminant = 0;
      var expectedRootsCount = 1;

      var actualRootsCount = QuadraticEquationSolver.CountRoots(discriminant);

      Assert.AreEqual(expectedRootsCount, actualRootsCount);
    }

    [TestMethod]
    public void CountRootsForPositiveDiscriminant_ReturnsTwo()
    {
      var discriminant = 5;
      var expectedRootsCount = 2;

      var actualRootsCount = QuadraticEquationSolver.CountRoots(discriminant);

      Assert.AreEqual(expectedRootsCount, actualRootsCount);
    }

    [TestMethod]
    public void FindFirstRoot_CalculateRootCorrectly()
    {
      var coefficients = new[] { 2, 5, 2 };
      var discriminant = 9;
      var expectedFirstRoot = -0.5;

      var actualFirstRoot = QuadraticEquationSolver.FindFirstRoot(coefficients, discriminant);

      Assert.AreEqual(expectedFirstRoot, actualFirstRoot);
    }

    [TestMethod]
    public void FindSecondRoot_CalculateRootCorrectly()
    {
      var coefficients = new[] { 2, 5, 2 };
      var discriminant = 9;
      var expectedSecondRoot = -2;

      var actualSecondRoot = QuadraticEquationSolver.FindSecondRoot(coefficients, discriminant);

      Assert.AreEqual(expectedSecondRoot, actualSecondRoot);
    }

    [TestMethod]
    public void SolveEquationWithZeroDiscriminant_ReturnsOneRoot()
    {
      var equation = "2x^2+4x+2=0";
      var expectedRootsCount = 1;

      var roots = QuadraticEquationSolver.SolveEquation(equation);
      var actualRootsCount = roots.Length;

      Assert.AreEqual(expectedRootsCount, actualRootsCount);
    }

    [TestMethod]
    public void SolveEquationWithPositiveDiscriminant_ReturnsTwoRoots()
    {
      var equation = "2x^2+5x+2=0";
      var expectedRootsCount = 2;

      var roots = QuadraticEquationSolver.SolveEquation(equation);
      var actualRootsCount = roots.Length;

      Assert.AreEqual(expectedRootsCount, actualRootsCount);
    }

    [TestMethod]
    public void SolveEquationWithNegativeDiscriminant_ReturnsNull()
    {
      var equation = "1x^2+2x+3=0";

      var roots = QuadraticEquationSolver.SolveEquation(equation);

      Assert.IsNull(roots);
    }
  }
}
