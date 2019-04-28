using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace ExamRef70_483.Chapter1.UserInterface
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private double computeAverages(long noOfValues)
        {
            double total = 0;
            Random rand = new Random();
            for (long values = 0; values < noOfValues; values++)
            {
                total = total + rand.NextDouble();
            }
            return total / noOfValues;
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            StartButton.IsEnabled = false;
            //RunComputeLockUI();
            //RunComputeTaskError();
            //RunComputeTaskDispatcher();
            RunComputeAsyncTask();
        }


        private void RunComputeAvarages()
        {
            long noOfValues = long.Parse(NumberOfValuesTextBox.Text);
            ResultTextBlock.Text = "Calculating...";
            ResultTextBlock.Text = "Result: " + computeAverages(noOfValues);
            StartButton.IsEnabled = true;
        }

        private void RunComputeLockUI()
        {
            RunComputeAvarages();            
        }

        private void RunComputeTaskError()
        {
            Task.Run(() => RunComputeAvarages());
        }

        private void RunComputeTaskDispatcher()
        {
            long noOfValues = long.Parse(NumberOfValuesTextBox.Text);
            Task.Run(() =>
            {
                double result = computeAverages(noOfValues);
                ResultTextBlock.Text = "Calculating...";
                ResultTextBlock.Dispatcher.Invoke(() =>
                {
                    ResultTextBlock.Text = "Result: " + result.ToString();
                    StartButton.IsEnabled = true;
                });
            });
        }

        private async void RunComputeAsyncTask()
        {
            long noOfValues = long.Parse(NumberOfValuesTextBox.Text);
            ResultTextBlock.Text = "Calculating...";
            double result = await asyncComputeAverage(noOfValues);
            ResultTextBlock.Text = "Result: " + result.ToString();
            StartButton.IsEnabled = true;
        }

        private Task<double> asyncComputeAverage(long noOfValues)
        {
            return Task<double>.Run(() => computeAverages(noOfValues));
        }
    }
}
