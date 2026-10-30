// Contestant ID: ____________
// Date:
// Program: Timed Build 02 - Food Truck Sales
// Description:

using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace TimedBuild02
{
    public partial class Form1 : Form
    {
        // File names (relative paths - the files sit next to the .exe)
        const string SALES_FILE = "sales.csv";
        const string REPORT_FILE = "sales_report.txt";

        // TODO: after you write the FoodItem class (in FoodItem.cs), add the list field:
        // private List<FoodItem> items = new List<FoodItem>();

        public Form1()
        {
            InitializeComponent();
        }

        // ---------------------------------------------------------------
        // Helper methods - write your own here (whole-number check, load the
        // CSV, build the table lines, find the best sellers, ...)
        // ---------------------------------------------------------------


        // ---------------------------------------------------------------
        // Events - every method below is already wired to its control.
        // Do not rename them.
        // ---------------------------------------------------------------

        // Runs when the form opens: load sales.csv, show the load message in
        // lbl_Status, and fill lst_Items with "1. Taco ($3.50)" lines.
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO
        }

        // Option 1 - fill lst_Sales with the sales table and the TOTAL row.
        private void btn_ShowTable_Click(object sender, EventArgs e)
        {
            // TODO
        }

        // Option 2 - read txt_ItemNumber and txt_Quantity, validate both,
        // call AddSale, show the confirmation in lbl_Status.
        private void btn_AddSale_Click(object sender, EventArgs e)
        {
            // TODO
        }

        // Option 3 - show the two best-seller lines in lbl_BestRevenue and lbl_BestQuantity.
        private void btn_BestSellers_Click(object sender, EventArgs e)
        {
            // TODO
        }

        // Option 4 - search with txt_Search; results go in lst_Results.
        private void btn_Search_Click(object sender, EventArgs e)
        {
            // TODO
        }

        // Option 5 - write sales_report.txt inside try/catch.
        private void btn_SaveReport_Click(object sender, EventArgs e)
        {
            // TODO
        }

        // Option 6 - say Goodbye! in a MessageBox and close the form.
        private void btn_Quit_Click(object sender, EventArgs e)
        {
            // TODO
        }

        // Bonus (not in the 100 points) - click the other buttons from code.
        private void btn_TestAll_Click(object sender, EventArgs e)
        {
            // TODO
        }
    }
}
