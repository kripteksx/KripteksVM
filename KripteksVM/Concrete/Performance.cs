using System;
using System.Diagnostics;

namespace KripteksVM.Concrete
{
    public class Performance
    {
        public int controllerElapsedTimeMs = 0;
        public int varRefreshTickMs = 0;
        public int varRefreshAliveCount = 0;
        public float gpuUsage = 0;
        public TimeSpan stopWatchCycleElapsed;
        public Stopwatch stopWatchCycleTimer = new Stopwatch();

        public Performance()
        {
            this.controllerElapsedTimeMs = 0;
            this.varRefreshTickMs = 0;
            this.varRefreshAliveCount = 0;
            this.gpuUsage = 0;
        }
    }
}
