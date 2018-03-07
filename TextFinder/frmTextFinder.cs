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


        /// <summary>
        /// We use the KeyDown event of the searchTerm textbox control, 
        /// which works with both printing (e.g. "A", "B", "?") and non printing keys
        /// keys (e.g. Enter, Esc, Spacebar) to trap presses of the Enter key to trigger
        /// the application to perform a search of the contents of the RichTextBox control
        /// inputText.
        /// 
        /// Before performing a search, the code verifies that something to search for
        /// has been entered into the searchTerm textbox control. It also verifies that
        /// inputText has some text in it. If either of these conditions are false, there is
        /// nothing to search for.
        /// 
        /// Three variables that control the selection of text in the RichTextBox control are
        /// initialized. These are important because when an occurrence of the search term is found
        /// somewhere in the RichTextBox control, we need to select just that phrase and apply
        /// highlighting to it. Plus, we need to update the starting position from where the next
        /// search for the search term will begin, since we don't want to keep examining the same range
        /// of text ad infinitum.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchTerm_KeyDown(object sender, KeyEventArgs e)
        {
            //search for text when Enter key has been pressed
            if (e.KeyCode == Keys.Enter)
            {
                var start = 0;
                var searchTermLength = 0;
                var searchTermValue = "";
                var selectedTextValue = "";
                
                //store the contents of the searchTerm textbox in a variable
                searchTermValue = searchTerm.Text;

                //make sure the search term isn't just whitespace and 
                //make sure the RichTextBox control has some text in it
                if ((searchTermValue.Trim() == string.Empty) || 
                        (inputText.Text == string.Empty))
                {   //can't search on just spaces
                    //and can't search on no input
                    return;
                }

               
                /*Call ClearInput(), which, desipite its name, doesn't actually wipe out data
                 * in inputText control but rather removes any highlighted words so that
                 * we don't confuse one search operation with any subsequent operations, 
                 * in other words, we want to highlight only words from the current
                 * search operation. Nevertheless, the listview control foundItems will
                 * store the position of every found search term so that the user can locate
                 * any search term during this session at any time
                */
                ClearInput();

                searchTermLength = searchTermValue.Length;
                do
                {
                    /*find index of next occurence of search term
                    *stop searching if the Find() method returns -1, which indicates
                    that the search term was not found anymore
                    */
                    start = inputText.Find(searchTermValue, start, RichTextBoxFinds.None);
                    if (start != -1)
                    {
                        //highlight the occurence of the search term
                        inputText.Select(start, searchTermLength);
                        inputText.SelectionBackColor = Color.Yellow;

                        //write the value of the found item, not the original 
                        //search item, since we have selected case insensitive
                        //seach
                        selectedTextValue = inputText.SelectedText;
                        AddItem(selectedTextValue, start, searchTermLength);

                        /*update the position from which the next search will be performed
                         * but stop searching if the updated starting position is greater
                         * than the length of the contents of the RichTextBox control
                         */ 
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



        /// <summary>
        /// This method stores the contents of the RichTextBox in a temporary variable
        /// and then clears inputText so that nothing is highlighted anymore. Then the 
        /// original, unformatted text is reloaded into the control
        /// This ensures that any highlighted words are from the current search operation,
        /// not previous ones, which might confuse the user
        /// </summary>
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

            /* Extract the starting position and ending position for the found
             * occurrence of the search term from the listview control and use them
             * in the Select() method of the RichTextBox control to select (not
             * highlight) the portion of the contents of the control containing the
             * occurrence of the search term
             */ 
            var value = foundItems.SelectedItems[0].SubItems[0].Text;
            var start = int.Parse(foundItems.SelectedItems[0].SubItems[1].Text);
            var end = int.Parse(foundItems.SelectedItems[0].SubItems[2].Text);
            var len = end - start;

  
            if (inputText.Text.Length == 0)
            {
                return;
            }
            else if (inputText.Text.Length < start + len) //user must have tampered with text
            {
                return;
            }

            //select the item 
            inputText.Select(start, len);
            //must set focus or you won't see the highlight
            inputText.Focus();

        }//foundItems_Click()

        /*was planning on using this event originally but decided against it
        * could have been a performance drain since searching every time we
        * add or change a character in the searchTerm textbox, imitating 
        * the behavior of a search engine input box would be very processing 
        * intensive
        */
        private void searchTerm_TextChanged(object sender, EventArgs e)
        {
            

        }//searchTerm_TextChanged()


        /// <summary>
        /// foundItems_DoubleClick() we use this event procedure to display an inputbox
        /// dialog, borrowed from the .NET Visual Basic library (because C# doesn't
        /// have an equivalent dialog) and prompt the user to edit a found occurrence of the 
        /// search term. Must set a reference to the Microsoft Visual Basic library.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void foundItems_DoubleClick(object sender, EventArgs e)
        {
            //replace the selected item
            if (foundItems.SelectedItems.Count == 0)
            {
                return;
            }

           /* Inspect the submitems collection of the selected item in the listview 
            * control to get the start and end positions of the found occurrence of 
            * the search term
            */ 
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


        /// <summary>
        /// Clears the listview control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void resetFoundItems_Click(object sender, EventArgs e)
        {
            //to remove all items from the list, use Items.Clear()
            //don't call Clear() on the ListView object itself or all columns
            //will be deleted, too!
            foundItems.Items.Clear();
        }//resetFoundItems_Click()



        /// <summary>
        /// Clears the contents of the searchTerm textbox and removes highlighting
        /// from any words in the RichTextBox control, in preparation for subsequent
        /// searches
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteSearchBox_Click(object sender, EventArgs e)
        {
            searchTerm.Clear();
            ClearInput();

        }//deleteSearchBox_Click()

        /// <summary>
        /// Clears the RichTextBox control and also clears the listview control
        /// of its items, since they become invalid if the text of the inputText control
        /// has been altered or removed completely
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteInputText_Click(object sender, EventArgs e)
        {
            inputText.Clear();
            //clear list of found items since input box now is empty
            //so the items in Found Items no longer reference the original
            //text
            foundItems.Items.Clear();
        } // deleteInputText_Click()


        /// <summary>
        /// Display a cheeky about box!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Text Finder is a C# Windows Forms application " +
                "that does almost nothing useful. You're welcome.",
                "Text Finder 2018 Professional", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

       
    }//class frmTextFinder : Form
}//TextFinder
