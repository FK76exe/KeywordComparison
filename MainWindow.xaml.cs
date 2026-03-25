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
            // onCompareText is the function assigned to receive the event handler from compare tab
            compareTab.eventHandler += onCompareText;
        }

        private void onCompareText(object sender, EventArgs e)
        {
            // this is how we access public variables from a user control
            string jobDescription = compareTab.jobDescription;
            string resume = compareTab.resume;

            // this is how we access public methods
            // note: string and String are the same thing, just need to be consistent with it.
            List<string> keywords = keywordTab.extractKeywords();
            List<String> jobDescKeywords = GetKeywordsFromJobDescription(keywords, jobDescription);
            int resumeCount = CountKeywordAppearances(jobDescKeywords, resume);

            double score = 0;
            if (jobDescKeywords.Count > 0)
            {
               score =  ((Double) resumeCount / jobDescKeywords.Count) * 100;        
            }
            // aaaand we ship things over when we are done.
            compareTab.DisplayScore(score);
        }

        // we can call this function static as it does not rely on instance data (there are none!)
        // Question is... when to use static fns?
        private static List<String> GetKeywordsFromJobDescription(List<string> keywords, string jobDescription)
        {
            List<String> keywordsInJD = new List<String>();
            for (int i = 0; i < keywords.Count; i++)
            {
                // what does \b mean?
                // it means boundary anchor, so we have to match the word bordering a nonword character,
                // like a space or tab
                String pattern = $@"\b{(keywords[i]).ToLower()}\b";
                // lowercase everything to avoid missing stuff
                if (Regex.Match(jobDescription.ToLower(), pattern).Success)
                {
                    keywordsInJD.Add((keywords[i]));
                }
            }
            return keywordsInJD;
        }

        private static int CountKeywordAppearances(List<String> keywords, string body)
        {
            int keywordCount = 0;
            foreach (String keyword in keywords)
            {
                String pattern = $@"\b{keyword.ToLower()}\b";
                if (Regex.Match(body.ToLower(), pattern).Success)
                {
                    keywordCount++;
                }
            }
            return keywordCount;
        }
    }
}