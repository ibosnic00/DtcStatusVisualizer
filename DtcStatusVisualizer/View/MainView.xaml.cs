using DtcStatusVisualizer.ViewModel;
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

namespace DtcStatusVisualizer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainView_Loaded;
            Closing += MainView_Closing;
        }

        private void MainView_Loaded(object sender, RoutedEventArgs e)
        {
            // you can use pattern matching here later

            var mainVM = DataContext as MainViewModel;

            if (mainVM == null)
                throw new Exception("Data context in main view is not valid.");
        }

        private void MainView_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var userDecision = MessageBox.Show("Are you sure you want to exit?", "Warning", MessageBoxButton.YesNo);
            if (userDecision == MessageBoxResult.Yes)
                e.Cancel = false;
            else
                e.Cancel = true;
        }
    }

}
