using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLNetDemo01.Part13
{
    public class ResultModel
    {
        [ColumnName("Score")]
        public float Salary { get; set; }
    }
}
