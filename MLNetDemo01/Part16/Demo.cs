using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLNetDemo01.Part16
{
    public class Demo
    {
        public static void Execute()
        {
            MLContext context = new MLContext();

            //var columnToLoad = new TextLoader.Column[]
            //{
            //    new TextLoader.Column("YearsOfExperience",DataKind.Single,0),
            //    new TextLoader.Column("Salary",DataKind.Single,1),

            //};

            //IDataView dataView = context.Data.LoadFromTextFile(path: "Part16/Data.csv", hasHeader: true, separatorChar: ',',columns:columnToLoad);

            //IDataView dataView = context.Data.LoadFromTextFile<InputModel>(path: "Part16/Data.csv", hasHeader: true, separatorChar: ',');
            IDataView dataView = context.Data.LoadFromTextFile<InputModel>(path: "Part16/Data.tsv", hasHeader: false);

            //var estimator = context.Transforms.Concatenate("Features", new[] { "YearsOfExperience" });
            //var pipeline = estimator.Append(context.Regression.Trainers.OnlineGradientDescent(labelColumnName: "Salary"));

            //var model = pipeline.Fit(dataView);

            //var predictionEnginee = context.Model.CreatePredictionEngine<InputModel, ResultModel>(model);

            //var experience = new InputModel { YearsOfExperience = 6 };
            //var result = predictionEnginee.Predict(experience);

            //Console.WriteLine($"With Years of experice: {experience.YearsOfExperience}, Salary can be: {result.Salary}");

            var preview = dataView.Preview();
        }
    }
}
