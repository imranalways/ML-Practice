using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLNetDemo01.Part27
{
    internal class Demo
    {
        public static void Execute()
        {
            MLContext context = new MLContext();

            IDataView dataView = context.Data.LoadFromTextFile<InputModel>(path: "Part27/flight_data.csv", hasHeader: true, separatorChar: ',');

            var pipeline = context.Transforms.SelectColumns(nameof(InputModel.Origin), nameof(InputModel.Destination),
                                                                     nameof(InputModel.DepartureTime), nameof(InputModel.ExpectedArrivalTime),
                                                                     nameof(InputModel.IsDelayBy15Minutes))
                            .Append(context.Transforms.Categorical.OneHotEncoding("Encoded_ORIGIN", nameof(InputModel.Origin)))
                            .Append(context.Transforms.Categorical.OneHotEncoding("Encoded_DESTINATION", nameof(InputModel.Destination)))
                            .Append(context.Transforms.DropColumns(nameof(InputModel.Origin), nameof(InputModel.Destination)))
                            .Append(context.Transforms.Concatenate("Features", "Encoded_ORIGIN", "Encoded_DESTINATION",
                                                                              nameof(InputModel.DepartureTime), nameof(InputModel.ExpectedArrivalTime)))
                            .Append(context.Transforms.Conversion.ConvertType("Label", nameof(InputModel.IsDelayBy15Minutes), Microsoft.ML.Data.DataKind.Boolean))
                            .Append(context.BinaryClassification.Trainers.SdcaLogisticRegression());
            var model = pipeline.Fit(dataView);
            var preview = model.Transform(dataView).Preview();

            var predictEnginee = context.Model.CreatePredictionEngine<InputModel, ResultModel>(model);
            var input = new InputModel { Origin = "BOS", Destination = "JFK", DepartureTime = 0100, ExpectedArrivalTime = 1645,OriginalArrivalTime=1700 };
            PrintResult(predictEnginee.Predict(input));
        }
        
        static void PrintResult(ResultModel result)
        {
            Console.WriteLine($"Prediction: {result.WillDelayBy15Minutes} | Score: {result.Score}");
        }
    }
}
