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

namespace ScadaSystem.Usc {
    /// <summary>
    /// Dialog.xaml 的交互逻辑
    /// </summary>
    public partial class Dialog : UserControl {
        public Dialog() {
            InitializeComponent();
        }

        public Dialog(string content) {
            InitializeComponent();
            TextBlock.Text = content;
        }
        public Dialog(string content, MessageBoxButton button = MessageBoxButton.OK) {
            InitializeComponent();
            TextBlock.Text = content;
            if (button == MessageBoxButton.OK) {
                this.stackPanelOk.Visibility = Visibility.Visible;
            } else {
                this.stackPanelYesOrNo.Visibility = Visibility.Visible;
            }
        }
    }
}
