Imports System.IO
Imports Newtonsoft.Json
Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim project_dir As String = Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString()
        File.Create(project_dir + "\Test.txt").Dispose()

        Dim file_dir As String = project_dir + "\Test.txt"
        Dim fileExists As Boolean = File.Exists(file_dir)
        Using sw As New StreamWriter(File.Open(file_dir, FileMode.OpenOrCreate))
            sw.WriteLine(TextBox1.Text.ToString() + "," + TextBox2.Text.ToString() + "," + TextBox3.Text.ToString())
        End Using
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim project_dir As String = Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString()
        Dim name As String = TextBox1.Text.ToString()
        Dim age As String = TextBox2.Text.ToString()
        Dim address As String = TextBox3.Text.ToString()

        Dim xmlDeclaration As New XDeclaration("1.0", "UTF-8", "yes")
        Dim document As XDocument =
            New XDocument(xmlDeclaration,
                            New XElement("TestFile",
                                New XElement("name", name),
                                New XElement("age", age),
                                New XElement("address", address)))
        document.Save(project_dir + "\test.xml")
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim project_dir As String = Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()).ToString()
        Dim dict As New Dictionary(Of String, String)
        dict.Add("name", TextBox1.Text.ToString())
        dict.Add("age", TextBox2.Text.ToString())
        dict.Add("address", TextBox3.Text.ToString())

        File.WriteAllText(project_dir & "\test.json", JsonConvert.SerializeObject(dict, NewtonSoft.Json.Formatting.Indented))
    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".")
    End Sub
End Class
