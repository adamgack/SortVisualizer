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

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void OnGenerateArrayClick(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button) sender;
        }

        private void CreateBars(int[] genArray)
        {
            int[] array = genArray;
            double maxWidth = Canvas.Width;
            double maxHeight = Canvas.Height;
            double barWidth = maxWidth / array.Length;
            double heightIncrement = maxHeight / array.Length;
            for (int i = 0; i < array.Length; i++)
            {
                double barHeight = (array[i] * heightIncrement);
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

        private void UpdateBars(int[] genArray)
        {
            int[] array = genArray;
            double maxWidth = Canvas.Width;
            double maxHeight = Canvas.Height;
            double barWidth = maxWidth / array.Length;
            double heightIncrement = maxHeight / array.Length;
            UIElementCollection bars = Canvas.Children;
            for (int i = 0; i < array.Length; i++)
            {
                Rectangle bar = (Rectangle)bars[i];
                double barHeight = (array[i] * heightIncrement);
                Windows.UI.Color barColor = new Windows.UI.Color();
                barColor.R = Convert.ToByte((barHeight / maxHeight) * 255);
                barColor.B = Convert.ToByte(((maxHeight - barHeight) / maxHeight) * 255);
                barColor.A = 255;
                bar.Fill = new SolidColorBrush(barColor);
                bar.Stroke = new SolidColorBrush(barColor);
                bar.Margin = new Thickness(i * barWidth, maxHeight - barHeight, 0, 0);
                bar.Width = barWidth;
                bar.Height = barHeight;
            }
        }

        private void OnBubbleSort(object sender, RoutedEventArgs e)
        {
            GeneratedArray generatedArray = new GeneratedArray(128);
            CreateBars(generatedArray.array);

            BubbleSort bubbleSort = new BubbleSort(generatedArray.array);

            new AnimationTimer(Render).Start();

            new IteratorTimer(Iterate, bubbleSort).Start();
         
        }

        public int[] Iterate(BubbleSort bubbleSort)
        {
            if (bubbleSort.CanIterate())
            {
                return bubbleSort.Iterate();
            } else
            {
                Debug.WriteLine(generatedArray);
            }
        }

        public void Render(int[] genArray)
        {
            UpdateBars(genArray);
        }
    }
}
