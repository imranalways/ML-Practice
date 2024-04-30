using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLNetDemo01.Part20
{
    public class Demo
    {
        public static void Execute()
        {
            MLContext context = new MLContext();
            
            var textLoader = context.Data.CreateTextLoader<InputModel>(separatorChar:',');

            IDataView dataView = textLoader.Load("Part20/TestData/Data-1.csv", "Part20/TestData/Data-2.csv");

            var list = context.Data.CreateEnumerable<InputModel>(dataView, false).ToList();

            using(FileStream stream = new FileStream("Part20/DataDownload.tsv", FileMode.OpenOrCreate))
            {
                context.Data.SaveAsText(dataView, stream);
            }
            using (FileStream stream = new FileStream("Part20/DataDownload.csv", FileMode.OpenOrCreate))
            {
                context.Data.SaveAsText(dataView, stream,separatorChar:',',headerRow:false,schema:false);
            }
            using (FileStream stream = new FileStream("Part20/DataDownload.bin", FileMode.OpenOrCreate))
            {
                context.Data.SaveAsBinary(dataView, stream);
            }

        }
    }
}
