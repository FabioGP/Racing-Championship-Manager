Imports System.IO

Public Class MainForm

  'Variáveis para controle de movimentação do form
  Const WM_NCHITTEST As Integer = &H84
  Const HTCLIENT As Integer = &H1
  Const HTCAPTION As Integer = &H2

  'Listas de Objetos
  Public listEquipes As List(Of Equipe)
  Public listPilotos As List(Of Piloto)
  Public listEtapas As List(Of Etapa)
  Public listPaises As List(Of Pais)
  Public listMundialPilotos As List(Of ResultadoPiloto)
  Public listMundialConstrutores As List(Of ResultadoEquipe)

  'Configuração de Diretórios
  Public dirCampeonato As DirectoryInfo = Nothing
  Public dirCampeonatoEquipes As DirectoryInfo = Nothing
  Public dirCampeonatoPilotos As DirectoryInfo = Nothing
  Public dirCampeonatoEtapas As DirectoryInfo = Nothing

  'Dicionários para Auxílio
  Public dicPaises As Dictionary(Of String, Image)
  Public dicMenuEtapas As Dictionary(Of String, Etapa)
  Public dicEtapas As Dictionary(Of String, Etapa)
  Public dicEquipes As Dictionary(Of String, Equipe)
  Public dicPilotos As Dictionary(Of String, Piloto)
  Public dicResultadosPilotos As Dictionary(Of String, Piloto)
  Public dicPontos As Dictionary(Of String, Integer)
  Public dicPontosAproximacaoClassificacao As Dictionary(Of TimeSpan, Integer)

  ''' <summary>
  ''' Função para permitir movimentar o form quando clica e arrasta
  ''' </summary>
  ''' <param name="m"></param>
  ''' <remarks></remarks>
  Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
    Select Case m.Msg
      Case WM_NCHITTEST
        MyBase.WndProc(m)
        If m.Result = IntPtr.op_Explicit(HTCLIENT) Then m.Result = IntPtr.op_Explicit(HTCAPTION)
      Case Else
        MyBase.WndProc(m)
    End Select
  End Sub

  ''' <summary>
  ''' Carregamento do MainForm
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  ''' <remarks></remarks>
  Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles Me.Load
    Try
      dtGridView.DataSource = Nothing
      dtGridView.Columns.Clear()

      Pais.Carregar(listPaises, dicPaises)
      Dim novoSelecaoUsuario As New ChampionshipOptionForm()
      novoSelecaoUsuario.ShowDialog()

      If novoSelecaoUsuario.boolCreate Then
        CriarCampeonato()
      End If

      If novoSelecaoUsuario.boolLoad Then
        CarregarCampeonato()
      End If

      imgTitle.Image = Nothing
      lblTitle.Text = ""
      lblDescription.Text = ""

    Catch ex As Exception
      MessageBox.Show(ex.Message)
    End Try
  End Sub

  ''' <summary>
  ''' Carrega um campeonato existente
  ''' </summary>
  ''' <remarks></remarks>
  Private Sub CarregarCampeonato()
    Try
      If dirCampeonato Is Nothing Then
        'Devemos deixar o usuario selecionar o campeonato
        Dim novoCampeonatoUsuario As New ChampionshipSelectForm()
        novoCampeonatoUsuario.ShowDialog()

        'Salvar os diretórios
        dirCampeonato = novoCampeonatoUsuario.dirCampeonatoPasta
        dirCampeonatoEquipes = novoCampeonatoUsuario.dirCampeonatoEquipes
        dirCampeonatoEtapas = novoCampeonatoUsuario.dirCampeonatoEtapas
        dirCampeonatoPilotos = novoCampeonatoUsuario.dirCampeonatoPilotos
      End If

      'Carregar a pontuação do campeonato
      CarregarPontuacao(dirCampeonato)

      'Carregar as Equipes
      Equipe.Carregar(dirCampeonato, listEquipes, dicPaises, dicEquipes)

      'Carregar os Pilotos
      Piloto.Carregar(dirCampeonato, listPilotos, dicPaises, dicEquipes, dicPilotos, dicResultadosPilotos)
      dtGridView.RowTemplate.Height = (dtGridView.Size.Height / listPilotos.Count) - 2

      'Carregar as Etapas
      Etapa.Carregar(dirCampeonato, listEtapas, dicPaises, dicEtapas, listPilotos)

      'Carrega o resultado das Etapas
      Etapa.CompilarResultadosEtapas(dirCampeonato, listEtapas, dicResultadosPilotos, dicPontos, dicPontosAproximacaoClassificacao)

      'Calcula a pontuacao de construtores e pilotos
      ComputarPontuacaoCampeonato()

      'Montamos o menu das etapas
      MontarMenuEtapas()

    Catch ex As Exception
      MessageBox.Show(ex.Message)
    End Try
  End Sub

  ''' <summary>
  ''' Monta o menu das etapas
  ''' </summary>
  ''' <remarks></remarks>
  Private Sub MontarMenuEtapas()
    Try
      'Montar o menu das etapas
      Dim theMainMenuEtapas As ToolStripMenuItem = mainMenu.Items("mnuEtapas")
      theMainMenuEtapas.DropDownItems.Clear()

      'Montaremos o dicionário que relaciona o item do menu a etapa
      dicMenuEtapas = New Dictionary(Of String, Etapa)
      dicMenuEtapas.Clear()

      For Each tmpEtapa As Etapa In listEtapas

        'Criamos o Botão da Etapa
        Dim newEtapaMenuName As String = "mnuEtapa" & tmpEtapa.Etapa.ToString("00")
        Dim newEtapaItem As ToolStripMenuItem = New ToolStripMenuItem()
        newEtapaItem.Name = newEtapaMenuName
        newEtapaItem.Image = tmpEtapa.Pais
        newEtapaItem.Text = tmpEtapa.Etapa.ToString("00") & " - " & tmpEtapa.NomeCircuito
        theMainMenuEtapas.DropDownItems.Add(newEtapaItem)

        'Criamos o Botão do Grid da Etapa
        Dim newEtapaGridName As String = newEtapaMenuName & "Grid"
        Dim newEtapaGridItem As ToolStripMenuItem = New ToolStripMenuItem()
        newEtapaGridItem.Name = newEtapaGridName
        newEtapaGridItem.Image = My.Resources.Timer
        newEtapaGridItem.Text = "Grid de Largada"
        newEtapaItem.DropDownItems.Add(newEtapaGridItem)
        AddHandler newEtapaGridItem.Click, AddressOf mnuEtapaGrid_Click
        dicMenuEtapas.Add(newEtapaGridItem.Name, tmpEtapa)

        'Criamos o Botão do Grid da Etapa
        Dim newEtapaResultadoName As String = newEtapaMenuName & "Resultado"
        Dim newEtapaResultadoItem As ToolStripMenuItem = New ToolStripMenuItem()
        newEtapaResultadoItem.Name = newEtapaGridName
        newEtapaResultadoItem.Image = My.Resources.FinishFlag
        newEtapaResultadoItem.Text = "Resultados"
        newEtapaItem.DropDownItems.Add(newEtapaResultadoItem)
        AddHandler newEtapaResultadoItem.Click, AddressOf mnuEtapaResultado_Click
        dicMenuEtapas.Add(newEtapaItem.Name, tmpEtapa)

        'Limpamos nossas variáveis
        newEtapaItem = Nothing
        newEtapaGridItem = Nothing
        newEtapaResultadoItem = Nothing
      Next
    Catch ex As Exception
      MessageBox.Show(ex.Message)
    End Try
  End Sub

  ''' <summary>
  ''' Cria um novo campeonato
  ''' </summary>
  ''' <remarks></remarks>
  Private Sub CriarCampeonato()
    Try

    Catch ex As Exception
      MessageBox.Show(ex.Message)
    End Try
  End Sub

  ''' <summary>
  ''' Mostra a tabela de equipes do campeonato
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  ''' <remarks></remarks>
  Private Sub mnuEquipes_Click(sender As Object, e As EventArgs) Handles mnuEquipes.Click
    Try
      imgTitle.Image = My.Resources.Equipes
      lblTitle.Text = "Tabela de Equipes"
      lblDescription.Text = dirCampeonato.Name

      listEquipes = listEquipes.OrderBy(Function(equipe) equipe.Nome).ToList()
      dtGridView.DataSource = listEquipes
      FormatarDataGridViewParaEquipes()
      dtGridView.Refresh()
    Catch ex As Exception
      MessageBox.Show(ex.Message)
    End Try
  End Sub

  ''' <summary>
  ''' Mostra o calendário do campeonato, com as etapas e configurações definidas
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  ''' <remarks></remarks>
  Private Sub mnuCalendario_Click(sender As Object, e As EventArgs) Handles mnuCalendario.Click
    Try
      imgTitle.Image = My.Resources.Circuitos
      lblTitle.Text = "Calendário"
      lblDescription.Text = dirCampeonato.Name

      listEtapas = listEtapas.OrderBy(Function(etapa) etapa.Etapa).ToList()
      dtGridView.DataSource = listEtapas
      FormatarDataGridViewParaEtapas()
      dtGridView.Refresh()
    Catch ex As Exception
      MessageBox.Show(ex.Message)
    End Try
  End Sub

  ''' <summary>
  ''' Mostra os resultados da etapa em questão
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  ''' <remarks></remarks>
  Private Sub mnuEtapaGrid_Click(sender As Object, e As EventArgs)
    Try
      Dim mnuItem As ToolStripMenuItem = DirectCast(sender, ToolStripMenuItem)
      If mnuItem Is Nothing Then
        Exit Sub
      End If

      Dim curEtapa As Etapa = dicMenuEtapas(mnuItem.Name)
      If curEtapa Is Nothing Then
        Exit Sub
      End If

      imgTitle.Image = curEtapa.Pais
      lblTitle.Text = curEtapa.NomeCircuito
      lblDescription.Text = dirCampeonato.Name

      curEtapa.Resultados = curEtapa.Resultados.OrderBy(Function(resultadoEtapa) resultadoEtapa.PosicaoGrid).ToList()
      dtGridView.DataSource = curEtapa.Resultados
      FormatarDataGridViewParaEtapaGrid()
      dtGridView.Refresh()
      curEtapa = Nothing
    Catch ex As Exception
      MessageBox.Show(ex.Message)
    End Try
  End Sub

  ''' <summary>
  ''' Mostra os resultados da etapa em questão
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  ''' <remarks></remarks>
  Private Sub mnuEtapaResultado_Click(sender As Object, e As EventArgs)
    Try
      Dim mnuItem As ToolStripMenuItem = DirectCast(sender, ToolStripMenuItem)
      If mnuItem Is Nothing Then
        Exit Sub
      End If

      Dim curEtapa As Etapa = dicMenuEtapas(mnuItem.Name)
      If curEtapa Is Nothing Then
        Exit Sub
      End If

      imgTitle.Image = curEtapa.Pais
      lblTitle.Text = curEtapa.NomeCircuito
      lblDescription.Text = dirCampeonato.Name

      curEtapa.Resultados = curEtapa.Resultados.OrderBy(Function(resultadoEtapa) resultadoEtapa.PosicaoEtapa).ToList()
      dtGridView.DataSource = curEtapa.Resultados
      FormatarDataGridViewParaEtapaResultados()
      dtGridView.Refresh()
      curEtapa = Nothing
    Catch ex As Exception
      MessageBox.Show(ex.Message)
    End Try
  End Sub

  ''' <summary>
  ''' Pilotos Ordenados Por Nome
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  ''' <remarks></remarks>
  Private Sub mnuPilotosPorNome_Click(sender As Object, e As EventArgs) Handles mnuPilotosPorNome.Click
    Try
      imgTitle.Image = My.Resources.Pilotos
      lblTitle.Text = "Tabela de Pilotos"
      lblDescription.Text = dirCampeonato.Name

      listPilotos = listPilotos.OrderBy(Function(piloto) piloto.Nome).ToList()
      dtGridView.DataSource = listPilotos
      FormatarDataGridViewParaPilotos()
      dtGridView.Refresh()
    Catch ex As Exception
      MessageBox.Show(ex.Message)
    End Try
  End Sub

  ''' <summary>
  ''' Pilotos Ordenados Por Equipe
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  ''' <remarks></remarks>
  Private Sub mnuPilotosPorEquipe_Click(sender As Object, e As EventArgs) Handles mnuPilotosPorEquipe.Click
    Try
      imgTitle.Image = My.Resources.Pilotos
      lblTitle.Text = "Tabela de Pilotos"
      lblDescription.Text = dirCampeonato.Name

      listPilotos = listPilotos.OrderBy(Function(piloto) piloto.NomeEquipe).ThenBy(Function(piloto) piloto.Piloto).ToList()
      dtGridView.DataSource = listPilotos
      FormatarDataGridViewParaPilotos()
      dtGridView.Refresh()
    Catch ex As Exception
      MessageBox.Show(ex.Message)
    End Try
  End Sub

  ''' <summary>
  ''' Pilotos Ordenados Por Titulos
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  ''' <remarks></remarks>
  Private Sub mnuPilotosPorTitulos_Click(sender As Object, e As EventArgs) Handles mnuPilotosPorTitulos.Click
    Try
      imgTitle.Image = My.Resources.Pilotos
      lblTitle.Text = "Tabela de Pilotos"
      lblDescription.Text = dirCampeonato.Name

      listPilotos = listPilotos.OrderByDescending(Function(piloto) piloto.Titulos).ToList()
      dtGridView.DataSource = listPilotos
      FormatarDataGridViewParaPilotos()
      dtGridView.Refresh()
    Catch ex As Exception
      MessageBox.Show(ex.Message)
    End Try
  End Sub

  ''' <summary>
  ''' Pilotos Ordenados Por Vitórias
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  ''' <remarks></remarks>
  Private Sub mnuPilotosPorVitorias_Click(sender As Object, e As EventArgs) Handles mnuPilotosPorVitorias.Click
    Try
      imgTitle.Image = My.Resources.Pilotos
      lblTitle.Text = "Tabela de Pilotos"
      lblDescription.Text = dirCampeonato.Name

      listPilotos = listPilotos.OrderByDescending(Function(piloto) piloto.Vitorias).ToList()
      dtGridView.DataSource = listPilotos
      FormatarDataGridViewParaPilotos()
      dtGridView.Refresh()
    Catch ex As Exception
      MessageBox.Show(ex.Message)
    End Try
  End Sub

  ''' <summary>
  ''' Pilotos Ordenados Por Poles
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  ''' <remarks></remarks>
  Private Sub mnuPilotosPorPole_Click(sender As Object, e As EventArgs) Handles mnuPilotosPorPole.Click
    Try
      imgTitle.Image = My.Resources.Pilotos
      lblTitle.Text = "Tabela de Pilotos"
      lblDescription.Text = dirCampeonato.Name

      listPilotos = listPilotos.OrderByDescending(Function(piloto) piloto.Poles).ToList()
      dtGridView.DataSource = listPilotos
      FormatarDataGridViewParaPilotos()
      dtGridView.Refresh()
    Catch ex As Exception
      MessageBox.Show(ex.Message)
    End Try
  End Sub

  ''' <summary>
  ''' Pilotos Ordenados Por Idade
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  ''' <remarks></remarks>
  Private Sub mnuPilotosPorIdade_Click(sender As Object, e As EventArgs) Handles mnuPilotosPorIdade.Click
    Try
      imgTitle.Image = My.Resources.Pilotos
      lblTitle.Text = "Tabela de Pilotos"
      lblDescription.Text = dirCampeonato.Name

      listPilotos = listPilotos.OrderByDescending(Function(piloto) piloto.Idade).ToList()
      dtGridView.DataSource = listPilotos
      FormatarDataGridViewParaPilotos()
      dtGridView.Refresh()
    Catch ex As Exception
      MessageBox.Show(ex.Message)
    End Try
  End Sub

  ''' <summary>
  ''' Mostra a classificação do mundial de pilotos
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  ''' <remarks></remarks>
  Private Sub mnuMundialPilotos_Click(sender As Object, e As EventArgs) Handles mnuMundialPilotos.Click
    Try
      imgTitle.Image = My.Resources.Campeonato
      lblTitle.Text = "Mundial de Pilotos"
      lblDescription.Text = dirCampeonato.Name

      listMundialPilotos = listMundialPilotos.OrderBy(Function(resultPiloto) resultPiloto.Posicao).ToList()
      dtGridView.DataSource = listMundialPilotos
      FormatarDataGridViewParaMundialPilotos()
      dtGridView.Refresh()
    Catch ex As Exception
      MessageBox.Show(ex.Message)
    End Try
  End Sub

  ''' <summary>
  ''' Mostra a classificação do mundial de construtores
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  ''' <remarks></remarks>
  Private Sub mnuMundialConstrutores_Click(sender As Object, e As EventArgs) Handles mnuMundialConstrutores.Click
    Try
      imgTitle.Image = My.Resources.Campeonato
      lblTitle.Text = "Mundial de Construtores"
      lblDescription.Text = dirCampeonato.Name

      listMundialConstrutores = listMundialConstrutores.OrderBy(Function(resultEquipe) resultEquipe.Posicao).ToList()
      dtGridView.DataSource = listMundialConstrutores
      FormatarDataGridViewParaMundialConstrutores()
      dtGridView.Refresh()
    Catch ex As Exception
      MessageBox.Show(ex.Message)
    End Try
  End Sub

  ''' <summary>
  ''' Formata o grid para visualizar as equipes
  ''' </summary>
  ''' <remarks></remarks>
  Private Sub FormatarDataGridViewParaEquipes()
    Try
      dtGridView.Columns.Clear()
      'Declaramos dois tipos de colunas, texto e imagens
      Dim newTextColumn As DataGridViewTextBoxColumn = Nothing
      Dim newImgColumn As DataGridViewImageColumn = Nothing

      '1 - Nome da Equipe
      newTextColumn = New DataGridViewTextBoxColumn()
      newTextColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
      newTextColumn.Name = "colNome"
      newTextColumn.DataPropertyName = "Nome"
      newTextColumn.HeaderText = "Nome da Equipe"
      newTextColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
      newTextColumn.ReadOnly = True
      dtGridView.Columns.Add(newTextColumn)

      '2 - Logo
      newImgColumn = New DataGridViewImageColumn()
      newImgColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
      newImgColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
      newImgColumn.Name = "colLogo"
      newImgColumn.DataPropertyName = "Logo"
      newImgColumn.HeaderText = "Logo"
      newImgColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      newImgColumn.ReadOnly = True
      dtGridView.Columns.Add(newImgColumn)

      '3 - Carro
      newImgColumn = New DataGridViewImageColumn()
      newImgColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
      newImgColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
      newImgColumn.Name = "colCarro"
      newImgColumn.DataPropertyName = "Carro"
      newImgColumn.HeaderText = "Carro"
      newImgColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      newImgColumn.ReadOnly = True
      dtGridView.Columns.Add(newImgColumn)

      '4 - Nacionalidade
      newImgColumn = New DataGridViewImageColumn()
      newImgColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
      newImgColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
      newImgColumn.Name = "colBandeira"
      newImgColumn.DataPropertyName = "Bandeira"
      newImgColumn.HeaderText = "Nacionalidade da Equipe"
      newImgColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      newImgColumn.ReadOnly = True
      dtGridView.Columns.Add(newImgColumn)

      newTextColumn = Nothing
      newImgColumn = Nothing
    Catch ex As Exception
      MessageBox.Show(ex.Message)
    End Try
    AlternarCoresDoGrid()
  End Sub

  ''' <summary>
  ''' Formata o grid para visualizar os pilotos
  ''' </summary>
  ''' <remarks></remarks>
  Private Sub FormatarDataGridViewParaPilotos()
    Try
      dtGridView.Columns.Clear()
      'Declaramos dois tipos de colunas, texto e imagens
      Dim newTextColumn As DataGridViewTextBoxColumn = Nothing
      Dim newImgColumn As DataGridViewImageColumn = Nothing

      '1 - Nome
      newTextColumn = New DataGridViewTextBoxColumn()
      newTextColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
      newTextColumn.Name = "colNome"
      newTextColumn.DataPropertyName = "Nome"
      newTextColumn.HeaderText = "Nome do Piloto"
      newTextColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
      newTextColumn.ReadOnly = True
      dtGridView.Columns.Add(newTextColumn)

      '2 - Idade
      newTextColumn = New DataGridViewTextBoxColumn()
      newTextColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
      newTextColumn.Name = "colIdade"
      newTextColumn.DataPropertyName = "Idade"
      newTextColumn.HeaderText = "Idade do Piloto"
      newTextColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      newTextColumn.ReadOnly = True
      dtGridView.Columns.Add(newTextColumn)

      '3 - Bandeira
      newImgColumn = New DataGridViewImageColumn()
      newImgColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
      newImgColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
      newImgColumn.Name = "colBandeira"
      newImgColumn.DataPropertyName = "Bandeira"
      newImgColumn.HeaderText = "Nacionalidade"
      newImgColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      newImgColumn.ReadOnly = True
      dtGridView.Columns.Add(newImgColumn)

      '4 - Nome da Equipe
      newTextColumn = New DataGridViewTextBoxColumn()
      newTextColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
      newTextColumn.Name = "colEquipeNome"
      newTextColumn.DataPropertyName = "NomeEquipe"
      newTextColumn.HeaderText = "Equipe"
      newTextColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
      newTextColumn.ReadOnly = True
      dtGridView.Columns.Add(newTextColumn)

      '5 - Logo da Equipe
      newImgColumn = New DataGridViewImageColumn()
      newImgColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
      newImgColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
      newImgColumn.Name = "colEquipeLogo"
      newImgColumn.DataPropertyName = "Logo"
      newImgColumn.HeaderText = "Logo"
      newImgColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      newImgColumn.ReadOnly = True
      dtGridView.Columns.Add(newImgColumn)

      '6 - Carro da Equipe
      newImgColumn = New DataGridViewImageColumn()
      newImgColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
      newImgColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
      newImgColumn.Name = "colEquipeCarro"
      newImgColumn.DataPropertyName = "Carro"
      newImgColumn.HeaderText = "Carro"
      newImgColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      newImgColumn.ReadOnly = True
      dtGridView.Columns.Add(newImgColumn)

      '7 - Piloto
      newTextColumn = New DataGridViewTextBoxColumn()
      newTextColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
      newTextColumn.Name = "colPiloto"
      newTextColumn.DataPropertyName = "Piloto"
      newTextColumn.HeaderText = "Piloto Nº"
      newTextColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      newTextColumn.ReadOnly = True
      dtGridView.Columns.Add(newTextColumn)

      '8 - Numero do Carro
      newTextColumn = New DataGridViewTextBoxColumn()
      newTextColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
      newTextColumn.Name = "colNumero"
      newTextColumn.DataPropertyName = "Numero"
      newTextColumn.HeaderText = "Número do Carro"
      newTextColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      newTextColumn.ReadOnly = True
      dtGridView.Columns.Add(newTextColumn)

      '8 - Poles
      newTextColumn = New DataGridViewTextBoxColumn()
      newTextColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
      newTextColumn.Name = "colPoles"
      newTextColumn.DataPropertyName = "Poles"
      newTextColumn.HeaderText = "Histórico de Poles"
      newTextColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      newTextColumn.ReadOnly = True
      dtGridView.Columns.Add(newTextColumn)

      '9 - Vitorias
      newTextColumn = New DataGridViewTextBoxColumn()
      newTextColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
      newTextColumn.Name = "colVitorias"
      newTextColumn.DataPropertyName = "Vitorias"
      newTextColumn.HeaderText = "Histórico de Vitórias"
      newTextColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      newTextColumn.ReadOnly = True
      dtGridView.Columns.Add(newTextColumn)

      '10 - Títulos
      newTextColumn = New DataGridViewTextBoxColumn()
      newTextColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
      newTextColumn.Name = "colTitulos"
      newTextColumn.DataPropertyName = "Titulos"
      newTextColumn.HeaderText = "Histórico de Títulos"
      newTextColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      newTextColumn.ReadOnly = True
      dtGridView.Columns.Add(newTextColumn)

      newTextColumn = Nothing
      newImgColumn = Nothing
    Catch ex As Exception
      MessageBox.Show(ex.Message)
    End Try
    AlternarCoresDoGrid()
  End Sub

  ''' <summary>
  ''' Formata o grid para visualizar as etapas
  ''' </summary>
  ''' <remarks></remarks>
  Private Sub FormatarDataGridViewParaEtapas()
    Try
      dtGridView.Columns.Clear()
      'Declaramos dois tipos de colunas, texto e imagens
      Dim newTextColumn As DataGridViewTextBoxColumn = Nothing
      Dim newImgColumn As DataGridViewImageColumn = Nothing

      '1 - Etapa
      newTextColumn = New DataGridViewTextBoxColumn()
      newTextColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
      newTextColumn.Name = "colEtapa"
      newTextColumn.DataPropertyName = "Etapa"
      newTextColumn.HeaderText = "Etapa"
      newTextColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
      newTextColumn.ReadOnly = True
      dtGridView.Columns.Add(newTextColumn)

      '2 - País
      newImgColumn = New DataGridViewImageColumn()
      newImgColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
      newImgColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
      newImgColumn.Name = "colPais"
      newImgColumn.DataPropertyName = "Pais"
      newImgColumn.HeaderText = "País"
      newImgColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
      newImgColumn.ReadOnly = True
      dtGridView.Columns.Add(newImgColumn)

      '3 - Nome do Circuito
      newTextColumn = New DataGridViewTextBoxColumn()
      newTextColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
      newTextColumn.Name = "colNomeCircuito"
      newTextColumn.DataPropertyName = "NomeCircuito"
      newTextColumn.HeaderText = "Nome do Circuito"
      newTextColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
      newTextColumn.ReadOnly = True
      dtGridView.Columns.Add(newTextColumn)

      '4 - Tomada Recorde
      newTextColumn = New DataGridViewTextBoxColumn()
      newTextColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
      newTextColumn.Name = "colTomada"
      newTextColumn.DataPropertyName = "Tomada"
      newTextColumn.HeaderText = "Tomada Recorde"
      newTextColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      newTextColumn.ReadOnly = True
      dtGridView.Columns.Add(newTextColumn)

      '5 - Volta Recorde
      newTextColumn = New DataGridViewTextBoxColumn()
      newTextColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
      newTextColumn.Name = "colVoltaRecorde"
      newTextColumn.DataPropertyName = "VoltaRecorde"
      newTextColumn.HeaderText = "Volta Recorde"
      newTextColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      newTextColumn.ReadOnly = True
      dtGridView.Columns.Add(newTextColumn)

      '6 - Voltas
      newTextColumn = New DataGridViewTextBoxColumn()
      newTextColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
      newTextColumn.Name = "colVoltas"
      newTextColumn.DataPropertyName = "Voltas"
      newTextColumn.HeaderText = "Quantidade de Voltas"
      newTextColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      newTextColumn.ReadOnly = True
      dtGridView.Columns.Add(newTextColumn)

      '7 - Consumo
      newTextColumn = New DataGridViewTextBoxColumn()
      newTextColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
      newTextColumn.Name = "colConsumo"
      newTextColumn.DataPropertyName = "Consumo"
      newTextColumn.HeaderText = "Consumo de Combustível"
      newTextColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      newTextColumn.ReadOnly = True
      dtGridView.Columns.Add(newTextColumn)

      '8 - Massa
      newTextColumn = New DataGridViewTextBoxColumn()
      newTextColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
      newTextColumn.Name = "colMassa"
      newTextColumn.DataPropertyName = "Massa"
      newTextColumn.HeaderText = "Massa do Combustível"
      newTextColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      newTextColumn.ReadOnly = True
      dtGridView.Columns.Add(newTextColumn)

      '9 - Danos
      newTextColumn = New DataGridViewTextBoxColumn()
      newTextColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
      newTextColumn.Name = "colDanos"
      newTextColumn.DataPropertyName = "Danos"
      newTextColumn.HeaderText = "Coeficiente de Danos"
      newTextColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      newTextColumn.ReadOnly = True
      dtGridView.Columns.Add(newTextColumn)

      '10 - Desgaste
      newTextColumn = New DataGridViewTextBoxColumn()
      newTextColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
      newTextColumn.Name = "colDesgaste"
      newTextColumn.DataPropertyName = "Desgaste"
      newTextColumn.HeaderText = "Desgaste de Pneus"
      newTextColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      newTextColumn.ReadOnly = True
      dtGridView.Columns.Add(newTextColumn)

      newTextColumn = Nothing
      newImgColumn = Nothing
    Catch ex As Exception
      MessageBox.Show(ex.Message)
    End Try
    AlternarCoresDoGrid()
  End Sub

  ''' <summary>
  ''' Formata o grid para visualizar o resultado da etapa
  ''' </summary>
  ''' <remarks></remarks>
  Private Sub FormatarDataGridViewParaEtapaResultados()
    Try
      dtGridView.Columns.Clear()
      'Declaramos dois tipos de colunas, texto e imagens
      Dim newTextColumn As DataGridViewTextBoxColumn = Nothing
      Dim newImgColumn As DataGridViewImageColumn = Nothing
      Dim newChckColumn As DataGridViewCheckBoxColumn = Nothing

      '1 - Posição
      newTextColumn = New DataGridViewTextBoxColumn()
      newTextColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
      newTextColumn.Width = 40
      newTextColumn.Name = "colPosicaoEtapa"
      newTextColumn.DataPropertyName = "PosicaoEtapa"
      newTextColumn.HeaderText = "Pos"
      newTextColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
      newTextColumn.ReadOnly = True
      dtGridView.Columns.Add(newTextColumn)

      '2 - Nome do Piloto
      newTextColumn = New DataGridViewTextBoxColumn()
      newTextColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
      newTextColumn.Name = "colPilotoNome"
      newTextColumn.DataPropertyName = "GridPilotoNome"
      newTextColumn.HeaderText = "Piloto"
      newTextColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
      newTextColumn.ReadOnly = True
      dtGridView.Columns.Add(newTextColumn)

      '3 - Número do Piloto
      newTextColumn = New DataGridViewTextBoxColumn()
      newTextColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
      newTextColumn.Width = 40
      newTextColumn.Name = "colPilotoNumero"
      newTextColumn.DataPropertyName = "GridPilotoNumero"
      newTextColumn.HeaderText = "Nº"
      newTextColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      newTextColumn.ReadOnly = True
      dtGridView.Columns.Add(newTextColumn)

      '4 - País
      newImgColumn = New DataGridViewImageColumn()
      newImgColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
      newImgColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
      newImgColumn.Width = 50
      newImgColumn.Name = "colPais"
      newImgColumn.DataPropertyName = "GridPilotoPais"
      newImgColumn.HeaderText = "País"
      newImgColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      newImgColumn.ReadOnly = True
      dtGridView.Columns.Add(newImgColumn)

      '5 - Nome da Equipe
      newTextColumn = New DataGridViewTextBoxColumn()
      newTextColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
      newTextColumn.Name = "colEquipeNome"
      newTextColumn.DataPropertyName = "GridEquipeNome"
      newTextColumn.HeaderText = "Equipe"
      newTextColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      newTextColumn.ReadOnly = True
      dtGridView.Columns.Add(newTextColumn)

      '6 - Logo
      newImgColumn = New DataGridViewImageColumn()
      newImgColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
      newImgColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
      newImgColumn.Width = 50
      newImgColumn.Name = "colEquipeLogo"
      newImgColumn.DataPropertyName = "GridEquipeLogo"
      newImgColumn.HeaderText = ""
      newImgColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      newImgColumn.ReadOnly = True
      dtGridView.Columns.Add(newImgColumn)

      '7 - Carro
      newImgColumn = New DataGridViewImageColumn()
      newImgColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
      newImgColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
      newImgColumn.Name = "colEquipeCarro"
      newImgColumn.DataPropertyName = "GridEquipeCarro"
      newImgColumn.HeaderText = ""
      newImgColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      newImgColumn.ReadOnly = True
      dtGridView.Columns.Add(newImgColumn)

      '8 - Tomada
      newTextColumn = New DataGridViewTextBoxColumn()
      newTextColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
      newTextColumn.Width = 100
      newTextColumn.Name = "colTomada"
      newTextColumn.DataPropertyName = "TomadaCorrida"
      newTextColumn.HeaderText = "Tomada" & vbNewLine & "(Corrida)"
      newTextColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      newTextColumn.DefaultCellStyle.Format = "mm\:ss\,ff"
      newTextColumn.ReadOnly = True
      dtGridView.Columns.Add(newTextColumn)

      '9 - Punição na Corrida
      newTextColumn = New DataGridViewTextBoxColumn()
      newTextColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
      newTextColumn.Width = 100
      newTextColumn.Name = "colPunicaoCorrida"
      newTextColumn.DataPropertyName = "PunicaoCorrida"
      newTextColumn.HeaderText = "Punição" & vbNewLine & "(Corrida)"
      newTextColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      newTextColumn.DefaultCellStyle.Format = "mm\:ss\,ff"
      newTextColumn.ReadOnly = True
      dtGridView.Columns.Add(newTextColumn)

      '10 - Gap para Líder
      newTextColumn = New DataGridViewTextBoxColumn()
      newTextColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
      newTextColumn.Width = 100
      newTextColumn.Name = "colGapLider"
      newTextColumn.DataPropertyName = "GapLider"
      newTextColumn.HeaderText = "GAP" & vbNewLine & "(Líder)"
      newTextColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      newTextColumn.DefaultCellStyle.Format = "mm\:ss\,ff"
      newTextColumn.ReadOnly = True
      dtGridView.Columns.Add(newTextColumn)

      '11 - Gap para Frente
      newTextColumn = New DataGridViewTextBoxColumn()
      newTextColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
      newTextColumn.Width = 100
      newTextColumn.Name = "colGapFrente"
      newTextColumn.DataPropertyName = "GapFrente"
      newTextColumn.HeaderText = "GAP" & vbNewLine & "(Frente)"
      newTextColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      newTextColumn.DefaultCellStyle.Format = "mm\:ss\,ff"
      newTextColumn.ReadOnly = True
      dtGridView.Columns.Add(newTextColumn)

      '12 - Melhor Volta da Corrida
      newTextColumn = New DataGridViewTextBoxColumn()
      newTextColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
      newTextColumn.Width = 100
      newTextColumn.Name = "colMelhorVoltaCorrida"
      newTextColumn.DataPropertyName = "MelhorVoltaCorrida"
      newTextColumn.HeaderText = "Melhor Volta" & vbNewLine & "(Corrida)"
      newTextColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      newTextColumn.DefaultCellStyle.Format = "mm\:ss\,ff"
      newTextColumn.ReadOnly = True
      dtGridView.Columns.Add(newTextColumn)

      '13 - Pneus
      newTextColumn = New DataGridViewTextBoxColumn()
      newTextColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
      newTextColumn.Width = 50
      newTextColumn.Name = "colPneus"
      newTextColumn.DataPropertyName = "CorridaTyresConsumption"
      newTextColumn.HeaderText = "Pneus"
      newTextColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      newTextColumn.ReadOnly = True
      dtGridView.Columns.Add(newTextColumn)

      '14 - Evolucao
      newTextColumn = New DataGridViewTextBoxColumn()
      newTextColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
      newTextColumn.Width = 50
      newTextColumn.Name = "colEvolucao"
      newTextColumn.DataPropertyName = "Evolucao"
      newTextColumn.HeaderText = ""
      newTextColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      newTextColumn.ReadOnly = True
      dtGridView.Columns.Add(newTextColumn)

      '15 - Fator Grid
      newTextColumn = New DataGridViewTextBoxColumn()
      newTextColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
      newTextColumn.Width = 80
      newTextColumn.Name = "colFatorGrid"
      newTextColumn.DataPropertyName = "FatorGrid"
      newTextColumn.HeaderText = "Efeito" & vbNewLine & "Grid"
      newTextColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      newTextColumn.ReadOnly = True
      dtGridView.Columns.Add(newTextColumn)

      '16 - Pontos da Etapa
      newTextColumn = New DataGridViewTextBoxColumn()
      newTextColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
      newTextColumn.Width = 80
      newTextColumn.Name = "colPontosPosicao"
      newTextColumn.DataPropertyName = "PontosPosicao"
      newTextColumn.HeaderText = "Pontos " & vbNewLine & "Posição"
      newTextColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      newTextColumn.ReadOnly = True
      dtGridView.Columns.Add(newTextColumn)

      '17 - Pontos Totais
      newTextColumn = New DataGridViewTextBoxColumn()
      newTextColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
      newTextColumn.Width = 80
      newTextColumn.Name = "colPontosTotais"
      newTextColumn.DataPropertyName = "PontosTotais"
      newTextColumn.HeaderText = "Pontos " & vbNewLine & "Totais"
      newTextColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      newTextColumn.ReadOnly = True
      dtGridView.Columns.Add(newTextColumn)

      newTextColumn = Nothing
      newImgColumn = Nothing
      newChckColumn = Nothing
    Catch ex As Exception
      MessageBox.Show(ex.Message)
    End Try
    AlternarCoresDoGrid()
  End Sub

  ''' <summary>
  ''' Formata o grid para visualizar o grid da etapa
  ''' </summary>
  ''' <remarks></remarks>
  Private Sub FormatarDataGridViewParaEtapaGrid()
    Try
      dtGridView.Columns.Clear()
      'Declaramos dois tipos de colunas, texto e imagens
      Dim newTextColumn As DataGridViewTextBoxColumn = Nothing
      Dim newImgColumn As DataGridViewImageColumn = Nothing
      Dim newChckColumn As DataGridViewCheckBoxColumn = Nothing

      '1 - Posição
      newTextColumn = New DataGridViewTextBoxColumn()
      newTextColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
      newTextColumn.Width = 40
      newTextColumn.Name = "colPosicao"
      newTextColumn.DataPropertyName = "PosicaoGrid"
      newTextColumn.HeaderText = "Pos"
      newTextColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
      newTextColumn.ReadOnly = True
      dtGridView.Columns.Add(newTextColumn)

      '2 - Nome do Piloto
      newTextColumn = New DataGridViewTextBoxColumn()
      newTextColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
      newTextColumn.Name = "colPilotoNome"
      newTextColumn.DataPropertyName = "GridPilotoNome"
      newTextColumn.HeaderText = "Piloto"
      newTextColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
      newTextColumn.ReadOnly = True
      dtGridView.Columns.Add(newTextColumn)

      '3 - Número do Piloto
      newTextColumn = New DataGridViewTextBoxColumn()
      newTextColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
      newTextColumn.Width = 40
      newTextColumn.Name = "colPilotoNumero"
      newTextColumn.DataPropertyName = "GridPilotoNumero"
      newTextColumn.HeaderText = "Nº"
      newTextColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      newTextColumn.ReadOnly = True
      dtGridView.Columns.Add(newTextColumn)

      '4 - País
      newImgColumn = New DataGridViewImageColumn()
      newImgColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
      newImgColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
      newImgColumn.Width = 50
      newImgColumn.Name = "colPais"
      newImgColumn.DataPropertyName = "GridPilotoPais"
      newImgColumn.HeaderText = "País"
      newImgColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      newImgColumn.ReadOnly = True
      dtGridView.Columns.Add(newImgColumn)

      '5 - Nome da Equipe
      newTextColumn = New DataGridViewTextBoxColumn()
      newTextColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
      newTextColumn.Name = "colEquipeNome"
      newTextColumn.DataPropertyName = "GridEquipeNome"
      newTextColumn.HeaderText = "Equipe"
      newTextColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      newTextColumn.ReadOnly = True
      dtGridView.Columns.Add(newTextColumn)

      '6 - Logo
      newImgColumn = New DataGridViewImageColumn()
      newImgColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
      newImgColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
      newImgColumn.Width = 50
      newImgColumn.Name = "colEquipeLogo"
      newImgColumn.DataPropertyName = "GridEquipeLogo"
      newImgColumn.HeaderText = ""
      newImgColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      newImgColumn.ReadOnly = True
      dtGridView.Columns.Add(newImgColumn)

      '7 - Carro
      newImgColumn = New DataGridViewImageColumn()
      newImgColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
      newImgColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
      newImgColumn.Name = "colEquipeCarro"
      newImgColumn.DataPropertyName = "GridEquipeCarro"
      newImgColumn.HeaderText = ""
      newImgColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      newImgColumn.ReadOnly = True
      dtGridView.Columns.Add(newImgColumn)

      '8 - Melhor Volta da Classificação
      newTextColumn = New DataGridViewTextBoxColumn()
      newTextColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
      newTextColumn.Width = 100
      newTextColumn.Name = "colMelhorVoltaClassificacao"
      newTextColumn.DataPropertyName = "MelhorVoltaClassificacao"
      newTextColumn.HeaderText = "Melhor Volta" & vbNewLine & "(Classificação)"
      newTextColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      newTextColumn.DefaultCellStyle.Format = "mm\:ss\,ff"
      newTextColumn.ReadOnly = True
      dtGridView.Columns.Add(newTextColumn)

      '9 - Tomada da Classificação
      newTextColumn = New DataGridViewTextBoxColumn()
      newTextColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
      newTextColumn.Width = 100
      newTextColumn.Name = "colTomada"
      newTextColumn.DataPropertyName = "TomadaClassificacao"
      newTextColumn.HeaderText = "Tomada" & vbNewLine & "(Classificação)"
      newTextColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      newTextColumn.DefaultCellStyle.Format = "mm\:ss\,ff"
      newTextColumn.ReadOnly = True
      dtGridView.Columns.Add(newTextColumn)

      '10 - Punição na Classificação
      newTextColumn = New DataGridViewTextBoxColumn()
      newTextColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
      newTextColumn.Width = 100
      newTextColumn.Name = "colPunicaoClassificacao"
      newTextColumn.DataPropertyName = "PunicaoClassificacao"
      newTextColumn.HeaderText = "Punição" & vbNewLine & "(Classificação)"
      newTextColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      newTextColumn.DefaultCellStyle.Format = "mm\:ss\,ff"
      newTextColumn.ReadOnly = True
      dtGridView.Columns.Add(newTextColumn)

      '11 - Gap para Líder
      newTextColumn = New DataGridViewTextBoxColumn()
      newTextColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
      newTextColumn.Width = 100
      newTextColumn.Name = "colGapLider"
      newTextColumn.DataPropertyName = "GapMelhorVolta"
      newTextColumn.HeaderText = "GAP" & vbNewLine & "(Líder)"
      newTextColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      newTextColumn.DefaultCellStyle.Format = "mm\:ss\,ff"
      newTextColumn.ReadOnly = True
      dtGridView.Columns.Add(newTextColumn)

      '12 - Pneus
      newTextColumn = New DataGridViewTextBoxColumn()
      newTextColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
      newTextColumn.Width = 50
      newTextColumn.Name = "colPneus"
      newTextColumn.DataPropertyName = "ClassificacaoTyresConsumption"
      newTextColumn.HeaderText = "Pneus"
      newTextColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      newTextColumn.ReadOnly = True
      dtGridView.Columns.Add(newTextColumn)

      '13 - Pontos Deadline 1
      newTextColumn = New DataGridViewTextBoxColumn()
      newTextColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
      newTextColumn.Width = 80
      newTextColumn.Name = "colPontosDeadline1"
      newTextColumn.DataPropertyName = "PontosDeadline1"
      newTextColumn.HeaderText = "Pontos" & vbNewLine & "(Envio)"
      newTextColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      newTextColumn.ReadOnly = True
      dtGridView.Columns.Add(newTextColumn)

      '14 - Pontos GRID
      newTextColumn = New DataGridViewTextBoxColumn()
      newTextColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
      newTextColumn.Width = 80
      newTextColumn.Name = "colPontosGrid"
      newTextColumn.DataPropertyName = "PontosGrid"
      newTextColumn.HeaderText = "Pontos" & vbNewLine & "(Grid)"
      newTextColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      newTextColumn.ReadOnly = True
      dtGridView.Columns.Add(newTextColumn)

      '15 - Pontos de Aproximação
      newTextColumn = New DataGridViewTextBoxColumn()
      newTextColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
      newTextColumn.Width = 80
      newTextColumn.Name = "colPontosAproximacao"
      newTextColumn.DataPropertyName = "PontosAproximacao"
      newTextColumn.HeaderText = "Pontos" & vbNewLine & "(Aprox.)"
      newTextColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      newTextColumn.ReadOnly = True
      dtGridView.Columns.Add(newTextColumn)

      newTextColumn = Nothing
      newImgColumn = Nothing
      newChckColumn = Nothing
    Catch ex As Exception
      MessageBox.Show(ex.Message)
    End Try
    AlternarCoresDoGrid()
  End Sub

  ''' <summary>
  ''' Formata o grid para visualizar o mundial de pilotos
  ''' </summary>
  ''' <remarks></remarks>
  Private Sub FormatarDataGridViewParaMundialPilotos()
    Try
      dtGridView.Columns.Clear()
      'Declaramos dois tipos de colunas, texto e imagens
      Dim newTextColumn As DataGridViewTextBoxColumn = Nothing
      Dim newImgColumn As DataGridViewImageColumn = Nothing
      Dim newChckColumn As DataGridViewCheckBoxColumn = Nothing

      '1 - Posição
      newTextColumn = New DataGridViewTextBoxColumn()
      newTextColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
      newTextColumn.Name = "colPosicao"
      newTextColumn.DataPropertyName = "Posicao"
      newTextColumn.HeaderText = "Pos"
      newTextColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
      newTextColumn.ReadOnly = True
      dtGridView.Columns.Add(newTextColumn)

      '2 - Nome do Piloto
      newTextColumn = New DataGridViewTextBoxColumn()
      newTextColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
      newTextColumn.Width = 200
      newTextColumn.Name = "colPilotoNome"
      newTextColumn.DataPropertyName = "GridPilotoNome"
      newTextColumn.HeaderText = "Piloto"
      newTextColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
      newTextColumn.ReadOnly = True
      dtGridView.Columns.Add(newTextColumn)

      '3 - Número do Piloto
      newTextColumn = New DataGridViewTextBoxColumn()
      newTextColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
      newTextColumn.Name = "colPilotoNumero"
      newTextColumn.DataPropertyName = "GridPilotoNumero"
      newTextColumn.HeaderText = "Nº"
      newTextColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      newTextColumn.ReadOnly = True
      dtGridView.Columns.Add(newTextColumn)

      '4 - País
      newImgColumn = New DataGridViewImageColumn()
      newImgColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
      newImgColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
      newImgColumn.Width = 50
      newImgColumn.Name = "colPais"
      newImgColumn.DataPropertyName = "GridPilotoPais"
      newImgColumn.HeaderText = "País"
      newImgColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      newImgColumn.ReadOnly = True
      dtGridView.Columns.Add(newImgColumn)

      '5 - Nome da Equipe
      newTextColumn = New DataGridViewTextBoxColumn()
      newTextColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
      newTextColumn.Width = 200
      newTextColumn.Name = "colEquipeNome"
      newTextColumn.DataPropertyName = "GridEquipeNome"
      newTextColumn.HeaderText = "Equipe"
      newTextColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      newTextColumn.ReadOnly = True
      dtGridView.Columns.Add(newTextColumn)

      '6 - Logo
      newImgColumn = New DataGridViewImageColumn()
      newImgColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
      newImgColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
      newImgColumn.Width = 50
      newImgColumn.Name = "colEquipeLogo"
      newImgColumn.DataPropertyName = "GridEquipeLogo"
      newImgColumn.HeaderText = ""
      newImgColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      newImgColumn.ReadOnly = True
      dtGridView.Columns.Add(newImgColumn)

      '7 - Carro
      newImgColumn = New DataGridViewImageColumn()
      newImgColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
      newImgColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
      newImgColumn.Name = "colEquipeCarro"
      newImgColumn.DataPropertyName = "GridEquipeCarro"
      newImgColumn.HeaderText = ""
      newImgColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      newImgColumn.ReadOnly = True
      dtGridView.Columns.Add(newImgColumn)

      '8 - Pontos
      newTextColumn = New DataGridViewTextBoxColumn()
      newTextColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
      newTextColumn.Width = 90
      newTextColumn.Name = "colPontos"
      newTextColumn.DataPropertyName = "Pontos"
      newTextColumn.HeaderText = "Pontos"
      newTextColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      newTextColumn.ReadOnly = True
      dtGridView.Columns.Add(newTextColumn)

      newTextColumn = Nothing
      newImgColumn = Nothing
      newChckColumn = Nothing
    Catch ex As Exception
      MessageBox.Show(ex.Message)
    End Try
    AlternarCoresDoGrid()
  End Sub

  ''' <summary>
  ''' Formata o grid para visualizar o mundial de construtores
  ''' </summary>
  ''' <remarks></remarks>
  Private Sub FormatarDataGridViewParaMundialConstrutores()
    Try
      dtGridView.Columns.Clear()
      'Declaramos dois tipos de colunas, texto e imagens
      Dim newTextColumn As DataGridViewTextBoxColumn = Nothing
      Dim newImgColumn As DataGridViewImageColumn = Nothing
      Dim newChckColumn As DataGridViewCheckBoxColumn = Nothing

      '1 - Posição
      newTextColumn = New DataGridViewTextBoxColumn()
      newTextColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
      newTextColumn.Name = "colPosicao"
      newTextColumn.DataPropertyName = "Posicao"
      newTextColumn.HeaderText = "Pos"
      newTextColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
      newTextColumn.ReadOnly = True
      dtGridView.Columns.Add(newTextColumn)

      '2 - Nome da Equipe
      newTextColumn = New DataGridViewTextBoxColumn()
      newTextColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
      newTextColumn.Width = 200
      newTextColumn.Name = "colEquipeNome"
      newTextColumn.DataPropertyName = "GridEquipeNome"
      newTextColumn.HeaderText = "Equipe"
      newTextColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
      newTextColumn.ReadOnly = True
      dtGridView.Columns.Add(newTextColumn)

      '3 - Logo
      newImgColumn = New DataGridViewImageColumn()
      newImgColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
      newImgColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
      newImgColumn.Width = 50
      newImgColumn.Name = "colEquipeLogo"
      newImgColumn.DataPropertyName = "GridEquipeLogo"
      newImgColumn.HeaderText = ""
      newImgColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      newImgColumn.ReadOnly = True
      dtGridView.Columns.Add(newImgColumn)

      '4 - Carro
      newImgColumn = New DataGridViewImageColumn()
      newImgColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
      newImgColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
      newImgColumn.Name = "colEquipeCarro"
      newImgColumn.DataPropertyName = "GridEquipeCarro"
      newImgColumn.HeaderText = ""
      newImgColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      newImgColumn.ReadOnly = True
      dtGridView.Columns.Add(newImgColumn)

      '5 - Pontos
      newTextColumn = New DataGridViewTextBoxColumn()
      newTextColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None
      newTextColumn.Width = 90
      newTextColumn.Name = "colPontos"
      newTextColumn.DataPropertyName = "Pontos"
      newTextColumn.HeaderText = "Pontos"
      newTextColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
      newTextColumn.ReadOnly = True
      dtGridView.Columns.Add(newTextColumn)

      newTextColumn = Nothing
      newImgColumn = Nothing
      newChckColumn = Nothing
    Catch ex As Exception
      MessageBox.Show(ex.Message)
    End Try
    AlternarCoresDoGrid()
  End Sub

  ''' <summary>
  ''' Reinicia a Aplicação
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  ''' <remarks></remarks>
  Private Sub mnuReiniciar_Click(sender As Object, e As EventArgs) Handles mnuReiniciar.Click
    Application.Restart()
  End Sub

  ''' <summary>
  ''' Sai da Aplicação
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  ''' <remarks></remarks>
  Private Sub mnuSair_Click(sender As Object, e As EventArgs) Handles mnuSair.Click
    Application.Exit()
  End Sub

  ''' <summary>
  ''' Alternar as cores do grid
  ''' </summary>
  ''' <remarks></remarks>
  Private Sub AlternarCoresDoGrid()
    Dim rowOdd As Boolean = False
    For Each tmpRow As DataGridViewRow In dtGridView.Rows
      If rowOdd Then
        dtGridView.Rows(tmpRow.Index).DefaultCellStyle.BackColor = Color.FromArgb(50, 50, 50)
      Else
        dtGridView.Rows(tmpRow.Index).DefaultCellStyle.BackColor = Color.FromArgb(30, 30, 30)
      End If
      rowOdd = Not rowOdd
    Next
  End Sub

  ''' <summary>
  ''' Carrega dicionário de pontuação
  ''' </summary>
  ''' <remarks></remarks>
  Private Sub CarregarPontuacao(ByRef _dirCampeonato As DirectoryInfo)
    dicPontos = New Dictionary(Of String, Integer)
    dicPontos.Clear()

    For Each tmpEquipeTxtPath As FileInfo In _dirCampeonato.GetFiles("PontuacaoFixa.txt")
      Dim newReader As New StreamReader(tmpEquipeTxtPath.FullName, System.Text.Encoding.Default)
      While Not newReader.EndOfStream
        Dim curLine() As String = Split(newReader.ReadLine(), "=")
        If curLine.Length = 2 Then
          dicPontos.Add(curLine(0), CInt(curLine(1)))
        End If
        curLine = Nothing
        newReader.Peek()
      End While
      newReader.Close()
      newReader = Nothing
    Next

    dicPontosAproximacaoClassificacao = New Dictionary(Of TimeSpan, Integer)
    dicPontosAproximacaoClassificacao.Clear()

    For Each tmpEquipeTxtPath As FileInfo In _dirCampeonato.GetFiles("PontuacaoVariavel.txt")
      Dim newReader As New StreamReader(tmpEquipeTxtPath.FullName, System.Text.Encoding.Default)
      While Not newReader.EndOfStream
        Dim curLine() As String = Split(newReader.ReadLine(), "=")
        If curLine.Length = 2 Then
          dicPontosAproximacaoClassificacao.Add(Etapa.FormataTempo(curLine(0), New TimeSpan()), CInt(curLine(1)))
        End If
        curLine = Nothing
        newReader.Peek()
      End While
      newReader.Close()
      newReader = Nothing
    Next
  End Sub

  ''' <summary>
  ''' Calcula o mundial de pilotos e construtores
  ''' </summary>
  ''' <remarks></remarks>
  Private Sub ComputarPontuacaoCampeonato()
    Dim dicPontosPilotos As New Dictionary(Of Piloto, Integer)
    Dim dicPontosEquipes As New Dictionary(Of Equipe, Integer)
    For Each tmpEtapa As Etapa In listEtapas
      For Each tmpResultadoEtapa As ResultadoEtapa In tmpEtapa.Resultados
        If Not dicPontosPilotos.ContainsKey(tmpResultadoEtapa.Piloto) Then
          dicPontosPilotos.Add(tmpResultadoEtapa.Piloto, 0)
        End If
        dicPontosPilotos(tmpResultadoEtapa.Piloto) += tmpResultadoEtapa.PontosTotais

        If Not dicPontosEquipes.ContainsKey(tmpResultadoEtapa.Equipe) Then
          dicPontosEquipes.Add(tmpResultadoEtapa.Equipe, 0)
        End If
        dicPontosEquipes(tmpResultadoEtapa.Equipe) += tmpResultadoEtapa.PontosTotais
      Next
    Next

    listMundialPilotos = Nothing
    listMundialPilotos = New List(Of ResultadoPiloto)
    For Each tmpPiloto As Piloto In dicPontosPilotos.Keys
      listMundialPilotos.Add(New ResultadoPiloto(tmpPiloto, tmpPiloto.Equipe, dicPontosPilotos(tmpPiloto)))
    Next
    listMundialPilotos = listMundialPilotos.OrderByDescending(Function(resultPiloto) resultPiloto.Pontos).ToList()
    Dim pos As Integer = 1
    For Each tmpResultadoPiloto As ResultadoPiloto In listMundialPilotos
      tmpResultadoPiloto.Posicao = pos
      pos += 1
    Next

    listMundialConstrutores = Nothing
    listMundialConstrutores = New List(Of ResultadoEquipe)
    For Each tmpEquipe As Equipe In dicPontosEquipes.Keys
      listMundialConstrutores.Add(New ResultadoEquipe(tmpEquipe, dicPontosEquipes(tmpEquipe)))
    Next
    listMundialConstrutores = listMundialConstrutores.OrderByDescending(Function(resultEquipe) resultEquipe.Pontos).ToList()
    pos = 1
    For Each tmpResultadoEquipe As ResultadoEquipe In listMundialConstrutores
      tmpResultadoEquipe.Posicao = pos
      pos += 1
    Next
  End Sub

  Private Sub dtGridView_SelectionChanged(sender As Object, e As EventArgs) Handles dtGridView.SelectionChanged
    dtGridView.ClearSelection()
  End Sub

  Private Sub dtGridView_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dtGridView.CellFormatting
    Select Case dtGridView.Columns(e.ColumnIndex).Name
      Case "colTomada", "colMelhorVoltaCorrida", "colMelhorVoltaClassificacao"
        If e.Value.ToString = New TimeSpan().ToString() Then
          e.CellStyle.ForeColor = Color.White
          e.Value = ""
        End If
      Case "colPunicaoClassificacao", "colPunicaoCorrida"
        If e.Value.ToString = New TimeSpan().ToString() Then
          e.CellStyle.ForeColor = Color.White
          e.Value = ""
        Else
          e.CellStyle.ForeColor = Color.LightCoral
          e.Value = "+ " & DirectCast(e.Value, TimeSpan).ToString("mm\:ss\,ff")
        End If
      Case "colGapLider", "colGapFrente"
        If e.Value.ToString = New TimeSpan().ToString() Then
          e.Value = ""
        Else
          e.Value = "+ " & DirectCast(e.Value, TimeSpan).ToString("mm\:ss\,ff")
        End If
      Case "colEvolucao"
        If CInt(e.Value) = 0 Then
          e.Value = "▬"
          e.CellStyle.ForeColor = Color.LightBlue
          Exit Sub
        End If

        If CInt(e.Value) < 0 Then
          e.Value = "▼ " & e.Value.ToString
          e.CellStyle.ForeColor = Color.LightCoral
          Exit Sub
        End If

        If CInt(e.Value) > 0 Then
          e.Value = "▲ " & e.Value.ToString
          e.CellStyle.ForeColor = Color.LightGreen
          Exit Sub
        End If

      Case "colPneus"
        e.Value = e.Value.ToString & " %"
    End Select
  End Sub
End Class