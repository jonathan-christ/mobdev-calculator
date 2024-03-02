using System.Globalization;

class BasicCalculator
{
    private Tuple<double, string> result;
    private readonly Dictionary<string, Func<double, double, double>> operations;
    private string display;

    public BasicCalculator()
    {
        result = Constants.EmptyState;
        display = Constants.Empty;
        operations = new(){
            {"+", Operations.Add},
            {"-", Operations.Subtract},
            {"*", Operations.Multiply},
            {"/", Operations.Divide},
        };

        while (true)
        {
            string input = Console.ReadLine() ?? Constants.Empty;

            if ("1234567890.".Contains(input))
            {
                display = (display.Equals(Constants.Empty) ? "" : display) + input;
                continue;
            }
            else if ("+-*/-".Contains(input))
            {
                double operand2 = Validate();
                Calculate(operand2, input);
                display = Constants.Empty;
                continue;
            }

            switch (input)
            {
                case "C":
                    Clear();
                    break;
                case "DEL":
                    Delete();
                    break;
                case "=":
                    Equals();
                    break;
            }
        }
    }

    private double Validate()
    {
        double temp = double.TryParse(display, out double num) ? num : 0;
        Console.WriteLine("Parsed Number: " + temp);
        return temp;
    }

    private void Calculate(double operand2, string op = "none")
    {
        if (!result.Item2.Equals("none"))
        {
            result = new(operations[result.Item2](result.Item1, operand2), op);
        }
        else
        {
            result = new(operand2, op);
        }
    }

    public string Display
    {
        get { return display; }
    }

    public double Result
    {
        get { return result.Item1; }
    }

    public void Clear()
    {
        display = Constants.Empty;
        result = Constants.EmptyState;
    }

    public void Delete()
    {
        display = display.Remove(display.Length - 1, 1);
    }

    public void Equals()
    {
        Calculate(Validate());

        display = result.Item1.ToString();
        Console.WriteLine(display);
    }

}