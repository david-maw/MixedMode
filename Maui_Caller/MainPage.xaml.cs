using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Maui_Caller
{
    public partial class MainPage : ContentPage
    {
        [DllImport(@"..\..\..\..\..\..\x64\Debug\MixedMode.dll", EntryPoint =
        "mixed_mode_multiply", CallingConvention = CallingConvention.StdCall)]
        public static extern int Multiply(int x, int y);

        [DllImport(@"..\..\..\..\..\..\x64\Debug\MixedMode.dll", EntryPoint =
        "mixed_mode_divide", CallingConvention = CallingConvention.StdCall)]
        public static extern int Divide(int x, int y);

        public MainPage()
        {
            InitializeComponent();
            Directory.SetCurrentDirectory(AppContext.BaseDirectory);
        }

        protected override void OnAppearing()
        {
            try
            {
                var nullVar = BindingContext; // should be null
                _ = nullVar.GetHashCode(); // force a fault
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception: " + ex);
            }
        }

        private void OnButtonClicked(object sender, EventArgs e)
        {
            Debug.WriteLine("Current Directory = " + Directory.GetCurrentDirectory());
            Debug.WriteLine("Base Directory = " + AppContext.BaseDirectory);
            int result = Multiply(7, 7);
            Debug.WriteLine("The multiply answer is {0}", result);

            try
            {
                var nullVar = BindingContext; // should be null
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