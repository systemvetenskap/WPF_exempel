﻿using Kortflip.Model;
using Kortflip.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Kortflip.ViewModel
{
    public class MainViewModel : baseViewModel
    {
        public bool CardFlipped { get; set; } = true;

        public ICommand Flip { get; set; }

        //private ImageSource _imgSource;

        //public ImageSource ImgSource
        //{
        //    get { return _imgSource; }
        //    set
        //    {
        //        _imgSource = value;
        //        OnPropertyChanged(nameof(_imgSource));
        //    }
        //}
        private BitmapImage _picture;
        public BitmapImage Picture
        {
            get { return _picture; }
            set
            {
                _picture = value;
                OnPropertyChanged("Picture");
            }
 }
        public MainViewModel()
        {
            flipCard();
            Flip = new RelayCommand(flipCard);
        }

        public void flipCard() 
        {
            Card card = new Card();

            if (CardFlipped == true)
            {

                Picture =  new BitmapImage(new Uri(card.frontOfCard, UriKind.Relative));
                CardFlipped = false;
            }
            else
            {

                Picture = new BitmapImage(new Uri(card.backOfCard, UriKind.Relative));
                CardFlipped = true;
            }
        }

    }
}
