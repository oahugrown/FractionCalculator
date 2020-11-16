using System;
using FractionCalculator;

// Version: 1.0
// Date: 11/15/2020
// Author: Yvonne Yeung
// Note: Failed cases will print in red.
// Limitations: RunTests() uses the generic Random seed that System has to offer.
//				Due Random not being able to produce a negative values, this current
//				version of the automation only accepts positive numbers hence the
//				choice of unsigned ints.
// Potential upgrades: Support negative values in randomized automation tests.
//                     Support permutation ranges for both fractions.
//                     Refactor CheckOperations() methods to condense repetitve code.

namespace AutomationFractionCalculator
{

    public enum OperationType
    {
        ADDITION,
        SUBTRACTION,
        MULTIPLICATION,
        DIVISION
    }

    public class AutomationFractionCalculator
    {
        FractionCalculator.FractionCalulator fractionCalulator;
        Fraction.Fraction firstFraction;
        Fraction.Fraction secondFraction;

        public AutomationFractionCalculator()
        {
            firstFraction = new Fraction.Fraction();
            secondFraction = new Fraction.Fraction();
            fractionCalulator = new FractionCalulator();
        }

        private void FailedTestCase(string type)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.Write("------------FAILED  " + type + " TESTCASE HERE------------");
            Console.ForegroundColor = ConsoleColor.White;
        }

        // Vetting the inverse of the results addition
        private bool CheckAddition(Fraction.Fraction first, Fraction.Fraction second)
        {
            // Saving the original data
            Fraction.Fraction firstFraction = first;
            Fraction.Fraction secondFraction = second;
            System.Console.Write("\n" + fractionCalulator.ReducedFraction(firstFraction).GetNumerator().ToString() + '/' + fractionCalulator.ReducedFraction(firstFraction).GetDenominator().ToString()
                + " + " + fractionCalulator.ReducedFraction(secondFraction).GetNumerator().ToString() + '/' + fractionCalulator.ReducedFraction(secondFraction).GetDenominator().ToString());

            // Grab the results from the calculator, 
            // MODIFY: Changing method to something else will produce failed test cases
            // Fraction.Fraction actualResults = fractionCalulator.Subtractive(first, second);
            Fraction.Fraction actualResults = fractionCalulator.Addition(first, second);
            System.Console.Write(" = " + fractionCalulator.ReducedFraction(actualResults).GetNumerator().ToString() + '/' + fractionCalulator.ReducedFraction(actualResults).GetDenominator().ToString());

            // Run the inverse function of the calculator to pull the expected results
            Fraction.Fraction expectedResult = fractionCalulator.Subtraction(actualResults, secondFraction);

            // Compare
            if ((expectedResult.GetNumerator() == firstFraction.GetNumerator()) && (expectedResult.GetDenominator() == firstFraction.GetDenominator()))
                return true;
            // if numerators are both 0, the value is 0
            else if ((expectedResult.GetNumerator() == 0) && (expectedResult.GetNumerator() == 0))
                return true;
            else
            {
                // try reducting both fractions and check for failing
                expectedResult = fractionCalulator.ReducedFraction(expectedResult);
                firstFraction = fractionCalulator.ReducedFraction(firstFraction);
                if ((expectedResult.GetNumerator() == firstFraction.GetNumerator()) && (expectedResult.GetDenominator() == firstFraction.GetDenominator()))
                    return true;
            }
            return false;
        }

        // Vetting the inverse of the results subtraction
        private bool CheckSubtraction(Fraction.Fraction first, Fraction.Fraction second)
        {
            // Saving the original data
            Fraction.Fraction firstFraction = first;
            Fraction.Fraction secondFraction = second;
            System.Console.Write("\n" + fractionCalulator.ReducedFraction(firstFraction).GetNumerator().ToString() + '/' + fractionCalulator.ReducedFraction(firstFraction).GetDenominator().ToString()
                + " - " + fractionCalulator.ReducedFraction(secondFraction).GetNumerator().ToString() + '/' + fractionCalulator.ReducedFraction(secondFraction).GetDenominator().ToString());

            // Grab the results from the calculator
            // MODIFY: Changing method to something else will produce failed test cases
            // Fraction.Fraction actualResults = fractionCalulator.Addition(first, second);
            Fraction.Fraction actualResults = fractionCalulator.Subtraction(first, second);
            System.Console.Write(" = " + actualResults.GetNumerator().ToString() + '/' + actualResults.GetDenominator().ToString());

            // Run the inverse function of the calculator to pull the expected results
            Fraction.Fraction expectedResult = fractionCalulator.Addition(actualResults, secondFraction);

            // Compare
            if ((expectedResult.GetNumerator() == firstFraction.GetNumerator()) && (expectedResult.GetDenominator() == firstFraction.GetDenominator()))
                return true;
            
            // if numerators are both 0, the value is 0
            else if ((expectedResult.GetNumerator() == 0) && (expectedResult.GetNumerator() == 0))
                return true;
            
            else
            {
                // try reducing both fractions and check for failing
                expectedResult = fractionCalulator.ReducedFraction(expectedResult);
                firstFraction = fractionCalulator.ReducedFraction(firstFraction);
                if ((expectedResult.GetNumerator() == firstFraction.GetNumerator()) && (expectedResult.GetDenominator() == firstFraction.GetDenominator()))
                    return true;
            }
            return false;
        }

