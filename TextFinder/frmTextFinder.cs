using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

namespace TextFinder
{
    public partial class frmTextFinder : Form
    {
        public frmTextFinder()
        {
            InitializeComponent();
        }

        private void frmTextFinder_Load(object sender, EventArgs e)
        {

        }//frmTextFinder_Load()

        private void searchTerm_KeyDown(object sender, KeyEventArgs e)
        {
            //search for text when Enter key has been pressed
            if (e.KeyCode == Keys.Enter)
            {
                var start = 0;
                var searchTermLength = 0;
                var searchTermValue = "";
                var selectedTextValue = "";
                

                searchTermValue = searchTerm.Text;

                if ((searchTermValue.Trim() == string.Empty) || 
                        (inputText.Text == string.Empty))
                {   //can't search on just spaces
                    //and can't search on no input
                    return;
                }

                ClearInput();

                searchTermLength = searchTermValue.Length;
                do
                {
                    //find index of next occurence of search term
                    start = inputText.Find(searchTermValue, start, RichTextBoxFinds.None);
                    if (start != -1)
                    {
                        inputText.Select(start, searchTermLength);
                        inputText.SelectionBackColor = Color.Yellow;
                        //write the value of the found item, not the original 
                        //search item, since we have selected case insensitive
                        //seach
                        selectedTextValue = inputText.SelectedText;
                        AddItem(selectedTextValue, start, searchTermLength);
                        start += searchTermLength;
                        if (start >= inputText.Text.Length)
                        {
                            break;
                        }
                    }

                } while (start != -1);


            }//(e.KeyCode == Keys.Enter)
        }//searchTerm_KeyDown

        /// <summary>
        /// Adds text highlighted item to ListView control
        /// along with starting and ending positions
        /// Can't use a ListBox since it doesn't support
        /// multiple columns like a table would
        /// </summary>
        private void AddItem(string value, int start, int len)
        {
            //first column of new row is main item
            //subsequent columns in same row are subitems
            //Add a new row using ListView.Items.Add(new ListViewItem())
            //In ListViewItem constructor declare a new string array
            //and follow that with an array literal {}
            var end = start + len;
            foundItems.Items.Add(new ListViewItem(new string[] 
                             { value, start.ToString(), end.ToString() }));
        }

        private void ClearInput()
        {
            var tempText = "";
            //clear highlighting, if any, from previous search
            tempText = inputText.Text;
            inputText.Clear();
            inputText.Text = tempText;
        }

        private void foundItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            //having problems getting SelectedItems. .NET says its null
            //and doesn't have any items. Same for FocusItem and
            //SelectedIndices :-(
            //Having better luck using the Click() method
        }

        private void foundItems_Click(object sender, EventArgs e)
        {
            //ensure inputText is not empty and that its length is
            //at least start + item length
            //can't do anything if the user has tampered with the inpuText 

            if (foundItems.SelectedItems.Count == 0)
            {
                return;
            } 

            var value = foundItems.SelectedItems[0].SubItems[0].Text;
            var start = int.Parse(foundItems.SelectedItems[0].SubItems[1].Text);
            var end = int.Parse(foundItems.SelectedItems[0].SubItems[2].Text);
            var len = end - start;

  
            if (inputText.Text.Length == 0)
            {
                return;
            }
            else if (inputText.Text.Length < start + len)
            {
                return;
            }

            //select the item 
            inputText.Select(start, len);
            //must set focus or you won't see the highlight
            inputText.Focus();

        }//foundItems_Click()

        private void searchTerm_TextChanged(object sender, EventArgs e)
        {
            

        }//searchTerm_TextChanged()

        private void foundItems_DoubleClick(object sender, EventArgs e)
        {
            //replace the selected item
            if (foundItems.SelectedItems.Count == 0)
            {
                return;
            }

            var value = foundItems.SelectedItems[0].SubItems[0].Text;
            var start = int.Parse(foundItems.SelectedItems[0].SubItems[1].Text);
            var end = int.Parse(foundItems.SelectedItems[0].SubItems[2].Text);
            var len = end - start;
            var replaceValue = "";

            replaceValue = 
                Microsoft.VisualBasic.Interaction.InputBox("Enter replacement text", "Replace", value);
            if ((replaceValue != string.Empty) && (replaceValue !=value))
            {
                inputText.SelectedText = replaceValue;
            }


        }//foundItems_DoubleClick()

        private void resetFoundItems_Click(object sender, EventArgs e)
        {
            //to remove all items from the list, use Items.Clear()
            //don't call Clear() on the ListView object itself or all columns
            //will be deleted, too!
            foundItems.Items.Clear();
        }//resetFoundItems_Click()

        private void deleteSearchBox_Click(object sender, EventArgs e)
        {
            searchTerm.Clear();
            ClearInput();

        }//deleteSearchBox_Click()

        private void deleteInputText_Click(object sender, EventArgs e)
        {
            inputText.Clear();
            //clear list of found items since input box now is empty
            //so the items in Found Items no longer reference the original
            //text
            foundItems.Items.Clear();
        } // deleteInputText_Click()

        private void btnAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Text Finder is a C# Windows Forms application " +
                "that does almost nothing useful. You're welcome.",
                "Text Finder 2018 Professional", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void inputText_TextChanged(object sender, EventArgs e)
        {
            if (inputText.Text == "")
            {
                //if user manually empties the Input box, must clear Found Items
                foundItems.Items.Clear();
            }
        }
    }//class frmTextFinder : Form
}//TextFinder
