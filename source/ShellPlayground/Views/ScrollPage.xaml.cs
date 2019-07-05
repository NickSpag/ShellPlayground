using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ShellPlayground.Views
{
    public partial class ScrollPage : ContentPage
    {
        private double _fixedHeaderTextTopGuideline;

        public ScrollPage()
        {
            InitializeComponent();

            Scroller.PropertyChanged += OnScrollViewPropertyChanged;

            //listen for first size change on image, which is the element loading.
            CarImage.SizeChanged += OnCarImageSizeChanged;

            //listen for first size change on label, which is the initial reposition based on the image loading
            FixedHeaderText.SizeChanged += OnFixedHeaderTextChanged;
        }

        private void OnFixedHeaderTextChanged(object sender, System.EventArgs e)
        {
            FixedHeaderText.SizeChanged -= OnFixedHeaderTextChanged;

            //On first header change, which is initiated by the image loading and its SizeChanged property being changed,
            //take note of the top position of our visible box, in local cordinates (i.e., with respect to the bounds of the parent view)
            //which we'll later compare during scrolling to see if the scrollview's position is above the visible bounds
            _fixedHeaderTextTopGuideline = FixedHeaderText.Y;
        }

        private void OnCarImageSizeChanged(object sender, System.EventArgs e)
        {
            CarImage.SizeChanged -= OnCarImageSizeChanged;

            //When the image has been loaded, reposition the header to the bottom of said image
            FixedHeaderText.Margin = new Thickness(0, CarImage.Height - FixedHeaderText.Height, 0, 0);
        }

        private void OnScrollViewPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals(ScrollView.ScrollYProperty.PropertyName) &&
                sender is ScrollView scrollView)
            {
                var yScrollPosition = scrollView.ScrollY;

                if (yScrollPosition < _fixedHeaderTextTopGuideline)
                {
                    FixedHeaderText.TranslationY = (0 - yScrollPosition);
                }
                else
                {
                    FixedHeaderText.TranslationY = (0 - _fixedHeaderTextTopGuideline);
                }
            }
        }
    }
}
