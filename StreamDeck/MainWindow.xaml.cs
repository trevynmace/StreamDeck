using System;
using System.Collections.Generic;
using System.Linq;
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
using WindowsInput;
using WindowsInput.Native;

namespace StreamDeck
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private InputSimulator simulator = new InputSimulator();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void TwitchPrimeInstructions_Click(object sender, RoutedEventArgs e)
        {
            var modifierKeys = new List<VirtualKeyCode>
            {
                VirtualKeyCode.CONTROL,
                VirtualKeyCode.LMENU,
                VirtualKeyCode.SHIFT
            };

            var keys = new List<VirtualKeyCode>
            {
                VirtualKeyCode.VK_1
            };

            TypeKeys(keys, modifierKeys);
        }

        private void PrimeSubShareInstructions_Click(object sender, RoutedEventArgs e)
        {
            var modifierKeys = new List<VirtualKeyCode>
            {
                VirtualKeyCode.CONTROL,
                VirtualKeyCode.LMENU,
                VirtualKeyCode.SHIFT
            };

            var keys = new List<VirtualKeyCode>
            {
                VirtualKeyCode.VK_2
            };

            TypeKeys(keys, modifierKeys);
        }

        private void TypeKeys(IEnumerable<VirtualKeyCode> keys, IEnumerable<VirtualKeyCode> modifierKeys = null)
        {
            if (modifierKeys != null && modifierKeys.Any())
            {
                simulator.Keyboard.ModifiedKeyStroke(modifierKeys, keys);
            }
            else
            {
                foreach (var virtualKeyCode in keys)
                {
                    simulator.Keyboard.KeyPress(virtualKeyCode);
                }
            }
        }
    }
}
