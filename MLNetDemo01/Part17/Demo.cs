using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLNetDemo01.Part17
{
    public class Demo
    {
        public static void Execute()
        {
            MLContext context = new MLContext();

            //IDataView dataView = context.Data.LoadFromTextFile<InputModel>(path: "Part17/TestData/*", hasHeader: false, separatorChar: ',');
            //var preview = dataView.Preview();

            var textLoader = context.Data.CreateTextLoader<InputModel>(separatorChar:',');

            IDataView dataView = textLoader.Load("Part17/TestData/Data-1.csv", "Part17/TestData/Data-2.csv");
            var preview = dataView.Preview();
        }
    }
}
