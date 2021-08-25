using Dice_3D.ViewModels;
using System.Windows;


namespace Dice_3D
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
            DataContext = viewModel;
        }
        MainViewModel viewModel = new MainViewModel();
    }
}
