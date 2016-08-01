Imports System.IO
Imports System.Text
Imports System.Xml

Imports DataStreams.Csv
Imports DataStreams.Xml

Public Class MainForm
	Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

	Public Sub New()
		MyBase.New()

		'This call is required by the Windows Form Designer.
		InitializeComponent()

		'Add any initialization after the InitializeComponent() call

	End Sub

	'Form overrides dispose to clean up the component list.
	Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
		If disposing Then
			If Not (components Is Nothing) Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(disposing)
	End Sub

	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer

	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.  
	'Do not modify it using the code editor.
	Friend WithEvents Label3 As System.Windows.Forms.Label
	Friend WithEvents CsvTextBox As System.Windows.Forms.TextBox
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents XmlTextBox As System.Windows.Forms.TextBox
	Friend WithEvents DataGrid As System.Windows.Forms.DataGrid
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Me.Label3 = New System.Windows.Forms.Label
		Me.CsvTextBox = New System.Windows.Forms.TextBox
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.XmlTextBox = New System.Windows.Forms.TextBox
		Me.DataGrid = New System.Windows.Forms.DataGrid
		CType(Me.DataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'Label3
		'
		Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top
		Me.Label3.Location = New System.Drawing.Point(347, 234)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(96, 24)
		Me.Label3.TabIndex = 11
		Me.Label3.Text = "XML to DataGrid"
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'CsvTextBox
		'
		Me.CsvTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.CsvTextBox.BackColor = System.Drawing.Color.White
		Me.CsvTextBox.Location = New System.Drawing.Point(399, 26)
		Me.CsvTextBox.Multiline = True
		Me.CsvTextBox.Name = "CsvTextBox"
		Me.CsvTextBox.ReadOnly = True
		Me.CsvTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
		Me.CsvTextBox.Size = New System.Drawing.Size(384, 200)
		Me.CsvTextBox.TabIndex = 10
		Me.CsvTextBox.WordWrap = False
		'
		'Label2
		'
		Me.Label2.Location = New System.Drawing.Point(551, 2)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(72, 24)
		Me.Label2.TabIndex = 9
		Me.Label2.Text = "XML to CSV"
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'Label1
		'
		Me.Label1.Location = New System.Drawing.Point(183, 2)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(32, 24)
		Me.Label1.TabIndex = 8
		Me.Label1.Text = "XML"
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'XmlTextBox
		'
		Me.XmlTextBox.BackColor = System.Drawing.Color.White
		Me.XmlTextBox.Location = New System.Drawing.Point(7, 26)
		Me.XmlTextBox.Multiline = True
		Me.XmlTextBox.Name = "XmlTextBox"
		Me.XmlTextBox.ReadOnly = True
		Me.XmlTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
		Me.XmlTextBox.Size = New System.Drawing.Size(384, 200)
		Me.XmlTextBox.TabIndex = 7
		Me.XmlTextBox.WordWrap = False
		'
		'DataGrid
		'
		Me.DataGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
					Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.DataGrid.DataMember = ""
		Me.DataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText
		Me.DataGrid.Location = New System.Drawing.Point(7, 258)
		Me.DataGrid.Name = "DataGrid"
		Me.DataGrid.ReadOnly = True
		Me.DataGrid.Size = New System.Drawing.Size(779, 312)
		Me.DataGrid.TabIndex = 6
		'
		'MainForm
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.ClientSize = New System.Drawing.Size(792, 573)
		Me.Controls.Add(Me.Label3)
		Me.Controls.Add(Me.CsvTextBox)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.XmlTextBox)
		Me.Controls.Add(Me.DataGrid)
		Me.Name = "MainForm"
		Me.Text = "XmlRecordReader Demo"
		Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
		CType(Me.DataGrid, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

#End Region

	Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		Dim fileToLoad As String = "../../../../sample data/products.xml"

		Using readerXML As New StreamReader(fileToLoad, Encoding.UTF8)
			XmlTextBox.Text = readerXML.ReadToEnd()
		End Using

		Using readerGrid As New XmlRecordReader(fileToLoad, "products/product")

			With readerGrid.Columns
				.Add("productID", "ProductID")
				.Add("productName", "ProductName")
				.Add("supplierID", "SupplierID")
				.Add("categoryID", "CategoryID")
				.Add("quantityPerUnit", "QuantityPerUnit")
				.Add("unitPrice", "UnitPrice")
				.Add("unitsInStock", "UnitsInStock")
				.Add("unitsOnOrder", "UnitsOnOrder")
				.Add("reorderLevel", "ReorderLevel")
				.Add("discontinued", "Discontinued")
			End With

			DataGrid.DataSource = readerGrid.ReadToEnd()

		End Using

		Using result As New MemoryStream()
			Using readerCSV As New XmlRecordReader(fileToLoad, "products/product")
				Using writer As New CsvWriter(result, ","c, Encoding.Default)

					With readerCSV.Columns
						.Add("productID", "ProductID")
						.Add("productName", "ProductName")
						.Add("supplierID", "SupplierID")
						.Add("categoryID", "CategoryID")
						.Add("quantityPerUnit", "QuantityPerUnit")
						.Add("unitPrice", "UnitPrice")
						.Add("unitsInStock", "UnitsInStock")
						.Add("unitsOnOrder", "UnitsOnOrder")
						.Add("reorderLevel", "ReorderLevel")
						.Add("discontinued", "Discontinued")
					End With

					writer.WriteAll(readerCSV.ReadToEnd())
				End Using
			End Using

			Using resultReader As New StreamReader(New MemoryStream(result.ToArray()))
				CsvTextBox.Text = resultReader.ReadToEnd()
			End Using
		End Using
	End Sub
End Class
