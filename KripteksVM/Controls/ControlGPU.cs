using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using System.Threading.Tasks;

namespace KripteksVM.Controls
{
    public class ControlGPU
    {
        /*
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    var gpuCounters = GetGPUCounters();
                    var gpuUsage = GetGPUUsage(gpuCounters);
                    Console.WriteLine(gpuUsage);
                    continue;
                }
                catch { }
                
            }
        }*/

        public float fbGetGPUUsage()
        {
            float fGPUUsage = 0;

            try
            {
                var gpuCounters = GetGPUCounters();
                fGPUUsage = GetGPUUsage(gpuCounters);
            }
            catch
            {

            }

            return fGPUUsage;

        }

        public static List<PerformanceCounter> GetGPUCounters()
        {
            var category = new PerformanceCounterCategory("GPU Engine");
            var counterNames = category.GetInstanceNames();

            var gpuCounters = counterNames
                                .Where(counterName => counterName.EndsWith("engtype_3D"))
                                .SelectMany(counterName => category.GetCounters(counterName))
                                .Where(counter => counter.CounterName.Equals("Utilization Percentage"))
                                .ToList();

            return gpuCounters;
        }

        public static float GetGPUUsage(List<PerformanceCounter> gpuCounters)
        {
            gpuCounters.ForEach(x => x.NextValue());
            
            var result = gpuCounters.Sum(x => x.NextValue());

            return result;
        }
    }
}
