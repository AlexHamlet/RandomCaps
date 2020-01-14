using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.InteropServices;

namespace SQLEnhancer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);
        private bool active;
        private Random r;
        public MainWindow()
        {
            InitializeComponent();
            active = false;
            r = new Random();
        }

        private void Enhance(object sender, RoutedEventArgs e)
        {
            active = true;
            btnEnhance.Visibility = Visibility.Hidden;
            btnNormal.Visibility = Visibility.Visible;
            Task.Run(Caps);
        }

        private void Normal(object sender, RoutedEventArgs e)
        {
            active = false;
            btnNormal.Visibility = Visibility.Hidden;
            btnEnhance.Visibility = Visibility.Visible;
        }

        private void Caps()
        {
            while (active)
            {
                const int KEYEVENTF_EXTENDEDKEY = 0x1;
                const int KEYEVENTF_KEYUP = 0x2;
                keybd_event(0x14, 0x45, KEYEVENTF_EXTENDEDKEY, (UIntPtr)0);
                keybd_event(0x14, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, (UIntPtr)0);
                int randTime = r.Next(50, 1000);
                Thread.Sleep(randTime);
            }
        }

    }
}
