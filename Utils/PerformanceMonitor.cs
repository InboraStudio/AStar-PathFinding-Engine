using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace AStarPathfindingEngine.Utils
{
     // Performance tracking utility
public class PerformanceMonitor // its for performance monitoring only
    {
        private Stopwatch stopwatch;

        public PerformanceMonitor()
        {
            stopwatch = new Stopwatch();
        }

        public void Start()
        {
            stopwatch.Reset();
            stopwatch.Start();
        }

        public void Stop()
        {
            stopwatch.Stop();
        }

        public long ElapsedMilliseconds
        {
            get { return stopwatch.ElapsedMilliseconds; }
        }

        public long ElapsedTicks
        {
            get { return stopwatch.ElapsedTicks; }
        }

        public void PrintResults(string label = "")
        {
            Console.WriteLine($"{label} - Elapsed: {ElapsedMilliseconds}ms ({ElapsedTicks} ticks)");
        }
    }
}
