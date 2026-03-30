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
        // a readonly keyword? cool
        private readonly string filename = "data.json";
        private ListBoxItem selectedItem = null;
        private string NewKeyword => keywordInput.Text;
        public List<string> keywordList = []; // turns out this simplifies a lot...

        public Keywords()
        {
            InitializeComponent();
        }

        // by making this function public, we can use this function should we use Keywords as part of another component

        /* Hey, what do these parameters even mean?
         * sender is the object that calls it (in our case, the List Box with a load lifecycle hook
         * e is the event argument from the system... so lifecycle hooks are one I guess since
         * the individual objects don't have control over that (for good reason!)
         */
        private void ReadDataFile(object sender, System.EventArgs e)
        {
            if (File.Exists(this.filename)) {
                string fileJSON = File.ReadAllText(this.filename); // read from data.json, a static file
                // JsonSerializer is a static class, don't need to instantiate an object for it.
                this.keywordList = JsonSerializer.Deserialize<List<string>>(fileJSON);
                this.keywordList.Sort();
                // with keywords loaded, make ListBoxItems out of it
                this.RefreshListBox();
            }
        }
    
        // now, let's create another lifecycle hook... for when the program is destroyed/ended
        // what do we need to do? Rewrite the file!
        public void WriteDataFile()
        {
            // turns
            string serailizedList = JsonSerializer.Serialize(this.keywordList);
            // overwrite data.json with new serializedList
            File.WriteAllText(this.filename, serailizedList);
        }

        // keep a selected keyword variable -> useful for display and editing/deleting it.
        private void SetSelectedKeywordItem(object sender, RoutedEventArgs e)
            {
                this.selectedItem = (ListBoxItem) sender;
                removeButton.Content = $"Remove {selectedItem.Content}?";
            }

        private void RemoveKeyword(object sender, RoutedEventArgs e)
        {
            if (this.selectedItem != null)
            {
                // remove this item from the listbox
                keywords.Items.Remove(this.selectedItem);
                // reset selected item
                this.selectedItem = null;
            }
        }

        private void AddKeyword(object sender, RoutedEventArgs e)
        {
            // check if not duplicate, otherwise add to it to the list
            if (this.keywordList.Contains(this.NewKeyword))
            {
                this.DisplayErrorMessage($"{this.NewKeyword} is already present in your list of keywords");
                return;
            }
            

            this.HideErrorMessage();
            this.keywordList.Add(this.NewKeyword);
            this.keywordList.Sort();
            this.RefreshListBox();
        }

        private void RefreshListBox()
        {
            keywords.Items.Clear(); // so we don't get duplicates over and over again
            for (int i = 0; i < this.keywordList.Count; i++)
            {
                ListBoxItem keywordItem = new(); // this is neat
                keywordItem.Selected += this.SetSelectedKeywordItem;
                keywordItem.Content = keywordList[i];
                keywords.Items.Add(keywordItem);
            }
        }

        private void DisplayErrorMessage(string message)
        {
            errorLabel.Content = message;
            errorLabel.Visibility = Visibility.Visible;
        }

        private void HideErrorMessage()
        {
            errorLabel.Visibility = Visibility.Hidden;
        }

    }
}
