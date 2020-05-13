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

        Action<int> func;

        public AnimationTimer(Action<int> func)
        {
            this.func = func;
        }

        public void Start()
        {
            Debug.WriteLine("Started Animation timer");

            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 3); 
            dispatcherTimer.Start();
           
        }

        void dispatcherTimer_Tick(object sender, object e) //Executes every frame
        {
            func(0);
        }
    }
}
