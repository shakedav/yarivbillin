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
            'row = xlApp.Cells.Find("*", SearchOrder:=xlByRows, SearchDirection:=xlPrevious).Row
            'If (IsNewClient(txtBoxClientNumber.Text, xlWorkSheet)) Then
            For Each item As String In items
                xlWorkSheet.Cells(row, column) = item
                column = column + 1
            Next
            'Else
            '    MsgBox("aaa")

            'End If

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


    'Private Function IsNewClient(ByVal item As String, ByVal worksheet As Excel.Worksheet) As Boolean
    '    Excel.Range allCellsRng;
    'string lowerRightCell = "IV65536";
    'allCellsRng = ws.get_Range("A1", lowerRightCell).Cells;
    '    Dim row = 2
    '    For Each Cell In Activeshee
    '        If worksheet.Cells(row,0) == item Then
    '            Return True
    '            row = row + 1
    '        End If
    '    Next
    '    Return False
    'End Function

End Class

