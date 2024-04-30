using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLNetDemo01.Part24
{
    internal class Demo
    {
        public static void Execute()
        {
            MLContext context = new MLContext();
            IDataView dataView = context.Data.LoadFromTextFile<InputModel>(path: "Part24/Data-1.csv", separatorChar: ',');

            var estimator = context.Transforms.Concatenate("Features", new[] { "YearsOfExperience" });

            var pipeling = estimator.Append(context.Regression.Trainers.Sdca(labelColumnName: "Salary", maximumNumberOfIterations: 100));

            var model = pipeling.Fit(dataView);

            //context.Model.Save(model, dataView.Schema, "Part24/ResultModel.zip");

            //using(FileStream stream = new FileStream("Part24/ResultModel.zip", FileMode.OpenOrCreate))
            //{
            //    context.Model.Save(model, dataView.Schema, stream);
            //}

            var file = new MultiFileSource("Part24/Data-1.csv");

            var dataLoader = context.Data.CreateTextLoader<InputModel>(hasHeader: false,separatorChar:',',dataSample:file);
            context.Model.Save(model, dataLoader, "Part24/ResultModel.zip");

        }
    }
}