        // Vetting the inverse of the results multiplication
        private bool CheckMultiplication(Fraction.Fraction first, Fraction.Fraction second)
        {
            // Saving the original data
            Fraction.Fraction firstFraction = first;
            Fraction.Fraction secondFraction = second;
            System.Console.Write("\n" + fractionCalulator.ReducedFraction(firstFraction).GetNumerator().ToString() + '/' + fractionCalulator.ReducedFraction(firstFraction).GetDenominator().ToString()
                + " * " + fractionCalulator.ReducedFraction(secondFraction).GetNumerator().ToString() + '/' + fractionCalulator.ReducedFraction(secondFraction).GetDenominator().ToString());

            // Grab the results from the calculator
            // MODIFY: Changing method to something else will produce failed test cases
            //Fraction.Fraction actualResults = fractionCalulator.Addition(first, second);
            Fraction.Fraction actualResults = fractionCalulator.Multiplication(first, second);
            System.Console.Write(" = " + actualResults.GetNumerator().ToString() + '/' + actualResults.GetDenominator().ToString());

            // Run the inverse operations of the function to pull the expected results
            Fraction.Fraction expectedResults = new Fraction.Fraction();
            expectedResults.SetDenominator(actualResults.GetDenominator() / second.GetDenominator());
            // Protect from divide against zero
            if (second.GetNumerator() != 0)
                expectedResults.SetNumerator(actualResults.GetNumerator() / second.GetNumerator());


            // Compare
            if ((expectedResults.GetNumerator() == firstFraction.GetNumerator()) && (expectedResults.GetDenominator() == firstFraction.GetDenominator()))
                return true;

            // if numerators are both 0, the value is 0
            else if ((expectedResults.GetNumerator() == 0) && (expectedResults.GetNumerator() == 0))
                return true;
            
            else
            {
                // try reducing both fractions and check for failing
                expectedResults = fractionCalulator.ReducedFraction(expectedResults);
                firstFraction = fractionCalulator.ReducedFraction(firstFraction);
                if ((expectedResults.GetNumerator() == firstFraction.GetNumerator()) && (expectedResults.GetDenominator() == firstFraction.GetDenominator()))
                    return true;
            }
            return false;
        }


        // Vetting the inverse of the results division
        private bool CheckDivision(Fraction.Fraction first, Fraction.Fraction second)
        {
            // Saving the original data
            Fraction.Fraction firstFraction = first;
            Fraction.Fraction secondFraction = second;
            System.Console.Write("\n" + fractionCalulator.ReducedFraction(firstFraction).GetNumerator().ToString() + '/' + fractionCalulator.ReducedFraction(firstFraction).GetDenominator().ToString()
                + " / " + fractionCalulator.ReducedFraction(secondFraction).GetNumerator().ToString() + '/' + fractionCalulator.ReducedFraction(secondFraction).GetDenominator().ToString());

            // Grab the results from the calculator
            // MODIFY: Changing method to something else will produce failed test cases
            //Fraction.Fraction actualResults = fractionCalulator.Addition(first, second);
            Fraction.Fraction actualResults = fractionCalulator.Division(first, second);
            System.Console.Write(" = " + actualResults.GetNumerator().ToString() + '/' + actualResults.GetDenominator().ToString());

            // actual results turns out to be a non-real fraction so pass it
            if (actualResults.GetDenominator() == 0 && second.GetNumerator() == 0)
                return true;


            // Run the inverse operations of the function to pull the expected results
            Fraction.Fraction expectedResults = new Fraction.Fraction();
            expectedResults.SetDenominator(actualResults.GetDenominator() / second.GetNumerator());
            expectedResults.SetNumerator(actualResults.GetNumerator() / second.GetDenominator());

            // Compare
            if ((expectedResults.GetNumerator() == firstFraction.GetNumerator()) && (expectedResults.GetDenominator() == firstFraction.GetDenominator()))
                return true;

            // if numerators are both 0, the value is 0
            else if ((expectedResults.GetNumerator() == 0) && (expectedResults.GetNumerator() == 0))
                return true;

            else
            {
                // try reducing both fractions and check for failing
                expectedResults = fractionCalulator.ReducedFraction(expectedResults);
                firstFraction = fractionCalulator.ReducedFraction(firstFraction);
                if ((expectedResults.GetNumerator() == firstFraction.GetNumerator()) && (expectedResults.GetDenominator() == firstFraction.GetDenominator()))
                    return true;
            }
            return false;
        }

        // Creates a random numerator and denominator for both fractions between minRange (inclusive), and maxRange (exclusive).
        // Requires an (OperationType)operationType to determine the operation to test, ie. Subraction. Requires a length of
        // the amount of tests to run.
        public void RunTests(uint minRange, uint maxRange, OperationType operationType, uint length)
        {
            Random random = new Random();
            for (int i = 0; i < length; ++i)
            {
                // Generate random fractions
                secondFraction.SetDenominator(random.Next((int)minRange, (int)maxRange));
                secondFraction.SetNumerator(random.Next((int)minRange, (int)maxRange));
                firstFraction.SetNumerator(random.Next((int)minRange, (int)maxRange));
                firstFraction.SetDenominator(random.Next((int)minRange, (int)maxRange));

                // Run the operation checks based on the operationType submitted.
                if (operationType == OperationType.ADDITION)
                {
                    if (!CheckAddition(firstFraction, secondFraction))
                        FailedTestCase("ADDITIVE");
                }
                else if (operationType == OperationType.SUBTRACTION)
                {
                    if (!CheckSubtraction(firstFraction, secondFraction))
                        FailedTestCase("SUBTRACTIVE");
                }
                else if (operationType == OperationType.MULTIPLICATION)
                {
                    if (!CheckMultiplication(firstFraction, secondFraction))
                        FailedTestCase("MULTIPLICATION");
                }
                else
                {
                    if (!CheckDivision(firstFraction, secondFraction))
                        FailedTestCase("DIVISION");
                }
            }
            System.Console.WriteLine("\nDone!---------------------------");
        }
    }
}
