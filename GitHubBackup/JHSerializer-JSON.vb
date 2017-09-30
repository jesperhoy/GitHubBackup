Partial Class JhSerializer

  Private Shared Sub SkipWhiteSpace(ByVal s As String, ByRef pos As Integer)
    While pos < s.Length
      Select Case AscW(s(pos))
        Case 32, 9, 10, 13, 12
          pos += 1
        Case Else
          Exit Sub
      End Select
    End While
  End Sub

  Public Class JsonParsePassedEndException
    Inherits Exception
  End Class
  Public Class JsonParseInvalidDataException
    Inherits Exception
    Public ReadOnly AtCharacter As Integer
    Public Sub New(ByVal AtCharacter As Integer)
      Me.AtCharacter = AtCharacter
    End Sub
  End Class

  Partial Class JhsValue
    Public MustOverride Function EncodeJson(pretty As Boolean, Optional indentLevel As Integer = 0) As String

    Public Shared Function TryParseJson(ByVal s As String, ByRef v As JhsValue) As Boolean
      Try
        v = ParseJson(s)
        Return True
      Catch
        Return False
      End Try
    End Function

    Public Shared Function ParseJson(ByVal s As String, Optional ByRef fromIndex As Integer = 0) As JhsValue
      SkipWhiteSpace(s, fromIndex)
      Dim dl = s.Length - fromIndex
      If dl <= 0 Then Throw New JsonParsePassedEndException

      If s(fromIndex) = "{"c Then
        fromIndex += 1
        Return ParseJsonObject(s, fromIndex)
      ElseIf s(fromIndex) = "["c Then
        fromIndex += 1
        Return ParseJsonArray(s, fromIndex)
      ElseIf s(fromIndex) = """"c Then
        fromIndex += 1
        Return ParseJsonString(s, fromIndex)
      ElseIf dl >= 4 AndAlso String.Compare(s.Substring(fromIndex, 4), "true", StringComparison.InvariantCultureIgnoreCase) = 0 Then
        fromIndex += 4
        Return New JhsBoolean(True)
      ElseIf dl >= 5 AndAlso String.Compare(s.Substring(fromIndex, 5), "false", StringComparison.InvariantCultureIgnoreCase) = 0 Then
        fromIndex += 5
        Return New JhsBoolean(False)
      ElseIf dl >= 4 AndAlso String.Compare(s.Substring(fromIndex, 4), "null", StringComparison.InvariantCultureIgnoreCase) = 0 Then
        fromIndex += 4
        Return JhsNull.Value
      Else
        Return ParseJsonNumber(s, fromIndex)
      End If
    End Function

    Private Shared Function ParseJsonObject(ByVal s As String, ByRef pos As Integer) As JhsObject
      Dim oName As String
      Dim oVal As JhsValue
      Dim rv As New JhsObject

      SkipWhiteSpace(s, pos)
      If pos >= s.Length Then Throw New JsonParsePassedEndException
      If s(pos) = "}"c Then pos += 1 : Return rv

      Do
        If s(pos) <> """"c Then Throw New JsonParseInvalidDataException(pos)
        pos += 1
        oName = ParseJsonString(s, pos).Value

        SkipWhiteSpace(s, pos)
        If pos >= s.Length Then Throw New JsonParsePassedEndException
        If s(pos) <> ":"c Then Throw New JsonParseInvalidDataException(pos)
        pos += 1

        SkipWhiteSpace(s, pos)
        If pos >= s.Length Then Throw New JsonParsePassedEndException
        oVal = ParseJson(s, pos)

        rv.Members.Add(oName, oVal)

        SkipWhiteSpace(s, pos)
        If pos >= s.Length Then Throw New JsonParsePassedEndException
        If s(pos) = "}"c Then pos += 1 : Return rv
        If s(pos) <> ","c Then Throw New JsonParseInvalidDataException(pos)
        pos += 1

        JhSerializer.SkipWhiteSpace(s, pos)
        If pos >= s.Length Then Throw New JsonParsePassedEndException
      Loop
    End Function

    Private Shared Function ParseJsonArray(ByVal s As String, ByRef pos As Integer) As JhsArray
      JhSerializer.SkipWhiteSpace(s, pos)
      If pos >= s.Length Then Throw New JsonParsePassedEndException
      Dim rv As New JhsArray
      If s(pos) = "]"c Then pos += 1 : Return rv
      Do
        rv.Elements.Add(JhSerializer.JhsValue.ParseJson(s, pos))
        SkipWhiteSpace(s, pos)
        If pos >= s.Length Then Throw New JsonParsePassedEndException
        If s(pos) = "]"c Then pos += 1 : Return rv
        If s(pos) <> ","c Then Throw New JsonParseInvalidDataException(pos)
        pos += 1
        SkipWhiteSpace(s, pos)
      Loop

    End Function

    Private Shared Function ParseJsonString(ByVal s As String, ByRef pos As Integer) As JhsString
      Dim sb As New System.Text.StringBuilder
      Dim c As Char
      Do
        If pos >= s.Length Then Throw New JsonParsePassedEndException
        c = s(pos)
        If c = """"c Then pos += 1 : Return New JhsString(sb.ToString)
        If c <> "\"c Then sb.Append(c) : pos += 1 : Continue Do
        pos += 1
        If pos >= s.Length Then Throw New JsonParsePassedEndException
        Select Case s(pos)
          Case "b"c 'backspace (BS)
            sb.Append(ChrW(8))
          Case "t"c 'tab (TAB)
            sb.Append(ChrW(9))
          Case "n"c 'new line (LF)
            sb.Append(ChrW(10))
          Case "f"c 'form feed (FF)
            sb.Append(ChrW(12))
          Case "r"c 'return (CR)
            sb.Append(ChrW(13))
          Case "u"c ' "0"c To "9"c, "a"c To "f"c, "A"c To "F"c '4 digit hex
            If pos + 4 >= s.Length Then Throw New JsonParsePassedEndException
            sb.Append(ChrW(Convert.ToInt32(s.Substring(pos + 1, 4), 16)))
            pos += 4 '+1 after End Select
          Case Else ' everything else including ", \, /
            sb.Append(s(pos))
        End Select
        pos += 1
      Loop
    End Function

    Private Shared Function ParseJsonNumber(ByVal s As String, ByRef pos As Integer) As JhsValue
      If pos >= s.Length Then Throw New JsonParsePassedEndException
      Dim sp = pos
      Dim FloatFlag = False
      If s(pos) = "-"c Then pos += 1
      If pos >= s.Length Then Throw New JsonParsePassedEndException
      If SkipDigits(s, pos) = 0 Then Throw New JsonParseInvalidDataException(pos)
      If pos >= s.Length Then GoTo markDone
      REM look for decimal point
      If s(pos) = "."c Then
        FloatFlag = True
        pos += 1
        If SkipDigits(s, pos) = 0 Then Throw New JsonParseInvalidDataException(pos)
      End If
      REM look for e/E
      If Char.ToLowerInvariant(s(pos)) <> "e"c Then GoTo markDone
      FloatFlag = True
      pos += 1
      If pos >= s.Length Then Throw New JsonParsePassedEndException
      If s(pos) = "-" Or s(pos) = "+" Then pos += 1
      If pos >= s.Length Then Throw New JsonParsePassedEndException
      If SkipDigits(s, pos) = 0 Then Throw New JsonParseInvalidDataException(pos)
markDone:
      If FloatFlag Then
        Return New JhsFloat(Double.Parse(s.Substring(sp, pos - sp), System.Globalization.NumberFormatInfo.InvariantInfo))
      Else
        Return New JhsInteger(Int64.Parse(s.Substring(sp, pos - sp), System.Globalization.NumberFormatInfo.InvariantInfo))
      End If
    End Function

    Private Shared Function SkipDigits(ByVal s As String, ByRef pos As Integer) As Integer
      Dim skipCt = 0
      Do
        If pos >= s.Length OrElse s(pos) < "0"c OrElse s(pos) > "9"c Then Return skipCt
        pos += 1
        skipCt += 1
      Loop
    End Function

  End Class


  Partial Class JhsObject
    Public Overrides Function EncodeJson(pretty As Boolean, Optional indentLevel As Integer = 0) As String
      If Members.Count = 0 Then Return "{}"
      Dim sb As New System.Text.StringBuilder
      sb.Append("{"c)
      If pretty Then sb.Append(vbCrLf)
      Dim firstM = True
      For Each m In Members
        If Not firstM Then
          sb.Append(","c)
          If pretty Then sb.Append(vbCrLf)
        End If
        If pretty Then sb.Append(New String(" "c, (indentLevel + 1) * 2))
        sb.Append((New JhsString(m.Key)).EncodeJson(pretty, indentLevel + 1))
        If pretty Then sb.Append(" : ") Else sb.Append(":"c)
        sb.Append(m.Value.EncodeJson(pretty, indentLevel + 1))
        firstM = False
      Next
      If pretty Then sb.Append(vbCrLf & New String(" "c, indentLevel * 2))
      sb.Append("}"c)
      Return sb.ToString
    End Function
  End Class

  Partial Class JhsArray
    Public Overrides Function EncodeJson(pretty As Boolean, Optional indentLevel As Integer = 0) As String
      If Elements.Count = 0 Then Return "[]"
      Dim sb As New System.Text.StringBuilder
      sb.Append("["c)
      If pretty Then sb.Append(vbCrLf)
      Dim firstE = True
      For Each m In Elements
        If Not firstE Then
          sb.Append(","c)
          If pretty Then sb.Append(vbCrLf)
        End If
        If pretty Then sb.Append(New String(" "c, (indentLevel + 1) * 2))
        sb.Append(m.EncodeJson(pretty, indentLevel + 1))
        firstE = False
      Next
      If pretty Then sb.Append(vbCrLf & New String(" "c, indentLevel * 2))
      sb.Append("]"c)
      Return sb.ToString
    End Function
  End Class

  Partial Class JhsString
    Public Overrides Function EncodeJson(pretty As Boolean, Optional indentLevel As Integer = 0) As String
      If Value Is Nothing Then Return "null"
      Dim sb As New System.Text.StringBuilder
      sb.Append(""""c)
      For i = 0 To Value.Length - 1
        Select Case AscW(Value(i))
          Case 8 'backspace (BS)
            sb.Append("\b")
          Case 9 'horizontal tab (TAB)
            sb.Append("\t")
          Case 10 ' newline (LF)
            sb.Append("\n")
          Case 12 'formfeed (FF)
            sb.Append("\f")
          Case 13 'carriage return (CR)
            sb.Append("\r")
          Case 34 ' "
            sb.Append("\""")
          Case 92 ' \
            sb.Append("\\")
          Case Is < 32, 127 ' control chars
            sb.Append("\" & Hex(AscW(Value(i))).PadLeft(4, "0"c))
          Case Else
            sb.Append(Value(i))
        End Select
      Next
      sb.Append(""""c)
      Return sb.ToString
    End Function
  End Class

  Partial Class JhsDateTime
    Public Overloads Overrides Function EncodeJson(pretty As Boolean, Optional indentLevel As Integer = 0) As String
      Return """" & Value.ToString("yyyy-MM-ddTHH:mm:ss") & """"
    End Function
  End Class

  Partial Class JhsInteger
    Public Overrides Function EncodeJson(pretty As Boolean, Optional indentLevel As Integer = 0) As String
      Return Value.ToString(System.Globalization.NumberFormatInfo.InvariantInfo)
    End Function
  End Class

  Partial Class JhsFloat
    Public Overrides Function EncodeJson(pretty As Boolean, Optional indentLevel As Integer = 0) As String
      Return Value.ToString(System.Globalization.NumberFormatInfo.InvariantInfo)
    End Function
  End Class

  Partial Class JhsBoolean
    Public Overrides Function EncodeJson(pretty As Boolean, Optional indentLevel As Integer = 0) As String
      Return If(Value, "true", "false")
    End Function
  End Class

  Partial Class JhsNull
    Public Overrides Function EncodeJson(pretty As Boolean, Optional indentLevel As Integer = 0) As String
      Return "null"
    End Function
  End Class

  Partial Class JhsBinary
    Public Overloads Overrides Function EncodeJson(pretty As Boolean, Optional indentLevel As Integer = 0) As String
      Return """" & System.Convert.ToBase64String(Value) & """"
    End Function
  End Class


End Class
