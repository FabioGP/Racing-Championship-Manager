Public Class ResultadoEquipe
  Implements IComparer(Of ResultadoEquipe)

  'Objetos da Classe
  Private intPosicao As Integer = 0
  Private objEquipe As Equipe = Nothing
  Private intPontos As Integer = 0
  Private intVitorias As Integer = 0
  Private intPoles As Integer = 0
  Private intCriterio As Integer = 0

  'Objetos para o GridView
  Private imgGridBandeira As Image = Nothing
  Private strGridEquipeNome As String = String.Empty
  Private imgGridLogo As Image = Nothing
  Private imgGridCarro As Image = Nothing

  ''' <summary>
  ''' Posicao da Equipe no Campeonato
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Property Posicao As Integer
    Get
      Return intPosicao
    End Get
    Set(value As Integer)
      intPosicao = value
    End Set
  End Property

  ''' <summary>
  ''' Equipe
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
  ''' Pontos da Posicao
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Property Pontos As Integer
    Get
      Return intPontos
    End Get
    Set(value As Integer)
      intPontos = value
    End Set
  End Property

  ''' <summary>
  ''' Número de Poles da Equipe
  ''' </summary>
  ''' <returns></returns>
  Public ReadOnly Property Poles As Integer
    Get
      Return Equipe.Poles
    End Get
  End Property

  ''' <summary>
  ''' Número de Vitorias da Equipe
  ''' </summary>
  ''' <returns></returns>
  Public ReadOnly Property Vitorias As Integer
    Get
      Return Equipe.Vitorias
    End Get
  End Property

  ''' <summary>
  ''' Critério de Desempate
  ''' </summary>
  ''' <returns></returns>
  Public ReadOnly Property Criterio As Integer
    Get
      Return Equipe.Criterio
    End Get
  End Property

  ''' <summary>
  ''' Nacionalidade da Equipe
  ''' </summary>
  ''' <value></value>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Property GridEquipePais As Image
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
  ''' 
  ''' </summary>
  ''' <param name="_Equipe"></param>
  ''' <remarks></remarks>
  Public Sub New(ByRef _Equipe As Equipe, ByVal _Pontos As Integer)
    Equipe = _Equipe
    GridEquipePais = _Equipe.Bandeira
    GridEquipeCarro = _Equipe.Carro
    GridEquipeLogo = _Equipe.Logo
    GridEquipeNome = _Equipe.Nome
    Pontos = _Pontos
    Posicao = -1
  End Sub

  ''' <summary>
  ''' 
  ''' </summary>
  ''' <param name="x"></param>
  ''' <param name="y"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Function Compare(x As ResultadoEquipe, y As ResultadoEquipe) As Integer Implements IComparer(Of ResultadoEquipe).Compare
    Return String.Compare(x.Equipe.Nome, y.Equipe.Nome)
  End Function

End Class
