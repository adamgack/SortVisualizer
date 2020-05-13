using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SortVisualizer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void OnClick(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            clickedButton.Content = "Clicked";
            int[] data = {5, 12, 9, 2, 16, 4, 14, 11, 1, 7, 13, 8, 10, 3, 15, 6};
            createBars(data);
        }

        private void createBars(int[] data)
        {
            Canvas.Children.Clear();
            double maxWidth = Canvas.Width;
            double maxHeight = Canvas.Height;
            double barWidth = maxWidth / data.Length;
            double heightIncrement = maxHeight / data.Length;
            for (int i = 0; i < data.Length; i++)
            {
                double barHeight = (data[i] * heightIncrement);
                var bar = new Rectangle();
                Windows.UI.Color barColor = new Windows.UI.Color();
                barColor.R = Convert.ToByte((barHeight / maxHeight) * 255);
                barColor.B = Convert.ToByte(((maxHeight - barHeight) / maxHeight) * 255);
                barColor.A = 255;
                Canvas.Children.Add(bar);
                bar.Name = "Bar" + i;
                bar.Fill = new SolidColorBrush(barColor);
                bar.Stroke = new SolidColorBrush(barColor);
                bar.Margin = new Thickness(i * barWidth, maxHeight - barHeight, 0, 0);
                bar.Width = barWidth;
                bar.Height = barHeight;
            }
        }
    }
}
