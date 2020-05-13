using System;
using Windows.UI.Xaml;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SortVisualizer.Sorts;
using System.Diagnostics;

namespace SortVisualizer
{
    public class AnimationTimer
    {

        int count = 0;

        DispatcherTimer dispatcherTimer;

        Action<BubbleSort> func;

        BubbleSort bubbleSort;

        public AnimationTimer(Action<BubbleSort> func, BubbleSort bubbleSort)
        {
            this.func = func;
            this.bubbleSort = bubbleSort;
        }

        public void Start()
        {
            Debug.WriteLine("Started timer");

            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
            dispatcherTimer.Start();
           
        }

        void dispatcherTimer_Tick(object sender, object e)
        {
            count += 1;
            
            if (bubbleSort.CanIterate())
            {
                func(bubbleSort);
            }
            else
            {
                Debug.WriteLine(count);
                dispatcherTimer.Stop();
            }
            
        }
    }
}
