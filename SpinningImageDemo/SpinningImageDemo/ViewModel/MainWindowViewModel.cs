using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SpinningImageDemo.ViewModel
{
   public class MainWindowViewModel : BaseViewModel
    {
        public ICommand GetFoodSpin { get; set; }
        public List<string> AvailableFood { get; set; } = new List<string>() { "Spaghetti och köttfärssås", "Fläsksida med ärtpuré", "Vietnamesiska pannkakor", "Torskrygg med pressad potatis" };
        public string FoodToEat { get; set; }

        private static readonly Random RandomNumber = new Random();
        public MainWindowViewModel()
        {
            GetFoodSpin = new RelayCommand(FoodSpin);
        }
        private void FoodSpin()
        {
            FoodToEat = "";
            int randomNumber = GetRandomNumber();
            Task.Delay(1000).ContinueWith(t => GetResultFromSpin(randomNumber));
        }
        private int GetRandomNumber()
        {
            return RandomNumber.Next(0, 4);
        }
        private void GetResultFromSpin(int numberFromSpin)
        {
            FoodToEat = AvailableFood[numberFromSpin];
        }
    }
}
