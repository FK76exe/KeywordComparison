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
using System.Text.Json;
using System.IO;

namespace KeywordComparison
{
    /// <summary>
    /// Interaction logic for Keywords.xaml
    /// </summary>
    public partial class Keywords : UserControl
    {
        private string filename = "data.json";
        public Keywords()
        {
            InitializeComponent();
        }

        // by making this function public, we can use this function should we use Keywords as part of another component
        public List<string> extractKeywords()
        {
            List<string> keywordList = new List<string>();
            for (int i = 0; i< keywords.Items.Count; i++)
            {
                keywordList.Add((String) ((ListBoxItem) keywords.Items.GetItemAt(i)).Content);
            }
            return keywordList;
        }

        /* Hey, what do these parameters even mean?
         * sender is the object that calls it (in our case, the List Box with a load lifecycle hook
         * e is the event argument from the system... so lifecycle hooks are one I guess since
         * the individual objects don't have control over that (for good reason!)
         */
        private void readDataFile(object sender, System.EventArgs e)
        {
            if (File.Exists(filename)) {
                string fileJSON = File.ReadAllText(filename); // read from data.json, a static file
                // JsonSerializer is a static class, don't need to instantiate an object for it.
                List<String> keywordsFromFile = JsonSerializer.Deserialize<List<string>>(fileJSON);
                // with keywords loaded, make ListBoxItems out of it
                for (int i = 0; i < keywordsFromFile.Count; i++)
                {
                    // for each keyword, create a ListBoxItem and add to to ListBox
                    // at the end, we will have all our keywords added to ListBox, yay!
                    ListBoxItem keywordItem = new ListBoxItem();
                    keywordItem.Content = keywordsFromFile[i];
                    keywords.Items.Add(keywordItem);
                }
            }
        }
    }
}
