Imports System.Data.Sql
Imports System.IO.Ports

Module SQLConnections

    Public MainSqlConn As New SqlClient.SqlConnection
    Public MAINCON As New SqlClient.SqlConnection
    Public TempCon As New SqlClient.SqlConnection
    Public SQLFcmd As New SqlClient.SqlCommand
    Public ConnectionStrinG As String = "Server=JYOTHISURESH-PC\SQLEXPRESS;Integrated Security=True;User ID=sa"
    Public TxtSoftwareSQlServer As String = ""
    Public TxtSoftwareSQLDatabaseName As String = ""
    Public txtSoftwareSQlUserID As String = ""
    Public TxtSoftwareSQLPassword As String = ""
    Public TxtSoftwareSQLIPaddress As String = ""
    Public txtSoftwareSQLdefaultCompany As String = "MESWERPDBDD"
    Public IMServer As New IMSServerClass


    Public Function TestSQLConnection() As Boolean
        Try
            MainSqlConn.ConnectionString = ConnectionStrinG
            MainSqlConn.Open()
            MainSqlConn.Close()


            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Sub GetServerList(ByVal cmbServers As ComboBox)

        Dim Server As String = String.Empty
        Dim instance As SqlDataSourceEnumerator = SqlDataSourceEnumerator.Instance
        Dim table As System.Data.DataTable = instance.GetDataSources()

        For Each row As System.Data.DataRow In table.Rows
            Server = String.Empty
            Server = row("ServerName")
            If row("InstanceName").ToString.Length > 0 Then
                Server = Server & "\" & row("InstanceName")
            End If
            cmbServers.Items.Add(Server)
        Next

        cmbServers.SelectedIndex = cmbServers.FindStringExact(Environment.MachineName)


    End Sub

    Public Function TestSQLDatabaseIsEXIST(ByVal DBname As String) As Boolean
        Dim IsExists As Boolean = False
        Dim Sqlcmmd As New SqlClient.SqlCommand
        Try
            MainSqlConn.ConnectionString = ConnectionStringFromFile
            MainSqlConn.Open()
            Try

                Sqlcmmd.Connection = MainSqlConn
                Sqlcmmd.CommandText = "Use " & DBname
                Sqlcmmd.CommandType = CommandType.Text
                Sqlcmmd.ExecuteNonQuery()
                IsExists = True
            Catch ex As Exception
                IsExists = False
            End Try
            MainSqlConn.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return IsExists
    End Function
    Public Function ExecuteSQLQueryWithConString(ByVal SQLInsertString As String, ByVal connstr As String) As Boolean
        Dim err As Boolean = True
        Dim SqlConn As New SqlClient.SqlConnection
        Dim Sqlcmmd As New SqlClient.SqlCommand
        Try
            SqlConn.ConnectionString = connstr
            SqlConn.Open()
            Sqlcmmd.Connection = SqlConn
            Sqlcmmd.CommandText = SQLInsertString
            Sqlcmmd.CommandType = CommandType.Text
            Sqlcmmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
            err = False
        Finally
            SqlConn.Close()
            SqlConn.Dispose()
            Sqlcmmd.Connection = Nothing
        End Try
        Return err
    End Function
    Public Function GetNoofRowsEffected(ByVal SQLInsertString As String) As Long
        Dim err As Long = 0
        Dim SqlConn As New SqlClient.SqlConnection
        Dim Sqlcmmd As New SqlClient.SqlCommand

        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            Sqlcmmd.Connection = SqlConn
            Sqlcmmd.CommandText = SQLInsertString
            Sqlcmmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = Sqlcmmd.ExecuteReader
            While Sreader.Read()
                err = err + 1
            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()
            SqlConn.Dispose()
            Sqlcmmd.Connection = Nothing
        End Try
        Return err
    End Function
    Public Function ExecuteSQLQuery(ByVal SQLInsertString As String, Optional ShowError As Boolean = True) As Boolean
        Dim err As Boolean = True
        Dim SqlConn As New SqlClient.SqlConnection
        Dim Sqlcmmd As New SqlClient.SqlCommand
        Sqlcmmd.CommandTimeout = 1000
        ' MsgBox(SqlConn.ConnectionTimeout.ToString)
        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            Sqlcmmd.Connection = SqlConn
            Sqlcmmd.CommandText = SQLInsertString
            Sqlcmmd.CommandType = CommandType.Text
            Sqlcmmd.ExecuteNonQuery()
        Catch ex As Exception
            If ShowError = True Then
                MsgBox(ex.Message)
            End If

            err = False
        Finally
            SqlConn.Close()
            SqlConn.Dispose()
            Sqlcmmd.Connection = Nothing
        End Try
        Return err
    End Function
    Public Function ExecuteSQLQueryForDELETE(ByVal SQLInsertString As String, Optional ShowError As Boolean = True) As Boolean
        Dim err As Boolean = True
        Dim SqlConn As New SqlClient.SqlConnection
        Dim Sqlcmmd As New SqlClient.SqlCommand
        Sqlcmmd.CommandTimeout = 1000
        ' MsgBox(SqlConn.ConnectionTimeout.ToString)
        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            Sqlcmmd.Connection = SqlConn
            Sqlcmmd.CommandText = SQLInsertString
            Sqlcmmd.CommandType = CommandType.Text
            Sqlcmmd.ExecuteNonQuery()
        Catch ex As Exception
            If ShowError = True Then
                MsgBox("Delete is not Possible, This entry used in Other table..", MsgBoxStyle.Critical)
            End If

            err = False
        Finally
            SqlConn.Close()
            SqlConn.Dispose()
            Sqlcmmd.Connection = Nothing
        End Try
        Return err
    End Function
    Public Function ExecuteSQLQuerywithoutmsgs(ByVal SQLInsertString As String) As Boolean
        Dim err As Boolean = True
        Dim SqlConn As New SqlClient.SqlConnection
        Dim Sqlcmmd As New SqlClient.SqlCommand
        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            Sqlcmmd.Connection = SqlConn
            Sqlcmmd.CommandText = SQLInsertString
            Sqlcmmd.CommandType = CommandType.Text
            Sqlcmmd.CommandTimeout = 900000
            Sqlcmmd.ExecuteNonQuery()
        Catch ex As Exception

            err = False
        Finally
            SqlConn.Close()
            SqlConn.Dispose()
            Sqlcmmd.Connection = Nothing
        End Try
        Return err
    End Function
    Public Function LoadStockItemsIntoClass(ByVal StockUniqeCode As String, ByVal stockLocation As String, ByRef cstock As ChooseItemClass) As Boolean
        Dim SqlConn As New SqlClient.SqlConnection
        Dim Sqlcmmd As New SqlClient.SqlCommand
        Dim SQLStr As String = ""
        Dim RetValu As Boolean = False
        Try

            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            Sqlcmmd.Connection = SqlConn
            SQLStr = "select * from stockdbf where barcode=N'" & StockUniqeCode & "' and location=N'" & stockLocation & "'"
            Sqlcmmd.CommandText = SQLStr
            Sqlcmmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = Sqlcmmd.ExecuteReader
            cstock.ClearData()
            While Sreader.Read()
                RetValu = True
                cstock.StockItemBarCode = Sreader("barcode")
                cstock.StockItemCode = Sreader("stockcode").ToString.Trim
                cstock.StockLocation = stockLocation
                cstock.StockITemDescription = Sreader("description").ToString.Trim
                cstock.StockItemName = Sreader("stockname").ToString.Trim
                cstock.StockITemSize = Sreader("stocksize").ToString.Trim
                cstock.StockLocationNames = Sreader("location").ToString.Trim

                cstock.StockGroup = Sreader("stockgroup").ToString.Trim
                cstock.StockRate = Sreader("StockRate")
                cstock.StockRRPRate = Sreader("StockDRP")
                cstock.StockWRPRate = Sreader("StockWRP")
                cstock.StockUnitName = Sreader("BaseUnit").ToString.Trim
                cstock.IsBatchNo = Sreader("ISBatch")
                cstock.StockExpirydate = Sreader("Expiry")
                cstock.StockBatchNo = Sreader("BatchNo").ToString.Trim
                Try
                    cstock.StockType = Sreader("StockType")
                Catch ex As Exception
                    cstock.StockType = 0
                End Try
                Try
                    cstock.IsTaxInclude = Sreader("IsTaxInclude")
                Catch ex As Exception
                    cstock.IsTaxInclude = False
                End Try



                cstock.StockMainUnitName = Sreader("MainUnit").ToString.Trim
                cstock.StockSubUnitName = Sreader("SubUnit").ToString.Trim
                cstock.IsSimpleUnit = Sreader("IsSimpleUnit")
                cstock.TotalQty = Sreader("TotalQty")
                cstock.TotalQtytext = Sreader("QtyText").ToString.Trim
                cstock.CurrentStockQty = Sreader("TotalQty")
                cstock.CustBarCode = Sreader("custbarcode").ToString.Trim
                cstock.StockPhotoPath = Sreader("StockImagePath").ToString.Trim
                cstock.StockCat = Sreader("category").ToString.Trim
                cstock.Madeby = Sreader("Company").ToString.Trim
                cstock.HScode = Sreader("HScode").ToString.Trim
                cstock.CostMethod = Sreader("costmethod").ToString.Trim
                cstock.OpRate = Sreader("OpstockRate")
                cstock.Unitconversion = Sreader("unitcon")
                If cstock.CostMethod.Length = 0 Then
                    cstock.CostMethod = "FIFO"
                End If
                Try
                    cstock.Tax = Sreader("Tax")
                Catch ex As Exception

                End Try
                Try
                    cstock.Tax2 = Sreader("Tax2")
                Catch ex As Exception

                End Try
                Try
                    cstock.CSTtax = Sreader("cst")
                Catch ex As Exception
                    cstock.CSTtax = 0
                End Try
                cstock.ServiceTax = Sreader("servicetax")
                cstock.IsAllowDiscount = Sreader("AllowDiscount")
                cstock.MRP = Sreader("MRP")
                cstock.Packing = Sreader("packing").ToString.Trim
                Try
                    cstock.IsAllowSerialNumbers = Sreader("allowserialnumbers")
                Catch ex As Exception

                End Try
                RetValu = True
                Exit While
            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
            RetValu = False
        Finally
            SqlConn.Close()
            SqlConn.Dispose()
            Sqlcmmd.Connection = Nothing
        End Try
        Return RetValu
    End Function
    Public Function GetDefLocationStockDetails(ByVal stocklocation As String, ByVal stockcode As String, ByVal stocksize As String, ByRef cstock As ChooseItemClass) As Boolean
        Dim SqlConn As New SqlClient.SqlConnection
        Dim Sqlcmmd As New SqlClient.SqlCommand
        Dim SQLStr As String = ""
        Dim RetValu As Boolean = False

        Try

            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            Sqlcmmd.Connection = SqlConn
            SQLStr = "select * from stockdbf where stockcode=N'" & stockcode & "' and stocksize=N'" & stocksize & "' and location=N'" & stocklocation & "'"
            Sqlcmmd.CommandText = SQLStr
            Sqlcmmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = Sqlcmmd.ExecuteReader
            cstock.ClearData()
            While Sreader.Read()
                RetValu = True
                cstock.StockItemBarCode = Sreader("barcode")
                cstock.StockItemCode = Sreader("stockcode").ToString.Trim
                cstock.StockITemDescription = Sreader("description").ToString.Trim
                cstock.StockItemName = Sreader("stockname").ToString.Trim
                cstock.StockITemSize = Sreader("stocksize").ToString.Trim
                cstock.StockLocationNames = Sreader("location").ToString.Trim
                cstock.StockGroup = Sreader("stockgroup").ToString.Trim
                cstock.StockRate = Sreader("StockRate")
                cstock.StockRRPRate = Sreader("StockDRP")
                cstock.StockWRPRate = Sreader("StockWRP")
                cstock.StockUnitName = Sreader("BaseUnit").ToString.Trim
                cstock.IsBatchNo = Sreader("ISBatch")
                cstock.StockExpirydate = Sreader("Expiry")
                cstock.StockBatchNo = Sreader("BatchNo").ToString.Trim
                Try
                    cstock.StockType = Sreader("StockType")
                Catch ex As Exception
                    cstock.StockType = 0
                End Try
                Try
                    cstock.IsTaxInclude = Sreader("IsTaxInclude")
                Catch ex As Exception
                    cstock.IsTaxInclude = False
                End Try
                cstock.StockMainUnitName = Sreader("MainUnit").ToString.Trim
                cstock.StockSubUnitName = Sreader("SubUnit").ToString.Trim
                cstock.IsSimpleUnit = Sreader("IsSimpleUnit")
                cstock.TotalQty = Sreader("TotalQty")
                cstock.TotalQtytext = Sreader("QtyText").ToString.Trim
                cstock.CurrentStockQty = Sreader("TotalQty")
                cstock.CustBarCode = Sreader("custbarcode").ToString.Trim
                cstock.StockPhotoPath = Sreader("StockImagePath").ToString.Trim
                cstock.ImagePath = Sreader("StockImagePath").ToString.Trim
                cstock.StockCat = Sreader("category").ToString.Trim
                cstock.Madeby = Sreader("Company").ToString.Trim
                cstock.HScode = Sreader("HScode").ToString.Trim
                cstock.CostMethod = Sreader("costmethod").ToString.Trim
                cstock.OpRate = Sreader("OpstockRate")
                cstock.Unitconversion = Sreader("unitcon")

                If cstock.CostMethod.Length = 0 Then
                    cstock.CostMethod = "FIFO"
                End If
                Try
                    cstock.Tax = Sreader("Tax")
                Catch ex As Exception

                End Try
                Try
                    cstock.Tax2 = Sreader("Tax2")
                Catch ex As Exception

                End Try
                Try
                    cstock.CSTtax = Sreader("cst")
                Catch ex As Exception
                    cstock.CSTtax = 0
                End Try
                RetValu = True
                cstock.Packing = Sreader("packing").ToString.Trim
                cstock.ServiceTax = Sreader("servicetax")
                cstock.IsAllowDiscount = Sreader("AllowDiscount")
                cstock.MRP = Sreader("MRP")
                Try
                    cstock.IsAllowSerialNumbers = Sreader("allowserialnumbers")
                Catch ex As Exception

                End Try
                Exit While

            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
            RetValu = False
        Finally
            SqlConn.Close()
            SqlConn.Dispose()
            Sqlcmmd.Connection = Nothing
        End Try
        Return RetValu
    End Function
    Public Function LoadStockItemsIntoClassWithStockDetails(ByVal stockcode As String, ByVal stocksize As String, ByVal stockbatchno As String, ByRef cstock As ChooseItemClass, Optional StockLocation As String = "") As Boolean
        Dim SqlConn As New SqlClient.SqlConnection
        Dim Sqlcmmd As New SqlClient.SqlCommand
        Dim SQLStr As String = ""
        Dim RetValu As Boolean = False
        stockbatchno = ""
        Try

            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            Sqlcmmd.Connection = SqlConn
            If StockLocation.Length = 0 Then
                SQLStr = "select * from stockdbf where stockcode=N'" & stockcode & "' and stocksize=N'" & stocksize & "' and batchno=N'" & stockbatchno & "'"
            Else
                SQLStr = "select * from stockdbf where stockcode=N'" & stockcode & "' and stocksize=N'" & stocksize & "' and batchno=N'" & stockbatchno & "' and location=N'" & StockLocation & "'"
            End If

            Sqlcmmd.CommandText = SQLStr
            Sqlcmmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = Sqlcmmd.ExecuteReader
            cstock.ClearData()
            While Sreader.Read()
                RetValu = True
                cstock.StockItemBarCode = Sreader("barcode")
                cstock.StockItemCode = Sreader("stockcode").ToString.Trim
                cstock.StockITemDescription = Sreader("description").ToString.Trim
                cstock.StockItemName = Sreader("stockname").ToString.Trim
                cstock.StockITemSize = Sreader("stocksize").ToString.Trim
                cstock.StockLocationNames = Sreader("location").ToString.Trim
                cstock.StockLocation = Sreader("location").ToString.Trim
                cstock.StockGroup = Sreader("stockgroup").ToString.Trim
                cstock.StockRate = Sreader("StockRate")
                cstock.StockRRPRate = Sreader("StockDRP")
                cstock.StockWRPRate = Sreader("StockWRP")
                cstock.StockUnitName = Sreader("BaseUnit").ToString.Trim
                cstock.IsBatchNo = Sreader("ISBatch")
                cstock.StockExpirydate = Sreader("Expiry")
                cstock.StockBatchNo = Sreader("BatchNo").ToString.Trim
                Try
                    cstock.StockType = Sreader("StockType")
                Catch ex As Exception
                    cstock.StockType = 0
                End Try
                Try
                    cstock.IsTaxInclude = Sreader("IsTaxInclude")
                Catch ex As Exception
                    cstock.IsTaxInclude = False
                End Try
                cstock.StockMainUnitName = Sreader("MainUnit").ToString.Trim
                cstock.StockSubUnitName = Sreader("SubUnit").ToString.Trim
                cstock.IsSimpleUnit = Sreader("IsSimpleUnit")
                cstock.TotalQty = Sreader("TotalQty")
                cstock.TotalQtytext = Sreader("QtyText").ToString.Trim
                cstock.CurrentStockQty = Sreader("TotalQty")
                cstock.CustBarCode = Sreader("custbarcode").ToString.Trim
                cstock.StockPhotoPath = Sreader("StockImagePath").ToString.Trim
                cstock.ImagePath = Sreader("StockImagePath").ToString.Trim
                cstock.StockCat = Sreader("category").ToString.Trim
                cstock.Madeby = Sreader("Company").ToString.Trim
                cstock.HScode = Sreader("HScode").ToString.Trim
                cstock.CostMethod = Sreader("costmethod").ToString.Trim
                cstock.OpRate = Sreader("OpstockRate")
                cstock.Unitconversion = Sreader("unitcon")

                If cstock.CostMethod.Length = 0 Then
                    cstock.CostMethod = "FIFO"
                End If
                Try
                    cstock.Tax = Sreader("Tax")
                Catch ex As Exception

                End Try
                Try
                    cstock.Tax2 = Sreader("Tax2")
                Catch ex As Exception

                End Try
                Try
                    cstock.CSTtax = Sreader("cst")
                Catch ex As Exception
                    cstock.CSTtax = 0
                End Try
                RetValu = True
                cstock.Packing = Sreader("packing").ToString.Trim
                cstock.ServiceTax = Sreader("servicetax")
                cstock.IsAllowDiscount = Sreader("AllowDiscount")
                cstock.MRP = Sreader("MRP")
                Try
                    cstock.IsAllowSerialNumbers = Sreader("allowserialnumbers")
                Catch ex As Exception

                End Try
                Exit While

            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
            RetValu = False
        Finally
            SqlConn.Close()
            SqlConn.Dispose()
            Sqlcmmd.Connection = Nothing
        End Try
        Return RetValu
    End Function
    Public Function LoadStockItemsIntoClassByCustBarCode(ByVal barcode As String, ByVal stockLocation As String, ByRef cstock As ChooseItemClass) As Boolean
        Dim SqlConn As New SqlClient.SqlConnection
        Dim Sqlcmmd As New SqlClient.SqlCommand
        Dim SQLStr As String = ""
        Dim IsFound As Boolean = False
        Try

            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            Sqlcmmd.Connection = SqlConn
            SQLStr = "select * from stockdbf where custbarcode=N'" & barcode & "' and location=N'" & stockLocation & "'"
            Sqlcmmd.CommandText = SQLStr
            Sqlcmmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = Sqlcmmd.ExecuteReader
            cstock.ClearData()

            While Sreader.Read()
                cstock.StockItemBarCode = Sreader("barcode")
                cstock.StockItemCode = Sreader("stockcode").ToString.Trim
                cstock.StockLocation = stockLocation
                cstock.StockITemDescription = Sreader("description").ToString.Trim
                cstock.StockItemName = Sreader("stockname").ToString.Trim
                cstock.StockITemSize = Sreader("stocksize").ToString.Trim
                cstock.StockLocationNames = Sreader("location").ToString.Trim
                cstock.StockGroup = Sreader("stockgroup").ToString.Trim
                cstock.StockRate = Sreader("StockRate")
                cstock.StockRRPRate = Sreader("StockDRP")
                cstock.StockWRPRate = Sreader("StockWRP")
                cstock.StockUnitName = Sreader("BaseUnit").ToString.Trim
                cstock.IsBatchNo = Sreader("ISBatch")
                cstock.StockExpirydate = Sreader("Expiry")
                cstock.StockBatchNo = Sreader("BatchNo").ToString.Trim
                Try
                    cstock.StockType = Sreader("StockType")
                Catch ex As Exception
                    cstock.StockType = 0
                End Try
                Try
                    cstock.IsTaxInclude = Sreader("IsTaxInclude")
                Catch ex As Exception
                    cstock.IsTaxInclude = False
                End Try
                cstock.StockMainUnitName = Sreader("MainUnit").ToString.Trim
                cstock.StockSubUnitName = Sreader("SubUnit").ToString.Trim
                cstock.IsSimpleUnit = Sreader("IsSimpleUnit")
                cstock.TotalQty = Sreader("TotalQty")
                cstock.TotalQtytext = Sreader("QtyText").ToString.Trim
                cstock.CurrentStockQty = Sreader("TotalQty")
                cstock.CustBarCode = Sreader("custbarcode").ToString.Trim
                cstock.StockPhotoPath = Sreader("StockImagePath").ToString.Trim
                cstock.StockCat = Sreader("category").ToString.Trim
                cstock.Madeby = Sreader("Company").ToString.Trim
                cstock.HScode = Sreader("HScode").ToString.Trim
                cstock.CostMethod = Sreader("costmethod").ToString.Trim
                cstock.OpRate = Sreader("OpstockRate")
                cstock.Unitconversion = Sreader("unitcon")
                If cstock.CostMethod.Length = 0 Then
                    cstock.CostMethod = "FIFO"
                End If
                Try
                    cstock.Tax = Sreader("Tax")
                Catch ex As Exception

                End Try
                Try
                    cstock.Tax2 = Sreader("Tax2")
                Catch ex As Exception

                End Try
                Try
                    cstock.CSTtax = Sreader("cst")
                Catch ex As Exception
                    cstock.CSTtax = 0
                End Try
                cstock.ServiceTax = Sreader("servicetax")
                cstock.IsAllowDiscount = Sreader("AllowDiscount")
                cstock.MRP = Sreader("MRP")
                cstock.Packing = Sreader("packing").ToString.Trim
                Try
                    cstock.IsAllowSerialNumbers = Sreader("allowserialnumbers")
                Catch ex As Exception

                End Try
                IsFound = True
                Exit While
            End While
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
            IsFound = False
        Finally
            SqlConn.Close()
            SqlConn.Dispose()
            Sqlcmmd.Connection = Nothing
        End Try
        Return IsFound
    End Function
    Public Sub LoadDataIntoComboBox(ByVal SQLStr As String, ByVal cob As ComboBox, ByVal FieldName As String, Optional ByVal AnyExtraItem As String = "")
        Dim SqlConn As New SqlClient.SqlConnection
        Dim Sqlcmmd As New SqlClient.SqlCommand
        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            Sqlcmmd.Connection = SqlConn
            Sqlcmmd.CommandText = SQLStr
            Sqlcmmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = Sqlcmmd.ExecuteReader
            cob.BeginUpdate()
            cob.Items.Clear()
            While Sreader.Read()
                cob.Items.Add(Sreader(FieldName).ToString.Trim)
            End While
            If AnyExtraItem.Trim.Length > 0 Then
                cob.Items.Add(AnyExtraItem)
            End If
            cob.EndUpdate()
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)

        Finally
            SqlConn.Close()
            SqlConn.Dispose()
            Sqlcmmd.Connection = Nothing
        End Try

    End Sub

    Public Sub LoadDataIntoGridViewComboBox(ByVal SQLStr As String, ByVal cob As DataGridViewComboBoxColumn, ByVal FieldName As String, Optional ByVal AnyExtraItem As String = "")
        Dim SqlConn As New SqlClient.SqlConnection
        Dim Sqlcmmd As New SqlClient.SqlCommand
        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            Sqlcmmd.Connection = SqlConn
            Sqlcmmd.CommandText = SQLStr
            Sqlcmmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = Sqlcmmd.ExecuteReader
            cob.Items.Clear()
            While Sreader.Read()
                cob.Items.Add(Sreader(FieldName).ToString.Trim)
            End While
            If AnyExtraItem.Trim.Length > 0 Then
                cob.Items.Add(AnyExtraItem)
            End If
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)

        Finally
            SqlConn.Close()
            SqlConn.Dispose()
            Sqlcmmd.Connection = Nothing
        End Try
    End Sub

    Public Sub LoadDataIntoComboBox(ByVal SQLStr As String, ByVal cob As IMSComboBox, ByVal FieldName As String, Optional ByVal AnyExtraItem As String = "")
        Dim SqlConn As New SqlClient.SqlConnection
        Dim Sqlcmmd As New SqlClient.SqlCommand
        
        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            Sqlcmmd.Connection = SqlConn
            Sqlcmmd.CommandText = SQLStr
            Sqlcmmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = Sqlcmmd.ExecuteReader
            cob.BeginUpdate()
            cob.Items.Clear()

            While Sreader.Read()
                cob.Items.Add(Sreader(FieldName).ToString.Trim)
            End While
            If AnyExtraItem.Trim.Length > 0 Then
                cob.Items.Add(AnyExtraItem)
            End If
            cob.EndUpdate()
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()
            SqlConn.Dispose()
            Sqlcmmd.Connection = Nothing
        End Try
    End Sub
    Public Sub LoadDataIntoCostCenterComboBox(ByVal SQLStr As String, ByVal cob As IMSComboBox, ByVal FieldName As String, Optional ByVal AnyExtraItem As String = "")
        Dim SqlConn As New SqlClient.SqlConnection
        Dim Sqlcmmd As New SqlClient.SqlCommand

        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            Sqlcmmd.Connection = SqlConn
            Sqlcmmd.CommandText = SQLStr
            Sqlcmmd.CommandType = CommandType.Text
            Dim Sreader As SqlClient.SqlDataReader
            Sreader = Sqlcmmd.ExecuteReader
            cob.Items.Clear()
            While Sreader.Read()
                cob.Items.Add(Sreader(FieldName).ToString.Trim)
            End While
            If AnyExtraItem.Trim.Length > 0 Then
                cob.Items.Add(AnyExtraItem)
            End If
            Sreader.Close()
            Sreader = Nothing
        Catch ex As Exception

        Finally
            Try
                SqlConn.Close()
                SqlConn.Dispose()
                Sqlcmmd.Connection = Nothing
            Catch ex3 As Exception

            End Try
        End Try
    End Sub
    Public Function GetCurrencyRate(ByVal curcode As String) As Double
        Dim k As Double
        '  MsgBox("dfd")
        k = SQLGetNumericFieldValue("select ConRate from currencylist where CurrencyCode=N'" & curcode & "'", "ConRate")
        If k = 0 Then
            k = 1
        End If
        Return 1 / k
    End Function
    Public Function GetExchangeRate(ByVal curcode As String) As Double
        Dim k As Double
        '  MsgBox("dfd")
        k = SQLGetNumericFieldValue("select ConRate from currencylist where CurrencyCode=N'" & curcode & "'", "ConRate")
        If k = 0 Then
            k = 1
        End If

        Return k
    End Function
    Public Function SQLIsFieldExists(ByVal SQLStr As String) As Boolean
        Dim Retvalue As Boolean = False
        Dim SqlConn As New SqlClient.SqlConnection
        ' SQLStr = "select * from Stockdbf where stockcode=N'Kybar' and stocksize=N'' and location=N'MainLocation' and batchno='1254' and expiry='2013-01-04'"
        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            Dim Adapter As New SqlClient.SqlDataAdapter
            Adapter.SelectCommand = New SqlClient.SqlCommand(SQLStr, SqlConn)
            Dim TBD As New DataSet
            Adapter.Fill(TBD)
            If TBD.Tables(0).Rows.Count > 0 Then
                Retvalue = True
            Else
                Retvalue = False
            End If
            TBD.Dispose()
            Adapter.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
            Retvalue = False
        Finally
            SqlConn.Close()

            SqlConn.Dispose()
        End Try
        Return Retvalue
    End Function
    Public Sub FillDataset(ByRef TBD As DataSet, ByVal SQLStr As String)

        Dim SqlConn As New SqlClient.SqlConnection
        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            Dim Adapter As New SqlClient.SqlDataAdapter
            Adapter.SelectCommand = New SqlClient.SqlCommand(SQLStr, SqlConn)
            Adapter.Fill(TBD)
            Adapter.Dispose()
        Catch ex As Exception

        Finally
            SqlConn.Close()
            SqlConn.Dispose()

        End Try

    End Sub
    Public Function SQLGetStringFieldValue(ByVal SQLStr As String, ByVal GetFieldName As String, Optional ByVal DefReturn As String = "", Optional showerror As Boolean = True, Optional IsWithSpaces As Boolean = False) As String
        Dim Retvalue As String
        Dim SqlConn As New SqlClient.SqlConnection

        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            Dim Adapter As New SqlClient.SqlDataAdapter
            Adapter.SelectCommand = New SqlClient.SqlCommand(SQLStr, SqlConn)
            Dim TBD As New DataSet
            Adapter.Fill(TBD)
            If TBD.Tables(0).Rows.Count > 0 Then
                If IsDBNull(TBD.Tables(0).Rows(0).Item(GetFieldName).ToString.Trim) = True Then
                    Retvalue = ""
                Else
                    If IsWithSpaces = True Then
                        Retvalue = TBD.Tables(0).Rows(0).Item(GetFieldName).ToString
                    Else
                        Retvalue = TBD.Tables(0).Rows(0).Item(GetFieldName).ToString.Trim
                    End If

                End If

            Else
                Retvalue = DefReturn
            End If
            TBD.Dispose()
            Adapter.Dispose()
        Catch ex As Exception
            If showerror = True Then
                MsgBox(ex.Message)
            End If

            Retvalue = DefReturn
        Finally
            SqlConn.Close()
            SqlConn.Dispose()

        End Try
        Return Retvalue
    End Function

    Public Function SQLExecuteQueryForInvoiceNumber(ByVal SQLStr As String, Optional ByVal DefReturn As String = "") As String
        Dim Retvalue As String = ""
        Dim SqlConn As New SqlClient.SqlConnection
        ''(InvoicePreFix +CAST(InvoiceNumber as VARCHAR(50))+InvoicePostFix)
        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            Dim Adapter As New SqlClient.SqlDataAdapter
            Adapter.SelectCommand = New SqlClient.SqlCommand(SQLStr, SqlConn)
            Dim TBD As New DataSet
            Adapter.Fill(TBD)
            If TBD.Tables(0).Rows.Count > 0 Then
                Retvalue = Retvalue & TBD.Tables(0).Rows(0).Item("InvoicePreFix").ToString.Trim
                Retvalue = Retvalue & TBD.Tables(0).Rows(0).Item("InvoiceNumber").ToString.Trim
                Retvalue = Retvalue & TBD.Tables(0).Rows(0).Item("InvoicePostFix").ToString.Trim
            Else
                Retvalue = DefReturn
            End If
            TBD.Dispose()
            Adapter.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
            Retvalue = DefReturn
        Finally
            SqlConn.Close()
            SqlConn.Dispose()

        End Try
        Return Retvalue
    End Function

    Public Function GETIMSServerValues(ByVal SQLStr As String) As IMSServerClass
        Dim Retvalue As New IMSServerClass
        Dim SqlConn As New SqlClient.SqlConnection

        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            Dim Adapter As New SqlClient.SqlDataAdapter
            Adapter.SelectCommand = New SqlClient.SqlCommand(SQLStr, SqlConn)
            Dim TBD As New DataSet
            Adapter.Fill(TBD)
            If TBD.Tables(0).Rows.Count > 0 Then
                Retvalue.IMSServerReq.RequestSystemName = TBD.Tables(0).Rows(0).Item("ReqSystemName").ToString.Trim
                Retvalue.IMSServerReq.RequestID = CSng(TBD.Tables(0).Rows(0).Item("ReqNo"))
            Else
                Retvalue.IMSServerReq.RequestSystemName = ""
            End If
            TBD.Dispose()
            Adapter.Dispose()
        Catch ex As Exception
            Retvalue.IMSServerReq.RequestSystemName = ""
        Finally
            SqlConn.Close()
            SqlConn.Dispose()
        End Try
        Return Retvalue
    End Function



    Public Function GetStockRateByPriceListName(ByVal PriceListName As String, ByVal StockBarCode As String, ByVal Location As String) As Double
        Dim Retvalue As Double
        Dim SQLStr As String = ""
        Dim FiledDbName As String = ""
        If PriceListName = "Wholesale" Then
            FiledDbName = "StockWRP"
        ElseIf PriceListName = "Retail" Then
            FiledDbName = "StockDRP"
        Else
            FiledDbName = PriceListName
        End If
        SQLStr = "select * from stockdbf where barcode=N'" & StockBarCode & "' and location=N'" & Location & "'"
        Dim SqlConn As New SqlClient.SqlConnection
        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            Dim Adapter As New SqlClient.SqlDataAdapter
            Adapter.SelectCommand = New SqlClient.SqlCommand(SQLStr, SqlConn)
            Dim TBD As New DataSet
            Adapter.Fill(TBD)
            If TBD.Tables(0).Rows.Count > 0 Then
                Retvalue = CDbl(TBD.Tables(0).Rows(0).Item(FiledDbName).ToString.Trim)
            Else
                Retvalue = "0"
            End If
            TBD.Dispose()
            Adapter.Dispose()
        Catch ex As Exception
            '  MsgBox("Invalid Expression, Please Try again.. ")
            Retvalue = "0"
        Finally
            SqlConn.Close()
            SqlConn.Dispose()

        End Try
        Return Retvalue
    End Function
    Public Function SQLGetNumericFieldValueForNumericTextBox(ByVal SQLStr As String, ByVal GetFieldName As String, Optional Defval As Double = -1, Optional IsShowerr As Boolean = True) As Double
        Dim Retvalue As Double
        Dim SqlConn As New SqlClient.SqlConnection
        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            Dim Adapter As New SqlClient.SqlDataAdapter
            Adapter.SelectCommand = New SqlClient.SqlCommand(SQLStr, SqlConn)
            Dim TBD As New DataSet
            Adapter.Fill(TBD)
            If TBD.Tables(0).Rows.Count > 0 Then
                Retvalue = CDbl(TBD.Tables(0).Rows(0).Item(GetFieldName).ToString.Trim)
            Else
                Retvalue = "0"
            End If
            TBD.Dispose()
            Adapter.Dispose()
        Catch ex As Exception
            If IsShowerr = True Then
                MsgBox("Invalid Expression, Please Try again.. ")
            End If
            If Defval >= 0 Then
                Retvalue = 0
            Else
                Retvalue = "-999999999"
            End If

        Finally
            SqlConn.Close()
            SqlConn.Dispose()

        End Try
        Return Retvalue
    End Function
    Public Function SQLGetBooleanFieldValueSenond(ByVal SQLStr As String, ByVal GetFieldName As String) As Boolean
        Dim Retvalue As Boolean = False
        Dim SqlConn As New SqlClient.SqlConnection
        Dim temp As String = ""
        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            Dim Adapter As New SqlClient.SqlDataAdapter
            Adapter.SelectCommand = New SqlClient.SqlCommand(SQLStr, SqlConn)
            Dim TBD As New DataSet
            Adapter.Fill(TBD)
            If TBD.Tables(0).Rows.Count > 0 Then
                temp = TBD.Tables(0).Rows(0).Item(GetFieldName).ToString.Trim
                If temp.Length > 0 Then
                    Retvalue = temp
                Else
                    Retvalue = False
                End If

            Else
                Retvalue = False
            End If
            TBD.Dispose()
            Adapter.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
            Retvalue = False
        Finally
            SqlConn.Close()
            SqlConn.Dispose()
            ' Sqlcmmd.Connection = Nothing
        End Try
        Return Retvalue
    End Function
    Public Function SQLGetBooleanFieldValue(ByVal SQLStr As String, ByVal GetFieldName As String) As Boolean
        Dim Retvalue As Boolean
        Dim SqlConn As New SqlClient.SqlConnection
        Dim temp As String = ""
        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            Dim Adapter As New SqlClient.SqlDataAdapter
            Adapter.SelectCommand = New SqlClient.SqlCommand(SQLStr, SqlConn)
            Dim TBD As New DataSet
            Adapter.Fill(TBD)
            If TBD.Tables(0).Rows.Count > 0 Then
                If IsDBNull(TBD.Tables(0).Rows(0).Item(GetFieldName)) = True Then
                    temp = False
                Else
                    temp = TBD.Tables(0).Rows(0).Item(GetFieldName)
                End If


                If temp.Length > 0 Then
                    Retvalue = temp
                Else
                    Retvalue = False
                End If

            Else
                Retvalue = False
            End If
            TBD.Dispose()
            Adapter.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
            Retvalue = False
        Finally
            SqlConn.Close()
            SqlConn.Dispose()

        End Try

        Return Retvalue
    End Function
    Public Function SQLGetNumericFieldValue(ByVal SQLStr As String, ByVal GetFieldName As String) As Double
        Dim Retvalue As Double
        Dim SqlConn As New SqlClient.SqlConnection
        Dim temp As String = "0"
        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            Dim Adapter As New SqlClient.SqlDataAdapter
            Adapter.SelectCommand = New SqlClient.SqlCommand(SQLStr, SqlConn)
            Dim TBD As New DataSet
            Adapter.Fill(TBD)
            If TBD.Tables(0).Rows.Count > 0 Then
                temp = TBD.Tables(0).Rows(0).Item(GetFieldName).ToString.Trim
                If temp.Length > 0 Then
                    Retvalue = FormatNumber(CDbl(temp), ErpDecimalPlaces, , , TriState.False)
                Else
                    Retvalue = ErpZeroValue()
                End If

            Else
                Retvalue = ErpZeroValue()
            End If
            TBD.Dispose()
            Adapter.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
            Retvalue = 0
        Finally
            SqlConn.Close()
            SqlConn.Dispose()

        End Try

        Return Retvalue
    End Function
    Public Function SQLGetDateTimeFieldValue(ByVal SQLStr As String, ByVal GetFieldName As String) As DateTimePicker
        Dim Retvalue As New DateTimePicker
        Dim SqlConn As New SqlClient.SqlConnection
        Dim temp As String = "0"
        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            Dim Adapter As New SqlClient.SqlDataAdapter
            Adapter.SelectCommand = New SqlClient.SqlCommand(SQLStr, SqlConn)
            Dim TBD As New DataSet
            Adapter.Fill(TBD)
            If TBD.Tables(0).Rows.Count > 0 Then
                temp = TBD.Tables(0).Rows(0).Item(GetFieldName).ToString.Trim
                If temp.Length > 0 Then
                    Retvalue.Value = Convert.ToDateTime(temp)
                Else
                    Retvalue.Value = Nothing
                End If

            Else
                Retvalue.Value = Nothing
            End If
            TBD.Dispose()
            Adapter.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
            Retvalue.Value = Nothing
        Finally
            SqlConn.Close()
            SqlConn.Dispose()

        End Try

        Return Retvalue
    End Function
    Public Sub LockTransaction(ByVal Tcode As Decimal)
        If IsClientAndServerSystem = False Then Exit Sub
        Dim SQLstr As String
        Dim id As Double
        SQLstr = "INSERT INTO [LockTrans] ([TransCode],[UserName],[SystemName],[Details],[TransDate]) " _
            & "VALUES (@Transcode,@username,@systemname,@details,@TransDate) "
        id = GetAndSetIDCode(EnumIDType.LogFileID)
        MAINCON.ConnectionString = ConnectionStrinG
        MAINCON.Open()
        Dim DBF As New SqlClient.SqlCommand(SQLstr, MAINCON)
        With DBF.Parameters
            .AddWithValue("Transcode", Tcode)
            .AddWithValue("username", CurrentUserName)
            .AddWithValue("systemname", System.Environment.MachineName)
            .AddWithValue("details", "")
            .AddWithValue("TransDate", Now.ToString)
        End With
        DBF.ExecuteNonQuery()
        DBF.Dispose()
        SQLstr = Nothing
        id = Nothing
        MAINCON.Close()
    End Sub

    Public Sub UnLockTransaction(ByVal Tcode As Decimal)
        If IsClientAndServerSystem = False Then Exit Sub
        ExecuteSQLQuery("Delete from locktrans where transcode=" & Tcode & " and SystemName=N'" & System.Environment.MachineName & "'")
    End Sub

    Public Function IsTransactionLocked(ByVal Tcode As Decimal) As String
        Dim Retvalue As String = ""

        Dim SqlConn As New SqlClient.SqlConnection
        Try
            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            Dim Adapter As New SqlClient.SqlDataAdapter
            Adapter.SelectCommand = New SqlClient.SqlCommand("select * from locktrans where transcode=" & Tcode, SqlConn)
            Dim TBD As New DataSet
            Adapter.Fill(TBD)
            If TBD.Tables(0).Rows.Count > 0 Then
                Retvalue = "The Transaction Number: " & TBD.Tables(0).Rows(0).Item("transcode").ToString.Trim & " Already Used at " & TBD.Tables(0).Rows(0).Item("SystemName").ToString.Trim & " By the User " & TBD.Tables(0).Rows(0).Item("UserName").ToString.Trim & ", Date and Time is:" & TBD.Tables(0).Rows(0).Item("TransDate").ToString.Trim & Chr(13) & "Please Try Later or contact admin...."
            Else
                Retvalue = ""
            End If
            TBD.Dispose()
            Adapter.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
            Retvalue = ""
        Finally
            SqlConn.Close()
            SqlConn.Dispose()
        End Try
        Return Retvalue

    End Function
    Public Sub UpdateLogFile(ByVal storename As String, ByVal tcode As Single, ByVal vhname As String, ByVal vhno As String, ByVal username As String, ByVal status As String, ByVal sysname As String, ByVal transdetails As String)
        Dim SQLstr As String
        Dim id As Double
        '
        SQLstr = " INSERT INTO [logfile] ([StoreName],[TransDatetime],[Transcode],[vouchername],[voucherno],[username],[status],[systemno],[details],[id],[TransDateValue])    VALUES " _
            & "(@storename, @transdatetime,@transcoe,@vouchername,@voucherno,@username,@status,@systemno,@details,@id,@TransDateValue)"
        id = GetAndSetIDCode(EnumIDType.LogFileID)
        MAINCON.ConnectionString = ConnectionStrinG
        MAINCON.Open()
        Dim DBF As New SqlClient.SqlCommand(SQLstr, MAINCON)
        With DBF.Parameters
            .AddWithValue("storename", storename)
            .AddWithValue("transdatetime", Now)
            .AddWithValue("transcoe", tcode)
            .AddWithValue("vouchername", vhname)
            .AddWithValue("voucherno", vhno)
            .AddWithValue("username", username)
            .AddWithValue("status", status)
            .AddWithValue("details", transdetails)
            .AddWithValue("id", id)
            .AddWithValue("systemno", sysname)
            .AddWithValue("TransDateValue", Now.ToOADate)
        End With
        DBF.ExecuteNonQuery()
        DBF.Dispose()
        MAINCON.Close()
    End Sub
    Public Function SQLLoadGridData(ByVal SQLStr As String) As DataTable
        Dim TBD As New DataTable
        Dim SqlConn As New SqlClient.SqlConnection
        Try

            SqlConn.ConnectionString = ConnectionStrinG
            SqlConn.Open()
            Dim Adapter As New SqlClient.SqlDataAdapter
            Adapter.SelectCommand = New SqlClient.SqlCommand(SQLStr, SqlConn)
            TBD.Locale = System.Globalization.CultureInfo.InvariantCulture
            Adapter.Fill(TBD)
            Adapter.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            SqlConn.Close()
            SqlConn.Dispose()
        End Try

        Return TBD
    End Function
    Sub ReArrangeStockCategories()
        Dim zl As New ComboBox
        Dim sg As New ComboBox
        Dim SqlStr As String = ""
        sg.Items.Clear()
        sg.Sorted = False
        zl.Items.Clear()
        zl.Sorted = False
        Dim Sqlcmmd As New SqlClient.SqlCommand
        LoadDataIntoComboBox("select StockCategoryName from Categoriesgroups", zl, "StockCategoryName")
        ExecuteSQLQuery("delete from StockCategoriesList")
        If zl.Items.Count = 0 Then Exit Sub
        For i As Integer = 0 To zl.Items.Count - 1
            sg.Items.Clear()
            sg.Items.Add(zl.Items(i).ToString)
            Dim Size As Integer = 1
            Dim Index As Integer = 1
            While Size <= sg.Items.Count
                Dim SqlConn As New SqlClient.SqlConnection

                SqlStr = "select * from categoriesgroups where grouproot=N'" & sg.Items(Size - 1).ToString & "' and  StockCategoryName <>'*Primary' "
                Try
                    SqlConn.ConnectionString = ConnectionStrinG
                    SqlConn.Open()
                    Sqlcmmd.Connection = SqlConn
                    Sqlcmmd.CommandText = SqlStr
                    Sqlcmmd.CommandType = CommandType.Text
                    Dim Sreader As SqlClient.SqlDataReader
                    Sreader = Sqlcmmd.ExecuteReader
                    While Sreader.Read()
                        sg.Items.Add(Sreader("StockCategoryName").ToString.Trim)
                    End While
                    Sreader.Close()
                    Sreader = Nothing
                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    SqlConn.Close()
                    SqlConn.Dispose()
                    Sqlcmmd.Connection = Nothing
                End Try
                Size = Size + 1
            End While
            For ai As Integer = 0 To sg.Items.Count - 1
                SqlStr = "INSERT INTO [StockCategoriesList] ([groupname],[subgroup]) " _
                    & "VALUES(N'" & zl.Items(i).ToString & "',N'" & sg.Items(ai).ToString & "')"
                ExecuteSQLQuery(SqlStr)
            Next

        Next



    End Sub

    Sub ReArrangeDepartments()
        Dim zl As New ComboBox
        Dim sg As New ComboBox
        Dim SqlStr As String = ""
        sg.Items.Clear()
        sg.Sorted = False
        zl.Items.Clear()
        zl.Sorted = False
        Dim Sqlcmmd As New SqlClient.SqlCommand
        LoadDataIntoComboBox("select DepName from DepartmentGroups", zl, "DepName")
        ExecuteSQLQuery("delete from DepartmentsLists")
        If zl.Items.Count = 0 Then Exit Sub
        For i As Integer = 0 To zl.Items.Count - 1
            sg.Items.Clear()
            sg.Items.Add(zl.Items(i).ToString)
            Dim Size As Integer = 1
            Dim Index As Integer = 1
            While Size <= sg.Items.Count
                Dim SqlConn As New SqlClient.SqlConnection

                SqlStr = "select * from DepartmentGroups where grouproot=N'" & sg.Items(Size - 1).ToString & "' and  DepName <>'*Primary' "
                Try
                    SqlConn.ConnectionString = ConnectionStrinG
                    SqlConn.Open()
                    Sqlcmmd.Connection = SqlConn
                    Sqlcmmd.CommandText = SqlStr
                    Sqlcmmd.CommandType = CommandType.Text
                    Dim Sreader As SqlClient.SqlDataReader
                    Sreader = Sqlcmmd.ExecuteReader
                    While Sreader.Read()
                        ' MsgBox(Sreader("StockCategoryName").ToString.Trim)
                        sg.Items.Add(Sreader("DepName").ToString.Trim)
                    End While
                    Sreader.Close()
                    Sreader = Nothing
                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    SqlConn.Close()
                    SqlConn.Dispose()
                    Sqlcmmd.Connection = Nothing
                End Try
                Size = Size + 1
            End While
            For ai As Integer = 0 To sg.Items.Count - 1
                SqlStr = "INSERT INTO [DepartmentsLists] ([groupname],[subgroup]) " _
                    & "VALUES(N'" & zl.Items(i).ToString & "',N'" & sg.Items(ai).ToString & "')"
                ExecuteSQLQuery(SqlStr)
            Next

        Next



    End Sub
    Sub ReArrangeAccountGroups()
        Dim zl As New ComboBox
        Dim sg As New ComboBox
        Dim Sqlcmmd As New SqlClient.SqlCommand
        Dim SqlStr As String = ""
        sg.Items.Clear()
        sg.Sorted = False
        zl.Items.Clear()
        zl.Sorted = False
        LoadDataIntoComboBox("select groupname from Accountgroups", zl, "groupname")
        ExecuteSQLQuery("delete from Accountgroupslist")
        If zl.Items.Count = 0 Then Exit Sub
        For i As Integer = 0 To zl.Items.Count - 1
            sg.Items.Clear()
            sg.Items.Add(zl.Items(i).ToString)
            Dim Size As Integer = 1
            Dim Index As Integer = 1
            While Size <= sg.Items.Count
                Dim SqlConn As New SqlClient.SqlConnection

                SqlStr = "select * from Accountgroups where grouproot=N'" & sg.Items(Size - 1).ToString & "'"
                Try
                    SqlConn.ConnectionString = ConnectionStrinG
                    SqlConn.Open()
                    Sqlcmmd.Connection = SqlConn
                    Sqlcmmd.CommandText = SqlStr
                    Sqlcmmd.CommandType = CommandType.Text
                    Dim Sreader As SqlClient.SqlDataReader
                    Sreader = Sqlcmmd.ExecuteReader
                    While Sreader.Read()
                        ' MsgBox(Sreader("StockCategoryName").ToString.Trim)
                        sg.Items.Add(Sreader("groupname").ToString.Trim)
                    End While
                    Sreader.Close()
                    Sreader = Nothing
                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    SqlConn.Close()
                    SqlConn.Dispose()
                    Sqlcmmd.Connection = Nothing
                End Try
                Size = Size + 1
            End While
            For ai As Integer = 0 To sg.Items.Count - 1
                SqlStr = "INSERT INTO [Accountgroupslist] ([groupname],[subgroup]) " _
                    & "VALUES(N'" & zl.Items(i).ToString & "',N'" & sg.Items(ai).ToString & "')"
                ExecuteSQLQuery(SqlStr)
            Next

        Next



    End Sub

    Sub ReArrangeStockGroups()
        Dim zl As New ComboBox
        Dim sg As New ComboBox
        Dim Sqlcmmd As New SqlClient.SqlCommand
        Dim SqlStr As String = ""
        sg.Items.Clear()
        sg.Sorted = False
        zl.Items.Clear()
        zl.Sorted = False
        LoadDataIntoComboBox("select StockgroupName from stockgroups", zl, "StockgroupName")
        ExecuteSQLQuery("delete from StockgroupList")
        If zl.Items.Count = 0 Then Exit Sub
        For i As Integer = 0 To zl.Items.Count - 1
            sg.Items.Clear()
            sg.Items.Add(zl.Items(i).ToString)
            Dim Size As Integer = 1
            Dim Index As Integer = 1
            While Size <= sg.Items.Count
                Dim SqlConn As New SqlClient.SqlConnection

                SqlStr = "select * from stockgroups where grouproot=N'" & sg.Items(Size - 1).ToString & "' and  StockgroupName <>'*Primary' "
                Try
                    SqlConn.ConnectionString = ConnectionStrinG
                    SqlConn.Open()
                    Sqlcmmd.Connection = SqlConn
                    Sqlcmmd.CommandText = SqlStr
                    Sqlcmmd.CommandType = CommandType.Text
                    Dim Sreader As SqlClient.SqlDataReader
                    Sreader = Sqlcmmd.ExecuteReader
                    While Sreader.Read()
                        sg.Items.Add(Sreader("StockgroupName").ToString.Trim)
                    End While
                    Sreader.Close()
                    Sreader = Nothing
                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    SqlConn.Close()
                    SqlConn.Dispose()
                    Sqlcmmd.Connection = Nothing
                End Try
                Size = Size + 1
            End While
            For ai As Integer = 0 To sg.Items.Count - 1
                SqlStr = "INSERT INTO [StockgroupList] ([groupname],[subgroup]) " _
                    & "VALUES(N'" & zl.Items(i).ToString & "',N'" & sg.Items(ai).ToString & "')"
                ExecuteSQLQuery(SqlStr)
            Next

        Next



    End Sub
    Sub ReArrangeAssetTypes()
        Dim zl As New ComboBox
        Dim sg As New ComboBox
        Dim Sqlcmmd As New SqlClient.SqlCommand
        Dim SqlStr As String = ""
        sg.Items.Clear()
        sg.Sorted = False
        zl.Items.Clear()
        zl.Sorted = False
        LoadDataIntoComboBox("select AssetGroupName from assetgroups", zl, "AssetGroupName")
        ExecuteSQLQuery("delete from assetgroupList")
        If zl.Items.Count = 0 Then Exit Sub
        For i As Integer = 0 To zl.Items.Count - 1
            sg.Items.Clear()
            sg.Items.Add(zl.Items(i).ToString)
            Dim Size As Integer = 1
            Dim Index As Integer = 1
            While Size <= sg.Items.Count
                Dim SqlConn As New SqlClient.SqlConnection

                SqlStr = "select * from assetgroups where grouproot=N'" & sg.Items(Size - 1).ToString & "' and  AssetGroupName <>'*Primary' "
                Try
                    SqlConn.ConnectionString = ConnectionStrinG
                    SqlConn.Open()
                    Sqlcmmd.Connection = SqlConn
                    Sqlcmmd.CommandText = SqlStr
                    Sqlcmmd.CommandType = CommandType.Text
                    Dim Sreader As SqlClient.SqlDataReader
                    Sreader = Sqlcmmd.ExecuteReader
                    While Sreader.Read()
                        sg.Items.Add(Sreader("AssetGroupName").ToString.Trim)
                    End While
                    Sreader.Close()
                    Sreader = Nothing
                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    SqlConn.Close()
                    SqlConn.Dispose()
                    Sqlcmmd.Connection = Nothing
                End Try
                Size = Size + 1
            End While
            For ai As Integer = 0 To sg.Items.Count - 1
                SqlStr = "INSERT INTO [assetgroupList] ([groupname],[subgroup]) " _
                    & "VALUES(N'" & zl.Items(i).ToString & "',N'" & sg.Items(ai).ToString & "')"
                ExecuteSQLQuery(SqlStr)
            Next

        Next



    End Sub
    Sub ReArrangeCostCenterGroups()
        Dim zl As New ComboBox
        Dim sg As New ComboBox
        Dim Sqlcmmd As New SqlClient.SqlCommand
        Dim SqlStr As String = ""
        sg.Items.Clear()
        sg.Sorted = False
        zl.Items.Clear()
        zl.Sorted = False
        LoadDataIntoComboBox("select StockgroupName from CostCenters", zl, "StockgroupName")
        ExecuteSQLQuery("delete from CostCenterList")
        If zl.Items.Count = 0 Then Exit Sub
        For i As Integer = 0 To zl.Items.Count - 1
            sg.Items.Clear()
            sg.Items.Add(zl.Items(i).ToString)
            Dim Size As Integer = 1
            Dim Index As Integer = 1
            While Size <= sg.Items.Count
                Dim SqlConn As New SqlClient.SqlConnection

                SqlStr = "select * from CostCenters where grouproot=N'" & sg.Items(Size - 1).ToString & "' and  StockgroupName <>'*Primary' "
                Try
                    SqlConn.ConnectionString = ConnectionStrinG
                    SqlConn.Open()
                    Sqlcmmd.Connection = SqlConn
                    Sqlcmmd.CommandText = SqlStr
                    Sqlcmmd.CommandType = CommandType.Text
                    Dim Sreader As SqlClient.SqlDataReader
                    Sreader = Sqlcmmd.ExecuteReader
                    While Sreader.Read()
                        sg.Items.Add(Sreader("StockgroupName").ToString.Trim)
                    End While
                    Sreader.Close()
                    Sreader = Nothing
                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    SqlConn.Close()
                    SqlConn.Dispose()
                    Sqlcmmd.Connection = Nothing
                End Try
                Size = Size + 1
            End While
            For ai As Integer = 0 To sg.Items.Count - 1
                SqlStr = "INSERT INTO [CostCenterList] ([groupname],[subgroup]) " _
                    & "VALUES(N'" & zl.Items(i).ToString & "',N'" & sg.Items(ai).ToString & "')"
                ExecuteSQLQuery(SqlStr)
            Next

        Next



    End Sub
    'Public Sub LockFiledNames(ByVal vhtype As Byte, ByVal fieldname As String, ByVal FormCode As Single)
    '    Dim SQLstr As String
    '    Dim id As Double


    '    SQLstr = "INSERT INTO [LockEditings] ([FormCode],[AccountName],[SystemName],[AccountNameCode],[UserName]) " _
    '        & "VALUES (@FormCode,@AccountName,@SystemName,@AccountNameCode,@UserName) "
    '    id = GetAndSetIDCode(EnumIDType.LogFileID)
    '    MAINCON.ConnectionString = ConnectionStrinG
    '    MAINCON.Open()
    '    Dim DBF As New SqlClient.SqlCommand(SQLstr, MAINCON)
    '    With DBF.Parameters
    '        .AddWithValue("FormCode", FormCode)
    '        .AddWithValue("AccountName", fieldname)
    '        .AddWithValue("SystemName", System.Environment.MachineName)
    '        .AddWithValue("AccountNameCode", vhtype)
    '        .AddWithValue("UserName", CurrentUserName)
    '    End With
    '    DBF.ExecuteNonQuery()
    '    DBF = Nothing
    '    MAINCON.Close()
    'End Sub
    'Public Sub UnlockFiledNames(ByVal vhtype As Byte, ByVal fieldname As String, ByVal FormCode As Single)
    '    ExecuteSQLQuery("Delete from LockEditings where AccountNameCode=" & vhtype & " and SystemName=N'" & System.Environment.MachineName & "' and username=N'" & CurrentUserName & "' and AccountName=N'" & fieldname & "' and formcode=" & FormCode)
    'End Sub
    Public Sub open_cashdrawer(Optional Iscom As Boolean = False)
        If Iscom = True Then
            FileOpen(1, AppDomain.CurrentDomain.BaseDirectory & "open.txt", OpenMode.Output)
            PrintLine(1, Chr(27) & Chr(112) & Chr(0) & Chr(25) & Chr(250))
            FileClose(1)
            Shell("print /d:com1 open.txt", AppWinStyle.Hide)
        Else
            FileOpen(1, "c:\escapes.txt", OpenMode.Output)
            PrintLine(1, Chr(27) & "p" & Chr(0) & Chr(25) & Chr(250))
            FileClose(1)
            Shell("print /d:lpt1 c:\escapes.txt", vbNormalFocus)
        End If
       

        'Use this code if you are using COM Port
      
    End Sub
    Public Sub DisplyPort(ByVal FirstLineStr As String, ByVal SecondLineStr As String)
        Dim sp As New SerialPort("COM1", 9600, Parity.None, 8, StopBits.One)
        sp.Open()
        sp.Write(Convert.ToString(Chr(12)))
        sp.WriteLine(FirstLineStr)
        sp.WriteLine(Chr(13) + SecondLineStr)
        sp.Close()
        sp.Dispose()
        sp = Nothing

    End Sub
End Module
