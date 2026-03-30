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
        // this is an event handler. We use to... handle events like clicking a button or hovering over something
        // think of it like onclick in JS/vue
        // these public variables can be accessed by a parent component
        public event EventHandler EventHandler;

        /* What's this "=>" operator?
         * It's an "expression-bodied" property is a more concise way of implementing a function
         * or setting a variable
         * It's a shorthand for get/set methods of variables (remember your Java?)
         */
        public string JobDescription => jobDescriptionBox.Text; // so class properties must be capitalized?
        public string Resume => resumeBox.Text;

        public CompareTab()
        {
            InitializeComponent();
        }

        private void CompareText(object sender, RoutedEventArgs e)
        {
            /* in the XAML, we tie a click event to this function
             * When that happens, we invoke our event handler (I assume it is set when the event actually happens?)
             * Invoking the event handler sends an event to whoever is using it (in our case, Main Window)
            */
            EventHandler?.Invoke(this, EventArgs.Empty);
        }

        public void DisplayScore(double score)
        {
            // F0 -> float with zero decimal points
            scoreDisplay.Content = $"Score: {score:F0}%";
        }

        public void DisplayMissingKeywords(List<string> keywords)
        {
            if (keywords.Count == 0)
            {
                // hide the label
                missingKeywordsBold.Visibility = Visibility.Hidden;
                missingKeywordList.Visibility = Visibility.Hidden;
            }
            else
            {
                // show the label
                missingKeywordsBold.Visibility = Visibility.Visible;
                missingKeywordList.Visibility = Visibility.Visible;
                // now... make a list!
                missingKeywordList.Text = String.Join(", ", keywords);
            }
        }
    }
}
