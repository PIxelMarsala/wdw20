Imports System
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports System.Web.Security

Namespace Common
    Public Class CryptoHash
        Public Sub New()
            MyBase.New()
        End Sub

        Public Shared Function decrypt(ByVal plainText As String, ByVal encryptKey As String, ByVal ivKey As String) As String
            Dim numArray() As Byte = {20, 55, 53, 22, 93, 19, 1, 88, 91, 10, 98, 43, 33, 14, 15, 16, 93, 18, 19, 29, 21, 13, 39, 24}
            Dim numArray1 As Byte() = numArray
            numArray = New Byte() {65, 110, 68, 26, 69, 178, 200, 219}
            Dim numArray2 As Byte() = numArray
            Dim uTF8Encoding As System.Text.UTF8Encoding = New System.Text.UTF8Encoding()
            Dim cryptoTransform As ICryptoTransform = (New TripleDESCryptoServiceProvider()).CreateDecryptor(numArray1, numArray2)
            Dim memoryStream As System.IO.MemoryStream = New System.IO.MemoryStream()
            Dim cryptoStream As System.Security.Cryptography.CryptoStream = New System.Security.Cryptography.CryptoStream(memoryStream, cryptoTransform, 1)
            Dim numArray3 As Byte() = Convert.FromBase64String(plainText)
            cryptoStream.Write(numArray3, 0, numArray3.Length())
            cryptoStream.FlushFinalBlock()
            memoryStream.Position = (0L)
            Dim numArray4(CInt((memoryStream.Length() - 1L)) + 1 - 1) As Byte
            memoryStream.Read(numArray4, 0, CInt(memoryStream.Length()))
            cryptoStream.Close()
            Return uTF8Encoding.GetString(numArray4)
        End Function

        Public Shared Function encrypt(ByVal plainText As String, ByVal encryptKey As String, ByVal ivKey As String) As String
            Dim numArray() As Byte = {20, 55, 53, 22, 93, 19, 1, 88, 91, 10, 98, 43, 33, 14, 15, 16, 93, 18, 19, 29, 21, 13, 39, 24}
            Dim numArray1 As Byte() = numArray
            numArray = New Byte() {65, 110, 68, 26, 69, 178, 200, 219}
            Dim numArray2 As Byte() = numArray
            Dim bytes As Byte() = (New UTF8Encoding()).GetBytes(plainText)
            Dim cryptoTransform As ICryptoTransform = (New TripleDESCryptoServiceProvider()).CreateEncryptor(numArray1, numArray2)
            Dim memoryStream As System.IO.MemoryStream = New System.IO.MemoryStream()
            Dim cryptoStream As System.Security.Cryptography.CryptoStream = New System.Security.Cryptography.CryptoStream(memoryStream, cryptoTransform, 1)
            cryptoStream.Write(bytes, 0, bytes.Length())
            cryptoStream.FlushFinalBlock()
            memoryStream.Position = (0L)
            Dim numArray3(CInt((memoryStream.Length() - 1L)) + 1 - 1) As Byte
            memoryStream.Read(numArray3, 0, CInt(memoryStream.Length()))
            Dim base64String As String = Convert.ToBase64String(numArray3, 0, numArray3.Length())
            cryptoStream.Close()
            Return base64String
        End Function

        Public Shared Function generateHash(ByVal hashTarget As String) As String
            Return FormsAuthentication.HashPasswordForStoringInConfigFile(hashTarget, "SHA1")
        End Function
    End Class
End Namespace