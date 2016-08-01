using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Xml;
using System.Windows.Forms;

using DataStreams.FixedWidth;

namespace DemoFixedWidth
{
	public class MainForm : System.Windows.Forms.Form
	{
		#region Windows Form Designer generated code
		private System.Windows.Forms.TextBox fixedWidthTextBox;
		private System.Windows.Forms.TextBox XmlTextBox;
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
			this.fixedWidthTextBox = new System.Windows.Forms.TextBox();
			this.XmlTextBox = new System.Windows.Forms.TextBox();
			this.dataGrid = new System.Windows.Forms.DataGrid();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// fixedWidthTextBox
			// 
			this.fixedWidthTextBox.BackColor = System.Drawing.Color.White;
			this.fixedWidthTextBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.fixedWidthTextBox.Location = new System.Drawing.Point(8, 26);
			this.fixedWidthTextBox.Multiline = true;
			this.fixedWidthTextBox.Name = "fixedWidthTextBox";
			this.fixedWidthTextBox.ReadOnly = true;
			this.fixedWidthTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.fixedWidthTextBox.Size = new System.Drawing.Size(384, 200);
			this.fixedWidthTextBox.TabIndex = 10;
			this.fixedWidthTextBox.WordWrap = false;
			// 
			// XmlTextBox
			// 
			this.XmlTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.XmlTextBox.BackColor = System.Drawing.Color.White;
			this.XmlTextBox.Location = new System.Drawing.Point(400, 26);
			this.XmlTextBox.Multiline = true;
			this.XmlTextBox.Name = "XmlTextBox";
			this.XmlTextBox.ReadOnly = true;
			this.XmlTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.XmlTextBox.Size = new System.Drawing.Size(384, 200);
			this.XmlTextBox.TabIndex = 7;
			this.XmlTextBox.WordWrap = false;
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
			this.label1.Location = new System.Drawing.Point(144, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(136, 24);
			this.label1.TabIndex = 11;
			this.label1.Text = "Fixed Width";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(520, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(120, 24);
			this.label2.TabIndex = 9;
			this.label2.Text = "Fixed Width to XML";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label3
			// 
			this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label3.Location = new System.Drawing.Point(336, 232);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(152, 24);
			this.label3.TabIndex = 8;
			this.label3.Text = "Fixed Width to DataGrid";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(792, 573);
			this.Controls.Add(this.fixedWidthTextBox);
			this.Controls.Add(this.XmlTextBox);
			this.Controls.Add(this.dataGrid);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label3);
			this.Name = "MainForm";
			this.Text = "FixedWidthReader Demo";
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
			string fileToLoad = "../../../../../sample data/products.txt";

			using (StreamReader reader = new StreamReader(fileToLoad, Encoding.Default))
			{
				fixedWidthTextBox.Text = reader.ReadToEnd();
			}

			using (FixedWidthReader reader = new FixedWidthReader(fileToLoad))
			{
				reader.Columns.Add(5,"ProductID");
				reader.Columns.Add(35,"ProductName");
				reader.Columns.Add(5,"SupplierID");
				reader.Columns.Add(5,"CategoryID");
				reader.Columns.Add(20,"QuantityPerUnit");
				reader.Columns.Add(10,"UnitPrice");
				reader.Columns.Add(5,"UnitsInStock");
				reader.Columns.Add(5,"UnitsOnOrder");
				reader.Columns.Add(5,"ReorderLevel");
				reader.Columns.Add(1,"Discontinued");

				reader.Columns["ProductID"].Alignment = TextAlignment.Right;
				reader.Columns["ProductID"].PaddingChar = '0';
				reader.Columns["SupplierID"].Alignment = TextAlignment.Right;
				reader.Columns["SupplierID"].PaddingChar = '0';
				reader.Columns["CategoryID"].Alignment = TextAlignment.Right;
				reader.Columns["CategoryID"].PaddingChar = '0';
				reader.Columns["UnitPrice"].Alignment = TextAlignment.Right;
				reader.Columns["UnitPrice"].PaddingChar = '0';
				reader.Columns["UnitPrice"].MinLength = 1;
				reader.Columns["UnitsInStock"].Alignment = TextAlignment.Right;
				reader.Columns["UnitsInStock"].PaddingChar = '0';
				reader.Columns["UnitsInStock"].MinLength = 1;
				reader.Columns["UnitsOnOrder"].Alignment = TextAlignment.Right;
				reader.Columns["UnitsOnOrder"].PaddingChar = '0';
				reader.Columns["UnitsOnOrder"].MinLength = 1;
				reader.Columns["ReorderLevel"].Alignment = TextAlignment.Right;
				reader.Columns["ReorderLevel"].PaddingChar = '0';
				reader.Columns["ReorderLevel"].MinLength = 1;

				dataGrid.DataSource = reader.ReadToEnd();
			}

			using (MemoryStream result = new MemoryStream())
			{
				using (FixedWidthReader reader = new FixedWidthReader(fileToLoad))
				{
					reader.Columns.Add(5,"ProductID");
					reader.Columns.Add(35,"ProductName");
					reader.Columns.Add(5,"SupplierID");
					reader.Columns.Add(5,"CategoryID");
					reader.Columns.Add(20,"QuantityPerUnit");
					reader.Columns.Add(10,"UnitPrice");
					reader.Columns.Add(5,"UnitsInStock");
					reader.Columns.Add(5,"UnitsOnOrder");
					reader.Columns.Add(5,"ReorderLevel");
					reader.Columns.Add(1,"Discontinued");

					reader.Columns["ProductID"].Alignment = TextAlignment.Right;
					reader.Columns["ProductID"].PaddingChar = '0';
					reader.Columns["SupplierID"].Alignment = TextAlignment.Right;
					reader.Columns["SupplierID"].PaddingChar = '0';
					reader.Columns["CategoryID"].Alignment = TextAlignment.Right;
					reader.Columns["CategoryID"].PaddingChar = '0';
					reader.Columns["UnitPrice"].Alignment = TextAlignment.Right;
					reader.Columns["UnitPrice"].PaddingChar = '0';
					reader.Columns["UnitPrice"].MinLength = 1;
					reader.Columns["UnitsInStock"].Alignment = TextAlignment.Right;
					reader.Columns["UnitsInStock"].PaddingChar = '0';
					reader.Columns["UnitsInStock"].MinLength = 1;
					reader.Columns["UnitsOnOrder"].Alignment = TextAlignment.Right;
					reader.Columns["UnitsOnOrder"].PaddingChar = '0';
					reader.Columns["UnitsOnOrder"].MinLength = 1;
					reader.Columns["ReorderLevel"].Alignment = TextAlignment.Right;
					reader.Columns["ReorderLevel"].PaddingChar = '0';
					reader.Columns["ReorderLevel"].MinLength = 1;

					DataTable data = reader.ReadToEnd();

					XmlTextWriter writer = new XmlTextWriter(result, Encoding.UTF8);

					writer.Formatting = Formatting.Indented;
					writer.IndentChar = '\t';
					writer.Indentation = 1;

					writer.WriteStartDocument();
					writer.WriteStartElement("products");

					foreach (DataRow row in data.Rows)
					{
						writer.WriteStartElement("product");

						for (int i = 0; i < data.Columns.Count; i++)
						{
							writer.WriteElementString(data.Columns[i].ColumnName.ToLower()[0] + data.Columns[i].ColumnName.Substring(1), row[i].ToString());
						}

						writer.WriteEndElement();
					}

					writer.WriteEndElement();
					writer.WriteEndDocument();
					writer.Close();
				}

				using (StreamReader resultReader = new StreamReader(new MemoryStream(result.GetBuffer())))
				{
					XmlTextBox.Text = resultReader.ReadToEnd();
				}
			}
		}
	}
}
