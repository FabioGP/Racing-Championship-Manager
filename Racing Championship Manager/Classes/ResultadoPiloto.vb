Public Class ResultadoPiloto
  Implements IComparer(Of ResultadoPiloto)

  'Objetos da Classe
  Private intPosicao As Integer = 0
  Private objPiloto As Piloto = Nothing
  Private objEquipe As Equipe = Nothing
  Private intPontos As Integer = 0
  Private intVitorias As Integer = 0
  Private intPoles As Integer = 0
  Private intCriterio As Integer = 0

  'Objetos para o GridView
  Private strGridPilotoNome As String = String.Empty
  Private strGridNumero As String = ""
  Private imgGridBandeira As Image = Nothing
  Private strGridEquipeNome As String = String.Empty
  Private imgGridLogo As Image = Nothing
  Private imgGridCarro As Image = Nothing
  Private imgGridSkinPiloto As Image = Nothing

  ''' <summary>
  ''' Posicao do Piloto no Campeonato
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
  ''' Piloto
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
  ''' Número de Poles do Piloto
  ''' </summary>
  ''' <returns></returns>
  Public ReadOnly Property Poles As Integer
    Get
      Return Piloto.Poles
    End Get
  End Property

  ''' <summary>
  ''' Número de Vitorias do Piloto
  ''' </summary>
  ''' <returns></returns>
  Public ReadOnly Property Vitorias As Integer
    Get
      Return Piloto.Vitorias
    End Get
  End Property

  ''' <summary>
  ''' Critério de Desempate
  ''' </summary>
  ''' <returns></returns>
  Public ReadOnly Property Criterio As Integer
    Get
      Return Piloto.Criterio
    End Get
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
  Public Property GridPilotoNumero As String
    Get
      Return strGridNumero
    End Get
    Set(value As String)
      strGridNumero = value
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
  ''' Skin do Piloto
  ''' </summary>
  ''' <returns></returns>
  Public Property GridSkinPiloto As Image
    Get
      Return imgGridSkinPiloto
    End Get
    Set(value As Image)
      imgGridSkinPiloto = value
    End Set
  End Property

  ''' <summary>
  ''' 
  ''' </summary>
  ''' <param name="_Piloto"></param>
  ''' <param name="_Equipe"></param>
  ''' <remarks></remarks>
  Public Sub New(ByRef _Piloto As Piloto,
                 ByRef _Equipe As Equipe,
                 ByVal _Pontos As Integer)
    Piloto = _Piloto
    Equipe = _Equipe
    GridPilotoNome = _Piloto.Nome
    GridPilotoNumero = _Piloto.Numero
    GridPilotoPais = _Piloto.Bandeira
    GridEquipeCarro = _Equipe.Carro
    GridEquipeLogo = _Equipe.Logo
    GridEquipeNome = _Equipe.Nome
    GridSkinPiloto = _Piloto.Skin
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
  Public Function Compare(x As ResultadoPiloto, y As ResultadoPiloto) As Integer Implements IComparer(Of ResultadoPiloto).Compare
    Return String.Compare(x.Piloto.Nome, y.Piloto.Nome)
  End Function

End Class
