using System.Security.Cryptography;
using System.Text;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CompareText(object sender, RoutedEventArgs e)
        {
            int jobDescCount = keywordApperance(Keywords, txtBox1);
            int resumeCount = keywordApperance(Keywords, txtBox2);
            
            if (jobDescCount == 0 )
            {
                scoreDisplay.Content = "Score: 0%";
            }
            else
            {
                Double score =  ((Double) resumeCount / jobDescCount) * 100;
                scoreDisplay.Content = $"Score: {score.ToString("F0")}%";
            }
        }
        private int keywordApperance(ListBox keywords, TextBox body)
        {
            int keywordCount = 0;
            for (int i = 0; i < keywords.Items.Count; i++)
            {
                ListBoxItem item = (ListBoxItem) keywords.Items.GetItemAt(i);
                String keyword = (String) item.Content;
                if (body.Text.Contains(keyword)) {
                    keywordCount++;
                }
            }
            return keywordCount;
        }
    }
}