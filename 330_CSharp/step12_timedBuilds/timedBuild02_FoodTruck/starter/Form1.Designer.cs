namespace TimedBuild02
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lbl_Status = new Label();
            lbl_SalesTable = new Label();
            lst_Sales = new ListBox();
            btn_ShowTable = new Button();
            btn_BestSellers = new Button();
            btn_SaveReport = new Button();
            btn_TestAll = new Button();
            lbl_ItemNumber = new Label();
            txt_ItemNumber = new TextBox();
            lbl_Quantity = new Label();
            txt_Quantity = new TextBox();
            btn_AddSale = new Button();
            lbl_BestRevenue = new Label();
            lbl_BestQuantity = new Label();
            lbl_SearchFor = new Label();
            txt_Search = new TextBox();
            btn_Search = new Button();
            lst_Results = new ListBox();
            lbl_Items = new Label();
            lst_Items = new ListBox();
            btn_Quit = new Button();
            SuspendLayout();
            // 
            // lbl_Status
            // 
            lbl_Status.BorderStyle = BorderStyle.FixedSingle;
            lbl_Status.Location = new Point(12, 12);
            lbl_Status.Name = "lbl_Status";
            lbl_Status.Size = new Size(614, 23);
            lbl_Status.TabIndex = 0;
            lbl_Status.Text = "";
            // 
            // lbl_SalesTable
            // 
            lbl_SalesTable.AutoSize = true;
            lbl_SalesTable.Location = new Point(12, 45);
            lbl_SalesTable.Name = "lbl_SalesTable";
            lbl_SalesTable.Size = new Size(64, 15);
            lbl_SalesTable.TabIndex = 1;
            lbl_SalesTable.Text = "Sales table";
            // 
            // lst_Sales
            // 
            lst_Sales.Font = new Font("Consolas", 10F);
            lst_Sales.FormattingEnabled = true;
            lst_Sales.ItemHeight = 15;
            lst_Sales.Location = new Point(12, 68);
            lst_Sales.Name = "lst_Sales";
            lst_Sales.Size = new Size(400, 154);
            lst_Sales.TabIndex = 2;
            // 
            // btn_ShowTable
            // 
            btn_ShowTable.Location = new Point(436, 68);
            btn_ShowTable.Name = "btn_ShowTable";
            btn_ShowTable.Size = new Size(190, 30);
            btn_ShowTable.TabIndex = 3;
            btn_ShowTable.Text = "Show Sales Table";
            btn_ShowTable.UseVisualStyleBackColor = true;
            btn_ShowTable.Click += btn_ShowTable_Click;
            // 
            // btn_BestSellers
            // 
            btn_BestSellers.Location = new Point(436, 106);
            btn_BestSellers.Name = "btn_BestSellers";
            btn_BestSellers.Size = new Size(190, 30);
            btn_BestSellers.TabIndex = 4;
            btn_BestSellers.Text = "Best Sellers";
            btn_BestSellers.UseVisualStyleBackColor = true;
            btn_BestSellers.Click += btn_BestSellers_Click;
            // 
            // btn_SaveReport
            // 
            btn_SaveReport.Location = new Point(436, 144);
            btn_SaveReport.Name = "btn_SaveReport";
            btn_SaveReport.Size = new Size(190, 30);
            btn_SaveReport.TabIndex = 5;
            btn_SaveReport.Text = "Save Report";
            btn_SaveReport.UseVisualStyleBackColor = true;
            btn_SaveReport.Click += btn_SaveReport_Click;
            // 
            // btn_TestAll
            // 
            btn_TestAll.Location = new Point(436, 182);
            btn_TestAll.Name = "btn_TestAll";
            btn_TestAll.Size = new Size(190, 30);
            btn_TestAll.TabIndex = 6;
            btn_TestAll.Text = "Test All (bonus)";
            btn_TestAll.UseVisualStyleBackColor = true;
            btn_TestAll.Click += btn_TestAll_Click;
            // 
            // lbl_ItemNumber
            // 
            lbl_ItemNumber.AutoSize = true;
            lbl_ItemNumber.Location = new Point(12, 240);
            lbl_ItemNumber.Name = "lbl_ItemNumber";
            lbl_ItemNumber.Size = new Size(125, 15);
            lbl_ItemNumber.TabIndex = 7;
            lbl_ItemNumber.Text = "Choose an item (1-5):";
            // 
            // txt_ItemNumber
            // 
            txt_ItemNumber.Location = new Point(150, 237);
            txt_ItemNumber.Name = "txt_ItemNumber";
            txt_ItemNumber.Size = new Size(70, 23);
            txt_ItemNumber.TabIndex = 8;
            // 
            // lbl_Quantity
            // 
            lbl_Quantity.AutoSize = true;
            lbl_Quantity.Location = new Point(12, 272);
            lbl_Quantity.Name = "lbl_Quantity";
            lbl_Quantity.Size = new Size(126, 15);
            lbl_Quantity.TabIndex = 9;
            lbl_Quantity.Text = "Quantity sold (1-100):";
            // 
            // txt_Quantity
            // 
            txt_Quantity.Location = new Point(150, 269);
            txt_Quantity.Name = "txt_Quantity";
            txt_Quantity.Size = new Size(70, 23);
            txt_Quantity.TabIndex = 10;
            // 
            // btn_AddSale
            // 
            btn_AddSale.Location = new Point(236, 252);
            btn_AddSale.Name = "btn_AddSale";
            btn_AddSale.Size = new Size(120, 30);
            btn_AddSale.TabIndex = 11;
            btn_AddSale.Text = "Add Sale";
            btn_AddSale.UseVisualStyleBackColor = true;
            btn_AddSale.Click += btn_AddSale_Click;
            // 
            // lbl_BestRevenue
            // 
            lbl_BestRevenue.Location = new Point(12, 310);
            lbl_BestRevenue.Name = "lbl_BestRevenue";
            lbl_BestRevenue.Size = new Size(400, 20);
            lbl_BestRevenue.TabIndex = 12;
            lbl_BestRevenue.Text = "Highest revenue:";
            // 
            // lbl_BestQuantity
            // 
            lbl_BestQuantity.Location = new Point(12, 335);
            lbl_BestQuantity.Name = "lbl_BestQuantity";
            lbl_BestQuantity.Size = new Size(400, 20);
            lbl_BestQuantity.TabIndex = 13;
            lbl_BestQuantity.Text = "Highest quantity:";
            // 
            // lbl_SearchFor
            // 
            lbl_SearchFor.AutoSize = true;
            lbl_SearchFor.Location = new Point(12, 372);
            lbl_SearchFor.Name = "lbl_SearchFor";
            lbl_SearchFor.Size = new Size(64, 15);
            lbl_SearchFor.TabIndex = 14;
            lbl_SearchFor.Text = "Search for:";
            // 
            // txt_Search
            // 
            txt_Search.Location = new Point(140, 369);
            txt_Search.Name = "txt_Search";
            txt_Search.Size = new Size(120, 23);
            txt_Search.TabIndex = 15;
            // 
            // btn_Search
            // 
            btn_Search.Location = new Point(276, 366);
            btn_Search.Name = "btn_Search";
            btn_Search.Size = new Size(80, 30);
            btn_Search.TabIndex = 16;
            btn_Search.Text = "Search";
            btn_Search.UseVisualStyleBackColor = true;
            btn_Search.Click += btn_Search_Click;
            // 
            // lst_Results
            // 
            lst_Results.FormattingEnabled = true;
            lst_Results.ItemHeight = 15;
            lst_Results.Location = new Point(12, 405);
            lst_Results.Name = "lst_Results";
            lst_Results.Size = new Size(400, 64);
            lst_Results.TabIndex = 17;
            // 
            // lbl_Items
            // 
            lbl_Items.AutoSize = true;
            lbl_Items.Location = new Point(436, 222);
            lbl_Items.Name = "lbl_Items";
            lbl_Items.Size = new Size(36, 15);
            lbl_Items.TabIndex = 18;
            lbl_Items.Text = "Items";
            // 
            // lst_Items
            // 
            lst_Items.FormattingEnabled = true;
            lst_Items.ItemHeight = 15;
            lst_Items.Location = new Point(436, 240);
            lst_Items.Name = "lst_Items";
            lst_Items.Size = new Size(190, 184);
            lst_Items.TabIndex = 19;
            // 
            // btn_Quit
            // 
            btn_Quit.Location = new Point(436, 439);
            btn_Quit.Name = "btn_Quit";
            btn_Quit.Size = new Size(190, 30);
            btn_Quit.TabIndex = 20;
            btn_Quit.Text = "Quit";
            btn_Quit.UseVisualStyleBackColor = true;
            btn_Quit.Click += btn_Quit_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(640, 490);
            Controls.Add(btn_Quit);
            Controls.Add(lst_Items);
            Controls.Add(lbl_Items);
            Controls.Add(lst_Results);
            Controls.Add(btn_Search);
            Controls.Add(txt_Search);
            Controls.Add(lbl_SearchFor);
            Controls.Add(lbl_BestQuantity);
            Controls.Add(lbl_BestRevenue);
            Controls.Add(btn_AddSale);
            Controls.Add(txt_Quantity);
            Controls.Add(lbl_Quantity);
            Controls.Add(txt_ItemNumber);
            Controls.Add(lbl_ItemNumber);
            Controls.Add(btn_TestAll);
            Controls.Add(btn_SaveReport);
            Controls.Add(btn_BestSellers);
            Controls.Add(btn_ShowTable);
            Controls.Add(lst_Sales);
            Controls.Add(lbl_SalesTable);
            Controls.Add(lbl_Status);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Food Truck Sales";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_Status;
        private Label lbl_SalesTable;
        private ListBox lst_Sales;
        private Button btn_ShowTable;
        private Button btn_BestSellers;
        private Button btn_SaveReport;
        private Button btn_TestAll;
        private Label lbl_ItemNumber;
        private TextBox txt_ItemNumber;
        private Label lbl_Quantity;
        private TextBox txt_Quantity;
        private Button btn_AddSale;
        private Label lbl_BestRevenue;
        private Label lbl_BestQuantity;
        private Label lbl_SearchFor;
        private TextBox txt_Search;
        private Button btn_Search;
        private ListBox lst_Results;
        private Label lbl_Items;
        private ListBox lst_Items;
        private Button btn_Quit;
    }
}
