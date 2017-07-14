Imports System.IO

Public Class Pais
    Implements IComparer(Of Pais)

    Private strNome As String
    Private imgBandeira As Image

    ''' <summary>
    ''' Nome do País
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Nome() As String
        Get
            Return strNome
        End Get
        Set(value As String)
            strNome = value
        End Set
    End Property

    ''' <summary>
    ''' Bandeira do País
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Bandeira() As Image
        Get
            Return imgBandeira
        End Get
        Set(value As Image)
            imgBandeira = value
        End Set
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_Nome"></param>
    ''' <param name="_Bandeira"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal _Nome As String, _
                   Optional ByRef _Bandeira As Image = Nothing)
        Nome = _Nome
        Bandeira = _Bandeira
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_ListPaises"></param>
    ''' <param name="_DicPaises"></param>
    ''' <remarks></remarks>
    Public Shared Sub Carregar(ByRef _ListPaises As List(Of Pais), _
                               ByRef _DicPaises As Dictionary(Of String, Image))
        Try
            _ListPaises = New List(Of Pais)
            _ListPaises.Clear()
            _DicPaises = New Dictionary(Of String, Image)
            Dim configDir As DirectoryInfo = New DirectoryInfo(Application.StartupPath & "\Bandeiras")
            For Each tmpBandeiraPngPath As FileInfo In configDir.GetFiles("*.png")
                _ListPaises.Add(New Pais(Replace(tmpBandeiraPngPath.Name, ".png", ""), Image.FromFile(tmpBandeiraPngPath.FullName)))
                _DicPaises.Add(Replace(tmpBandeiraPngPath.Name, ".png", ""), Image.FromFile(tmpBandeiraPngPath.FullName))
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="x"></param>
    ''' <param name="y"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Compare(x As Pais, y As Pais) As Integer Implements IComparer(Of Pais).Compare
        Return String.Compare(x.Nome, y.Nome)
    End Function

End Class
