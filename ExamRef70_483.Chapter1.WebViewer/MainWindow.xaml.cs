using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

namespace ExamRef70_483.Chapter1.WebViewer
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

        private async void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadButton.IsEnabled = false;
                StatusTextBlock.Text = "Page Loading...";
                ResultTextBlock.Text = string.Empty;
                ResultTextBlock.Text = await FetchWebPage(URLTextBox.Text);
                StatusTextBlock.Text = "Page Loaded";
            }catch(Exception ex)
            {
                StatusTextBlock.Text = ex.Message;
            }
            finally
            {
                LoadButton.IsEnabled = true;
            }
        }

        private async void LoadURLs_Click(object sender, RoutedEventArgs e)
        {
            string[] urls = { "http://google.com", "http://gizmodo.com" };
            var pages = await FetchWebPages(urls);
            foreach(var page in pages)
            {
                ResultTextBlock.Text += page;
            }
        }

        private async Task<string> FetchWebPage(string url)
        {
            HttpClient httpClient = new HttpClient();
            return await httpClient.GetStringAsync(url);
        }

        private async Task<IEnumerable<string>> FetchWebPages(string [] urls)
        {
            var tasks = new List<Task<string>>();
            foreach (string url in urls)
            {
                tasks.Add(FetchWebPage(url));
            }
            return await Task.WhenAll(tasks);
        }
    }
}
