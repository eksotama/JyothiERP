Public Class AdminOptionPanel1

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        Customers.SuspendLayout()
        Customers.MdiParent = MainForm
        Customers.Dock = DockStyle.Fill
        Customers.Show()
        Customers.WindowState = FormWindowState.Maximized
        Customers.BringToFront()
        Customers.ResumeLayout()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        Suppliers.SuspendLayout()
        Suppliers.MdiParent = MainForm
        Suppliers.Dock = DockStyle.Fill
        Suppliers.Show()
        Suppliers.WindowState = FormWindowState.Maximized
        Suppliers.BringToFront()
        Suppliers.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LinkLabel3_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        Employees.SuspendLayout()
        Employees.MdiParent = MainForm
        Employees.Dock = DockStyle.Fill
        Employees.Show()
        Employees.WindowState = FormWindowState.Maximized
        Employees.BringToFront()
        Employees.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LinkLabel4_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked

        Me.Cursor = Cursors.WaitCursor
        StockItems.SuspendLayout()
        StockItems.MdiParent = MainForm
        StockItems.Dock = DockStyle.Fill
        StockItems.Show()
        StockItems.WindowState = FormWindowState.Maximized
        StockItems.BringToFront()
        StockItems.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LinkLabel5_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        Users.SuspendLayout()
        Users.MdiParent = MainForm
        Users.Dock = DockStyle.Fill
        Users.Show()
        Users.WindowState = FormWindowState.Maximized
        Users.BringToFront()
        Users.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LinkLabel6_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel6.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        StockCategories.SuspendLayout()
        StockCategories.MdiParent = MainForm
        StockCategories.Dock = DockStyle.Fill
        StockCategories.Show()
        StockCategories.WindowState = FormWindowState.Maximized
        StockCategories.BringToFront()
        StockCategories.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LinkLabel7_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel7.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        StockGroups.SuspendLayout()
        StockGroups.MdiParent = MainForm
        StockGroups.Dock = DockStyle.Fill
        StockGroups.Show()
        StockGroups.WindowState = FormWindowState.Maximized
        StockGroups.BringToFront()
        StockGroups.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LinkLabel8_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel8.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        Ledgers.SuspendLayout()
        Ledgers.MdiParent = MainForm
        Ledgers.Dock = DockStyle.Fill
        Ledgers.Show()
        Ledgers.WindowState = FormWindowState.Maximized
        Ledgers.BringToFront()
        Ledgers.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub LinkLabel9_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel9.LinkClicked
        Me.Cursor = Cursors.WaitCursor
        EmployeeAttendenceSheet.SuspendLayout()
        EmployeeAttendenceSheet.MdiParent = MainForm
        EmployeeAttendenceSheet.Dock = DockStyle.Fill
        EmployeeAttendenceSheet.Show()
        EmployeeAttendenceSheet.WindowState = FormWindowState.Maximized
        EmployeeAttendenceSheet.BringToFront()
        EmployeeAttendenceSheet.ResumeLayout()
        Me.Cursor = Cursors.Default
    End Sub
End Class
