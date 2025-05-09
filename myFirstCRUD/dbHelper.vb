Imports System.Data.Odbc
Public Class dbHelper
    Private con As OdbcConnection 'ginagamit para gumawa ng connection sa database
    Private cmd As OdbcCommand ' ginagamit para mag run ng sql command
    Private reader As OdbcDataReader 'ginagamit upang basahin ang query

    Public Sub New()
        con = New OdbcConnection("DSN=dbStudentInformation")
    End Sub
    Public Function OpenConnection() As Boolean
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()
                MsgBox("connection successfull", vbInformation, "Database")
                Return True
            End If
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, vbCritical, "Database Error")
            Return False
        Finally
            GC.Collect()
        End Try
        Return False
    End Function
    Public Sub ClosedConnection()
        Try
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, vbCritical, "Database Error")
        End Try
    End Sub
    Public Function GetConnection() As OdbcConnection
        Return con
    End Function

    Public Function ExecuteQuery(query As String, Optional parameters As List(Of OdbcParameter) = Nothing) As DataTable
        Dim dt As New DataTable
        Try
            If OpenConnection() Then
                Using cmd As New OdbcCommand(query, con)
                    If parameters IsNot Nothing AndAlso parameters.Count > 0 Then
                        cmd.Parameters.AddRange(parameters.ToArray)
                    End If
                    Using reader As OdbcDataReader = cmd.ExecuteReader()
                        dt.Load(reader)
                    End Using
                End Using
                ClosedConnection()
            End If
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, vbCritical, "Database")
        End Try
        Return dt
    End Function

End Class
