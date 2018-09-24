Module VB

    Public Function GetMD5(ByVal text As String) As String
        Dim md5Obj As New Security.Cryptography.MD5CryptoServiceProvider
        Dim bytesToHash() As Byte = System.Text.Encoding.ASCII.GetBytes(text)
        bytesToHash = md5Obj.ComputeHash(bytesToHash)

        Dim strResult As String = ""
        For Each b As Byte In bytesToHash
            strResult += b.ToString("x2")
        Next
        Return strResult
    End Function

    Public Function DGV_Hash(ByVal DGV As DataGridView) As String
        Dim strHash As String = ""
        With DGV
            For r As Integer = 0 To .Rows.Count - 1
                For c As Integer = 0 To .Columns.Count - 1
                    If Not IsDBNull(.Item(c, r).Value) Then
                        strHash += CStr(.Item(c, r).Value)
                    End If
                Next
            Next
            strHash = GetMD5(strHash)
        End With
        Return strHash
    End Function

End Module
