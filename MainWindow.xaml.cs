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
            // OnCompareText is the function assigned to receive the event handler from compare tab
            compareTab.EventHandler += OnCompareText;
        }

        private void OnCompareText(object sender, EventArgs e)
        {
            // this is how we access public variables from a user control
            string jobDescription = compareTab.JobDescription;
            string resume = compareTab.Resume;

            // this is how we access public methods
            // note: string and String are the same thing, just need to be consistent with it.
            List<String> jobDescKeywords = GetKeywordsFromText(keywordTab.keywordList, jobDescription);
            List<string> resumeKeywords = GetKeywordsFromText(keywordTab.keywordList, resume);

            // Can I treat lists like a set and get missing keywords?
            // [.. ] is like ".ToList" but simpler, like list comprehension. Cool!
            int resumeKeywordCount = jobDescKeywords.Intersect(resumeKeywords).Count();
            List<string> missingKeywords = [.. jobDescKeywords.Except(resumeKeywords)];

            double score = 0;
            if (jobDescKeywords.Count > 0)
            {
               score =  ((Double) resumeKeywordCount / jobDescKeywords.Count) * 100;        
            }
            // aaaand we ship things over when we are done.
            compareTab.DisplayScore(score);
            missingKeywords.Sort();
            compareTab.DisplayMissingKeywords(missingKeywords);
        }

        // we can call this function static as it does not rely on instance data (there are none!)
        // Question is... when to use static fns?
        private static List<String> GetKeywordsFromText(List<string> keywords, string jobDescription)
        {
            List<String> keywordsInJD = [];
            for (int i = 0; i < keywords.Count; i++)
            {
                // what does \b mean?
                // it means boundary anchor, so we have to match the word bordering a nonword character,
                // like a space or tab
                // what does Regex.Escape do? Converts a string to have escape characters
                // C++ -> would end up like invalid regex if formatted raw -> Regex.Escape fixes this!
                String pattern = $@"\b{(Regex.Escape(keywords[i].ToLower()))}";
                // lowercase everything to avoid missing stuff
                if (Regex.Match(jobDescription.ToLower(), pattern).Success)
                {
                    keywordsInJD.Add((keywords[i]));
                }
            }
            return keywordsInJD;
        }

        private void SaveData(object sender, System.ComponentModel.CancelEventArgs e)
        {
            keywordTab.WriteDataFile();
        }
    }
}