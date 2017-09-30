Public Class JhSerializer

  Public MustInherit Class JhsValue
  End Class


  Public Class JhsObject
    Inherits JhsValue
    Implements IEnumerable(Of KeyValuePair(Of String, JhsValue))

    Public ReadOnly Members As New Dictionary(Of String, JhsValue) 'It appears that this collection type does preserve adding order - so no need to make our own

    Public Sub Add(memberKey As String, value As Boolean)
      Members.Add(memberKey, New JhsBoolean(value))
    End Sub
    Public Sub Add(memberKey As String, value As Int64)
      Members.Add(memberKey, New JhsInteger(value))
    End Sub
    Public Sub Add(memberKey As String, value As Double)
      Members.Add(memberKey, New JhsFloat(value))
    End Sub
    Public Sub Add(memberKey As String, value As String)
      Members.Add(memberKey, New JhsString(value))
    End Sub
    Public Sub Add(memberKey As String, value As DateTime)
      Members.Add(memberKey, New JhsDateTime(value))
    End Sub
    Public Sub Add(memberKey As String, value As Byte())
      Members.Add(memberKey, New JhsBinary(value))
    End Sub
    Public Sub Add(memberKey As String, value As JhsValue)
      Members.Add(memberKey, value)
    End Sub

    Public Function GetBool(memberKey As String) As Boolean
      Return DirectCast(Members(memberKey), JhsBoolean).Value
    End Function
    Public Function GetBool(memberKey As String, [default] As Boolean) As Boolean
      If Not Members.ContainsKey(memberKey) Then Return [default]
      Return DirectCast(Members(memberKey), JhsBoolean).Value
    End Function

    Public Function GetInt64(memberKey As String) As Int64
      Return DirectCast(Members(memberKey), JhsInteger).Value
    End Function
    Public Function GetInt64(memberKey As String, [default] As Int64) As Int64
      If Not Members.ContainsKey(memberKey) Then Return [default]
      Return DirectCast(Members(memberKey), JhsInteger).Value
    End Function

    Public Function GetInt(memberKey As String) As Integer
      Return CInt(DirectCast(Members(memberKey), JhsInteger).Value)
    End Function
    Public Function GetInt(memberKey As String, [default] As Integer) As Integer
      If Not Members.ContainsKey(memberKey) Then Return [default]
      Return CInt(DirectCast(Members(memberKey), JhsInteger).Value)
    End Function

    Public Function GetDouble(memberKey As String) As Double
      Return DirectCast(Members(memberKey), JhsFloat).Value
    End Function
    Public Function GetDouble(memberKey As String, [default] As Double) As Double
      If Not Members.ContainsKey(memberKey) Then Return [default]
      Return DirectCast(Members(memberKey), JhsFloat).Value
    End Function

    Public Function GetString(memberKey As String) As String
      Return DirectCast(Members(memberKey), JhsString).Value
    End Function
    Public Function GetString(memberKey As String, [default] As String) As String
      If Not Members.ContainsKey(memberKey) Then Return [default]
      Return DirectCast(Members(memberKey), JhsString).Value
    End Function

    Public Function GetDateTime(memberKey As String) As DateTime
      Dim v = Members(memberKey)
      If TypeOf v Is JhsDateTime Then Return DirectCast(v, JhsDateTime).Value
      Dim s = DirectCast(v, JhsString).Value
      If s.Length <> 19 Then Throw New ArgumentException("Invalid date time value - length not 19")
      If s(4) <> "-"c OrElse _
         s(7) <> "-"c OrElse _
         s(10) <> "T"c OrElse _
         s(13) <> ":"c OrElse _
         s(16) <> ":"c Then Throw New ArgumentException("Invalid date time value")
      Return New DateTime(Integer.Parse(s.Substring(0, 4)),
                          Integer.Parse(s.Substring(5, 2)),
                          Integer.Parse(s.Substring(8, 2)),
                          Integer.Parse(s.Substring(11, 2)),
                          Integer.Parse(s.Substring(14, 2)),
                          Integer.Parse(s.Substring(17, 2)))
    End Function
    Public Function GetDateTime(memberKey As String, [default] As DateTime) As DateTime
      If Not Members.ContainsKey(memberKey) Then Return [default]
      Return GetDateTime(memberKey)
    End Function

    Friend Function GetBinary(memberKey As String) As Byte()
      Dim v = Members(memberKey)
      If TypeOf v Is JhsBinary Then Return DirectCast(v, JhsBinary).Value
      Return System.Convert.FromBase64String(DirectCast(v, JhsString).Value)
    End Function
    Friend Function GetBinary(memberKey As String, [default] As Byte()) As Byte()
      If Not Members.ContainsKey(memberKey) Then Return [default]
      Return GetBinary(memberKey)
    End Function


    Public Function GetArray(memberKey As String) As JhsArray
      Return DirectCast(Members(memberKey), JhsArray)
    End Function
    Public Function GetObject(memberKey As String) As JhsObject
      Return DirectCast(Members(memberKey), JhsObject)
    End Function

    Public Function GetEnumerator() As IEnumerator(Of KeyValuePair(Of String, JhsValue)) Implements IEnumerable(Of KeyValuePair(Of String, JhsValue)).GetEnumerator
      Return Members.GetEnumerator
    End Function
    Private Function IEnumerable_GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
      Return Members.GetEnumerator
    End Function

  End Class

  Public Class JhsArray
    Inherits JhsValue
    Implements IList(Of JhsValue)

    Public ReadOnly Elements As New List(Of JhsValue)

    Public ReadOnly Property Count As Integer Implements ICollection(Of JhsValue).Count
      Get
        Return Elements.Count
      End Get
    End Property

    Public ReadOnly Property IsReadOnly As Boolean Implements ICollection(Of JhsValue).IsReadOnly
      Get
        Return False
      End Get
    End Property

    Default Public Property Item(index As Integer) As JhsValue Implements IList(Of JhsValue).Item
      Get
        Return Elements(index)
      End Get
      Set(value As JhsValue)
        Elements(index) = value
      End Set
    End Property

    Public Sub Clear() Implements ICollection(Of JhsValue).Clear
      Elements.Clear()
    End Sub

    Public Sub CopyTo(array() As JhsValue, arrayIndex As Integer) Implements ICollection(Of JhsValue).CopyTo
      Elements.CopyTo(array, arrayIndex)
    End Sub

    Public Sub Insert(index As Integer, item As JhsValue) Implements IList(Of JhsValue).Insert
      Elements.Insert(index, item)
    End Sub

    Public Sub RemoveAt(index As Integer) Implements IList(Of JhsValue).RemoveAt
      Elements.RemoveAt(index)
    End Sub

    Public Sub Add(item As JhsValue) Implements ICollection(Of JhsValue).Add
      Elements.Add(item)
    End Sub

    Public Function Contains(item As JhsValue) As Boolean Implements ICollection(Of JhsValue).Contains
      Return Elements.Contains(item)
    End Function

    Public Function GetEnumerator() As IEnumerator(Of JhsValue) Implements IEnumerable(Of JhsValue).GetEnumerator
      Return Elements.GetEnumerator
    End Function
    Private Function IEnumerable_GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
      Return Elements.GetEnumerator
    End Function

    Public Function IndexOf(item As JhsValue) As Integer Implements IList(Of JhsValue).IndexOf
      Return Elements.IndexOf(item)
    End Function

    Public Function Remove(item As JhsValue) As Boolean Implements ICollection(Of JhsValue).Remove
      Return Elements.Remove(item)
    End Function

  End Class

  Public Class JhsString
    Inherits JhsValue

    Public ReadOnly Value As String

    Public Sub New(ByVal value As String)
      Me.Value = value
    End Sub

  End Class

  Public Class JhsDateTime
    Inherits JhsValue

    Public ReadOnly Value As DateTime

    Sub New(value As DateTime)
      Me.Value = value
    End Sub

  End Class

  Friend Class JhsBinary
    Inherits JhsValue
    Friend ReadOnly Value As Byte()
    Sub New(value As Byte())
      Me.Value = value
    End Sub
  End Class


  Public Class JhsInteger
    Inherits JhsValue

    Public ReadOnly Value As Int64

    Public Sub New(ByVal value As Int64)
      Me.Value = value
    End Sub

  End Class

  Public Class JhsFloat
    Inherits JhsValue

    Public ReadOnly Value As Double

    Public Sub New(ByVal value As Double)
      Me.Value = value
    End Sub

  End Class

  Public Class JhsBoolean
    Inherits JhsValue

    Public ReadOnly Value As Boolean

    Sub New(ByVal value As Boolean)
      Me.Value = value
    End Sub

  End Class

  Public Class JhsNull
    Inherits JhsValue

    Private Sub New()
    End Sub

    Public Shared ReadOnly Value As New JhsNull

  End Class

End Class


