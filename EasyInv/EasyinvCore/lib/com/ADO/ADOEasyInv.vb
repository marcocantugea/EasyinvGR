Imports EasyinvCore.com.objects

Namespace com.ADO
    Public Class ADOEasyInv
        Inherits com.data.OleDBConnectionObj

        Public Sub GetInputsDetail(ByVal location As String, ByVal fecha As String, ByVal returndetails As InventoryInputDetailCollection)
            Try

                OpenDB("DB-EASYINV")
                Dim query As String
                query = "select * from inventory_capture where code like'" & location & "%' and fechamod=#" & fecha & "#"
                connection.Command = New OleDb.OleDbCommand(query, connection.Connection)
                connection.Adap = New OleDb.OleDbDataAdapter(connection.Command)
                Dim dts As New DataSet
                connection.Adap.Fill(dts)
                If dts.Tables.Count > 0 Then
                    If dts.Tables(0).Rows.Count > 0 Then
                        For Each row As DataRow In dts.Tables(0).Rows
                            Dim o_input As New inventoryinputdetail
                            For Each member In o_input.GetType.GetProperties
                                If member.CanWrite Then
                                    If member.PropertyType.Name = "String" Or member.PropertyType.Name = "Int32" Or member.PropertyType.Name = "Int64" Or member.PropertyType.Name = "DateTime" Or member.PropertyType.Name = "Boolean" Then
                                        If Not IsDBNull(row(member.Name)) Then
                                            If member.PropertyType.Name = "String" Then
                                                member.SetValue(o_input, row(member.Name).ToString, Nothing)
                                            End If
                                            If member.PropertyType.Name = "Int32" Then
                                                member.SetValue(o_input, Integer.Parse(row(member.Name)), Nothing)
                                            End If
                                            If member.PropertyType.Name = "Int64" Then
                                                member.SetValue(o_input, Long.Parse(row(member.Name)), Nothing)
                                            End If
                                            If member.PropertyType.Name = "DateTime" Then
                                                member.SetValue(o_input, row(member.Name), Nothing)
                                            End If
                                        End If
                                    End If
                                End If

                            Next
                            returndetails.Add(o_input)
                        Next
                    End If
                End If
            Catch ex As Exception
                Throw
            Finally
                CloseDB()
            End Try
        End Sub

        Public Sub GetInvenotryInputs(ByVal inputs As inventoryInputsCollection)
            Try
                OpenDB("DB-EASYINV")
                Dim query As String
                query = "select * from q_inventoryinputs "
                connection.Command = New OleDb.OleDbCommand(query, connection.Connection)
                connection.Adap = New OleDb.OleDbDataAdapter(connection.Command)
                Dim dts As New DataSet
                connection.Adap.Fill(dts)
                If dts.Tables.Count > 0 Then
                    If dts.Tables(0).Rows.Count > 0 Then
                        For Each row As DataRow In dts.Tables(0).Rows
                            Dim o_input As New inventoryintpus
                            For Each member In o_input.GetType.GetProperties
                                If member.CanWrite Then
                                    If member.PropertyType.Name = "String" Or member.PropertyType.Name = "Int32" Or member.PropertyType.Name = "Int64" Or member.PropertyType.Name = "DateTime" Or member.PropertyType.Name = "Boolean" Then
                                        If Not IsDBNull(row(member.Name)) Then
                                            If member.PropertyType.Name = "String" Then
                                                member.SetValue(o_input, row(member.Name).ToString, Nothing)
                                            End If
                                            If member.PropertyType.Name = "Int32" Then
                                                member.SetValue(o_input, Integer.Parse(row(member.Name)), Nothing)
                                            End If
                                            If member.PropertyType.Name = "Int64" Then
                                                member.SetValue(o_input, Long.Parse(row(member.Name)), Nothing)
                                            End If
                                            If member.PropertyType.Name = "DateTime" Then
                                                member.SetValue(o_input, row(member.Name), Nothing)
                                            End If
                                        End If
                                    End If
                                End If

                            Next
                            inputs.Add(o_input)
                        Next
                    End If
                End If
            Catch ex As Exception
                Throw
            Finally
                CloseDB()
            End Try
        End Sub

        Public Sub AddInventoryCapture(ByVal captures As InventoryCaptureCollection)
            If Not IsNothing(captures.Items) Then
                For Each i As inventorycapture In captures.Items
                    AddInventoryCapture(i)
                Next
            End If
        End Sub

        Public Sub AddInventoryCapture(ByVal invcap As inventorycapture)
            Dim qbuilder As New QueryBuilder(Of inventorycapture)
            qbuilder.TypeQuery = TypeQuery.Insert
            qbuilder.Entity = invcap
            qbuilder.BuildInsert("inventory_capture")
            Try
                OpenDB("DB-EASYINV")
                connection.Command = New OleDb.OleDbCommand(qbuilder.Query, connection.Connection)
                connection.Command.ExecuteNonQuery()
            Catch ex As Exception
                Throw
            Finally
                CloseDB()
            End Try
        End Sub


        Public Sub GetStockInventoryByLocation(ByVal LocationCode As String, ByVal items As StockInventoryCollection)
            Try
                OpenDB("DB-EASYINV")
                Dim query As String
                query = "select * from q_stockwarehose where CODE Like '" & LocationCode & "%' order by CODE "
                connection.Command = New OleDb.OleDbCommand(query, connection.Connection)
                connection.Adap = New OleDb.OleDbDataAdapter(connection.Command)
                Dim dts As New DataSet
                connection.Adap.Fill(dts)
                If dts.Tables.Count > 0 Then
                    If dts.Tables(0).Rows.Count > 0 Then
                        For Each row As DataRow In dts.Tables(0).Rows
                            Dim o_stockinv As New stockinventory
                            For Each member In o_stockinv.GetType.GetProperties
                                If member.CanWrite Then
                                    If member.PropertyType.Name = "String" Or member.PropertyType.Name = "Int32" Or member.PropertyType.Name = "Int64" Or member.PropertyType.Name = "DateTime" Or member.PropertyType.Name = "Boolean" Then
                                        If Not IsDBNull(row(member.Name)) Then
                                            If member.PropertyType.Name = "String" Then
                                                member.SetValue(o_stockinv, row(member.Name).ToString, Nothing)
                                            End If
                                            If member.PropertyType.Name = "Int32" Then
                                                member.SetValue(o_stockinv, Integer.Parse(row(member.Name)), Nothing)
                                            End If
                                            If member.PropertyType.Name = "Int64" Then
                                                member.SetValue(o_stockinv, Long.Parse(row(member.Name)), Nothing)
                                            End If
                                            If member.PropertyType.Name = "DateTime" Then
                                                member.SetValue(o_stockinv, row(member.Name), Nothing)
                                            End If
                                        End If
                                    End If
                                End If

                            Next
                            items.Add(o_stockinv)
                        Next
                    End If
                End If
            Catch ex As Exception
                Throw
            Finally
                CloseDB()
            End Try
        End Sub

        Public Sub DeletePhoto(ByVal stockphoto As stocktypephoto)
            Dim query As String = "delete from stocktypephotos where IDstocktypephoto=" & stockphoto.IDstocktypephoto.ToString & ""
            Try
                OpenDB("DB-EASYINV")
                connection.Command = New OleDb.OleDbCommand(query, connection.Connection)
                connection.Command.ExecuteNonQuery()
            Catch ex As Exception
                Throw
            Finally
                CloseDB()
            End Try
        End Sub

        Public Sub GetPhotoStock(ByVal stockphoto As stocktypephoto)
            Try
                OpenDB("DB-EASYINV")
                Dim query As String
                query = "select * from stocktypephotos where IDstocktypephoto=" & stockphoto.IDstocktypephoto.ToString & " "
                connection.Command = New OleDb.OleDbCommand(query, connection.Connection)
                connection.Adap = New OleDb.OleDbDataAdapter(connection.Command)
                Dim dts As New DataSet
                connection.Adap.Fill(dts)
                If dts.Tables.Count > 0 Then
                    If dts.Tables(0).Rows.Count > 0 Then
                        For Each row As DataRow In dts.Tables(0).Rows
                            For Each member In stockphoto.GetType.GetProperties
                                If member.CanWrite Then
                                    If member.PropertyType.Name = "String" Or member.PropertyType.Name = "Int32" Or member.PropertyType.Name = "Int64" Or member.PropertyType.Name = "DateTime" Or member.PropertyType.Name = "Boolean" Then
                                        If Not IsDBNull(row(member.Name)) Then
                                            If member.PropertyType.Name = "String" Then
                                                member.SetValue(stockphoto, row(member.Name).ToString, Nothing)
                                            End If
                                            If member.PropertyType.Name = "Int32" Then
                                                member.SetValue(stockphoto, Integer.Parse(row(member.Name)), Nothing)
                                            End If
                                            If member.PropertyType.Name = "Int64" Then
                                                member.SetValue(stockphoto, Long.Parse(row(member.Name)), Nothing)
                                            End If
                                            If member.PropertyType.Name = "DateTime" Then
                                                member.SetValue(stockphoto, row(member.Name), Nothing)
                                            End If
                                        End If
                                    End If
                                End If
                            Next
                        Next
                    End If
                End If
            Catch ex As Exception
                Throw
            Finally
                CloseDB()
            End Try
        End Sub

        Public Sub GetPhotosStock(ByVal stocktypeid As Long, ByVal result As StockTypePhotoCollection)
            Try
                OpenDB("DB-EASYINV")
                Dim query As String
                query = "select * from stocktypephotos where stocktypeid=" & stocktypeid.ToString & " "
                connection.Command = New OleDb.OleDbCommand(query, connection.Connection)
                connection.Adap = New OleDb.OleDbDataAdapter(connection.Command)
                Dim dts As New DataSet
                connection.Adap.Fill(dts)
                If dts.Tables.Count > 0 Then
                    If dts.Tables(0).Rows.Count > 0 Then
                        For Each row As DataRow In dts.Tables(0).Rows
                            Dim photo As New stocktypephoto
                            For Each member In photo.GetType.GetProperties
                                If member.CanWrite Then
                                    If member.PropertyType.Name = "String" Or member.PropertyType.Name = "Int32" Or member.PropertyType.Name = "Int64" Or member.PropertyType.Name = "DateTime" Or member.PropertyType.Name = "Boolean" Then
                                        If Not IsDBNull(row(member.Name)) Then
                                            If member.PropertyType.Name = "String" Then
                                                member.SetValue(photo, row(member.Name).ToString, Nothing)
                                            End If
                                            If member.PropertyType.Name = "Int32" Then
                                                member.SetValue(photo, Integer.Parse(row(member.Name)), Nothing)
                                            End If
                                            If member.PropertyType.Name = "Int64" Then
                                                member.SetValue(photo, Long.Parse(row(member.Name)), Nothing)
                                            End If
                                            If member.PropertyType.Name = "DateTime" Then
                                                member.SetValue(photo, row(member.Name), Nothing)
                                            End If
                                        End If
                                    End If
                                End If
                            Next
                            result.Add(photo)
                        Next
                    End If
                End If
            Catch ex As Exception
                Throw
            Finally
                CloseDB()
            End Try
        End Sub

        Public Sub AddPhotoToStockType(ByVal photo As stocktypephoto)
            Dim qbuilder As New QueryBuilder(Of stocktypephoto)
            qbuilder.TypeQuery = TypeQuery.Insert
            qbuilder.Entity = photo
            qbuilder.BuildInsert("stocktypephotos")
            Try
                OpenDB("DB-EASYINV")
                connection.Command = New OleDb.OleDbCommand(qbuilder.Query, connection.Connection)
                connection.Command.ExecuteNonQuery()
            Catch ex As Exception
                Throw
            Finally
                CloseDB()
            End Try
        End Sub


        Public Sub GetStockType(ByVal itemStockType As stocktype)
            Try
                OpenDB("DB-EASYINV")
                Dim query As String
                query = "select * from q_maincatalogparts where stockunitid=" & itemStockType.STOCKUNITID.ToString & " "
                connection.Command = New OleDb.OleDbCommand(query, connection.Connection)
                connection.Adap = New OleDb.OleDbDataAdapter(connection.Command)
                Dim dts As New DataSet
                connection.Adap.Fill(dts)
                If dts.Tables.Count > 0 Then
                    If dts.Tables(0).Rows.Count > 0 Then
                        For Each row As DataRow In dts.Tables(0).Rows
                            For Each member In itemStockType.GetType.GetProperties
                                If member.CanWrite Then
                                    If member.PropertyType.Name = "String" Or member.PropertyType.Name = "Int32" Or member.PropertyType.Name = "Int64" Or member.PropertyType.Name = "DateTime" Or member.PropertyType.Name = "Boolean" Then
                                        If Not IsDBNull(row(member.Name)) Then
                                            If member.PropertyType.Name = "String" Then
                                                member.SetValue(itemStockType, row(member.Name).ToString, Nothing)
                                            End If
                                            If member.PropertyType.Name = "Int32" Then
                                                member.SetValue(itemStockType, Integer.Parse(row(member.Name)), Nothing)
                                            End If
                                            If member.PropertyType.Name = "Int64" Then
                                                member.SetValue(itemStockType, Long.Parse(row(member.Name)), Nothing)
                                            End If
                                            If member.PropertyType.Name = "DateTime" Then
                                                member.SetValue(itemStockType, row(member.Name), Nothing)
                                            End If
                                        End If
                                    End If
                                End If
                            Next
                        Next
                    End If
                End If
            Catch ex As Exception
                Throw
            Finally
                CloseDB()
            End Try
        End Sub

        Public Function GetOnHandStockType(ByVal StockType As stocktype) As Integer
            Dim result As Integer = 0
            Try
                OpenDB("DB-EASYINV")
                Dim query As String
                query = "select sumofinstock as r from q_onhand_stocktype where STOCKUNITID=" & StockType.STOCKTYPEID.ToString & " "
                connection.Command = New OleDb.OleDbCommand(query, connection.Connection)
                connection.Adap = New OleDb.OleDbDataAdapter(connection.Command)
                Dim dts As New DataSet
                connection.Adap.Fill(dts)
                If dts.Tables.Count > 0 Then
                    If dts.Tables(0).Rows.Count > 0 Then
                        For Each row As DataRow In dts.Tables(0).Rows
                            If Not IsDBNull(row("r")) Then
                                result = row("r")
                            End If
                        Next
                    End If
                End If
            Catch ex As Exception
                Throw
            Finally
                CloseDB()
            End Try
            Return result
        End Function

        Public Sub GetStockInventory(ByVal StockType As stocktype)
            Dim result As New StockInventoryCollection
            Try
                OpenDB("DB-EASYINV")
                Dim query As String
                query = "select * from q_stockwarehose where STOCKTYPEID=" & StockType.STOCKTYPEID.ToString & " "
                connection.Command = New OleDb.OleDbCommand(query, connection.Connection)
                connection.Adap = New OleDb.OleDbDataAdapter(connection.Command)
                Dim dts As New DataSet
                connection.Adap.Fill(dts)
                If dts.Tables.Count > 0 Then
                    If dts.Tables(0).Rows.Count > 0 Then
                        For Each row As DataRow In dts.Tables(0).Rows
                            Dim o_stockinv As New stockinventory
                            For Each member In o_stockinv.GetType.GetProperties
                                If member.CanWrite Then
                                    If member.PropertyType.Name = "String" Or member.PropertyType.Name = "Int32" Or member.PropertyType.Name = "Int64" Or member.PropertyType.Name = "DateTime" Or member.PropertyType.Name = "Boolean" Then
                                        If Not IsDBNull(row(member.Name)) Then
                                            If member.PropertyType.Name = "String" Then
                                                member.SetValue(o_stockinv, row(member.Name).ToString, Nothing)
                                            End If
                                            If member.PropertyType.Name = "Int32" Then
                                                member.SetValue(o_stockinv, Integer.Parse(row(member.Name)), Nothing)
                                            End If
                                            If member.PropertyType.Name = "Int64" Then
                                                member.SetValue(o_stockinv, Long.Parse(row(member.Name)), Nothing)
                                            End If
                                            If member.PropertyType.Name = "DateTime" Then
                                                member.SetValue(o_stockinv, row(member.Name), Nothing)
                                            End If
                                        End If
                                    End If
                                End If
                            Next
                            result.Add(o_stockinv)
                        Next
                    End If
                End If
                StockType.Stockinventory = result
            Catch ex As Exception
                Throw
            Finally
                CloseDB()
            End Try
        End Sub

        Public Sub SearchStockType(ByVal SearchText As String, ByVal result As StockTypeCollection)
            Try
                OpenDB("DB-EASYINV")
                Dim query As String
                If IsNumeric(SearchText.Substring(0, 3)) Then
                    query = "select * from q_maincatalogparts where stocktypecode like '" & SearchText & "%' "
                Else
                    query = "select * from q_maincatalogparts where pname like '%" & SearchText & "%'"
                End If
                connection.Command = New OleDb.OleDbCommand(query, connection.Connection)
                connection.Adap = New OleDb.OleDbDataAdapter(connection.Command)
                Dim dts As New DataSet
                connection.Adap.Fill(dts)
                If dts.Tables.Count > 0 Then
                    If dts.Tables(0).Rows.Count > 0 Then
                        For Each row As DataRow In dts.Tables(0).Rows
                            Dim o_stocktype As New stocktype
                            For Each member In o_stocktype.GetType.GetProperties
                                If member.CanWrite Then
                                    If member.PropertyType.Name = "String" Or member.PropertyType.Name = "Int32" Or member.PropertyType.Name = "Int64" Or member.PropertyType.Name = "DateTime" Or member.PropertyType.Name = "Boolean" Then
                                        If Not IsDBNull(row(member.Name)) Then
                                            If member.PropertyType.Name = "String" Then
                                                member.SetValue(o_stocktype, row(member.Name).ToString, Nothing)
                                            End If
                                            If member.PropertyType.Name = "Int32" Then
                                                member.SetValue(o_stocktype, Integer.Parse(row(member.Name)), Nothing)
                                            End If
                                            If member.PropertyType.Name = "Int64" Then
                                                member.SetValue(o_stocktype, Long.Parse(row(member.Name)), Nothing)
                                            End If
                                            If member.PropertyType.Name = "DateTime" Then
                                                member.SetValue(o_stocktype, row(member.Name), Nothing)
                                            End If
                                        End If
                                    End If
                                End If
                            Next
                            result.Add(o_stocktype)
                        Next
                    End If
                End If
            Catch ex As Exception
                Throw
            Finally
                CloseDB()
            End Try
        End Sub

    End Class
End Namespace
