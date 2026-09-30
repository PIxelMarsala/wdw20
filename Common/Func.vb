Imports System.Xml
Imports System.Net
Imports System.Security.Cryptography.X509Certificates
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Text.RegularExpressions
Imports System.Web
Imports System.Web.UI.WebControls
Imports System.Data.SqlClient
Imports DataAccess
Imports Common

Public NotInheritable Class Func

    Public Shared Function GetWebsiteRoot_UNC() As String
        Dim s As String = HttpContext.Current.Server.MapPath("~")
        If s.EndsWith("/") Then s = Left(s, Len(s) - 1)
        If s.EndsWith("\") Then s = Left(s, Len(s) - 1)
        Return s
    End Function
    Public Shared Function checkBoxListSelectedToStr_str(ByRef theCheckBoxList As CheckBoxList) As String
        Dim i As Integer
        Dim addIDStr As String = ""

        For i = 0 To theCheckBoxList.Items.Count - 1
            If theCheckBoxList.Items(i).Selected Then
                If addIDStr = "" Then addIDStr = theCheckBoxList.Items(i).Value.Replace("'", "''") Else addIDStr &= "," & theCheckBoxList.Items(i).Value.Replace("'", "''")
            End If
        Next
        Return addIDStr

    End Function

    Public Shared Sub preSelectCheckBoxList(ByRef TheCheckBoxList As CheckBoxList, ByVal SQLString As String, Optional ByVal ValueFieldName As String = Nothing)

        Dim r As SqlDataReader = SqlHelper.ExecuteReader(WDWConfiguration.ConnectionString, CommandType.Text, SQLString)
        TheCheckBoxList.DataSource = r
        TheCheckBoxList.DataBind()
    End Sub

    Public Shared Function checkBoxListSelectedToStr_int(ByRef theCheckBoxList As CheckBoxList) As String
        Dim i As Integer
        Dim addIDStr As String = ""

        For i = 0 To theCheckBoxList.Items.Count - 1
            If theCheckBoxList.Items(i).Selected Then
                If addIDStr = "" Then addIDStr = theCheckBoxList.Items(i).Value Else addIDStr &= "," & theCheckBoxList.Items(i).Value
            End If
        Next
        Return addIDStr
    End Function
    Public Shared Function StripHTMLTags(ByVal html As String) As String
        If html.Trim() = "" Then Return ""

        ' Remove HTML tags.
        Dim retStr As String = Regex.Replace(html, "<.*?>", " ")
        retStr = Regex.Replace(retStr, "\s+", " ")  ' Remove duplicate spaces

        Return retStr.Trim()
    End Function

    Public Function ObjectToString(ByVal O As Object) As String
        Dim ms As New MemoryStream()
        Dim bf As New BinaryFormatter()
        bf.Serialize(ms, O)
        Dim str As String = System.Convert.ToBase64String(ms.ToArray) & ""
        Return str
    End Function

    Public Function StringToObject(ByVal str As String) As Object
        Dim ms As New IO.MemoryStream(System.Convert.FromBase64String(str))
        Dim bf As New BinaryFormatter()
        Return bf.Deserialize(ms)
    End Function

    Public Shared Function isAlphaNumeric(theValue As Object, allowNumbers As Boolean, allowSpaces As Boolean, allowPeriods As Boolean, Optional allowOtherChars As String = "") As Boolean

        Dim mStr As String = "a-zA-Z"
        If allowSpaces Then mStr &= " "
        If allowNumbers Then mStr &= "0-9"
        If allowPeriods Then mStr &= "/."

        Return Regex.IsMatch(theValue & "", "^[" & mStr & allowOtherChars & "]+$")

    End Function

    Public Shared Function IsAllNumericDigit(ByVal input As String) As Boolean
        Return Regex.IsMatch(input, "^[0-9]+$")
    End Function

    Public Shared Function DateFriendlyDay(ByVal theDay As Integer) As String

        Dim friendlyday As String = theDay & "th"
        If theDay < 10 Or theDay > 20 Then ' excludes 11th...19th
            Dim m As Integer = theDay Mod 10
            If m = 1 Then friendlyday = theDay.ToString() & "st"
            If m = 2 Then friendlyday = theDay.ToString() & "nd"
            If m = 3 Then friendlyday = theDay.ToString() & "rd"
        End If

        Return friendlyday

    End Function

    Public Shared Function CastToBool(ByVal value As Object, Optional ByVal defaultValue As Boolean = False) As Boolean
        Try
            If value Is Nothing Then Return defaultValue
            If value Is DBNull.Value Then Return defaultValue
            Dim chkVal As String = UCase(value & "")

            Select Case chkVal
                Case "Y", "YES", "TRUE", "1" : Return True
                Case "N", "NO", "FALSE", "0" : Return False
                Case Else : Return CType(value, Boolean)
            End Select

        Catch ex As Exception
            Return defaultValue
        End Try
    End Function

    Public Shared Function CastToDate(ByVal value As Object, ByVal defaultValue As Date) As Date
        Try
            If value Is Nothing Then Return defaultValue
            If value Is DBNull.Value Then Return defaultValue

            Return CType(value, Date)
        Catch ex As Exception
            Return defaultValue
        End Try
    End Function

    Public Shared Function CastToDouble(ByVal value As Object, ByVal defaultValue As Double) As Double
        Try
            If value Is Nothing Then Return defaultValue
            If value Is DBNull.Value Then Return defaultValue

            Return CType(value, Double)
        Catch ex As Exception
            Return defaultValue
        End Try
    End Function

    Public Shared Function CastToDec(ByVal value As Object, ByVal defaultValue As Decimal) As Decimal
        Try
            If value Is Nothing Then Return defaultValue
            If value Is DBNull.Value Then Return defaultValue

            Return CType(value, Decimal)
        Catch ex As Exception
            Return defaultValue
        End Try
    End Function

    Public Shared Function CastToInt(ByVal value As Object, ByVal defaultValue As Integer) As Integer
        Try
            If value Is Nothing Then Return defaultValue
            If value Is DBNull.Value Then Return defaultValue

            Return CType(value, Integer)
        Catch ex As Exception
            Return defaultValue
        End Try
    End Function
    Public Shared Function CastToLong(ByVal value As Object, ByVal defaultValue As Long) As Long
        Try
            If value Is Nothing Then Return defaultValue
            If value Is DBNull.Value Then Return defaultValue

            Dim R As Long = defaultValue
            If Not Long.TryParse(Func.CastToStr(value), R) Then Return defaultValue Else Return R
        Catch ex As Exception
            Return defaultValue
        End Try
    End Function
    Public Shared Function CastToStr(ByVal value As Object, Optional ByVal defaultValue As String = "") As String
        Try
            If value Is Nothing Then Return defaultValue
            If value Is DBNull.Value Then Return defaultValue
            Return CType(value, String)
        Catch ex As Exception
            Return defaultValue
        End Try
    End Function

    Public Shared Function ConcatenateFullMailingAddress(ByVal Name As String, ByVal Company As String, ByVal CoAttn As String, ByVal Addr1 As String, ByVal Addr2 As String, ByVal City As String, ByVal State As String, ByVal Zip As String, ByVal Country As String, ByVal ReturnAsHTML As Boolean, ByVal Addr1and2OnSameLine As Boolean, Optional ByVal Title As String = "") As String
        Dim retStr As String = ""
        Dim nextLine As String = "<br />"
        Dim isForeign As Boolean = False
        Country &= ""
        If Country.Trim > "" And Country.Trim.ToUpper <> "UNITED STATES" And Country.Trim.ToUpper <> "U.S." And Country.Trim.ToUpper <> "US" And Country.Trim.ToUpper <> "USA" Then
            isForeign = True
        End If

        If Not ReturnAsHTML Then nextLine = vbCrLf

        If String.IsNullOrEmpty(Name) Then Name = ""
        If String.IsNullOrEmpty(Company) Then Company = ""
        If String.IsNullOrEmpty(CoAttn) Then CoAttn = ""
        If String.IsNullOrEmpty(Addr1) Then Addr1 = ""
        If String.IsNullOrEmpty(Addr2) Then Addr2 = ""
        If String.IsNullOrEmpty(State) Then State = ""
        If String.IsNullOrEmpty(Country) Then Country = ""
        If String.IsNullOrEmpty(Zip) Then Zip = ""

        If Name > "" Then
            retStr &= Name.Trim
            If Title.Trim > "" Then retStr &= ", " & Title
            retStr &= nextLine
        Else
            If Title.Trim > "" Then retStr &= Title & nextLine
        End If

        If Company.Trim > "" Then retStr &= Company.Trim & nextLine
        If CoAttn.Trim > "" Then retStr &= "c/o " & CoAttn.Trim & nextLine
        If Addr1.Trim > "" Then retStr &= Addr1.Trim & IIf(Addr1and2OnSameLine, " ", nextLine)
        If Addr2.Trim > "" Then retStr &= Addr2 & nextLine

        Dim csz As String = ConcatenateCityStateZip(City, State, Zip)
        If csz.Trim > "" Then retStr &= csz & nextLine

        If isForeign Then retStr &= Country.Trim & nextLine

        ' Remove the last nextline
        If retStr.Length > 0 Then
            Dim ix As Integer
            ix = retStr.LastIndexOf(nextLine)
            Try
                If ix > 0 Then
                    retStr = retStr.Substring(0, ix) & retStr.Substring(ix + nextLine.Length)
                End If
            Catch ex As Exception
            End Try
        End If

        Return retStr & ""

    End Function

    Public Shared Function ConcatenateCityStateZip(ByVal City As String, ByVal State As String, ByVal Zip As String) As String

        If String.IsNullOrEmpty(City) Then City = ""
        If String.IsNullOrEmpty(State) Then State = ""
        If String.IsNullOrEmpty(Zip) Then Zip = ""

        Dim csz As String = City.Trim

        If State.Trim > "" Then
            If csz > "" Then csz &= ", "
            csz &= State
        End If

        If Zip.Trim > "" Then
            If csz > "" Then csz &= " "
            csz &= Zip
        End If

        Return csz.Trim

    End Function

    Public Shared Function FormatCurrency(ByVal value As Object, ForceDecPlaces As Integer, includeCommas As Boolean, returnZeroInsteadOfBlanks As Boolean) As String
        Dim C As String = value & ""
        If returnZeroInsteadOfBlanks And C = "" Then C = "0"

        If Not IsNumeric(C) Then Return C ' If the value is not numeric then just return it back

        Try
            Dim rt As String = ""
            Dim lt As String = "0"

            If ForceDecPlaces > 0 Then
                rt = "."
                For i As Integer = 1 To ForceDecPlaces
                    rt &= "0"
                Next
            End If

            If includeCommas Then lt = "#,0" Else lt = "0"

            Dim valueDec As Decimal = C
            C = valueDec.ToString(lt & rt)
        Catch ex As Exception
        End Try

        Return C
    End Function

    Public Shared Function extractDigits(ByVal value As String) As String
        If value & "" = "" Then Return ""

        Dim digits As String = ""
        For i As Integer = 0 To Len(value) - 1
            If Regex.IsMatch(value.Substring(i, 1), "[0-9]") Then digits &= value.Substring(i, 1)
        Next

        Return digits & ""
    End Function

    Public Shared Function extractAlphaNum(ByVal value As Object, Optional ExtractAlpha As Boolean = True, Optional ExtractNumeric As Boolean = True, Optional AllowChars As String = " ", Optional ReplaceWithChar As String = "") As String
        If value & "" = "" Then Return ""

        Dim ValStr As String = value & ""
        Dim retStr As String = ""
        Dim dig As String = IIf(ExtractNumeric, "0-9", "")
        Dim alp As String = IIf(ExtractAlpha, "a-zA-Z", "")
        For i As Integer = 0 To Len(value) - 1
            If Regex.IsMatch(ValStr.Substring(i, 1), "[" & dig & alp & AllowChars & "]") Then retStr &= ValStr.Substring(i, 1) Else retStr &= ReplaceWithChar
        Next

        Return retStr & ""
    End Function

End Class
