Imports Telerik.WinControls.UI
Imports System.IO

Public Class frmValidarLenNombres
    Public Const folderKey As String = "folder"
    Public Const fileKey As String = "file"

    Private _maxLen As Integer
    Private _foundFilesOrFolders As Boolean

    Private _isProcessing As Boolean = False
    Private _isStopRequested As Boolean = False
    Private _isExplorationOk As Boolean = True

    Private Sub frmValidarLenNombres_Load(sender As Object, e As EventArgs) Handles Me.Load
        _maxLen = My.Settings.MaxLen
        Me.Text = Me.Text & " v." & My.Application.Info.Version.ToString & " (" & _maxLen.ToString & " caracteres)"
        Dim _imgLst As New ImageList
        _imgLst.Images.Add(folderKey, My.Resources.folder)
        _imgLst.Images.Add(fileKey, My.Resources.document)
        treeResult.ImageList = _imgLst
        Me.ActiveControl = txtPath
        btnRename.Shortcuts.Add(New Telerik.WinControls.RadShortcut(Keys.Control, Keys.R))
        btnOpenFolder.Shortcuts.Add(New Telerik.WinControls.RadShortcut(Keys.Control, Keys.O))
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        If _isProcessing Then
            _isStopRequested = True
        Else
            End
        End If
    End Sub

    Private Sub btnValidar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnValidar.Click
        Dim _txtBtnCerrar As String = btnCerrar.Text

        txtPath.Enabled = False
        btnBrowse.Enabled = False
        btnValidar.Enabled = False
        _isProcessing = True
        _isStopRequested = False
        btnCerrar.Text = "Cancelar"
        Try
            If Not Directory.Exists(txtPath.Text) Then
                Throw New Exception("La ruta especificada no existe")
            End If
            _isExplorationOk = True
            Me.validateLen(txtPath.Text)
            Me.expandNodes(treeResult.Nodes(0))
            If Not _isExplorationOk Then
                MessageBox.Show("Algunas carpetas no han podido explorarse por exceder su nombre de " & _maxLen.ToString & " caracteres.", My.Application.Info.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            btnValidar.Enabled = True
        End Try
        txtPath.Enabled = True
        btnBrowse.Enabled = True
        btnValidar.Enabled = True
        _isProcessing = False
        btnCerrar.Text = _txtBtnCerrar
    End Sub

    Private Function skipFolder(ByVal folderPath As String) As Boolean
        ' Devuelve TRUE si la carpeta es una de las que deben saltarse, falso en caso contrario
        Dim _foldersArray As List(Of String) = My.Settings.FoldersToSkip.Split("|").ToList
        Dim _folderName As String = Path.GetFileName(folderPath)

        For Each _folder As String In _foldersArray
            If _folder.ToLower = _folderName.ToLower Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub validateLen(ByVal pathToCheck As String)
        If Me.skipFolder(pathToCheck) Then
            Throw New Exception("Esta carpeta no está permitida")
        End If
        Me.showMsg("Validando " & txtPath.Text)
        _foundFilesOrFolders = False
        treeResult.Nodes.Clear()
        Me.checkLen(Nothing, txtPath.Text)
        If _foundFilesOrFolders Then
            Me.showMsg("Validación finalizada. SE HAN ENCONTRADO CARPETAS O FICHEROS CUYO NOMBRE EXCEDE DE " + _maxLen.ToString & " CARACTERES.")
        Else
            Me.showMsg("Validación finalizada. No se han encontrado carpetas o ficheros cuyo nombre exceda de " + _maxLen.ToString & " caracteres.")
        End If
        Me.showMsg("Calculando el tamaño total de la carpeta")
        lblFolderSize.Text = "Tamaño total: Calculando..."
        tmrCalcSize.Enabled = True
    End Sub

    Private Sub checkLen(ByRef parentNode As RadTreeNode, ByVal folder As String)
        Dim _folderNode As RadTreeNode = Nothing

        Application.DoEvents()
        If _isStopRequested Then
            Return
        End If

        If Me.skipFolder(folder) Then
            Return
        End If

        Me.showMsg("Validando carpeta " & folder)
        'If chkDetailedResults.Checked Then
        '    lstResult.Items.Add("Validando carpeta " & pathToCheck)
        '    lstResult.TopIndex = lstResult.Items.Count - 1
        'End If
        _folderNode = Me.addFolderNode(parentNode, folder)
        If _folderNode.FullPath.Length > _maxLen Then
            _isExplorationOk = False
            _folderNode.ForeColor = Color.Red
            Dim _parent As RadTreeNode = parentNode
            While Not _parent Is Nothing
                _parent.ForeColor = Color.Red
                _parent = _parent.Parent
            End While
            _foundFilesOrFolders = True
        Else
            For Each _folder As String In Directory.GetDirectories(folder)
                If Not _folder.Contains("DfsrPrivate") Then
                    Me.checkLen(_folderNode, _folder)
                End If
            Next
        End If
        For Each _file As String In Directory.GetFiles(folder)
            If _file.Length > _maxLen Then
                Me.addFileNode(_folderNode, _file)
            End If
        Next
    End Sub

    Private Function addFolderNode(ByRef parentNode As RadTreeNode, ByVal folderPath As String) As RadTreeNode
        Dim _node As RadTreeNode = New RadTreeNode

        _node.ImageKey = folderKey
        If parentNode Is Nothing Then
            _node.Text = folderPath
        Else
            _node.Text = Path.GetFileName(folderPath)
        End If
        _node.Value = _node.Text
        _node.ToolTipText = folderPath.Length.ToString & " cars"
        _node.ForeColor = Color.Black
        If parentNode Is Nothing Then
            treeResult.Nodes.Add(_node)
        Else
            parentNode.Nodes.Add(_node)
        End If
        Return _node
    End Function

    Private Function addFileNode(ByRef parentNode As RadTreeNode, ByVal filePath As String) As RadTreeNode
        Dim _node As RadTreeNode = New RadTreeNode
        Dim _redNode As RadTreeNode = Nothing

        _node.ImageKey = fileKey
        _node.Text = Path.GetFileName(filePath)
        _node.ToolTipText = filePath.Length.ToString & " cars"
        _node.ForeColor = Color.Red
        parentNode.Nodes.Add(_node)
        _redNode = parentNode
        While Not _redNode Is Nothing
            _redNode.ForeColor = Color.Red
            _redNode = _redNode.Parent
        End While
        _foundFilesOrFolders = True
        Return _node
    End Function

    Private Sub showMsg(ByVal msg As String)
        lblDoing.Text = msg
        Application.DoEvents()
    End Sub

    Private Function getFolderSizeInGBytes(ByVal DirPath As String, Optional ByVal IncludeSubFolders As Boolean = True) As Double
        Return Me.getFolderSizeInMBytes(DirPath, IncludeSubFolders) / 1024
    End Function

    Private Function getFolderSizeInMBytes(ByVal DirPath As String, Optional ByVal IncludeSubFolders As Boolean = True) As Double
        Return Me.getFolderSizeInKBytes(DirPath, IncludeSubFolders) / 1024
    End Function

    Private Function getFolderSizeInKBytes(ByVal DirPath As String, Optional ByVal IncludeSubFolders As Boolean = True) As Double
        Return Me.getFolderSizeInBytes(DirPath, IncludeSubFolders) / 1024
    End Function

    Private Function getFolderSizeInBytes(ByVal DirPath As String, Optional ByVal IncludeSubFolders As Boolean = True) As Double
        Dim lngDirSize As Long
        Dim objFileInfo As FileInfo
        Dim objSubFolder As DirectoryInfo

        Application.DoEvents()
        If _isStopRequested Then
            Return lngDirSize
        End If

        If DirPath.Contains("DfsrPrivate") Then
            lngDirSize = 0
        Else
            Dim objDir As DirectoryInfo = New DirectoryInfo(DirPath)

            'add length of each file
            For Each objFileInfo In objDir.GetFiles()
                lngDirSize += objFileInfo.Length
            Next

            'call recursively to get sub folders
            'if you don't want this set optional
            'parameter to false 
            If IncludeSubFolders Then
                For Each objSubFolder In objDir.GetDirectories()
                    lngDirSize = lngDirSize + CLng(getFolderSizeInBytes(objSubFolder.FullName))
                Next
            End If
        End If
        Return CDbl(lngDirSize)
    End Function

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Dim _fbd As FolderBrowserDialog
        Me.Cursor = Cursors.WaitCursor
        Try
            _fbd = New FolderBrowserDialog
            If txtPath.Text.Length > 0 Then
                _fbd.SelectedPath = txtPath.Text
            End If
            _fbd.ShowNewFolderButton = False
            _fbd.Description = "Seleccione la carpeta a validar"
            If _fbd.ShowDialog() = DialogResult.OK Then
                txtPath.Text = _fbd.SelectedPath
            End If
            txtPath.Focus()
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub expandNodes(ByRef node As RadTreeNode)
        If node.ForeColor = Color.Red Then
            node.Expand()
            For Each _child In node.Nodes
                Me.expandNodes(_child)
            Next
        End If
    End Sub

    Private Sub tmrCalcSize_Tick(sender As Object, e As EventArgs) Handles tmrCalcSize.Tick
        tmrCalcSize.Enabled = False
        Try
            lblFolderSize.Text = "Tamaño total: " & FormatNumber(Me.getFolderSizeInMBytes(txtPath.Text, True), 2).ToString & "Mb"
        Catch ex As Exception
            lblFolderSize.Text = "Tamaño total: N/A"
        Finally
            lblDoing.Text = ""
        End Try
    End Sub

    Private Sub btnExpand_Click(sender As Object, e As EventArgs) Handles btnExpand.Click
        Me.Cursor = Cursors.WaitCursor
        Try

            Dim _selectedNode As RadTreeNode = treeResult.SelectedNode()
            If _selectedNode Is Nothing Then
                treeResult.TreeViewElement.ExpandAll()
            Else
                _selectedNode.ExpandAll()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnContraer_Click(sender As Object, e As EventArgs) Handles btnContraer.Click
        Me.Cursor = Cursors.WaitCursor
        Try

            Dim _selectedNode As RadTreeNode = treeResult.SelectedNode()
            If _selectedNode Is Nothing Then
                treeResult.TreeViewElement.CollapseAll()
            Else
                _selectedNode.Collapse()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnRename_Click(sender As Object, e As EventArgs) Handles btnRename.Click
        Me.Cursor = Cursors.WaitCursor
        Try

            Me.RenameNode()

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub RenameNode()
        Dim _selectedNode As RadTreeNode = treeResult.SelectedNode()
        If Not _selectedNode Is Nothing Then
            If _selectedNode.Parent Is Nothing Then
                Throw New Exception("El nodo raíz no se puede modificar")
            End If
            If Not _selectedNode Is Nothing Then
                Dim _frm As New frmUpdateElement(_selectedNode, _maxLen)
                _frm.ShowDialog()
            End If
        End If
    End Sub

    Private Sub btnOpenFolder_Click(sender As Object, e As EventArgs) Handles btnOpenFolder.Click
        Me.Cursor = Cursors.WaitCursor
        Try
            Dim _selectedNode As RadTreeNode = treeResult.SelectedNode
            Me.openFolder(_selectedNode)
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub openFolder(ByRef nodo As RadTreeNode)
        If nodo Is Nothing Then
            Return
        End If

        Dim _dir As String
        If nodo.ImageKey = folderKey Then
            _dir = nodo.FullPath
        Else
            _dir = nodo.Parent.FullPath
        End If
        If Not Directory.Exists(_dir) Then
            Throw New Exception("El directorio " & _dir & " no existe")
        End If
        Process.Start(_dir)
    End Sub

    Private Sub treeResult_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles treeResult.KeyDown
        Me.Cursor = Cursors.WaitCursor
        Try

            Select Case e.KeyCode
                'Case Keys.F5
                '    Me.Actualizar()
                'Case Keys.C
                '    If lstFotos.SelectedItems.Count = 0 Then
                '        Me.Cursor = Cursors.Default
                '        Exit Sub
                '    End If
                '    If e.Control Then
                '        If lstFotos.SelectedItems.Count > 1 Then
                '            Throw New Exception("Hay más de una fotografía seleccionada." & vbCrLf & "Solo se pueden copiar las fotografías de una en una")
                '        End If

                '        _cancelRequested = False
                '        _progressForm.beginProgress("Copiando fotografías", False, True)
                '        _progressForm.SetupValue1("Foto", lstFotos.SelectedItems.Count, 0)
                '        Clipboard.Clear()
                '        For Each _li As ListViewItem In lstFotos.SelectedItems
                '            If _cancelRequested Then
                '                Exit For
                '            End If
                '            Dim _foto As clsPhoto = DirectCast(_li.Tag, clsPhoto)
                '            _progressForm.reportProgress1(_foto.nombre)
                '            Dim _img As Image = _foto.getImage()
                '            Dim _dataObject As New DataObject()
                '            _dataObject.SetImage(_img)
                '            Clipboard.SetDataObject(_dataObject, True)
                '            _img.Dispose()
                '        Next
                '        _progressForm.endProgress()
                '    End If
                Case Keys.Enter
                    Dim _selectedNode As RadTreeNode = treeResult.SelectedNode
                    Me.openFolder(_selectedNode)
                Case Keys.F2
                    Me.RenameNode()
                    'Case Keys.Delete
                    '    If lstFotos.SelectedItems.Count = 0 Then
                    '        Me.Cursor = Cursors.Default
                    '        Exit Sub
                    '    End If
                    '    Dim _s As String = "Ha solicitado eliminar las fotografías seleccionadas."
                    '    _s = _s & vbCrLf & "Esta operación no se puede deshacer."
                    '    _s = _s & vbCrLf & vbCrLf & "Pulse Aceptar para proceder a la eliminación. Pulse cancelar para cancelarla."
                    '    If MessageBox.Show(_s, My.Application.Info.ProductName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.OK Then
                    '        Me.deleteSelectedPhotos()
                    '    End If
            End Select

            'Catch ex As FaultException(Of DHException)
            '_progressForm.endProgress()
            'MessageBox.Show(ex.Detail.reason, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            '_progressForm.endProgress()
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub treeResult_GotFocus(sender As Object, e As EventArgs) Handles treeResult.GotFocus
        Me.AcceptButton = Nothing
    End Sub

    Private Sub txtPath_GotFocus(sender As Object, e As EventArgs) Handles txtPath.GotFocus
        Me.AcceptButton = btnValidar
    End Sub

    Private Sub btnBrowse_GotFocus(sender As Object, e As EventArgs) Handles btnBrowse.GotFocus
        Me.AcceptButton = btnValidar
    End Sub
End Class