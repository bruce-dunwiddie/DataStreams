Imports DataStreams.Xls

Public Class MainForm
	Inherits System.Windows.Forms.Form

	Private reader As XlsReader
	Private fileToLoad As String = "../../../../sample data/products.xls"

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
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents SheetNames As System.Windows.Forms.ComboBox
	Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
	Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
	Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents OpenToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
	Friend WithEvents DataGrid As System.Windows.Forms.DataGrid
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Me.Label1 = New System.Windows.Forms.Label
		Me.SheetNames = New System.Windows.Forms.ComboBox
		Me.DataGrid = New System.Windows.Forms.DataGrid
		Me.MenuStrip = New System.Windows.Forms.MenuStrip
		Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.OpenToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
		Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
		CType(Me.DataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.MenuStrip.SuspendLayout()
		Me.SuspendLayout()
		'
		'Label1
		'
		Me.Label1.Location = New System.Drawing.Point(12, 25)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(40, 23)
		Me.Label1.TabIndex = 0
		Me.Label1.Text = "Sheet:"
		Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'SheetNames
		'
		Me.SheetNames.Location = New System.Drawing.Point(69, 27)
		Me.SheetNames.Name = "SheetNames"
		Me.SheetNames.Size = New System.Drawing.Size(121, 21)
		Me.SheetNames.TabIndex = 1
		Me.SheetNames.Text = "sheet names"
		'
		'DataGrid
		'
		Me.DataGrid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
					Or System.Windows.Forms.AnchorStyles.Left) _
					Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.DataGrid.DataMember = ""
		Me.DataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText
		Me.DataGrid.Location = New System.Drawing.Point(8, 54)
		Me.DataGrid.Name = "DataGrid"
		Me.DataGrid.Size = New System.Drawing.Size(776, 514)
		Me.DataGrid.TabIndex = 2
		'
		'MenuStrip
		'
		Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem})
		Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
		Me.MenuStrip.Name = "MenuStrip"
		Me.MenuStrip.Size = New System.Drawing.Size(792, 24)
		Me.MenuStrip.TabIndex = 3
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
		Me.OpenToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
		Me.OpenToolStripMenuItem.Text = "&Open"
		'
		'ExitToolStripMenuItem
		'
		Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
		Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(103, 22)
		Me.ExitToolStripMenuItem.Text = "E&xit"
		'
		'OpenFileDialog
		'
		Me.OpenFileDialog.DefaultExt = "xls"
		Me.OpenFileDialog.Filter = "Excel files|*.xls|All files|*.*"
		'
		'MainForm
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
		Me.ClientSize = New System.Drawing.Size(792, 573)
		Me.Controls.Add(Me.DataGrid)
		Me.Controls.Add(Me.SheetNames)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.MenuStrip)
		Me.MainMenuStrip = Me.MenuStrip
		Me.Name = "MainForm"
		Me.Text = "XlsReader Demo"
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
		reader = New XlsReader(fileToLoad)
		reader.Settings.HasHeaders = True
		SheetNames.DataSource = reader.SheetNames
	End Sub

	Private Sub SheetNames_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SheetNames.SelectedIndexChanged
		reader.CurrentSheet = SheetNames.SelectedIndex
		DataGrid.DataSource = reader.Table
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
