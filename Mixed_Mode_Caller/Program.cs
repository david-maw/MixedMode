using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Mixed_Mode_Calling_App
{
    public class Program
    {
        [DllImport(@"..\..\..\..\..\x64\Debug\MixedMode.dll", EntryPoint =
        "mixed_mode_multiply", CallingConvention = CallingConvention.StdCall)]
        public static extern int Multiply(int x, int y);

        [DllImport(@"..\..\..\..\..\x64\Debug\MixedMode.dll", EntryPoint =
        "mixed_mode_divide", CallingConvention = CallingConvention.StdCall)]
        public static extern int Divide(int x, int y);

        public static void Main(string[] args)
        {
            Debug.WriteLine("Current Directory = " + Directory.GetCurrentDirectory());
            int result = Multiply(7, 7);
            Console.WriteLine("The answer is {0}", result);
            int surprise = Divide(7, 0);
            Console.ReadKey();
        }
    }
}