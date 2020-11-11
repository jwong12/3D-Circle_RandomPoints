using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

// Developer: James Wong
// Date: Nov 10, 2020
namespace RandomPoints
{
    class Program
    { 
        private static System.Timers.Timer pointTimer;
        private static long pointCount = 0;
        private static List<RandomPoint> pointList = new List<RandomPoint>();
        private static StringBuilder sb = new StringBuilder();

        static void Main(string[] args)
        {
            Console.SetWindowSize(140, 30);
            SetPointTimer();
            Console.ReadLine();
        }

        private static void SetPointTimer()
        {
            // Create a timer with a 200ms interval.
            pointTimer = new System.Timers.Timer(200);
            pointTimer.Elapsed += OnTimedRandomPointEvent;
            pointTimer.AutoReset = true;
            pointTimer.Enabled = true;
        }

        private static void OnTimedRandomPointEvent(Object source, ElapsedEventArgs e)
        {
            RandomPoint randomPoint = new RandomPoint();

            if (pointList.Count > 0)
            {
                randomPoint.GetNextRandomPoint(pointList[pointList.Count - 1].currPoint);
            }
            else
            {
                randomPoint.GetNextRandomPoint(new Point());
            }

            pointList.Add(randomPoint);
            string log = randomPoint.GetLogInfo();
            sb.Append(log);
            Console.Write(log);

            if (++pointCount % 15 == 0) 
            {
                // Write to JSON file
                string jsonResult = JsonConvert.SerializeObject(pointList);
                string filePath = @"..\..\RandomPoints.json";

                if (File.Exists(filePath))
                {
                    File.Delete(filePath);                    
                }

                using (var writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine(jsonResult.ToString());
                    writer.Close();
                }                
            }

            if (pointCount % 20 == 0)
            {
                // Write to log file
                File.AppendAllText(@"..\..\log.txt", sb.ToString());                
                sb.Clear();
            }
        }
    }
}
