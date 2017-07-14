Public Class ResultadoEtapa
    Implements IComparer(Of ResultadoEtapa)

    'Objetos da Classe
    Private intPosicaoGrid As Integer = 0
    Private intPosicaoEtapa As Integer = 0
    Private objEtapa As Etapa = Nothing
    Private objPiloto As Piloto = Nothing
    Private objEquipe As Equipe = Nothing
    Private strNomeArquivo As String = String.Empty
    Private timTomada As TimeSpan = Nothing
    Private timMelhorVoltaClassificacao As TimeSpan = Nothing
    Private timMelhorVoltaCorrida As TimeSpan = Nothing
    Private timGapMelhorVolta As TimeSpan = Nothing
    Private timGapLider As TimeSpan = Nothing
    Private timGapFrente As TimeSpan = Nothing
    Private boolClassificacaoEnviada As Boolean = False
    Private boolCorridaEnviada As Boolean = False
    Private intPontosGrid As Integer = 0
    Private intPontoAproximacao As Integer = 0
    Private intPontosDeadLine1 As Integer = 0
    Private intPontosPosicao As Integer = 0
    Private intPontosTotais As Integer = 0
    Private intPunicaoClassificacao As Integer = 0
    Private intPunicaoCorrida As Integer = 0

    'Objetos para o GridView
    Private strGridPilotoNome As String = String.Empty
    Private intGridNumero As Integer = 0
    Private imgGridBandeira As Image = Nothing
    Private strGridEquipeNome As String = String.Empty
    Private imgGridLogo As Image = Nothing
    Private imgGridCarro As Image = Nothing

    ''' <summary>
    ''' Posicao do Piloto no Grid
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PosicaoGrid As Integer
        Get
            Return intPosicaoGrid
        End Get
        Set(value As Integer)
            intPosicaoGrid = value
        End Set
    End Property

    ''' <summary>
    ''' Posicao do Piloto na Etapa
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PosicaoEtapa As Integer
        Get
            Return intPosicaoEtapa
        End Get
        Set(value As Integer)
            intPosicaoEtapa = value
        End Set
    End Property

    ''' <summary>
    ''' Etapa do Resultado
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Etapa As Etapa
        Get
            Return objEtapa
        End Get
        Set(value As Etapa)
            objEtapa = value
        End Set
    End Property

    ''' <summary>
    ''' Piloto do Resultado
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Piloto As Piloto
        Get
            Return objPiloto
        End Get
        Set(value As Piloto)
            objPiloto = value
        End Set
    End Property

    ''' <summary>
    ''' Equipe do Resultado
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Equipe As Equipe
        Get
            Return objEquipe
        End Get
        Set(value As Equipe)
            objEquipe = value
        End Set
    End Property

    ''' <summary>
    ''' Tempo da Tomada
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Tomada As TimeSpan
        Get
            Return timTomada
        End Get
        Set(value As TimeSpan)
            timTomada = value
        End Set
    End Property

    ''' <summary>
    ''' Tempo da Melhor Volta da Classificacao
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MelhorVoltaClassificacao As TimeSpan
        Get
            Return timMelhorVoltaClassificacao
        End Get
        Set(value As TimeSpan)
            timMelhorVoltaClassificacao = value
        End Set
    End Property

    ''' <summary>
    ''' Tempo da Melhor Volta da Corrida
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MelhorVoltaCorrida As TimeSpan
        Get
            Return timMelhorVoltaCorrida
        End Get
        Set(value As TimeSpan)
            timMelhorVoltaCorrida = value
        End Set
    End Property

    ''' <summary>
    ''' Gap para o líder (distância)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property GapLider As TimeSpan
        Get
            Return timGapLider
        End Get
        Set(value As TimeSpan)
            timGapLider = value
        End Set
    End Property

    ''' <summary>
    ''' Gap para a melhor volta (distância)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property GapMelhorVolta As TimeSpan
        Get
            Return timGapMelhorVolta
        End Get
        Set(value As TimeSpan)
            timGapMelhorVolta = value
        End Set
    End Property

    ''' <summary>
    ''' Gap para o carro da frente (distância)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property GapFrente As TimeSpan
        Get
            Return timGapFrente
        End Get
        Set(value As TimeSpan)
            timGapFrente = value
        End Set
    End Property

    ''' <summary>
    ''' Nome do Arquivo do Piloto
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property NomeArquivo As String
        Get
            Return strNomeArquivo
        End Get
        Set(value As String)
            strNomeArquivo = value
        End Set
    End Property

    ''' <summary>
    ''' Pontos da Posicao
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PontosPosicao As Integer
        Get
            Return intPontosPosicao
        End Get
        Set(value As Integer)
            intPontosPosicao = value
        End Set
    End Property

    ''' <summary>
    ''' Salva se o tempo de classifcacao foi entregue
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ClassificacaoEnviada As Boolean
        Get
            Return boolClassificacaoEnviada
        End Get
        Set(value As Boolean)
            boolClassificacaoEnviada = value
        End Set
    End Property

    ''' <summary>
    ''' Salva se o tempo de corrida foi entregue
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CorridaEnviada As Boolean
        Get
            Return boolCorridaEnviada
        End Get
        Set(value As Boolean)
            boolCorridaEnviada = value
        End Set
    End Property

    ''' <summary>
    ''' Determina se o piloto teve ponto(s) extra(s) pelo deadline 1
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PontosDeadLine1 As Integer
        Get
            Return intPontosDeadLine1
        End Get
        Set(value As Integer)
            intPontosDeadLine1 = value
        End Set
    End Property

    ''' <summary>
    ''' Determina quantos pontos o piloto teve pela classificação
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PontosGrid As Integer
        Get
            Return intPontosGrid
        End Get
        Set(value As Integer)
            intPontosGrid = value
        End Set
    End Property

    ''' <summary>
    ''' Determina se o piloto teve ponto(s) extra(s) pela aproximação do tempo da pole
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PontosAproximacao As Integer
        Get
            Return intPontoAproximacao
        End Get
        Set(value As Integer)
            intPontoAproximacao = value
        End Set
    End Property

    ''' <summary>
    ''' Pontos totais da etapa
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PontosTotais As Integer
        Get
            Return intPontosTotais
        End Get
        Set(value As Integer)
            intPontosTotais = value
        End Set
    End Property

    ''' <summary>
    ''' Segundos de Punição na Classificacao
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PunicaoClassificacao As Integer
        Get
            Return intPunicaoClassificacao
        End Get
        Set(value As Integer)
            intPunicaoClassificacao = value
        End Set
    End Property

    ''' <summary>
    ''' Segundos de Punição na Corrida
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PunicaoCorrida As Integer
        Get
            Return intPunicaoCorrida
        End Get
        Set(value As Integer)
            intPunicaoCorrida = value
        End Set
    End Property

    ''' <summary>
    ''' Nome do Piloto
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property GridPilotoNome As String
        Get
            Return strGridPilotoNome
        End Get
        Set(value As String)
            strGridPilotoNome = value
        End Set
    End Property

    ''' <summary>
    ''' Numero do Piloto
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property GridPilotoNumero As Integer
        Get
            Return intGridNumero
        End Get
        Set(value As Integer)
            intGridNumero = value
        End Set
    End Property

    ''' <summary>
    ''' Nacionalidade do Piloto
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property GridPilotoPais As Image
        Get
            Return imgGridBandeira
        End Get
        Set(value As Image)
            imgGridBandeira = value
        End Set
    End Property

    ''' <summary>
    ''' Equipe do Piloto
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property GridEquipeNome As String
        Get
            Return strGridEquipeNome
        End Get
        Set(value As String)
            strGridEquipeNome = value
        End Set
    End Property

    ''' <summary>
    ''' Imagem do Logo da Equipe
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property GridEquipeLogo As Image
        Get
            Return imgGridLogo
        End Get
        Set(value As Image)
            imgGridLogo = value
        End Set
    End Property

    ''' <summary>
    ''' Imagem do Carro da Equipe
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property GridEquipeCarro As Image
        Get
            Return imgGridCarro
        End Get
        Set(value As Image)
            imgGridCarro = value
        End Set
    End Property

    ''' <summary>
    ''' Texto que mostra a punição da classificacao
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property TextoPunicaoClassificacao As String
        Get
            If PunicaoClassificacao = 0 Then
                Return "---"
            Else
                Return "+" & PunicaoClassificacao & " [s]"
            End If

        End Get
    End Property

    ''' <summary>
    ''' Texto que mostra a punição da corrida
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property TextoPunicaoCorrida As String
        Get
            If PunicaoCorrida = 0 Then
                Return "---"
            Else
                Return "+" & PunicaoCorrida & " [s]"
            End If

        End Get
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_Piloto"></param>
    ''' <param name="_Etapa"></param>
    ''' <param name="_Equipe"></param>
    ''' <param name="_Tomada"></param>
    ''' <param name="_MelhorVoltaClassifcacao"></param>
    ''' <param name="_MelhorVoltaCorrida"></param>
    ''' <param name="_NomeArquivo"></param>
    ''' <remarks></remarks>
    Public Sub New(ByRef _Piloto As Piloto, _
                   ByRef _Etapa As Etapa, _
                   ByRef _Equipe As Equipe, _
                   Optional ByVal _Tomada As TimeSpan = Nothing, _
                   Optional ByVal _MelhorVoltaClassifcacao As TimeSpan = Nothing, _
                   Optional ByVal _MelhorVoltaCorrida As TimeSpan = Nothing, _
                   Optional ByVal _NomeArquivo As String = "")
        Etapa = _Etapa
        Piloto = _Piloto
        Equipe = _Equipe
        Tomada = _Tomada
        MelhorVoltaClassificacao = _MelhorVoltaClassifcacao
        MelhorVoltaCorrida = _MelhorVoltaCorrida
        NomeArquivo = _NomeArquivo
        GridPilotoNome = _Piloto.Nome
        GridPilotoNumero = _Piloto.Numero
        GridPilotoPais = _Piloto.Bandeira
        GridEquipeCarro = _Equipe.Carro
        GridEquipeLogo = _Equipe.Logo
        GridEquipeNome = _Equipe.Nome
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="x"></param>
    ''' <param name="y"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Compare(x As ResultadoEtapa, y As ResultadoEtapa) As Integer Implements IComparer(Of ResultadoEtapa).Compare
        Return String.Compare(x.Piloto.Nome, y.Piloto.Nome)
    End Function

End Class
