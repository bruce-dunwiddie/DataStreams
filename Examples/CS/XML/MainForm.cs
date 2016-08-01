using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Forms;

using DataStreams.Csv;
using DataStreams.Xml;

namespace DemoXML
{
	public class MainForm : System.Windows.Forms.Form
	{
		#region Windows Form Designer generated code
		private System.Windows.Forms.TextBox XmlTextBox;
		private System.Windows.Forms.TextBox CsvTextBox;
		private System.Windows.Forms.DataGrid dataGrid;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		
		private System.ComponentModel.Container components = null;

		public MainForm()
		{
			InitializeComponent();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.XmlTextBox = new System.Windows.Forms.TextBox();
			this.CsvTextBox = new System.Windows.Forms.TextBox();
			this.dataGrid = new System.Windows.Forms.DataGrid();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// XmlTextBox
			// 
			this.XmlTextBox.BackColor = System.Drawing.Color.White;
			this.XmlTextBox.Location = new System.Drawing.Point(8, 26);
			this.XmlTextBox.Multiline = true;
			this.XmlTextBox.Name = "XmlTextBox";
			this.XmlTextBox.ReadOnly = true;
			this.XmlTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.XmlTextBox.Size = new System.Drawing.Size(384, 200);
			this.XmlTextBox.TabIndex = 10;
			this.XmlTextBox.WordWrap = false;
			// 
			// CsvTextBox
			// 
			this.CsvTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.CsvTextBox.BackColor = System.Drawing.Color.White;
			this.CsvTextBox.Location = new System.Drawing.Point(400, 26);
			this.CsvTextBox.Multiline = true;
			this.CsvTextBox.Name = "CsvTextBox";
			this.CsvTextBox.ReadOnly = true;
			this.CsvTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.CsvTextBox.Size = new System.Drawing.Size(384, 200);
			this.CsvTextBox.TabIndex = 7;
			this.CsvTextBox.WordWrap = false;
			// 
			// dataGrid
			// 
			this.dataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid.DataMember = "";
			this.dataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid.Location = new System.Drawing.Point(8, 258);
			this.dataGrid.Name = "dataGrid";
			this.dataGrid.ReadOnly = true;
			this.dataGrid.Size = new System.Drawing.Size(776, 312);
			this.dataGrid.TabIndex = 6;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(184, 2);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 24);
			this.label1.TabIndex = 11;
			this.label1.Text = "XML";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(552, 2);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 24);
			this.label2.TabIndex = 9;
			this.label2.Text = "XML to CSV";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label3.Location = new System.Drawing.Point(352, 234);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(88, 24);
			this.label3.TabIndex = 8;
			this.label3.Text = "XML to DataGrid";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(792, 573);
			this.Controls.Add(this.XmlTextBox);
			this.Controls.Add(this.CsvTextBox);
			this.Controls.Add(this.dataGrid);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label3);
			this.Name = "MainForm";
			this.Text = "XmlRecordReader Demo";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.MainForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new MainForm());
		}

		private void MainForm_Load(object sender, System.EventArgs e)
		{
			string fileToLoad = "../../../../../sample data/products.xml";

			using (StreamReader reader = new StreamReader(fileToLoad, Encoding.UTF8))
			{
				XmlTextBox.Text = reader.ReadToEnd();
			}

			using (XmlRecordReader reader = new XmlRecordReader(fileToLoad, "products/product"))
			{
				reader.Columns.Add("productID", "ProductID");
				reader.Columns.Add("productName", "ProductName");
				reader.Columns.Add("supplierID", "SupplierID");
				reader.Columns.Add("categoryID", "CategoryID");
				reader.Columns.Add("quantityPerUnit", "QuantityPerUnit");
				reader.Columns.Add("unitPrice", "UnitPrice");
				reader.Columns.Add("unitsInStock", "UnitsInStock");
				reader.Columns.Add("unitsOnOrder", "UnitsOnOrder");
				reader.Columns.Add("reorderLevel", "ReorderLevel");
				reader.Columns.Add("discontinued", "Discontinued");

				dataGrid.DataSource = reader.ReadToEnd();
			}

			using (MemoryStream result = new MemoryStream())
			{
				using (XmlRecordReader reader = new XmlRecordReader(fileToLoad, "products/product"))
				using (CsvWriter writer = new CsvWriter(result, ',', Encoding.Default))
				{
					reader.Columns.Add("productID", "ProductID");
					reader.Columns.Add("productName", "ProductName");
					reader.Columns.Add("supplierID", "SupplierID");
					reader.Columns.Add("categoryID", "CategoryID");
					reader.Columns.Add("quantityPerUnit", "QuantityPerUnit");
					reader.Columns.Add("unitPrice", "UnitPrice");
					reader.Columns.Add("unitsInStock", "UnitsInStock");
					reader.Columns.Add("unitsOnOrder", "UnitsOnOrder");
					reader.Columns.Add("reorderLevel", "ReorderLevel");
					reader.Columns.Add("discontinued", "Discontinued");

					writer.WriteAll(reader.ReadToEnd());
				}

				using (StreamReader resultReader = new StreamReader(new MemoryStream(result.GetBuffer())))
				{
					CsvTextBox.Text = resultReader.ReadToEnd();
				}
			}
		}
	}
}
