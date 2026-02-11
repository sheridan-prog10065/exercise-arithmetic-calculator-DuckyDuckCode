using Microsoft.Maui.Graphics.Text;
using System.Diagnostics;

namespace MathCalculator;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }
    private void OnCalculate(object sender, EventArgs e)
    {
        // obtain user input: left operand, right operand, and operator

        string leftOperandInput = _txtLeftOp.Text;
        double leftOperand = double.Parse(leftOperandInput);

        double rightOperand = double.Parse(_txtRightOp.Text);

        string opInput = (string)_pckOperand.SelectedItem;
        char op = opInput[0];

        // Check the operator given. Perform decided operation on the operands
        double result = PerformArithmaticOperation(op, leftOperand, rightOperand);

        // Display the arithmetic expression in the output control

        string expression = $"{leftOperand} {op} {rightOperand} = {result}";
        _txtMathExp.Text = expression;
    }

    private double PerformArithmaticOperation(char op, double leftOperand, double rightOperand)
    {
        //check the type of operand and perform the corresponding operation
        double result;

        switch (op)
        {
            case '+':
                 result = PerformAddition(leftOperand, rightOperand);
                 break;
                

            case '-':
                result = PerformSubtraction(leftOperand, rightOperand);
                break;

           
            case '*':
                result = PerformMultiplication(leftOperand, rightOperand);
                break;

            case '/':
                result = PerformDivision(leftOperand, rightOperand);
                break;

            case '%':
                result = PerformDivRemainder(leftOperand, rightOperand);
                break;


            default:
                Debug.Assert(false, "Unknown arithmetic operation. Default result returned");
                result = 0;
                break;
          

        }
        return result;


    }

    private double PerformAddition(double leftOperand, double rightOperand)
    {
        double result;
        result = leftOperand + rightOperand;
        return result;
    }

    private double PerformSubtraction(double leftOperand, double rightOperand)
    {
        return leftOperand - rightOperand;
    }

    private double PerformMultiplication(double leftOperand, double rightOperand)
    {
        return leftOperand * rightOperand;
    }

    private double PerformDivision(double leftOperand, double rightOperand)
    {
        //Check whether the dicision operation is integer or real division
        string divOp = (string)_pckOperand.SelectedItem;
        if (divOp.Contains("int", StringComparison.OrdinalIgnoreCase))
        {
            //perform integer division which is done when both operands are integers
            int leftIntOp = (int)leftOperand;
            int rightIntOp = (int)rightOperand;
            int result = leftIntOp / rightIntOp;
            return result;
        }
        else
        {
            return leftOperand / rightOperand;
        }
        
    }

    private double PerformDivRemainder(double leftOperand, double rightOperand)
    {
        return leftOperand % rightOperand;
    }

}