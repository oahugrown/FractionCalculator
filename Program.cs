using System;
using AutomationFractionCalculator;

class Program
{
    public const uint CONST_MINRANGE = 0;
    public const uint CONST_MAXRANGE = 10;
    public const uint CONST_TESTLENGTH = 1000;


    static void Main(string[] args)
    {
        AutomationFractionCalculator.AutomationFractionCalculator automationFractionCalculator = new AutomationFractionCalculator.AutomationFractionCalculator();
        automationFractionCalculator.RunTests(CONST_MINRANGE, CONST_MAXRANGE, OperationType.ADDITION, CONST_TESTLENGTH);
        automationFractionCalculator.RunTests(CONST_MINRANGE, CONST_MAXRANGE, OperationType.SUBTRACTION, CONST_TESTLENGTH);
        automationFractionCalculator.RunTests(CONST_MINRANGE, CONST_MAXRANGE, OperationType.MULTIPLICATION, CONST_TESTLENGTH);
        automationFractionCalculator.RunTests(CONST_MINRANGE, CONST_MAXRANGE, OperationType.DIVISION, CONST_TESTLENGTH);
    }
}
