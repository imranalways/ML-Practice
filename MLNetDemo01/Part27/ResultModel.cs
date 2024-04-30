using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLNetDemo01.Part27
{
    internal class ResultModel
    {
        [ColumnName("PredictLabel")]
        public bool WillDelayBy15Minutes { get; set; }
        public float Score { get; set; }
    }
}
