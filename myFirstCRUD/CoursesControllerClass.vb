Public Class CoursesControllerClass
    Private CoursesController As New dbOperationClass
    Public Function LoadCourses(ByVal dataGridView As DataGridView) As Boolean
        Dim dt As DataTable = CoursesController.getCourse()
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            dataGridView.DataSource = dt
            SetColumnHeaders(dataGridView, {"Courses ID", "Name", "Code"})
            Return True
        Else
            Return False
        End If
    End Function
    ' Function to set column headers
    Private Sub SetColumnHeaders(ByVal dataGridView As DataGridView, ByVal headers As String())
        For i As Integer = 0 To Math.Min(headers.Length - 1, dataGridView.Columns.Count - 1)
            dataGridView.Columns(i).HeaderText = headers(i)
        Next
    End Sub

End Class
