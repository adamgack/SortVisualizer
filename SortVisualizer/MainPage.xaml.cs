using SortVisualizer.Sorts;
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
using System.Threading.Tasks;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace SortVisualizer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        int count = 0;

        GeneratedArray generatedArray;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void OnGenerateArrayClick(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button) sender;
            generatedArray = new GeneratedArray(100);
        }

        private void createBars()
        {
            Canvas.Children.Clear();
            double maxWidth = Canvas.Width;
            double maxHeight = Canvas.Height;
            double barWidth = maxWidth / generatedArray.array.Length;
            double heightIncrement = maxHeight / generatedArray.array.Length;
            for (int i = 0; i < generatedArray.array.Length; i++)
            {
                double barHeight = (generatedArray.array[i] * heightIncrement);
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

        private void OnBubbleSort(object sender, RoutedEventArgs e)
        {
            BubbleSort bubbleSort = new BubbleSort(generatedArray.array);

            new AnimationTimer(Iterate, bubbleSort).Start();
         
        }

        public void Iterate(BubbleSort bubbleSort)
        {
            if (bubbleSort.CanIterate())
            {
                count += 1;
                Debug.WriteLine(count);
                generatedArray.array = bubbleSort.Iterate();
                createBars();
            }
        }
    }
}
