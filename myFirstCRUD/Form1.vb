Public Class Form1
    Dim CourseController As New CoursesControllerClass
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim isLoad As Boolean = CourseController.LoadCourses(dgvList)
        If Not isLoad Then
            MsgBox("No record Found", vbInformation, "Database")
        End If
    End Sub
End Class
