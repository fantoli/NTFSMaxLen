<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmValidarLenNombres
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmValidarLenNombres))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblFolderSize = New System.Windows.Forms.Label()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnValidar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPath = New System.Windows.Forms.TextBox()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.lblDoing = New System.Windows.Forms.Label()
        Me.tmrCalcSize = New System.Windows.Forms.Timer(Me.components)
        Me.treeResult = New Telerik.WinControls.UI.RadTreeView()
        Me.RadMenu1 = New Telerik.WinControls.UI.RadMenu()
        Me.btnExpand = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.btnContraer = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.btnRename = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.btnOpenFolder = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.RadMenuButtonItem1 = New Telerik.WinControls.UI.RadMenuButtonItem()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.treeResult, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RadMenu1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel3, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDoing, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.treeResult, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.RadMenu1, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(809, 503)
        Me.TableLayoutPanel1.TabIndex = 29
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.AutoSize = True
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.btnCerrar, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblFolderSize, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 444)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(809, 29)
        Me.TableLayoutPanel2.TabIndex = 30
        '
        'btnCerrar
        '
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Location = New System.Drawing.Point(731, 3)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(75, 23)
        Me.btnCerrar.TabIndex = 6
        Me.btnCerrar.Text = "&Cerrar"
        '
        'lblFolderSize
        '
        Me.lblFolderSize.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.lblFolderSize.AutoSize = True
        Me.lblFolderSize.Location = New System.Drawing.Point(3, 8)
        Me.lblFolderSize.Name = "lblFolderSize"
        Me.lblFolderSize.Size = New System.Drawing.Size(72, 13)
        Me.lblFolderSize.TabIndex = 5
        Me.lblFolderSize.Text = "Tamaño total:"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 4
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.Controls.Add(Me.btnValidar, 3, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.txtPath, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btnBrowse, 2, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(803, 28)
        Me.TableLayoutPanel3.TabIndex = 31
        '
        'btnValidar
        '
        Me.btnValidar.Location = New System.Drawing.Point(725, 3)
        Me.btnValidar.Name = "btnValidar"
        Me.btnValidar.Size = New System.Drawing.Size(75, 23)
        Me.btnValidar.TabIndex = 3
        Me.btnValidar.Text = "&Validar"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 29)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "&Ruta"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPath
        '
        Me.txtPath.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtPath.Location = New System.Drawing.Point(39, 3)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.Size = New System.Drawing.Size(630, 20)
        Me.txtPath.TabIndex = 0
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(675, 3)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(29, 23)
        Me.btnBrowse.TabIndex = 2
        Me.btnBrowse.Text = "..."
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'lblDoing
        '
        Me.lblDoing.BackColor = System.Drawing.Color.LightGray
        Me.lblDoing.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDoing.Location = New System.Drawing.Point(0, 473)
        Me.lblDoing.Margin = New System.Windows.Forms.Padding(0)
        Me.lblDoing.Name = "lblDoing"
        Me.lblDoing.Size = New System.Drawing.Size(809, 30)
        Me.lblDoing.TabIndex = 32
        Me.lblDoing.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tmrCalcSize
        '
        '
        'treeResult
        '
        Me.treeResult.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.treeResult.Dock = System.Windows.Forms.DockStyle.Fill
        Me.treeResult.Location = New System.Drawing.Point(3, 101)
        Me.treeResult.Name = "treeResult"
        '
        '
        '
        Me.treeResult.RootElement.ControlBounds = New System.Drawing.Rectangle(3, 101, 150, 250)
        Me.treeResult.ShowLines = True
        Me.treeResult.ShowNodeToolTips = True
        Me.treeResult.Size = New System.Drawing.Size(803, 340)
        Me.treeResult.SpacingBetweenNodes = -1
        Me.treeResult.TabIndex = 33
        Me.treeResult.Text = "RadTreeView1"
        '
        'RadMenu1
        '
        Me.RadMenu1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.RadMenu1.Items.AddRange(New Telerik.WinControls.RadItem() {Me.btnExpand, Me.btnContraer, Me.btnRename, Me.btnOpenFolder})
        Me.RadMenu1.Location = New System.Drawing.Point(3, 37)
        Me.RadMenu1.Name = "RadMenu1"
        '
        '
        '
        Me.RadMenu1.RootElement.ControlBounds = New System.Drawing.Rectangle(3, 37, 100, 24)
        Me.RadMenu1.Size = New System.Drawing.Size(803, 58)
        Me.RadMenu1.TabIndex = 34
        Me.RadMenu1.Text = "RadMenu1"
        '
        'btnExpand
        '
        Me.btnExpand.AutoSize = False
        Me.btnExpand.Bounds = New System.Drawing.Rectangle(0, 0, 78, 58)
        Me.btnExpand.Image = Global.NTFSMaxLen.My.Resources.Resources.down_plus
        Me.btnExpand.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnExpand.Name = "btnExpand"
        Me.btnExpand.Text = "Expandir"
        Me.btnExpand.TextAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.btnExpand.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnContraer
        '
        Me.btnContraer.AutoSize = False
        Me.btnContraer.Bounds = New System.Drawing.Rectangle(0, 0, 78, 58)
        Me.btnContraer.Image = Global.NTFSMaxLen.My.Resources.Resources.up_minus
        Me.btnContraer.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnContraer.Name = "btnContraer"
        Me.btnContraer.Text = "Contraer"
        Me.btnContraer.TextAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.btnContraer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnRename
        '
        Me.btnRename.AutoSize = False
        Me.btnRename.Bounds = New System.Drawing.Rectangle(0, 0, 78, 58)
        Me.btnRename.Image = Global.NTFSMaxLen.My.Resources.Resources.pencil
        Me.btnRename.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnRename.Name = "btnRename"
        Me.btnRename.Text = "Renombrar"
        Me.btnRename.TextAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.btnRename.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'btnOpenFolder
        '
        Me.btnOpenFolder.AutoSize = False
        Me.btnOpenFolder.Bounds = New System.Drawing.Rectangle(0, 0, 78, 58)
        Me.btnOpenFolder.Image = Global.NTFSMaxLen.My.Resources.Resources.open_new_folder
        Me.btnOpenFolder.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnOpenFolder.Name = "btnOpenFolder"
        Me.btnOpenFolder.Text = "Abrir"
        Me.btnOpenFolder.TextAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.btnOpenFolder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'RadMenuButtonItem1
        '
        Me.RadMenuButtonItem1.AutoSize = False
        Me.RadMenuButtonItem1.Bounds = New System.Drawing.Rectangle(0, 0, 78, 58)
        Me.RadMenuButtonItem1.Image = Global.NTFSMaxLen.My.Resources.Resources.down_plus
        Me.RadMenuButtonItem1.ImageAlignment = System.Drawing.ContentAlignment.MiddleCenter
        Me.RadMenuButtonItem1.Name = "RadMenuButtonItem1"
        Me.RadMenuButtonItem1.Text = "Expandir"
        Me.RadMenuButtonItem1.TextAlignment = System.Drawing.ContentAlignment.TopCenter
        Me.RadMenuButtonItem1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'frmValidarLenNombres
        '
        Me.AcceptButton = Me.btnValidar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(809, 503)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(350, 140)
        Me.Name = "frmValidarLenNombres"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Validar longitud de nombres de ficheros"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout()
        CType(Me.treeResult, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RadMenu1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnValidar As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPath As System.Windows.Forms.TextBox
    Friend WithEvents lblDoing As System.Windows.Forms.Label
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents lblFolderSize As System.Windows.Forms.Label
    Friend WithEvents treeResult As Telerik.WinControls.UI.RadTreeView
    Friend WithEvents tmrCalcSize As System.Windows.Forms.Timer
    Friend WithEvents btnExpand As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents RadMenu1 As Telerik.WinControls.UI.RadMenu
    Friend WithEvents btnContraer As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents btnRename As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents btnOpenFolder As Telerik.WinControls.UI.RadMenuButtonItem
    Friend WithEvents RadMenuButtonItem1 As Telerik.WinControls.UI.RadMenuButtonItem
End Class
