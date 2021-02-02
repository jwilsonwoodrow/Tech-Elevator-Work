using Exceptions.Classes;
using System;

namespace Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            #region DoSomethingDangerous
            /* 
            * try/catch blocks will also catch Exceptions that are 
            * thrown from method called further down the stack 
            */
            #endregion

            #region DoMathFun
            //DoMathFun();
            //Console.ReadLine();
            #endregion

            #region A template for error-handling...
            try
            {
                // Do some work here...
            }
            catch (ArgumentNullException e)
            {
                // catch most specific Exceptions first
            }
            catch (Exception e)
            {
                // (optional) catch more general exceptions later
                // (optional) re-throw the same exception so it can be caught further up the stack
                throw;
            }
            finally
            {
                // (optional) Do work that should execute whether the above succeeded or failed
            }
            #endregion

            Console.ReadKey();
        }

        private static int DoSomethingDangerous(int a, int b)
        {
            int result = a / b;
            return result;
        }

        private static void DoMathFun()
        {
            try
            {
                MathFun math = new MathFun();
                Console.WriteLine(math.Average(new int[] { }));
                Console.WriteLine(math.ParseAndAdd("23, 45, 65"));
            }
            catch (Exception exc)
            {
                Console.WriteLine($"ERROR!!! {exc.Message}");
            }
            finally
            {
                Console.WriteLine("Running the final block...");
            }
        }

    }
}
