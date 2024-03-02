using System.ComponentModel;

namespace _3_Calculator;

class Program : IProgram
{
    // every button press = push stack
    //   - '.' is clickable once
    //   - delete is pop
    //   - clear is makenull
    // on operation press = read number made
    // calculate result on second operation press
    // 
    // OPTIONAL
    // - keep operation on stack
    private BasicCalculator bc;
    private Stack<char> input;

    public Program()
    {
        input = new Stack<char>();
        bc = new();
    }
    static void Main(string[] args)
    {
        Program p = new();

    }

    public void ReadNumber()
    {
        Console.WriteLine("Input:");
        input = new Stack<char>((Console.ReadLine() ?? "").ToCharArray()); //no ui purposes

    }

    public void Interface()
    {
        // int choice = -1;
        // double a = 0, b = 0;

        // Console.WriteLine("CALCULATOR APP\n");

        // do
        // {
        //     Console.WriteLine("Operations:");
        //     Console.WriteLine("[1] Add");
        //     Console.WriteLine("[2] Subtract");
        //     Console.WriteLine("[3] Multiply");
        //     Console.WriteLine("[4] Divide");
        //     Console.WriteLine("[5] Exit");

        //     Console.Write("Choice: ");
        //     if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 5)
        //     {
        //         Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.\n");
        //         continue;
        //     }
        //     Console.WriteLine();

        //     if (choice == 5)
        //     {
        //         break;
        //     }
        //     a = InputHandler("Num 1");
        //     b = InputHandler("Num 2");

        //     switch (choice)
        //     {
        //         case 1:
        //             bc.Add(a, b);
        //             break;
        //         case 2:
        //             bc.Subtract(a, b);
        //             break;
        //         case 3:
        //             bc.Multiply(a, b);
        //             break;
        //         case 4:
        //             if (b != 0)
        //             {
        //                 bc.Divide(a, b);
        //             }
        //             else
        //             {
        //                 Console.WriteLine("Cannot divide by 0");
        //             }
        //             break;
        //         default:
        //             break;
        //     }

        //     Console.Write("\n\nRESULT: ");
        //     Console.WriteLine(bc.Result.ToString(bc.Result % 1 == 0 ? "0" : "0.00"));
        //     Console.WriteLine();

        // } while (choice != 5);
    }

    public double InputHandler(string operandName)
    {
        string input, choice;
        while (true)
        {
            try
            {
                if (bc.Result != 0)
                {
                    Console.Write("\nUse previous result for {0}? (Y/N) ", operandName);
                    choice = Console.ReadLine() ?? "";
                    if (choice.ToLower().Equals("y"))
                    {
                        return bc.Result;
                    }
                }
                Console.Write("Input {0}: ", operandName);
                input = Console.ReadLine() ?? "";
                return Convert.ToDouble(input);
            }
            catch
            {
                Console.Write("Invalid input!");
            }
        }
    }
}

interface IProgram
{
    public void Interface();
    public double InputHandler(string operandName);
}