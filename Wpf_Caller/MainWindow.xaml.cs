using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf_Caller
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [DllImport(@"..\..\..\..\x64\Debug\MixedMode.dll", EntryPoint =
        "mixed_mode_multiply", CallingConvention = CallingConvention.StdCall)]
        public static extern int Multiply(int x, int y);

        [DllImport(@"..\..\..\..\x64\Debug\MixedMode.dll", EntryPoint =
        "mixed_mode_divide", CallingConvention = CallingConvention.StdCall)]
        public static extern int Divide(int x, int y);

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Current Directory = " + Directory.GetCurrentDirectory());
            int result = Multiply(7, 7);
            Debug.WriteLine("The multiply answer is {0}", result);

            try
            {
                var nullVar = this.BindingGroup; // should be null
                _ = nullVar.GetHashCode(); // force a fault
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception: " + ex);
            }
            try
            {
                result = Divide(7, 0);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception: " + ex);
            }
        }
    }
}
