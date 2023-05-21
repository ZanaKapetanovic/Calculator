using System;

namespace calc
{
    class Calculator
    {
        public static double add(double number1, double number2)
        {
            return number1 + number2;
        }
        public static double subtract(double number1, double number2)
        {
            return number1 - number2;
        }
        public static double mod(double number1, double number2)
        {
            int roundedNumber1 = Convert.ToInt32(Math.Floor(number1));
            int roundedNumber2 = Convert.ToInt32(Math.Floor(number2));
            return roundedNumber1 - (roundedNumber1 / roundedNumber2) * roundedNumber2;
        }
        public static double multiply(double number1, double number2)
        {
            return number1 * number2;
        }
        public static double divide(double number1, double number2)
        {
            if (number2 == 0)
            {
                Console.WriteLine("Division by zero is not allowed.");
                return Double.NaN;
            }
            return number1 / number2;
        }
        public static double pow(double number1, double number2)
        {
            double mem = 1;
            for (int i = 0; i < number2; i++)
            {
                mem *= number1;
            }
            return mem;
        }

        public static double squareRoot(double number1)
        {
            int counter = 0;
            while (counter <= number1 / 2)
            {
                if (Calculator.pow(counter, 2) == number1)
                {
                    return counter;
                }
                counter++;
            }
            return -1;
        }
        public void ExitProgram(string input)
        {
            if (input == "q" || input == "Q")
            {
                Console.WriteLine("Program is ended.");
                Environment.Exit(0);
            }
        }
        static List<double> numbersSaved = new List<double>();
        static void SaveResult(string inp, string lastInp)
        {
            if (inp.ToUpper() == "M")
            {
                double.TryParse(lastInp, out double lastResult);
                numbersSaved.Add(lastResult);
            }

            else if (inp.ToUpper() == "P")
            {
                if (numbersSaved.Count > 0)
                {
                    Console.WriteLine("Following numbers are saved: ");
                    for (int n = 0; n < numbersSaved.Count; n++)
                    {
                        Console.WriteLine($"{n + 1}: {numbersSaved[n]}");
                    }
                }
                else
                {
                    Console.WriteLine("There are no saved numbers!");
                }
            }
            else if (inp.ToUpper().StartsWith("R"))
            {
                if (int.TryParse(inp.Substring(1), out int n))
                {
                    if (n > 0 && n <= numbersSaved.Count)
                    {
                        var retrievedNumber = numbersSaved[n - 1];

                        Console.WriteLine($"{retrievedNumber}");
                    }
                    else
                    {
                        Console.WriteLine("Result does not exist at location.");
                    }
                }

            }

        }


        public static void Main(string[] args)
        {
            Calculator program = new Calculator();
            Console.WriteLine("This calculator consists of the following operations: + is sum operator, - is subtraction, * is multiplication, / is division, % is reminder(mod), ^ power function, and s is used to calculate square root of a single number.\n ");
            Console.WriteLine("By pressing '=' or 'enter', your operation will be successfully executed.\n");
            Console.WriteLine("If you want to calculate any operation except square root, enter number followed by operation and another number, with equal sign to obtain result. \n");
            Console.WriteLine("Every input should be separated by pressing enter.\n");
            Console.WriteLine("You can exit your program by pressing on q or Q character from the keyboard. \n");
            Console.WriteLine("Your next operation can be based on previous result, or you can enter new numbers and start another calculation regardless of your previous one. \n");
            Console.WriteLine("Press character M to save the last input/result and character P to list saved numbers. \n");

            string a = "";
            string equalSign = "";
            double number1 = 0.0;
            double number2 = 0.0;
            double result = 0.0;
            string operation = " ";
            string operation2 = " ";
 
            bool isNumber = false;
            while (isNumber == false)
            {
                a = Console.ReadLine().Trim();
                isNumber = double.TryParse(a, out number1);
                program.ExitProgram(a);
            }  
            while (true)
            {
                operation = Console.ReadLine();
                if (operation == "+" || operation == "-" || operation == "/" || operation == "*" || operation == "^" || operation == "%" || operation == "s")
                {
                    break;
                }
                program.ExitProgram(operation);

                if (operation.ToUpper() == "M" || operation.ToUpper() == "P" || operation.ToUpper().StartsWith("R"))
                {
                    SaveResult(operation, a);
                }
            }

            number1 = Convert.ToDouble(a);

            while (true)
            {
                if (operation != "s")
                {
                    isNumber = false;
                    while (true)
                    {
                        operation2 = Console.ReadLine();
                        isNumber = double.TryParse(operation2, out number2);
                        if (isNumber == true)
                        {
                            break;
                        }
                        program.ExitProgram(operation2);

                        if (operation2.ToUpper() == "M" || operation2.ToUpper() == "P" || operation2.ToUpper().StartsWith("R"))
                        {
                            SaveResult(operation2, number1.ToString());
                        }
                    }
                }
   
                while (true)
                {
                    equalSign = Console.ReadLine();
                    if (equalSign.ToUpper() == "M" || equalSign.ToUpper() == "P" || equalSign.ToUpper().StartsWith("R"))
                    {
                        SaveResult(equalSign, operation2);
                    }

                    if (equalSign == "=" || equalSign == "")
                    {
                        break;
                    }
                    program.ExitProgram(equalSign);

                }

                if (equalSign == "=" || equalSign == "")
                {
                    switch (operation)
                    {
                        case "+":
                            result = Calculator.add(number1, number2);
                            Console.WriteLine(result);
                            break;
                        case "-":
                            result = Calculator.subtract(number1, number2);
                            Console.WriteLine(result);
                            break;
                        case "*":
                            result = Calculator.multiply(number1, number2);
                            Console.WriteLine(result);
                            break;
                        case "/":
                            result = Calculator.divide(number1, number2);
                            Console.WriteLine(result);
                            break;
                        case "%":
                            result = Calculator.mod(number1, number2);
                            Console.WriteLine(result);
                            break;
                        case "^":
                            result = Calculator.pow(number1, number2);
                            Console.WriteLine(result);
                            break;
                        case "s":
                            result = Calculator.squareRoot(number1);
                            Console.WriteLine(result);
                            break;
                        default:
                            Console.WriteLine("Wrong input, please try again.\n");
                            break;
                    }

                }
               
                while (true)
                {
                    operation2 = Console.ReadLine();
                    program.ExitProgram(operation2);

                    bool checkNumber = double.TryParse(operation2, out number1);
                    if (checkNumber == false)
                    {
                        if (operation2 == "+" || operation2 == "-" || operation2 == "/" || operation2 == "*" || operation2 == "^" || operation2 == "%" || operation2 == "s")
                        {
                            number1 = result;

                        }
                    }
                }
            }
        }

    }
}

   


   