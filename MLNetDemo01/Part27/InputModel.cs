using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLNetDemo01.Part27
{
    internal class InputModel
    {
        [LoadColumn(0)]
        public string Origin { get; set; }
        [LoadColumn(1)]
        public string Destination { get; set; }
        [LoadColumn(2)]
        public float DepartureTime { get; set; }
        [LoadColumn(3)]
        public float ExpectedArrivalTime { get; set; }
        [LoadColumn(4)]
        public float OriginalArrivalTime { get; set; }
        [LoadColumn(5)]
        public float DelayMinutes { get; set; }
        [LoadColumn(6)]
        public bool IsDelayBy15Minutes { get; set; }
    }
}
