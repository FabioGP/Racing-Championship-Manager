Imports System.IO

<Serializable>
Public Class Equipe
    Implements IComparer(Of Equipe)

    Private strNome As String
    Private strPais As String
    Private imgCarro As Image
    Private imgLogo As Image
    Private imgBandeira As Image

    ''' <summary> 
    ''' Nome da Equipe
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
    ''' País da equipe
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Pais() As String
        Get
            Return strPais
        End Get
        Set(value As String)
            strPais = value
        End Set
    End Property

    ''' <summary>
    ''' Foto do carro da equipe
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Carro() As Image
        Get
            Return imgCarro
        End Get
        Set(value As Image)
            imgCarro = value
        End Set
    End Property

    ''' <summary>
    ''' Logo da equipe
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Logo() As Image
        Get
            Return imgLogo
        End Get
        Set(value As Image)
            imgLogo = value
        End Set
    End Property

    ''' <summary>
    ''' Bandeira do país da equipe
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
    ''' Construtor
    ''' </summary>
    ''' <param name="_Nome"></param>
    ''' <param name="_Pais"></param>
    ''' <param name="_Carro"></param>
    ''' <param name="_Logo"></param>
    ''' <param name="_Bandeira"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal _Nome As String, _
                   ByVal _Pais As String, _
                   Optional ByRef _Carro As Image = Nothing, _
                   Optional ByRef _Logo As Image = Nothing, _
                   Optional ByRef _Bandeira As Image = Nothing)
        Nome = _Nome
        Pais = _Pais
        Carro = _Carro
        Logo = _Logo
        Bandeira = _Bandeira
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_CampeonatoPasta"></param>
    ''' <param name="_ListEquipes"></param>
    ''' <param name="_DicPaises"></param>
    ''' <param name="_DicEquipes"></param>
    ''' <remarks></remarks>
    Public Shared Sub Carregar(ByRef _CampeonatoPasta As DirectoryInfo, _
                               ByRef _ListEquipes As List(Of Equipe), _
                               ByRef _DicPaises As Dictionary(Of String, Image), _
                               ByRef _DicEquipes As Dictionary(Of String, Equipe))
        Try
            _DicEquipes = New Dictionary(Of String, Equipe)
            _ListEquipes = New List(Of Equipe)
            _DicEquipes.Clear()
            _ListEquipes.Clear()

            Dim configDir As DirectoryInfo = New DirectoryInfo(_CampeonatoPasta.FullName & "\Equipes")
            For Each tmpEquipeTxtPath As FileInfo In configDir.GetFiles("*.txt")
                Dim dicOfParameters As New Dictionary(Of String, Object)
                Dim newReader As New StreamReader(tmpEquipeTxtPath.FullName, System.Text.Encoding.Default)
                While Not newReader.EndOfStream
                    Dim curLine() As String = Split(newReader.ReadLine(), "=")
                    If curLine.Length = 2 Then
                        dicOfParameters.Add(curLine(0), curLine(1))
                    End If
                    curLine = Nothing
                    newReader.Peek()
                End While
                newReader.Close()
                newReader = Nothing

                Dim newEquipe As Equipe = New Equipe(dicOfParameters("Nome"), _
                                          dicOfParameters("País"), _
                                          Image.FromFile(configDir.FullName & "\Carros\" & dicOfParameters("Nome") & ".png"), _
                                          Image.FromFile(configDir.FullName & "\Logos\" & dicOfParameters("Nome") & ".png"), _
                                          _DicPaises(dicOfParameters("País")))

                _ListEquipes.Add(newEquipe)
                _DicEquipes.Add(newEquipe.Nome, newEquipe)
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
    Public Function Compare(x As Equipe, y As Equipe) As Integer Implements IComparer(Of Equipe).Compare
        Return String.Compare(x.Nome, y.Nome)
    End Function

End Class
