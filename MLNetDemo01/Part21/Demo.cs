using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLNetDemo01.Part21
{
    internal class Demo
    {
        public static void Execute()
        {
            MLContext context = new MLContext();

            IDataView dataView = context.Data.LoadFromTextFile<InputModel>(path:"Part21/Data-1.csv",hasHeader:false,separatorChar:',');

            var shuffledData = context.Data.ShuffleRows(dataView);
            var preview = shuffledData.Preview();

            var skipedRows = context.Data.SkipRows(dataView, 5);
            preview = skipedRows.Preview();

            var takeRows = context.Data.TakeRows(dataView,8);
            preview = takeRows.Preview();

            var filterByValue = context.Data.FilterRowsByColumn(dataView,nameof(InputModel.YearsOfExperience),lowerBound:3,upperBound:5.5);
            preview = filterByValue.Preview();

            var filterByMissingValue = context.Data.FilterRowsByMissingValues(dataView, nameof(InputModel.Salary));

            preview = filterByMissingValue.Preview();
        }
    }
}
