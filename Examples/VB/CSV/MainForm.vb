Imports System.IO
Imports System.Text
Imports System.Xml

Imports DataStreams.Csv

Public Class MainForm
	Inherits System.Windows.Forms.Form

	Private fileToLoad As String = "../../../../sample data/products.csv"

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
	Friend WithEvents DataGrid As System.Windows.Forms.DataGrid
	Friend WithEvents CsvTextBox As System.Windows.Forms.TextBox
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents XmlTextBox As System.Windows.Forms.TextBox
	Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
	Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
	Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents Label3 As System.Windows.Forms.Label
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Me.DataGrid = New System.Windows.Forms.DataGrid
		Me.CsvTextBox = New System.Windows.Forms.TextBox
		Me.Label1 = New System.Windows.Forms.Label
		Me.Label2 = New System.Windows.Forms.Label
		Me.XmlTextBox = New System.Windows.Forms.TextBox
		Me.Label3 = New System.Windows.Forms.Label
		Me.MenuStrip = New System.Windows.Forms.MenuStrip
		Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
		CType(Me.DataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.MenuStrip.SuspendLayout()
		Me.SuspendLayout()
		'
		'DataGrid
		'
		Me.DataGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
					Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.DataGrid.DataMember = ""
		Me.DataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText
		Me.DataGrid.Location = New System.Drawing.Point(8, 283)
		Me.DataGrid.Name = "DataGrid"
		Me.DataGrid.ReadOnly = True
		Me.DataGrid.Size = New System.Drawing.Size(779, 285)
		Me.DataGrid.TabIndex = 0
		'
		'CsvTextBox
		'
		Me.CsvTextBox.BackColor = System.Drawing.Color.White
		Me.CsvTextBox.Location = New System.Drawing.Point(8, 50)
		Me.CsvTextBox.Multiline = True
		Me.CsvTextBox.Name = "CsvTextBox"
		Me.CsvTextBox.ReadOnly = True
		Me.CsvTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
		Me.CsvTextBox.Size = New System.Drawing.Size(384, 200)
		Me.CsvTextBox.TabIndex = 1
		Me.CsvTextBox.WordWrap = False
		'
		'Label1
		'
		Me.Label1.Location = New System.Drawing.Point(184, 26)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(32, 24)
		Me.Label1.TabIndex = 2
		Me.Label1.Text = "CSV"
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'Label2
		'
		Me.Label2.Location = New System.Drawing.Point(552, 26)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(72, 24)
		Me.Label2.TabIndex = 3
		Me.Label2.Text = "CSV to XML"
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'XmlTextBox
		'
		Me.XmlTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.XmlTextBox.BackColor = System.Drawing.Color.White
		Me.XmlTextBox.Location = New System.Drawing.Point(400, 50)
		Me.XmlTextBox.Multiline = True
		Me.XmlTextBox.Name = "XmlTextBox"
		Me.XmlTextBox.ReadOnly = True
		Me.XmlTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both
		Me.XmlTextBox.Size = New System.Drawing.Size(384, 200)
		Me.XmlTextBox.TabIndex = 4
		Me.XmlTextBox.WordWrap = False
		'
		'Label3
		'
		Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top
		Me.Label3.Location = New System.Drawing.Point(348, 256)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(96, 24)
		Me.Label3.TabIndex = 5
		Me.Label3.Text = "CSV to DataGrid"
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'MenuStrip
		'
		Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem})
		Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
		Me.MenuStrip.Name = "MenuStrip"
		Me.MenuStrip.Size = New System.Drawing.Size(792, 24)
		Me.MenuStrip.TabIndex = 6
		Me.MenuStrip.Text = "MenuStrip"
		'
		'FileToolStripMenuItem
		'
		Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem, Me.ExitToolStripMenuItem})
		Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
		Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
		Me.FileToolStripMenuItem.Text = "&File"
		'
		'OpenToolStripMenuItem
		'
		Me.OpenToolStripMenuItem.Name = "OpenToolStripMenuItem"
		Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
		Me.OpenToolStripMenuItem.Text = "&Open"
		'
		'ExitToolStripMenuItem
		'
		Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
		Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
		Me.ExitToolStripMenuItem.Text = "E&xit"
		'
		'OpenFileDialog
		'
		Me.OpenFileDialog.DefaultExt = "csv"
		Me.OpenFileDialog.Filter = "CSV files|*.csv|All files|*.*"
		'
		'MainForm
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.ClientSize = New System.Drawing.Size(792, 573)
		Me.Controls.Add(Me.Label3)
		Me.Controls.Add(Me.XmlTextBox)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.CsvTextBox)
		Me.Controls.Add(Me.DataGrid)
		Me.Controls.Add(Me.MenuStrip)
		Me.MainMenuStrip = Me.MenuStrip
		Me.Name = "MainForm"
		Me.Text = "CsvReader Demo"
		Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
		CType(Me.DataGrid, System.ComponentModel.ISupportInitialize).EndInit()
		Me.MenuStrip.ResumeLayout(False)
		Me.MenuStrip.PerformLayout()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

#End Region

	Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		LoadFromFile()
	End Sub

	Private Sub LoadFromFile()

		Using readerCSV As New StreamReader(fileToLoad, Encoding.Default)
			CsvTextBox.Text = readerCSV.ReadToEnd
		End Using

		Using readerGrid As New CsvReader(fileToLoad)
			DataGrid.DataSource = readerGrid.ReadToEnd()
		End Using

		Using readerXML As New CsvReader(fileToLoad)
			Using result As New MemoryStream()
				Dim writer As New XmlTextWriter(result, Encoding.UTF8)

				writer.Formatting = Formatting.Indented
				writer.IndentChar = CChar(vbTab)
				writer.Indentation = 1

				writer.WriteStartDocument()
				writer.WriteStartElement("products")

				readerXML.ReadHeaders()

				Do While readerXML.ReadRecord()
					writer.WriteStartElement("product")

					Dim i As Integer
					For i = 0 To readerXML.ColumnCount - 1
						writer.WriteElementString(readerXML.GetHeader(i).ToLower().Chars(0) + readerXML.GetHeader(i).Substring(1), readerXML.Item(i))
					Next

					writer.WriteEndElement()
				Loop

				writer.WriteEndElement()
				writer.WriteEndDocument()
				writer.Close()

				Using resultReader As New StreamReader(New MemoryStream(result.ToArray()))
					XmlTextBox.Text = resultReader.ReadToEnd()
				End Using
			End Using
		End Using
	End Sub

	Private Sub OpenToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem.Click
		Dim result As DialogResult = OpenFileDialog.ShowDialog(Me)
		If result = DialogResult.OK AndAlso OpenFileDialog.FileName.Length > 0 Then
			fileToLoad = OpenFileDialog.FileName
			LoadFromFile()
		End If
	End Sub

	Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
		Close()
	End Sub
End Class
