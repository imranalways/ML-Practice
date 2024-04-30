using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLNetDemo01.Part28
{
    public class InputModel
    {
        [LoadColumn(0)]
        public bool Sentiment { get; set; }
        [LoadColumn(1)]
        public string SentimentText { get; set; }
    }
}
