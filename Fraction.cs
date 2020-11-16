// Version: 1.0
// Date: 11/15/2020
// Author: Yvonne Yeung

namespace Fraction
{
    public class Fraction
    {
        private int numerator;
        private int denominator;
            
        public Fraction ()
        {
            numerator = 0;
            denominator = 0;
        }

        public int GetNumerator() { return numerator; }
        public int GetDenominator() { return denominator; }
        public void SetNumerator(int numeratorToSet) { numerator = numeratorToSet; }
        public void SetDenominator(int denominatorToSet) { denominator = denominatorToSet; }
    }
}