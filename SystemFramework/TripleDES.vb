Imports System
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

Namespace SystemFramework
    Public Class TripleDES
        Private key As Byte()

        Private iv As Byte()

        Public Sub New()
            MyBase.New()
            Dim numArray() As Byte = {20, 55, 53, 22, 93, 19, 1, 88, 91, 10, 98, 43, 33, 14, 15, 16, 93, 18, 19, 29, 21, 13, 39, 24}
            Me.key = numArray
            Dim numArray1() As Byte = {65, 110, 68, 26, 69, 178, 200, 219}
            Me.iv = numArray1
        End Sub

        Public Function Decrypt(ByVal plainText As String, ByVal key As String, ByVal ivKey As String) As String
            Dim uTF8Encoding As System.Text.UTF8Encoding = New System.Text.UTF8Encoding()
            Dim cryptoTransform As ICryptoTransform = (New TripleDESCryptoServiceProvider()).CreateDecryptor(Me.key, Me.iv)
            Dim memoryStream As System.IO.MemoryStream = New System.IO.MemoryStream()
            Dim cryptoStream As System.Security.Cryptography.CryptoStream = New System.Security.Cryptography.CryptoStream(memoryStream, cryptoTransform, 1)
            Dim numArray As Byte() = Convert.FromBase64String(plainText)
            cryptoStream.Write(numArray, 0, numArray.Length())
            cryptoStream.FlushFinalBlock()
            memoryStream.Position = (0L)
            Dim numArray1(CInt((memoryStream.Length() - 1L)) + 1 - 1) As Byte
            memoryStream.Read(numArray1, 0, CInt(memoryStream.Length()))
            cryptoStream.Close()
            Return uTF8Encoding.GetString(numArray1)
        End Function

        Public Function Encrypt(ByVal plainText As String, ByVal key As String, ByVal ivKey As String) As String
            Dim bytes As Byte() = (New UTF8Encoding()).GetBytes(plainText)
            Dim cryptoTransform As ICryptoTransform = (New TripleDESCryptoServiceProvider()).CreateEncryptor(Me.key, Me.iv)
            Dim memoryStream As System.IO.MemoryStream = New System.IO.MemoryStream()
            Dim cryptoStream As System.Security.Cryptography.CryptoStream = New System.Security.Cryptography.CryptoStream(memoryStream, cryptoTransform, 1)
            cryptoStream.Write(bytes, 0, bytes.Length())
            cryptoStream.FlushFinalBlock()
            memoryStream.Position = (0L)
            Dim numArray(CInt((memoryStream.Length() - 1L)) + 1 - 1) As Byte
            memoryStream.Read(numArray, 0, CInt(memoryStream.Length()))
            Dim base64String As String = Convert.ToBase64String(numArray, 0, numArray.Length())
            cryptoStream.Close()
            Return base64String
        End Function
    End Class
End Namespace