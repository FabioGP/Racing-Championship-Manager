Imports System.IO

Public Class Piloto
    Implements IComparer(Of Piloto)

    Private strNome As String
    Private strPais As String
    Private intIdade As String
    Private strEquipe As String
    Private intNumero As Integer
    Private intPiloto As Integer
    Private strMelhorResultadoEtapa As String
    Private strMelhorResultadoCampeonato As String
    Private intTitulos As Integer
    Private intPoles As Integer
    Private intVitorias As Integer
    Private objEquipe As Equipe
    Private imgCarro As Image
    Private imgLogo As Image
    Private imgBandeira As Image

    ''' <summary> 
    ''' Nome do Piloto
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
    ''' País do Piloto
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
    ''' Idade do Piloto
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Idade() As String
        Get
            Return intIdade
        End Get
        Set(value As String)
            intIdade = value
        End Set
    End Property

    ''' <summary> 
    ''' Equipe do Piloto
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property NomeEquipe() As String
        Get
            Return strEquipe
        End Get
        Set(value As String)
            strEquipe = value
        End Set
    End Property

    ''' <summary>
    ''' Número do Carro do Piloto
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Numero() As Integer
        Get
            Return intNumero
        End Get
        Set(value As Integer)
            intNumero = value
        End Set
    End Property

    ''' <summary>
    ''' Primeiro ou Segundo Piloto
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Piloto() As Integer
        Get
            Return intPiloto
        End Get
        Set(value As Integer)
            intPiloto = value
        End Set
    End Property

    ''' <summary> 
    ''' Melhor Resultado do Piloto em Etapas
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MelhorEtapa() As String
        Get
            Return strMelhorResultadoEtapa
        End Get
        Set(value As String)
            strMelhorResultadoEtapa = value
        End Set
    End Property

    ''' <summary> 
    ''' Melhor Resultado do Piloto em Campeonatos
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MelhorCampeonato() As String
        Get
            Return strMelhorResultadoCampeonato
        End Get
        Set(value As String)
            strMelhorResultadoCampeonato = value
        End Set
    End Property

    ''' <summary>
    ''' Títulos do Piloto
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Titulos() As Integer
        Get
            Return intTitulos
        End Get
        Set(value As Integer)
            intTitulos = value
        End Set
    End Property

    ''' <summary>
    ''' Vitporias do Piloto
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Vitorias() As Integer
        Get
            Return intVitorias
        End Get
        Set(value As Integer)
            intVitorias = value
        End Set
    End Property

    ''' <summary>
    ''' Poles do Piloto
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Poles() As Integer
        Get
            Return intPoles
        End Get
        Set(value As Integer)
            intPoles = value
        End Set
    End Property

    ''' <summary>
    ''' Equipe do Piloto
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Equipe() As Equipe
        Get
            Return objEquipe
        End Get
        Set(value As Equipe)
            objEquipe = value
        End Set
    End Property

    ''' <summary>
    ''' Nacionalidade do Piloto
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
    ''' Carro do Piloto
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
    ''' Logo da Equipe do Piloto
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
    ''' 
    ''' </summary>
    ''' <param name="_Nome"></param>
    ''' <param name="_Pais"></param>
    ''' <param name="_Idade"></param>
    ''' <param name="_NomeEquipe"></param>
    ''' <param name="_Piloto"></param>
    ''' <param name="_MelhorEtapa"></param>
    ''' <param name="_MelhorCampeonato"></param>
    ''' <param name="_Titulos"></param>
    ''' <param name="_Vitorias"></param>
    ''' <param name="_Poles"></param>
    ''' <param name="_Equipe"></param>
    ''' <param name="_Bandeira"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal _Nome As String, _
                   ByVal _Pais As String, _
                   ByVal _Idade As String, _
                   ByVal _NomeEquipe As String, _
                   ByVal _Piloto As Integer, _
                   ByVal _MelhorEtapa As String, _
                   ByVal _MelhorCampeonato As String, _
                   ByVal _Titulos As Integer, _
                   ByVal _Vitorias As Integer, _
                   ByVal _Poles As Integer, _
                   Optional ByRef _Equipe As Equipe = Nothing, _
                   Optional ByRef _Bandeira As Image = Nothing, _
                   Optional ByRef _Carro As Image = Nothing, _
                   Optional ByRef _Logo As Image = Nothing)
        Nome = _Nome
        Pais = _Pais
        Idade = _Idade
        NomeEquipe = _NomeEquipe
        Piloto = _Piloto
        MelhorEtapa = _MelhorEtapa
        MelhorCampeonato = _MelhorCampeonato
        Titulos = _Titulos
        Vitorias = _Vitorias
        Poles = _Poles
        Equipe = _Equipe
        Bandeira = _Bandeira
        Carro = _Carro
        Logo = _Logo
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_CampeonatoPasta"></param>
    ''' <param name="_ListPilotos"></param>
    ''' <param name="_DicPaises"></param>
    ''' <param name="_DicEquipes"></param>
    ''' <param name="_DicPilotos"></param>
    ''' <param name="_DicResultadosPilotos"></param>
    ''' <remarks></remarks>
    Public Shared Sub Carregar(ByRef _CampeonatoPasta As DirectoryInfo, _
                               ByRef _ListPilotos As List(Of Piloto), _
                               ByRef _DicPaises As Dictionary(Of String, Image),
                               ByRef _DicEquipes As Dictionary(Of String, Equipe), _
                               ByRef _DicPilotos As Dictionary(Of String, Piloto), _
                               ByRef _DicResultadosPilotos As Dictionary(Of String, Piloto))
        Try
            _DicPilotos = New Dictionary(Of String, Piloto)
            _DicResultadosPilotos = New Dictionary(Of String, Piloto)
            _ListPilotos = New List(Of Piloto)
            _DicPilotos.Clear()
            _DicResultadosPilotos.Clear()
            _ListPilotos.Clear()

            Dim configDir As DirectoryInfo = New DirectoryInfo(_CampeonatoPasta.FullName & "\Pilotos")
            For Each tmpPilotoTxtPath As FileInfo In configDir.GetFiles("*.txt")
                Dim dicOfParameters As New Dictionary(Of String, Object)
                Dim newReader As New StreamReader(tmpPilotoTxtPath.FullName, System.Text.Encoding.Default)
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

                Dim newPiloto As Piloto = New Piloto(dicOfParameters("Nome"), _
                                          dicOfParameters("País"), _
                                          dicOfParameters("Idade"), _
                                          dicOfParameters("Equipe"), _
                                          CInt(dicOfParameters("Piloto")), _
                                          dicOfParameters("MelhorResultadoEtapa"), _
                                          dicOfParameters("MelhorResultadoCampeonato"), _
                                          CInt(dicOfParameters("Títulos")), _
                                          CInt(dicOfParameters("Vitórias")), _
                                          CInt(dicOfParameters("Poles")), _
                                          _DicEquipes(dicOfParameters("Equipe")), _
                                          _DicPaises(dicOfParameters("País")), _
                                          DirectCast(_DicEquipes(dicOfParameters("Equipe")), Equipe).Carro, _
                                          DirectCast(_DicEquipes(dicOfParameters("Equipe")), Equipe).Logo)

                _ListPilotos.Add(newPiloto)
                _DicPilotos.Add(newPiloto.Nome, newPiloto)
                _DicResultadosPilotos.Add(Replace(tmpPilotoTxtPath.Name, ".txt", ""), newPiloto)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Compare function to sort by Equipe Name
    ''' </summary>
    ''' <param name="x"></param>
    ''' <param name="y"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Compare(ByVal x As Piloto, ByVal y As Piloto) As Integer Implements System.Collections.Generic.IComparer(Of Piloto).Compare
        Return String.Compare(x.NomeEquipe, y.NomeEquipe)
    End Function

End Class
