namespace TextFinder
{
    partial class frmTextFinder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTextFinder));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.searchTerm = new System.Windows.Forms.TextBox();
            this.inputText = new System.Windows.Forms.RichTextBox();
            this.foundItems = new System.Windows.Forms.ListView();
            this.colText = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStart = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEnd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.resetFoundItems = new System.Windows.Forms.Button();
            this.deleteSearchBox = new System.Windows.Forms.Button();
            this.deleteInputText = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search For";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Input";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(505, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Found Items";
            // 
            // searchTerm
            // 
            this.searchTerm.Location = new System.Drawing.Point(107, 91);
            this.searchTerm.Name = "searchTerm";
            this.searchTerm.Size = new System.Drawing.Size(374, 27);
            this.searchTerm.TabIndex = 0;
            this.toolTip1.SetToolTip(this.searchTerm, "Type in text and press Enter to search");
            this.searchTerm.TextChanged += new System.EventHandler(this.searchTerm_TextChanged);
            this.searchTerm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchTerm_KeyDown);
            // 
            // inputText
            // 
            this.inputText.Location = new System.Drawing.Point(12, 161);
            this.inputText.Name = "inputText";
            this.inputText.Size = new System.Drawing.Size(469, 279);
            this.inputText.TabIndex = 2;
            this.inputText.Text = "";
            this.toolTip1.SetToolTip(this.inputText, "Type or paste in text to be searched");
            // 
            // foundItems
            // 
            this.foundItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colText,
            this.colStart,
            this.colEnd});
            this.foundItems.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.foundItems.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.foundItems.Location = new System.Drawing.Point(499, 161);
            this.foundItems.MultiSelect = false;
            this.foundItems.Name = "foundItems";
            this.foundItems.Size = new System.Drawing.Size(300, 279);
            this.foundItems.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.foundItems.TabIndex = 4;
            this.toolTip1.SetToolTip(this.foundItems, "Click an item in the list to highlight it in the Input box\r\nDouble click to chang" +
        "e selected item");
            this.foundItems.UseCompatibleStateImageBehavior = false;
            this.foundItems.View = System.Windows.Forms.View.Details;
            this.foundItems.SelectedIndexChanged += new System.EventHandler(this.foundItems_SelectedIndexChanged);
            this.foundItems.Click += new System.EventHandler(this.foundItems_Click);
            this.foundItems.DoubleClick += new System.EventHandler(this.foundItems_DoubleClick);
            // 
            // colText
            // 
            this.colText.Text = "Text";
            this.colText.Width = 175;
            // 
            // colStart
            // 
            this.colStart.Text = "Start";
            this.colStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // colEnd
            // 
            this.colEnd.Text = "End";
            this.colEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // resetFoundItems
            // 
            this.resetFoundItems.Location = new System.Drawing.Point(705, 126);
            this.resetFoundItems.Name = "resetFoundItems";
            this.resetFoundItems.Size = new System.Drawing.Size(94, 29);
            this.resetFoundItems.TabIndex = 5;
            this.resetFoundItems.Text = "Reset";
            this.toolTip1.SetToolTip(this.resetFoundItems, "Clear Found Items list");
            this.resetFoundItems.UseVisualStyleBackColor = true;
            this.resetFoundItems.Click += new System.EventHandler(this.resetFoundItems_Click);
            // 
            // deleteSearchBox
            // 
            this.deleteSearchBox.Font = new System.Drawing.Font("Wingdings", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.deleteSearchBox.Location = new System.Drawing.Point(487, 92);
            this.deleteSearchBox.Name = "deleteSearchBox";
            this.deleteSearchBox.Size = new System.Drawing.Size(45, 26);
            this.deleteSearchBox.TabIndex = 1;
            this.deleteSearchBox.Text = "ý";
            this.toolTip1.SetToolTip(this.deleteSearchBox, "Clear Search For box");
            this.deleteSearchBox.UseVisualStyleBackColor = true;
            this.deleteSearchBox.Click += new System.EventHandler(this.deleteSearchBox_Click);
            // 
            // deleteInputText
            // 
            this.deleteInputText.Font = new System.Drawing.Font("Wingdings", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.deleteInputText.Location = new System.Drawing.Point(436, 132);
            this.deleteInputText.Name = "deleteInputText";
            this.deleteInputText.Size = new System.Drawing.Size(45, 26);
            this.deleteInputText.TabIndex = 3;
            this.deleteInputText.Text = "ý";
            this.toolTip1.SetToolTip(this.deleteInputText, "Clear Input box");
            this.deleteInputText.UseVisualStyleBackColor = true;
            this.deleteInputText.Click += new System.EventHandler(this.deleteInputText_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.AutoSize = true;
            this.btnAbout.Location = new System.Drawing.Point(730, 12);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(77, 37);
            this.btnAbout.TabIndex = 6;
            this.btnAbout.Text = "About...";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(496, 64);
            this.label4.TabIndex = 7;
            this.label4.Text = resources.GetString("label4.Text");
            // 
            // frmTextFinder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(817, 452);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.deleteInputText);
            this.Controls.Add(this.deleteSearchBox);
            this.Controls.Add(this.resetFoundItems);
            this.Controls.Add(this.foundItems);
            this.Controls.Add(this.inputText);
            this.Controls.Add(this.searchTerm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmTextFinder";
            this.Text = "Text Finder";
            this.Load += new System.EventHandler(this.frmTextFinder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox searchTerm;
        private System.Windows.Forms.RichTextBox inputText;
        private System.Windows.Forms.ListView foundItems;
        private System.Windows.Forms.ColumnHeader colText;
        private System.Windows.Forms.ColumnHeader colStart;
        private System.Windows.Forms.ColumnHeader colEnd;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button resetFoundItems;
        private System.Windows.Forms.Button deleteSearchBox;
        private System.Windows.Forms.Button deleteInputText;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Label label4;
    }
}

