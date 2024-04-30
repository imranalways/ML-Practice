using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLNetDemo01.Part25
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

            if (!File.Exists("Part25/ResultData.zip"))
                context.Model.Save(model, dataView.Schema, "Part25/ResultData.zip");

            var savedFile = context.Model.Load("Part25/ResultData.zip", out DataViewSchema schema);

            var predictEnginee = context.Model.CreatePredictionEngine<InputModel, ResultModel>(savedFile);

            var experience = new InputModel { YearsOfExperience = 2 };

            var predict = predictEnginee.Predict(experience);
            Console.WriteLine($"With Years of experice: {experience.YearsOfExperience}, Salary can be: {predict.Salary}");

        }
    }
}
