Imports Telerik.WinControls.UI
Imports System.IO

Public Class frmUpdateElement

    Private _selectedNode As RadTreeNode
    Private _maxPathLen As Integer
    Private _maxLen As Integer
    Private _nodeOriginalLen As Integer

    Public Sub New(ByRef element As RadTreeNode, ByVal maxLen As Integer)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _selectedNode = element
        _maxLen = maxLen
    End Sub

    Private Sub frmUpdateElement_Load(sender As Object, e As EventArgs) Handles Me.Load
        If _selectedNode.ImageKey = frmValidarLenNombres.folderKey Then
            Me.Icon = My.Resources.folder_icon
            Me.Text = "Renombrar directorio"
        Else
            Me.Icon = My.Resources.document_icon
            Me.Text = "Renombrar archivo"
        End If
        txtName.Text = _selectedNode.Text
        _nodeOriginalLen = _selectedNode.Text.Length
        _maxPathLen = _selectedNode.FullPath.Length
        Me.calcMaxPathLen(_selectedNode)
        setLblPathLen()
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Me.Cursor = Cursors.WaitCursor
        Try

            If txtName.Text.Length = 0 Then
                Throw New Exception("Debe informar el nombre")
            End If

            Dim _nombreActual As String = _selectedNode.Text
            Dim _nombreNuevo As String = txtName.Text
            If _nombreActual <> _nombreNuevo Then
                If _selectedNode.ImageKey = frmValidarLenNombres.folderKey Then
                    My.Computer.FileSystem.RenameDirectory(_selectedNode.FullPath, _nombreNuevo)
                Else
                    My.Computer.FileSystem.RenameFile(_selectedNode.FullPath, _nombreNuevo)
                End If
                _selectedNode.Text = _nombreNuevo
            End If
            Me.checkTree()
            Me.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub txtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged
        Me.setLblPathLen()
    End Sub

    Private Sub calcMaxPathLen(ByRef element As RadTreeNode)
        For Each _node As RadTreeNode In element.Nodes
            If _node.FullPath.Length > _maxPathLen Then
                _maxPathLen = _node.FullPath.Length
            End If
            Me.calcMaxPathLen(_node)
        Next
    End Sub

    Private Sub setLblPathLen()
        Dim _lenActual As Integer = _maxPathLen + txtName.Text.Length - _nodeOriginalLen
        lblPathLen.Text = "Longitud actual: " & _maxPathLen.ToString & ". Modificada: " & _lenActual.ToString
        If _lenActual <= _maxLen Then
            lblPathLen.ForeColor = Color.Black
        Else
            lblPathLen.ForeColor = Color.Red
        End If
    End Sub

    Private Sub checkTree()
        Dim _lenActual As Integer = _maxPathLen + txtName.Text.Length - _nodeOriginalLen
        Dim _color As Color
        If _lenActual <= _maxLen Then
            _color = Color.Black
        Else
            _color = Color.Red
        End If
        _selectedNode.ForeColor = _color
        Me.setColorDescendants(_selectedNode)
        Me.setColorAscendants(_selectedNode, _color)
    End Sub

    Private Sub setColorDescendants(ByRef nodo As RadTreeNode)
        For Each _nodo As RadTreeNode In nodo.Nodes
            If _nodo.FullPath.Length <= _maxLen Then
                _nodo.ForeColor = Color.Black
            Else
                _nodo.ForeColor = Color.Red
                Me.setColorAscendants(_nodo, Color.Red)
            End If
            Me.setColorDescendants(_nodo)
        Next
    End Sub

    Private Sub setColorAscendants(ByRef nodo As RadTreeNode, ByVal foreColor As Color)
        Dim _parent As RadTreeNode = nodo.Parent
        If _parent Is Nothing Then
            Return
        End If
        If foreColor = Color.Red Then
            _parent.ForeColor = foreColor
            Me.setColorAscendants(_parent, foreColor)
        Else
            Dim _allInBlack As Boolean = True
            For Each _child As RadTreeNode In _parent.Nodes
                If _child.ForeColor = Color.Red Then
                    _allInBlack = False
                End If
            Next
            If _allInBlack Then
                _parent.ForeColor = foreColor
                Me.setColorAscendants(_parent, foreColor)
            End If
        End If
    End Sub
End Class