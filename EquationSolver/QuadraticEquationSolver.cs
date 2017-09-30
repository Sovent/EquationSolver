using System;
using System.Text.RegularExpressions;

namespace EquationSolver
{
  public static class QuadraticEquationSolver
  {
    public static double[] SolveEquation(string equation)
    {
      var parsedCoefficients = ParseEquation(equation);
      if (parsedCoefficients == null)
      {
        return null;
      }

      var discriminant = FindDiscriminant(parsedCoefficients);
      var rootsCount = CountRoots(discriminant);
      
      switch (rootsCount)
      {
        case 2:
          return new[] 
          {
            FindFirstRoot(parsedCoefficients, discriminant),
            FindSecondRoot(parsedCoefficients, discriminant)
          };
        case 1:
          return new[]
          {
            FindFirstRoot(parsedCoefficients, discriminant)
          };
        default:
          return null;
      }
    }

    public static int[] ParseEquation(string rawEquation)
    {
      if (string.IsNullOrWhiteSpace(rawEquation))
      {
        return null;
      }

      var equationRegex = new Regex(@"^(-?\d+)x\^2([\+-]\d+)x([\+-]\d+)=0$");
      var match = equationRegex.Match(rawEquation);
      if (!match.Success)
      {
        return null;
      }

      var coefficients = new[]
      {
        int.Parse(match.Groups[1].Value),
        int.Parse(match.Groups[2].Value),
        int.Parse(match.Groups[3].Value)
      };

      if (coefficients[0] == 0)
      {
        return null;
      }

      return coefficients;
    }

    public static int FindDiscriminant(int[] coefficients)
    {
      var a = coefficients[0];
      var b = coefficients[1];
      var c = coefficients[2];

      return b * b - 4 * a * c;
    }

    public static int CountRoots(int discriminant)
    {
      if (discriminant < 0)
      {
        return 0;
      }

      if (discriminant > 0)
      {
        return 2;
      }

      return 1;
    }

    public static double FindFirstRoot(int[] coefficients, int discriminant)
    {
      var a = coefficients[0];
      var b = coefficients[1];
      var c = coefficients[2];

      return (-b + Math.Sqrt(discriminant)) / (2 * a);
    }

    public static double FindSecondRoot(int[] coefficients, int discriminant)
    {
      var a = coefficients[0];
      var b = coefficients[1];
      var c = coefficients[2];

      return (-b - Math.Sqrt(discriminant)) / (2 * a);
    }
    



  }
}
