using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
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
            List<String> jobDescKeywords = GetKeywordsFromJobDescription(keywords, jobDescriptionBox);
            int resumeCount = CountKeywordAppearances(jobDescKeywords, resumeBox);
            
            if (jobDescKeywords.Count == 0 )
            {
                scoreDisplay.Content = "Score: 0%";
            }
            else
            {
                Double score =  ((Double) resumeCount / jobDescKeywords.Count) * 100;
                scoreDisplay.Content = $"Score: {score:F0}%";
            }
        }

        // we can call this function static as it does not rely on instance data (there are none!)
        // Question is... when to use static fns?
        private static List<String> GetKeywordsFromJobDescription(ListBox keywords, TextBox jobDescription)
        {
            List<String> keywordsInJD = new List<String>();
            for (int i = 0; i < keywords.Items.Count; i++)
            {
                ListBoxItem keyword = (ListBoxItem) keywords.Items.GetItemAt(i);
                // what does \b mean?
                // it means boundary anchor, so we have to match the word bordering a nonword character,
                // like a space or tab
                String pattern = $@"\b{((String)keyword.Content).ToLower()}\b";
                // lowercase everything to avoid missing stuff
                if (Regex.Match(jobDescription.Text.ToLower(), pattern).Success)
                {
                    keywordsInJD.Add((String) keyword.Content);
                }
            }
            return keywordsInJD;
        }

        private static int CountKeywordAppearances(List<String> keywords, TextBox body)
        {
            int keywordCount = 0;
            foreach (String keyword in keywords)
            {
                String pattern = $@"\b{keyword.ToLower()}\b";
                if (Regex.Match(body.Text.ToLower(), pattern).Success)
                {
                    keywordCount++;
                }
            }
            return keywordCount;
        }
    }
}