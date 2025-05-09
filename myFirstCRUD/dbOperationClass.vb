Imports System.Data.Odbc
Public Class dbOperationClass
    Private db As New dbHelper
    Public Function getCourse() As DataTable
        Dim query As String = "select ID,name,code from tblcourses"
        Return db.ExecuteQuery(query)
    End Function
End Class
