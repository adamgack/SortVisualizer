using Windows.System.Threading;
using System;
using System.Diagnostics;
using SortVisualizer.Sorts;
using SortVisualizer;

public class IteratorTimer
{
    Func<int[]> action>;

    BubbleSort bubbleSort;

    ThreadPoolTimer timer;

    public IteratorTimer(Func<int[]> action, BubbleSort bubbleSort)
    {
        this.action = action;
        this.bubbleSort = bubbleSort;
    }

    public void Start()
    {
        timer = ThreadPoolTimer.CreatePeriodicTimer(TimerElapsedHandler, new TimeSpan(0, 0, 0, 0, 1));
    }

    private void TimerElapsedHandler(ThreadPoolTimer timer) //Executes every 1 ms
    {
        if (bubbleSort.CanIterate())
        {
            action(bubbleSort);
        } else
        {
            timer.Cancel();
        }
    }
}