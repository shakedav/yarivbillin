Imports Microsoft.Office.Interop
Imports Microsoft.Office.Interop.Excel

Public Class Client

    Dim xlApp As Excel.Application
    Dim wb As Workbook
    Dim ws As Worksheet
    Dim var As String

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet
        xlApp = New Excel.Application
        If Not (FileInUse("E:\Yariv Handasa\YarivBilling\DataBase.xls")) Then
            xlWorkBook = xlApp.Workbooks.Open("E:\Yariv Handasa\YarivBilling\DataBase.xls", , False, , , , True, , , True, , , , , )
            xlWorkSheet = xlWorkBook.Sheets("לקוחות")
            Dim items(0 To 10) As String
            items(0) = txtBoxName.Text
            items(1) = txtBoxProjectNumber.Text
            items(2) = txtBoxAddress.Text
            items(3) = txtBoxPhone.Text
            items(4) = txtBoxEmail.Text
            items(5) = txtBoxContactMan.Text
            items(6) = txtBoxClientNumber.Text
            items(7) = txtBoxProjectNameInviter.Text
            items(8) = txtBoxProjectCodeInviter.Text
            items(9) = txtBoxProjectName.Text
            Dim column, row As Integer
            column = 1
            row = 2
            If (IsNewClient(txtBoxClientNumber.Text, xlWorkSheet)) Then
                row = GetLastRow(xlWorkSheet)
                For Each item As String In items
                    xlWorkSheet.Cells(row, column) = item
                    column = column + 1
                Next
            Else
                MsgBox("Client Exists!")
            End If
            xlApp.DisplayAlerts = False
            xlWorkSheet.SaveAs("E:\Yariv Handasa\YarivBilling\DataBase.xls")
            xlWorkBook.Close()
            xlApp.Quit()
            releaseObject(xlApp)
            releaseObject(xlWorkBook)
            releaseObject(xlWorkSheet)
        Else
            MsgBox("File is open, close to continue")
        End If
    End Sub

    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

   Public Function FileInUse(ByVal sFile As String) As Boolean
        If System.IO.File.Exists(sFile) Then
            Try
                Dim F As Short = FreeFile()
                FileOpen(F, sFile, OpenMode.Binary, OpenAccess.ReadWrite, OpenShare.LockReadWrite)
                FileClose(F)
            Catch
                Return True
            End Try
        End If
    End Function


    Private Function IsNewClient(ByVal item As String, ByVal worksheet As Excel.Worksheet) As Boolean
        Dim row As Integer
        row = 2
        While TypeOf worksheet.Cells(row, 1) Is Object And Not (Format(worksheet.Cells(row, 1).Value) = vbNullString)
            If worksheet.Cells(row, 1).Value.ToString() = item Then
                Return False
            Else
                row = row + 1
            End If
        End While
        Return True
    End Function

    Private Function GetLastRow(ByVal worksheet As Worksheet) As Integer
        Dim row As Integer
        row = 2
        While Not (Format(worksheet.Cells(row, 1).Value) = vbNullString)
            row = row + 1
        End While
        Return row
    End Function

End Class

