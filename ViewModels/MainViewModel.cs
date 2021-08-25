using Dice_3D.Models;
using Dice_3D.ViewModels.Base;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Media.Media3D;

namespace Dice_3D.ViewModels
{
    public class MainViewModel:Base.baseViewModel
    {
        //Konstruktor som skapar vår tärning genom att instansiera Dice och ta DiceModel (tärningen).
        //Sätter metoden RotateDice i BtnRotate.
        public MainViewModel()
        {
            Dice = new Dice().DiceModel;
            BtnRotate = new RelayCommand(RotateDice);
        }
        public Model3DGroup Dice { get; set; }
        public ICommand BtnRotate { get; set; }
       
        
        private void RotateDice()
        {
            //Man kan animera på många olika sätt, detta är bara ett snabbt exempel taget från https://docs.microsoft.com/en-us/dotnet/desktop/wpf/graphics-multimedia/3-d-graphics-overview?view=netframeworkdesktop-4.8
            RotateTransform3D myRotateTransform = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(-1, -1, 0), 180));
            Vector3DAnimation myVectorAnimation = new Vector3DAnimation(new Vector3D(1, 1, 1), new Duration(TimeSpan.FromMilliseconds(5000)));
            myRotateTransform.Rotation.BeginAnimation(AxisAngleRotation3D.AxisProperty, myVectorAnimation);

            //Skapar en Transform3DGroup i vår Dice.Tansform.
            Dice.Transform = new Transform3DGroup();

            //Gör denna till en variabel så att vi kan använda den
            Transform3DGroup transformGroup = (Transform3DGroup) Dice.Transform;

            //Lägger till animationen i vår Transform3DGroup som är länkad till vår tärning. 
            transformGroup.Children.Add(myRotateTransform);
        }
    }
}
