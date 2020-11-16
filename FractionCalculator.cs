using System;
using Fraction;

// Version: 1.0
// Date: 11/15/2020
// Author: Yvonne Yeung
// Note: Failed cases will print in red.
// Limitations: RunTests() uses the generic Random seed that System has to offer.
//				Due Random not being able to produce a negative values, this current
//				version of the automation only accepts positive numbers hence the
//				choice of unsigned ints.
// Potential upgrades: Support negative values in automation tests.
//                     Support permutation ranges for both fractions.
//                     Refactor CheckOperations() methods to condense repetitve code.

namespace FractionCalculator
{

    public class FractionCalulator
    {

        // Reduce the fraction down to its lowest terms before my teacher gets mad at me
       public Fraction.Fraction ReducedFraction(Fraction.Fraction fractionToReduce)
        {
            // Protection against 0
            if (fractionToReduce.GetDenominator() == 0)
                return fractionToReduce;

            int gcd = GreatestCommonDenominator(fractionToReduce.GetNumerator(), fractionToReduce.GetDenominator());
            if (gcd !=0)
            {
                fractionToReduce.SetNumerator(fractionToReduce.GetNumerator() / gcd);
                fractionToReduce.SetDenominator(fractionToReduce.GetDenominator() / gcd);
            }
            if (gcd < 0)
            {
                fractionToReduce.SetNumerator(fractionToReduce.GetNumerator() * -1);
                fractionToReduce.SetDenominator(fractionToReduce.GetDenominator() * -1);
            }
            return fractionToReduce;
        }

        // Verify the fraction is valid
        bool IsNoneZeroDenominator(int denominator)
        {
            if (denominator == 0)
            {
                throw new DivideByZeroException("0 can not be a denominator!");
            }
            return true;
        }

        // Find the Greatest common denominator of the fractions numerator and denominator
        private int GreatestCommonDenominator(int numerator, int denominator)
        {
            while (numerator != denominator)
            {
                if (numerator > denominator)
                    numerator -= denominator;
                if (denominator > numerator)
                    denominator -= numerator;
                if (numerator <= 1)
                    break;
            }
            
            return numerator;
        }

        // Takes two fractions, adds them and returns the results
        public Fraction.Fraction Addition(Fraction.Fraction first, Fraction.Fraction second)
        {
            Fraction.Fraction results = new Fraction.Fraction();

            // check for errors
            if (!IsNoneZeroDenominator(first.GetDenominator()) || !IsNoneZeroDenominator(second.GetDenominator()))
                return results;

            // if not a common denominator do the thing
            if (first.GetDenominator() != second.GetDenominator())
            {
                int firstMultiple = first.GetDenominator();
                first.SetDenominator(first.GetDenominator() * second.GetDenominator());
                first.SetNumerator(first.GetNumerator() * second.GetDenominator());
                second.SetDenominator(firstMultiple * second.GetDenominator());
                second.SetNumerator(firstMultiple * second.GetNumerator());
            }

            // Do the math
            results.SetNumerator(first.GetNumerator() + second.GetNumerator());
            results.SetDenominator(first.GetDenominator());

            return results;
        }

        // Takes two fractions, subtracts the second from the first and returns the results
        public Fraction.Fraction Subtraction(Fraction.Fraction first, Fraction.Fraction second)
        {
            Fraction.Fraction results = new Fraction.Fraction();

            // check for errors
            if (!IsNoneZeroDenominator(first.GetDenominator()) || !IsNoneZeroDenominator(second.GetDenominator()))
                return results;

            // if not a common denominator do the thing
            if (first.GetDenominator() != second.GetDenominator())
            {
                int firstMultiple = first.GetDenominator();
                first.SetDenominator(first.GetDenominator() * second.GetDenominator());
                first.SetNumerator(first.GetNumerator() * second.GetDenominator());
                second.SetDenominator(firstMultiple * second.GetDenominator());
                second.SetNumerator(firstMultiple * second.GetNumerator());
            }

            // Do the math
            results.SetNumerator(first.GetNumerator() - second.GetNumerator());
            results.SetDenominator(first.GetDenominator());

            // Return the reduced version of the results
            return results;
        }

        // Takes two fractions, multiplies them and returns the results
        public Fraction.Fraction Multiplication(Fraction.Fraction first, Fraction.Fraction second)
        {
            Fraction.Fraction results = new Fraction.Fraction();

            // check for errors
            if (!IsNoneZeroDenominator(first.GetDenominator()) || !IsNoneZeroDenominator(second.GetDenominator()))
                return results;

            // Do the math
            results.SetNumerator(first.GetNumerator() * second.GetNumerator());
            results.SetDenominator(first.GetDenominator() * second.GetDenominator());

            // Return the reduced version of the results
            return results;
        }

        // Takes two fractions, divides the first with the second and returns the results
        public Fraction.Fraction Division(Fraction.Fraction first, Fraction.Fraction second)
        {
            Fraction.Fraction results = new Fraction.Fraction();

            // check for errors
            if (!IsNoneZeroDenominator(first.GetDenominator()) || !IsNoneZeroDenominator(second.GetDenominator()))
                return results;

            // Do the math
            results.SetNumerator(first.GetNumerator() * second.GetDenominator());
            results.SetDenominator(first.GetDenominator() * second.GetNumerator());

            // Return the reduced version of the results
            return results;
        }
    }
}
