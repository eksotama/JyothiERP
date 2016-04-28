Imports System.Collections.Generic
Module othersModules
    Public Function GetListOfMenuItems(menuStrip As MenuStrip) As List(Of ToolStripMenuItem)
        Dim ListofItems As New List(Of ToolStripMenuItem)()
        For Each i As ToolStripMenuItem In menuStrip.Items
            GetListOfSubMenuItems(i, ListofItems)
        Next
        'Dim myItems As List(Of ToolStripMenuItem) = GetAllMenuStripItems.GetItems(Me.MenuStrip1)
        'For Each item In myItems
        '    MessageBox.Show(item.Name)
        '    If item.Name = "ToolStripMenuItem7" Then
        '        item.Visible = False
        '    End If
        'Next
        Return ListofItems
    End Function

    Private Sub GetListOfSubMenuItems(Menuitem As ToolStripMenuItem, Menuitems As List(Of ToolStripMenuItem))
        Menuitems.Add(Menuitem)

        For Each i As ToolStripItem In Menuitem.DropDownItems
            If TypeOf i Is ToolStripMenuItem Then
                GetListOfSubMenuItems(DirectCast(i, ToolStripMenuItem), Menuitems)
            End If
        Next
    End Sub
End Module
