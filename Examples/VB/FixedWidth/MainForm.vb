Imports System.IO
Imports System.Text
Imports System.Xml

Imports DataStreams.FixedWidth

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
	Friend WithEvents XmlTextBox As System.Windows.Forms.TextBox
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents FixedWidthTextBox As System.Windows.Forms.TextBox
	Friend WithEvents DataGrid As System.Windows.Forms.DataGrid
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Me.Label3 = New System.Windows.Forms.Label
		Me.XmlTextBox = New System.Windows.Forms.TextBox
		Me.Label2 = New System.Windows.Forms.Label
		Me.Label1 = New System.Windows.Forms.Label
		Me.FixedWidthTextBox = New System.Windows.Forms.TextBox
		Me.DataGrid = New System.Windows.Forms.DataGrid
		CType(Me.DataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'Label3
		'
		Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top
		Me.Label3.Location = New System.Drawing.Point(328, 232)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(136, 24)
		Me.Label3.TabIndex = 11
		Me.Label3.Text = "Fixed Width to DataGrid"
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'XmlTextBox
		'
		Me.XmlTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.XmlTextBox.BackColor = System.Drawing.Color.White
		Me.XmlTextBox.Location = New System.Drawing.Point(399, 26)
		Me.XmlTextBox.Multiline = True
		Me.XmlTextBox.Name = "XmlTextBox"
		Me.XmlTextBox.ReadOnly = True
		Me.XmlTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
		Me.XmlTextBox.Size = New System.Drawing.Size(384, 200)
		Me.XmlTextBox.TabIndex = 10
		Me.XmlTextBox.WordWrap = False
		'
		'Label2
		'
		Me.Label2.Location = New System.Drawing.Point(536, 0)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(104, 24)
		Me.Label2.TabIndex = 9
		Me.Label2.Text = "Fixed Width to XML"
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'Label1
		'
		Me.Label1.Location = New System.Drawing.Point(168, 0)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(64, 24)
		Me.Label1.TabIndex = 8
		Me.Label1.Text = "Fixed Width"
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'FixedWidthTextBox
		'
		Me.FixedWidthTextBox.BackColor = System.Drawing.Color.White
		Me.FixedWidthTextBox.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.FixedWidthTextBox.Location = New System.Drawing.Point(7, 26)
		Me.FixedWidthTextBox.Multiline = True
		Me.FixedWidthTextBox.Name = "FixedWidthTextBox"
		Me.FixedWidthTextBox.ReadOnly = True
		Me.FixedWidthTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
		Me.FixedWidthTextBox.Size = New System.Drawing.Size(384, 200)
		Me.FixedWidthTextBox.TabIndex = 7
		Me.FixedWidthTextBox.WordWrap = False
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
		Me.Controls.Add(Me.XmlTextBox)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.FixedWidthTextBox)
		Me.Controls.Add(Me.DataGrid)
		Me.Name = "MainForm"
		Me.Text = "FixedWidthReader Demo"
		Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
		CType(Me.DataGrid, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

#End Region

	Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
		Dim fileToLoad As String = "../../../../sample data/products.txt"

		Using reader As New StreamReader(fileToLoad, Encoding.Default)
			FixedWidthTextBox.Text = reader.ReadToEnd()
		End Using

		Using readerGrid As New FixedWidthReader(fileToLoad)
			With readerGrid.Columns
				.Add(5, "ProductID")
				.Add(35, "ProductName")
				.Add(5, "SupplierID")
				.Add(5, "CategoryID")
				.Add(20, "QuantityPerUnit")
				.Add(10, "UnitPrice")
				.Add(5, "UnitsInStock")
				.Add(5, "UnitsOnOrder")
				.Add(5, "ReorderLevel")
				.Add(1, "Discontinued")

				.Item("ProductID").Alignment = TextAlignment.Right
				.Item("ProductID").PaddingChar = "0"c
				.Item("SupplierID").Alignment = TextAlignment.Right
				.Item("SupplierID").PaddingChar = "0"c
				.Item("CategoryID").Alignment = TextAlignment.Right
				.Item("CategoryID").PaddingChar = "0"c
				.Item("UnitPrice").Alignment = TextAlignment.Right
				.Item("UnitPrice").PaddingChar = "0"c
				.Item("UnitPrice").MinLength = 1
				.Item("UnitsInStock").Alignment = TextAlignment.Right
				.Item("UnitsInStock").PaddingChar = "0"c
				.Item("UnitsInStock").MinLength = 1
				.Item("UnitsOnOrder").Alignment = TextAlignment.Right
				.Item("UnitsOnOrder").PaddingChar = "0"c
				.Item("UnitsOnOrder").MinLength = 1
				.Item("ReorderLevel").Alignment = TextAlignment.Right
				.Item("ReorderLevel").PaddingChar = "0"c
				.Item("ReorderLevel").MinLength = 1
			End With

			DataGrid.DataSource = readerGrid.ReadToEnd()
		End Using

		Dim data As DataTable

		Using result As New MemoryStream()
			Using readerXML As New FixedWidthReader(fileToLoad)

				With readerXML.Columns
					.Add(5, "ProductID")
					.Add(35, "ProductName")
					.Add(5, "SupplierID")
					.Add(5, "CategoryID")
					.Add(20, "QuantityPerUnit")
					.Add(10, "UnitPrice")
					.Add(5, "UnitsInStock")
					.Add(5, "UnitsOnOrder")
					.Add(5, "ReorderLevel")
					.Add(1, "Discontinued")

					.Item("ProductID").Alignment = TextAlignment.Right
					.Item("ProductID").PaddingChar = "0"c
					.Item("SupplierID").Alignment = TextAlignment.Right
					.Item("SupplierID").PaddingChar = "0"c
					.Item("CategoryID").Alignment = TextAlignment.Right
					.Item("CategoryID").PaddingChar = "0"c
					.Item("UnitPrice").Alignment = TextAlignment.Right
					.Item("UnitPrice").PaddingChar = "0"c
					.Item("UnitPrice").MinLength = 1
					.Item("UnitsInStock").Alignment = TextAlignment.Right
					.Item("UnitsInStock").PaddingChar = "0"c
					.Item("UnitsInStock").MinLength = 1
					.Item("UnitsOnOrder").Alignment = TextAlignment.Right
					.Item("UnitsOnOrder").PaddingChar = "0"c
					.Item("UnitsOnOrder").MinLength = 1
					.Item("ReorderLevel").Alignment = TextAlignment.Right
					.Item("ReorderLevel").PaddingChar = "0"c
					.Item("ReorderLevel").MinLength = 1
				End With

				data = readerXML.ReadToEnd()
			End Using

			Dim writer As New XmlTextWriter(result, Encoding.UTF8)

			writer.Formatting = Formatting.Indented
			writer.IndentChar = CChar(vbTab)
			writer.Indentation = 1

			writer.WriteStartDocument()
			writer.WriteStartElement("products")

			Dim row As DataRow
			For Each row In Data.Rows
				writer.WriteStartElement("product")

				Dim i As Integer
				For i = 0 To Data.Columns.Count - 1
					writer.WriteElementString(Data.Columns.Item(i).ColumnName.ToLower().Chars(0) + Data.Columns.Item(i).ColumnName.Substring(1), row.Item(i).ToString())
				Next

				writer.WriteEndElement()
			Next

			writer.WriteEndElement()
			writer.WriteEndDocument()
			writer.Close()

			Using resultReader As New StreamReader(New MemoryStream(result.GetBuffer()))
				XmlTextBox.Text = resultReader.ReadToEnd()
			End Using
		End Using
	End Sub
End Class
