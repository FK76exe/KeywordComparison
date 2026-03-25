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
    /// Interaction logic for Keywords.xaml
    /// </summary>
    public partial class Keywords : UserControl
    {
        public Keywords()
        {
            InitializeComponent();
        }

        public List<string> extractKeywords()
        {
            List<string> keywordList = new List<string>();
            for (int i = 0; i< keywords.Items.Count; i++)
            {
                keywordList.Add((String) ((ListBoxItem) keywords.Items.GetItemAt(i)).Content);
            }
            return keywordList;
        }
    }
}
