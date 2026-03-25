using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KeywordComparison
{
    /// <summary>
    /// Interaction logic for CompareTab.xaml
    /// </summary>

    public partial class CompareTab : UserControl
    {
        public event EventHandler eventHandler;
        public string jobDescription => jobDescriptionBox.Text;
        public string resume => resumeBox.Text;

        public CompareTab()
        {
            InitializeComponent();
        }

        private void CompareText(object sender, RoutedEventArgs e)
        {
            eventHandler?.Invoke(this, EventArgs.Empty);
        }

        public void DisplayScore(double score)
        {
            scoreDisplay.Content = $"Score: {score:F0}%";
        }
    }
}
