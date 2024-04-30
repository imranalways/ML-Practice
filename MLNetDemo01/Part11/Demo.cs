using Microsoft.ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLNetDemo01.Part11
{
    public class Demo
    {
        public static void Execute()
        {
            MLContext context = new MLContext(seed:0);
            List<InputModel> data = new List<InputModel>{
                new InputModel { YearsOfExperience = 1, Salary = 20000 },
                new InputModel { YearsOfExperience = 2.5f, Salary = 45000 },
                new InputModel { YearsOfExperience = 1.8f, Salary = 38000 },
                new InputModel { YearsOfExperience = 5.2f, Salary = 60000 },
                new InputModel { YearsOfExperience = 3.9f, Salary = 52000 },
                new InputModel { YearsOfExperience = 7.1f, Salary = 78000 },
                new InputModel { YearsOfExperience = 4.3f, Salary = 55000 },
                new InputModel { YearsOfExperience = 6.5f, Salary = 72000 },
                new InputModel { YearsOfExperience = 2.0f, Salary = 42000 },
                new InputModel { YearsOfExperience = 4.8f, Salary = 59000 },
                new InputModel { YearsOfExperience = 3.2f, Salary = 48000 },
                new InputModel { YearsOfExperience = 5.5f, Salary = 63000 },
                new InputModel { YearsOfExperience = 6.8f, Salary = 71000 },
                new InputModel { YearsOfExperience = 1.5f, Salary = 36000 },
                new InputModel { YearsOfExperience = 4.0f, Salary = 53000 },
                new InputModel { YearsOfExperience = 7.5f, Salary = 80000 },
                new InputModel { YearsOfExperience = 2.3f, Salary = 44000 },
                new InputModel { YearsOfExperience = 5.9f, Salary = 66000 },
                new InputModel { YearsOfExperience = 3.7f, Salary = 51000 },
                new InputModel { YearsOfExperience = 6.2f, Salary = 69000 },
                new InputModel { YearsOfExperience = 4.5f, Salary = 57000 },
                new InputModel { YearsOfExperience = 7.8f, Salary = 83000 },
                new InputModel { YearsOfExperience = 2.7f, Salary = 46000 },
                new InputModel { YearsOfExperience = 5.0f, Salary = 61000 },
                new InputModel { YearsOfExperience = 3.5f, Salary = 50000 },
                new InputModel { YearsOfExperience = 6.0f, Salary = 68000 },
                new InputModel { YearsOfExperience = 4.2f, Salary = 56000 },
                new InputModel { YearsOfExperience = 8.0f, Salary = 85000 },
                new InputModel { YearsOfExperience = 2.9f, Salary = 48000 },
                new InputModel { YearsOfExperience = 5.8f, Salary = 65000 },
                new InputModel { YearsOfExperience = 3.3f, Salary = 49000 },
                new InputModel { YearsOfExperience = 6.3f, Salary = 70000 },
                new InputModel { YearsOfExperience = 4.7f, Salary = 58000 },
                new InputModel { YearsOfExperience = 8.5f, Salary = 88000 },
                new InputModel { YearsOfExperience = 3.0f, Salary = 47000 },
                new InputModel { YearsOfExperience = 5.7f, Salary = 64000 },
                new InputModel { YearsOfExperience = 3.6f, Salary = 52000 },
                new InputModel { YearsOfExperience = 6.7f, Salary = 74000 },
                new InputModel { YearsOfExperience = 4.1f, Salary = 55000 },
                new InputModel { YearsOfExperience = 8.2f, Salary = 86000 },
                new InputModel { YearsOfExperience = 2.2f, Salary = 43000 },
                new InputModel { YearsOfExperience = 5.6f, Salary = 63000 },
                new InputModel { YearsOfExperience = 3.4f, Salary = 51000 },
                new InputModel { YearsOfExperience = 6.4f, Salary = 71000 },
                new InputModel { YearsOfExperience = 4.6f, Salary = 59000 },
                new InputModel { YearsOfExperience = 8.8f, Salary = 90000 },
                new InputModel { YearsOfExperience = 3.1f, Salary = 46000 },
                new InputModel { YearsOfExperience = 5.4f, Salary = 62000 },
                new InputModel { YearsOfExperience = 3.8f, Salary = 54000 },
                new InputModel { YearsOfExperience = 6.6f, Salary = 73000 },
                new InputModel { YearsOfExperience = 4.4f, Salary = 58000 },
                new InputModel { YearsOfExperience = 8.3f, Salary = 87000 },
                new InputModel { YearsOfExperience = 2.8f, Salary = 47000 },
                new InputModel { YearsOfExperience = 5.3f, Salary = 63000 },
                new InputModel { YearsOfExperience = 4.9f, Salary = 60000 },
                new InputModel { YearsOfExperience = 6.9f, Salary = 75000 },
                new InputModel { YearsOfExperience = 4.0f, Salary = 57000 },
                new InputModel { YearsOfExperience = 8.7f, Salary = 89000 },
                new InputModel { YearsOfExperience = 3.2f, Salary = 48000 },
                new InputModel { YearsOfExperience = 5.1f, Salary = 64000 },
                new InputModel { YearsOfExperience = 3.7f, Salary = 55000 },
                new InputModel { YearsOfExperience = 6.1f, Salary = 70000 },
                new InputModel { YearsOfExperience = 4.8f, Salary = 58000 },
                new InputModel { YearsOfExperience = 8.9f, Salary = 91000 },
                new InputModel { YearsOfExperience = 3.5f, Salary = 49000 },
                new InputModel { YearsOfExperience = 5.9f, Salary = 65000 },
                new InputModel { YearsOfExperience = 3.0f, Salary = 46000 },
                new InputModel { YearsOfExperience = 6.5f, Salary = 72000 },
                new InputModel { YearsOfExperience = 4.7f, Salary = 59000 },
                new InputModel { YearsOfExperience = 9.0f, Salary = 93000 },
                new InputModel { YearsOfExperience = 3.3f, Salary = 47000 },
                new InputModel { YearsOfExperience = 5.8f, Salary = 66000 },
                new InputModel { YearsOfExperience = 3.2f, Salary = 48000 },
                new InputModel { YearsOfExperience = 6.7f, Salary = 74000 },
                new InputModel { YearsOfExperience = 4.5f, Salary = 60000 },
            };

            IDataView trainingData = context.Data.LoadFromEnumerable(data);

            var estimator = context.Transforms.Concatenate("Features", new[] { "YearsOfExperience" });
            var pipeline = estimator.Append(context.Regression.Trainers.Sdca(labelColumnName: "Salary", maximumNumberOfIterations: 100));

            var model = pipeline.Fit(trainingData);

            List<InputModel> testModel = new List<InputModel>
            {
                 new InputModel { YearsOfExperience = 1, Salary = 20000 },
                new InputModel { YearsOfExperience = 2.5f, Salary = 45000 },
                new InputModel { YearsOfExperience = 1.8f, Salary = 38000 },
                new InputModel { YearsOfExperience = 5.2f, Salary = 60000 },
                new InputModel { YearsOfExperience = 3.9f, Salary = 52000 },
                new InputModel { YearsOfExperience = 7.1f, Salary = 78000 },
                new InputModel { YearsOfExperience = 4.3f, Salary = 55000 },
                new InputModel { YearsOfExperience = 6.5f, Salary = 72000 },
                new InputModel { YearsOfExperience = 2.0f, Salary = 42000 },
                new InputModel { YearsOfExperience = 4.8f, Salary = 59000 },
                new InputModel { YearsOfExperience = 3.2f, Salary = 48000 },
                new InputModel { YearsOfExperience = 5.5f, Salary = 63000 },
                new InputModel { YearsOfExperience = 6.8f, Salary = 71000 },
                new InputModel { YearsOfExperience = 1.5f, Salary = 36000 },
                new InputModel { YearsOfExperience = 4.0f, Salary = 53000 },
            };
            var testDataView = context.Data.LoadFromEnumerable(testModel);

            var matrix = context.Regression.Evaluate(model.Transform(testDataView), labelColumnName: "Salary");

            Console.WriteLine($"R^2: {matrix.RSquared:0.00}");
            Console.WriteLine($"MA Error: {matrix.MeanAbsoluteError:0.00}");
            Console.WriteLine($"MS: {matrix.MeanSquaredError:0.00}");
            Console.WriteLine($"RMS: {matrix.RootMeanSquaredError:0.00}");
            Console.WriteLine($"Loss Function: {matrix.LossFunction:0.00}");
            
        }
    }
}
