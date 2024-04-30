using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLNetDemo01.Part28
{
    public class Demo
    {
        public static void Execute()
        {
            MLContext context = new MLContext();

            var trainingDataView = context.Data.LoadFromTextFile<InputModel>(path:"Part28/Data.tsv",hasHeader:true);

            var pipeline = context.Transforms.Text.FeaturizeText("Features", nameof(InputModel.SentimentText))
                            .Append(context.BinaryClassification.Trainers.AveragedPerceptron(
                                labelColumnName:nameof(InputModel.Sentiment),numberOfIterations:100));

            var model = pipeline.Fit(trainingDataView);

            var predictionEnginee = context.Model.CreatePredictionEngine<InputModel, ResultModel>(model);

            var input = new InputModel { SentimentText = "Met some amazing people at the conference today" };
            PrintResult(predictionEnginee.Predict(input));

            input = new InputModel { SentimentText = "Screenplay was not good" };
            PrintResult(predictionEnginee.Predict(input));

            input = new InputModel { SentimentText = "Lighting was very good" };
            PrintResult(predictionEnginee.Predict(input));

            input = new InputModel { SentimentText = "boring acting" };
            PrintResult(predictionEnginee.Predict(input));

        }
        
        public static void PrintResult(ResultModel result)
        {
            Console.WriteLine($"Prediction: {result.IsPositiveReview} | Score: {result.Score}");
        }
    }
}
