<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
  Inherits System.Windows.Forms.Form

  'Form overrides dispose to clean up the component list.
  <System.Diagnostics.DebuggerNonUserCode()>
  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    Try
      If disposing AndAlso components IsNot Nothing Then
        components.Dispose()
      End If
    Finally
      MyBase.Dispose(disposing)
    End Try
  End Sub

  'Required by the Windows Form Designer
  Private components As System.ComponentModel.IContainer

  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.  
  'Do not modify it using the code editor.
  <System.Diagnostics.DebuggerStepThrough()>
  Private Sub InitializeComponent()
    Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
    Me.mainMenu = New System.Windows.Forms.MenuStrip()
    Me.mnuMainMenu = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuReiniciar = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuSair = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuEquipes = New System.Windows.Forms.ToolStripMenuItem()
    Me.PilotosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuPilotosPorNome = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuPilotosPorEquipe = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuPilotosPorPole = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuPilotosPorVitorias = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuPilotosPorTitulos = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuPilotosPorIdade = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuCalendario = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuEtapas = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuMundialPilotos = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuMundialConstrutores = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuBtnMenu = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuBtnReiniciar = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuBtnSair = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuBtnEquipes = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuBtnPilotos = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuBtnPilotosPorNome = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuBtnPilotosPorEquipe = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuBtnPilotosPorTitulos = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuBtnPilotosPorVitorias = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuBtnPilotosPorPoles = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuBtnPilotosPorIdade = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuBtnCalendario = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuBtnEtapas = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuBtnMundialPilotos = New System.Windows.Forms.ToolStripMenuItem()
    Me.mnuBtnMundialConstrutores = New System.Windows.Forms.ToolStripMenuItem()
    Me.dtGridView = New System.Windows.Forms.DataGridView()
    Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
    Me.lblTitle = New System.Windows.Forms.Label()
    Me.lblDescription = New System.Windows.Forms.Label()
    Me.imgTitle = New System.Windows.Forms.PictureBox()
    Me.imgPos1Driver = New System.Windows.Forms.PictureBox()
    Me.lblPos1Position = New System.Windows.Forms.Label()
    Me.lblPos1DriverName = New System.Windows.Forms.Label()
    Me.lblPos2DriverName = New System.Windows.Forms.Label()
    Me.lblPos2Position = New System.Windows.Forms.Label()
    Me.imgPos2Driver = New System.Windows.Forms.PictureBox()
    Me.lblPos3DriverName = New System.Windows.Forms.Label()
    Me.lblPos3Position = New System.Windows.Forms.Label()
    Me.imgPos3Driver = New System.Windows.Forms.PictureBox()
    Me.imgPos1Trophy = New System.Windows.Forms.PictureBox()
    Me.imgPos2Trophy = New System.Windows.Forms.PictureBox()
    Me.imgPos3Trophy = New System.Windows.Forms.PictureBox()
    Me.mainMenu.SuspendLayout()
    CType(Me.dtGridView, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.imgTitle, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.imgPos1Driver, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.imgPos2Driver, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.imgPos3Driver, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.imgPos1Trophy, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.imgPos2Trophy, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.imgPos3Trophy, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'mainMenu
    '
    Me.mainMenu.BackColor = System.Drawing.SystemColors.ControlLight
    Me.mainMenu.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.mainMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuMainMenu, Me.mnuEquipes, Me.PilotosToolStripMenuItem, Me.mnuCalendario, Me.mnuEtapas, Me.mnuMundialPilotos, Me.mnuMundialConstrutores})
    Me.mainMenu.Location = New System.Drawing.Point(0, 0)
    Me.mainMenu.Name = "mainMenu"
    Me.mainMenu.Size = New System.Drawing.Size(1605, 26)
    Me.mainMenu.TabIndex = 1
    Me.mainMenu.Text = "MenuStrip1"
    '
    'mnuMainMenu
    '
    Me.mnuMainMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuReiniciar, Me.mnuSair})
    Me.mnuMainMenu.Name = "mnuMainMenu"
    Me.mnuMainMenu.Size = New System.Drawing.Size(57, 22)
    Me.mnuMainMenu.Text = "Menu"
    '
    'mnuReiniciar
    '
    Me.mnuReiniciar.Name = "mnuReiniciar"
    Me.mnuReiniciar.Size = New System.Drawing.Size(130, 22)
    Me.mnuReiniciar.Text = "Reiniciar"
    '
    'mnuSair
    '
    Me.mnuSair.Name = "mnuSair"
    Me.mnuSair.Size = New System.Drawing.Size(130, 22)
    Me.mnuSair.Text = "Sair"
    '
    'mnuEquipes
    '
    Me.mnuEquipes.Name = "mnuEquipes"
    Me.mnuEquipes.Size = New System.Drawing.Size(69, 22)
    Me.mnuEquipes.Text = "Equipes"
    '
    'PilotosToolStripMenuItem
    '
    Me.PilotosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuPilotosPorNome, Me.mnuPilotosPorEquipe, Me.mnuPilotosPorPole, Me.mnuPilotosPorVitorias, Me.mnuPilotosPorTitulos, Me.mnuPilotosPorIdade})
    Me.PilotosToolStripMenuItem.Name = "PilotosToolStripMenuItem"
    Me.PilotosToolStripMenuItem.Size = New System.Drawing.Size(63, 22)
    Me.PilotosToolStripMenuItem.Text = "Pilotos"
    '
    'mnuPilotosPorNome
    '
    Me.mnuPilotosPorNome.Name = "mnuPilotosPorNome"
    Me.mnuPilotosPorNome.Size = New System.Drawing.Size(148, 22)
    Me.mnuPilotosPorNome.Text = "Por Nome"
    '
    'mnuPilotosPorEquipe
    '
    Me.mnuPilotosPorEquipe.Name = "mnuPilotosPorEquipe"
    Me.mnuPilotosPorEquipe.Size = New System.Drawing.Size(148, 22)
    Me.mnuPilotosPorEquipe.Text = "Por Equipe"
    '
    'mnuPilotosPorPole
    '
    Me.mnuPilotosPorPole.Name = "mnuPilotosPorPole"
    Me.mnuPilotosPorPole.Size = New System.Drawing.Size(148, 22)
    Me.mnuPilotosPorPole.Text = "Por Poles"
    '
    'mnuPilotosPorVitorias
    '
    Me.mnuPilotosPorVitorias.Name = "mnuPilotosPorVitorias"
    Me.mnuPilotosPorVitorias.Size = New System.Drawing.Size(148, 22)
    Me.mnuPilotosPorVitorias.Text = "Por Vitórias"
    '
    'mnuPilotosPorTitulos
    '
    Me.mnuPilotosPorTitulos.Name = "mnuPilotosPorTitulos"
    Me.mnuPilotosPorTitulos.Size = New System.Drawing.Size(148, 22)
    Me.mnuPilotosPorTitulos.Text = "Por Títulos"
    '
    'mnuPilotosPorIdade
    '
    Me.mnuPilotosPorIdade.Name = "mnuPilotosPorIdade"
    Me.mnuPilotosPorIdade.Size = New System.Drawing.Size(148, 22)
    Me.mnuPilotosPorIdade.Text = "Por Idade"
    '
    'mnuCalendario
    '
    Me.mnuCalendario.Name = "mnuCalendario"
    Me.mnuCalendario.Size = New System.Drawing.Size(87, 22)
    Me.mnuCalendario.Text = "Calendário"
    '
    'mnuEtapas
    '
    Me.mnuEtapas.Name = "mnuEtapas"
    Me.mnuEtapas.Size = New System.Drawing.Size(60, 22)
    Me.mnuEtapas.Text = "Etapas"
    '
    'mnuMundialPilotos
    '
    Me.mnuMundialPilotos.Name = "mnuMundialPilotos"
    Me.mnuMundialPilotos.Size = New System.Drawing.Size(137, 22)
    Me.mnuMundialPilotos.Text = "Mundial de Pilotos"
    '
    'mnuMundialConstrutores
    '
    Me.mnuMundialConstrutores.Name = "mnuMundialConstrutores"
    Me.mnuMundialConstrutores.Size = New System.Drawing.Size(174, 22)
    Me.mnuMundialConstrutores.Text = "Mundial de Construtores"
    '
    'mnuBtnMenu
    '
    Me.mnuBtnMenu.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuBtnReiniciar, Me.mnuBtnSair})
    Me.mnuBtnMenu.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.mnuBtnMenu.Name = "mnuBtnMenu"
    Me.mnuBtnMenu.Size = New System.Drawing.Size(57, 22)
    Me.mnuBtnMenu.Text = "Menu"
    '
    'mnuBtnReiniciar
    '
    Me.mnuBtnReiniciar.Name = "mnuBtnReiniciar"
    Me.mnuBtnReiniciar.Size = New System.Drawing.Size(130, 22)
    Me.mnuBtnReiniciar.Text = "Reiniciar"
    '
    'mnuBtnSair
    '
    Me.mnuBtnSair.Name = "mnuBtnSair"
    Me.mnuBtnSair.Size = New System.Drawing.Size(130, 22)
    Me.mnuBtnSair.Text = "Sair"
    '
    'mnuBtnEquipes
    '
    Me.mnuBtnEquipes.Name = "mnuBtnEquipes"
    Me.mnuBtnEquipes.Size = New System.Drawing.Size(69, 22)
    Me.mnuBtnEquipes.Text = "Equipes"
    '
    'mnuBtnPilotos
    '
    Me.mnuBtnPilotos.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuBtnPilotosPorNome, Me.mnuBtnPilotosPorEquipe, Me.mnuBtnPilotosPorTitulos, Me.mnuBtnPilotosPorVitorias, Me.mnuBtnPilotosPorPoles, Me.mnuBtnPilotosPorIdade})
    Me.mnuBtnPilotos.Name = "mnuBtnPilotos"
    Me.mnuBtnPilotos.Size = New System.Drawing.Size(63, 22)
    Me.mnuBtnPilotos.Text = "Pilotos"
    '
    'mnuBtnPilotosPorNome
    '
    Me.mnuBtnPilotosPorNome.Name = "mnuBtnPilotosPorNome"
    Me.mnuBtnPilotosPorNome.Size = New System.Drawing.Size(134, 22)
    Me.mnuBtnPilotosPorNome.Text = "Por Nome"
    '
    'mnuBtnPilotosPorEquipe
    '
    Me.mnuBtnPilotosPorEquipe.Name = "mnuBtnPilotosPorEquipe"
    Me.mnuBtnPilotosPorEquipe.Size = New System.Drawing.Size(134, 22)
    Me.mnuBtnPilotosPorEquipe.Text = "Por Equipe"
    '
    'mnuBtnPilotosPorTitulos
    '
    Me.mnuBtnPilotosPorTitulos.Name = "mnuBtnPilotosPorTitulos"
    Me.mnuBtnPilotosPorTitulos.Size = New System.Drawing.Size(134, 22)
    Me.mnuBtnPilotosPorTitulos.Text = "Por Títulos"
    '
    'mnuBtnPilotosPorVitorias
    '
    Me.mnuBtnPilotosPorVitorias.Name = "mnuBtnPilotosPorVitorias"
    Me.mnuBtnPilotosPorVitorias.Size = New System.Drawing.Size(134, 22)
    Me.mnuBtnPilotosPorVitorias.Text = "Por Vitórias"
    '
    'mnuBtnPilotosPorPoles
    '
    Me.mnuBtnPilotosPorPoles.Name = "mnuBtnPilotosPorPoles"
    Me.mnuBtnPilotosPorPoles.Size = New System.Drawing.Size(134, 22)
    Me.mnuBtnPilotosPorPoles.Text = "Por Poles"
    '
    'mnuBtnPilotosPorIdade
    '
    Me.mnuBtnPilotosPorIdade.Name = "mnuBtnPilotosPorIdade"
    Me.mnuBtnPilotosPorIdade.Size = New System.Drawing.Size(134, 22)
    Me.mnuBtnPilotosPorIdade.Text = "Por Idade"
    '
    'mnuBtnCalendario
    '
    Me.mnuBtnCalendario.Name = "mnuBtnCalendario"
    Me.mnuBtnCalendario.Size = New System.Drawing.Size(87, 22)
    Me.mnuBtnCalendario.Text = "Calendário"
    '
    'mnuBtnEtapas
    '
    Me.mnuBtnEtapas.Name = "mnuBtnEtapas"
    Me.mnuBtnEtapas.Size = New System.Drawing.Size(60, 22)
    Me.mnuBtnEtapas.Text = "Etapas"
    '
    'mnuBtnMundialPilotos
    '
    Me.mnuBtnMundialPilotos.Name = "mnuBtnMundialPilotos"
    Me.mnuBtnMundialPilotos.Size = New System.Drawing.Size(137, 22)
    Me.mnuBtnMundialPilotos.Text = "Mundial de Pilotos"
    '
    'mnuBtnMundialConstrutores
    '
    Me.mnuBtnMundialConstrutores.Name = "mnuBtnMundialConstrutores"
    Me.mnuBtnMundialConstrutores.Size = New System.Drawing.Size(174, 22)
    Me.mnuBtnMundialConstrutores.Text = "Mundial de Construtores"
    '
    'dtGridView
    '
    Me.dtGridView.AllowUserToAddRows = False
    Me.dtGridView.AllowUserToDeleteRows = False
    Me.dtGridView.AllowUserToResizeColumns = False
    Me.dtGridView.AllowUserToResizeRows = False
    DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
    Me.dtGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
    Me.dtGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
    Me.dtGridView.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
    Me.dtGridView.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.dtGridView.CausesValidation = False
    Me.dtGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
    Me.dtGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable
    Me.dtGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
    DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
    DataGridViewCellStyle2.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Bold)
    DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
    DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.dtGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
    Me.dtGridView.ColumnHeadersHeight = 40
    Me.dtGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
    DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
    DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
    DataGridViewCellStyle3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
    DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.AliceBlue
    DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
    DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
    Me.dtGridView.DefaultCellStyle = DataGridViewCellStyle3
    Me.dtGridView.GridColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
    Me.dtGridView.Location = New System.Drawing.Point(12, 91)
    Me.dtGridView.MultiSelect = False
    Me.dtGridView.Name = "dtGridView"
    Me.dtGridView.ReadOnly = True
    Me.dtGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
    DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
    DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
    DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    DataGridViewCellStyle4.ForeColor = System.Drawing.Color.White
    DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
    DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
    DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
    Me.dtGridView.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
    Me.dtGridView.RowHeadersVisible = False
    Me.dtGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
    DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
    DataGridViewCellStyle5.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.dtGridView.RowsDefaultCellStyle = DataGridViewCellStyle5
    Me.dtGridView.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
    Me.dtGridView.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.dtGridView.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.White
    Me.dtGridView.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Transparent
    Me.dtGridView.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Transparent
    Me.dtGridView.RowTemplate.Height = 28
    Me.dtGridView.RowTemplate.ReadOnly = True
    Me.dtGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
    Me.dtGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
    Me.dtGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
    Me.dtGridView.Size = New System.Drawing.Size(1581, 910)
    Me.dtGridView.TabIndex = 5
    '
    'DataGridViewTextBoxColumn1
    '
    Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
    Me.DataGridViewTextBoxColumn1.DataPropertyName = "Equipe"
    Me.DataGridViewTextBoxColumn1.HeaderText = "Equipe"
    Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
    Me.DataGridViewTextBoxColumn1.ReadOnly = True
    '
    'lblTitle
    '
    Me.lblTitle.AutoSize = True
    Me.lblTitle.BackColor = System.Drawing.Color.Transparent
    Me.lblTitle.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblTitle.ForeColor = System.Drawing.Color.White
    Me.lblTitle.Location = New System.Drawing.Point(64, 40)
    Me.lblTitle.Name = "lblTitle"
    Me.lblTitle.Size = New System.Drawing.Size(30, 26)
    Me.lblTitle.TabIndex = 7
    Me.lblTitle.Text = "---"
    '
    'lblDescription
    '
    Me.lblDescription.AutoSize = True
    Me.lblDescription.BackColor = System.Drawing.Color.Transparent
    Me.lblDescription.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblDescription.ForeColor = System.Drawing.Color.White
    Me.lblDescription.Location = New System.Drawing.Point(65, 66)
    Me.lblDescription.Name = "lblDescription"
    Me.lblDescription.Size = New System.Drawing.Size(24, 19)
    Me.lblDescription.TabIndex = 8
    Me.lblDescription.Text = "---"
    '
    'imgTitle
    '
    Me.imgTitle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
    Me.imgTitle.Location = New System.Drawing.Point(12, 40)
    Me.imgTitle.Name = "imgTitle"
    Me.imgTitle.Size = New System.Drawing.Size(49, 45)
    Me.imgTitle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
    Me.imgTitle.TabIndex = 9
    Me.imgTitle.TabStop = False
    '
    'imgPos1Driver
    '
    Me.imgPos1Driver.BackColor = System.Drawing.Color.Transparent
    Me.imgPos1Driver.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
    Me.imgPos1Driver.Location = New System.Drawing.Point(860, 36)
    Me.imgPos1Driver.Name = "imgPos1Driver"
    Me.imgPos1Driver.Size = New System.Drawing.Size(49, 45)
    Me.imgPos1Driver.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
    Me.imgPos1Driver.TabIndex = 10
    Me.imgPos1Driver.TabStop = False
    Me.imgPos1Driver.Visible = False
    '
    'lblPos1Position
    '
    Me.lblPos1Position.AutoSize = True
    Me.lblPos1Position.BackColor = System.Drawing.Color.Transparent
    Me.lblPos1Position.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblPos1Position.ForeColor = System.Drawing.Color.White
    Me.lblPos1Position.Location = New System.Drawing.Point(916, 36)
    Me.lblPos1Position.Name = "lblPos1Position"
    Me.lblPos1Position.Size = New System.Drawing.Size(32, 26)
    Me.lblPos1Position.TabIndex = 13
    Me.lblPos1Position.Text = "1º"
    Me.lblPos1Position.Visible = False
    '
    'lblPos1DriverName
    '
    Me.lblPos1DriverName.AutoSize = True
    Me.lblPos1DriverName.BackColor = System.Drawing.Color.Transparent
    Me.lblPos1DriverName.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblPos1DriverName.ForeColor = System.Drawing.Color.White
    Me.lblPos1DriverName.Location = New System.Drawing.Point(916, 64)
    Me.lblPos1DriverName.Name = "lblPos1DriverName"
    Me.lblPos1DriverName.Size = New System.Drawing.Size(24, 19)
    Me.lblPos1DriverName.TabIndex = 14
    Me.lblPos1DriverName.Text = "---"
    Me.lblPos1DriverName.Visible = False
    '
    'lblPos2DriverName
    '
    Me.lblPos2DriverName.AutoSize = True
    Me.lblPos2DriverName.BackColor = System.Drawing.Color.Transparent
    Me.lblPos2DriverName.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblPos2DriverName.ForeColor = System.Drawing.Color.White
    Me.lblPos2DriverName.Location = New System.Drawing.Point(1184, 64)
    Me.lblPos2DriverName.Name = "lblPos2DriverName"
    Me.lblPos2DriverName.Size = New System.Drawing.Size(24, 19)
    Me.lblPos2DriverName.TabIndex = 17
    Me.lblPos2DriverName.Text = "---"
    Me.lblPos2DriverName.Visible = False
    '
    'lblPos2Position
    '
    Me.lblPos2Position.AutoSize = True
    Me.lblPos2Position.BackColor = System.Drawing.Color.Transparent
    Me.lblPos2Position.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblPos2Position.ForeColor = System.Drawing.Color.White
    Me.lblPos2Position.Location = New System.Drawing.Point(1184, 36)
    Me.lblPos2Position.Name = "lblPos2Position"
    Me.lblPos2Position.Size = New System.Drawing.Size(32, 26)
    Me.lblPos2Position.TabIndex = 16
    Me.lblPos2Position.Text = "2º"
    Me.lblPos2Position.Visible = False
    '
    'imgPos2Driver
    '
    Me.imgPos2Driver.BackColor = System.Drawing.Color.Transparent
    Me.imgPos2Driver.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
    Me.imgPos2Driver.Location = New System.Drawing.Point(1128, 36)
    Me.imgPos2Driver.Name = "imgPos2Driver"
    Me.imgPos2Driver.Size = New System.Drawing.Size(49, 45)
    Me.imgPos2Driver.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
    Me.imgPos2Driver.TabIndex = 15
    Me.imgPos2Driver.TabStop = False
    Me.imgPos2Driver.Visible = False
    '
    'lblPos3DriverName
    '
    Me.lblPos3DriverName.AutoSize = True
    Me.lblPos3DriverName.BackColor = System.Drawing.Color.Transparent
    Me.lblPos3DriverName.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblPos3DriverName.ForeColor = System.Drawing.Color.White
    Me.lblPos3DriverName.Location = New System.Drawing.Point(1448, 64)
    Me.lblPos3DriverName.Name = "lblPos3DriverName"
    Me.lblPos3DriverName.Size = New System.Drawing.Size(24, 19)
    Me.lblPos3DriverName.TabIndex = 20
    Me.lblPos3DriverName.Text = "---"
    Me.lblPos3DriverName.Visible = False
    '
    'lblPos3Position
    '
    Me.lblPos3Position.AutoSize = True
    Me.lblPos3Position.BackColor = System.Drawing.Color.Transparent
    Me.lblPos3Position.Font = New System.Drawing.Font("Calibri", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblPos3Position.ForeColor = System.Drawing.Color.White
    Me.lblPos3Position.Location = New System.Drawing.Point(1448, 36)
    Me.lblPos3Position.Name = "lblPos3Position"
    Me.lblPos3Position.Size = New System.Drawing.Size(32, 26)
    Me.lblPos3Position.TabIndex = 19
    Me.lblPos3Position.Text = "3º"
    Me.lblPos3Position.Visible = False
    '
    'imgPos3Driver
    '
    Me.imgPos3Driver.BackColor = System.Drawing.Color.Transparent
    Me.imgPos3Driver.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
    Me.imgPos3Driver.Location = New System.Drawing.Point(1392, 36)
    Me.imgPos3Driver.Name = "imgPos3Driver"
    Me.imgPos3Driver.Size = New System.Drawing.Size(49, 45)
    Me.imgPos3Driver.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
    Me.imgPos3Driver.TabIndex = 18
    Me.imgPos3Driver.TabStop = False
    Me.imgPos3Driver.Visible = False
    '
    'imgPos1Trophy
    '
    Me.imgPos1Trophy.BackColor = System.Drawing.Color.Transparent
    Me.imgPos1Trophy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
    Me.imgPos1Trophy.Image = CType(resources.GetObject("imgPos1Trophy.Image"), System.Drawing.Image)
    Me.imgPos1Trophy.Location = New System.Drawing.Point(808, 36)
    Me.imgPos1Trophy.Name = "imgPos1Trophy"
    Me.imgPos1Trophy.Size = New System.Drawing.Size(49, 45)
    Me.imgPos1Trophy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
    Me.imgPos1Trophy.TabIndex = 21
    Me.imgPos1Trophy.TabStop = False
    Me.imgPos1Trophy.Visible = False
    '
    'imgPos2Trophy
    '
    Me.imgPos2Trophy.BackColor = System.Drawing.Color.Transparent
    Me.imgPos2Trophy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
    Me.imgPos2Trophy.Image = CType(resources.GetObject("imgPos2Trophy.Image"), System.Drawing.Image)
    Me.imgPos2Trophy.InitialImage = Nothing
    Me.imgPos2Trophy.Location = New System.Drawing.Point(1076, 36)
    Me.imgPos2Trophy.Name = "imgPos2Trophy"
    Me.imgPos2Trophy.Size = New System.Drawing.Size(49, 45)
    Me.imgPos2Trophy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
    Me.imgPos2Trophy.TabIndex = 22
    Me.imgPos2Trophy.TabStop = False
    Me.imgPos2Trophy.Visible = False
    '
    'imgPos3Trophy
    '
    Me.imgPos3Trophy.BackColor = System.Drawing.Color.Transparent
    Me.imgPos3Trophy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
    Me.imgPos3Trophy.Image = CType(resources.GetObject("imgPos3Trophy.Image"), System.Drawing.Image)
    Me.imgPos3Trophy.Location = New System.Drawing.Point(1340, 36)
    Me.imgPos3Trophy.Name = "imgPos3Trophy"
    Me.imgPos3Trophy.Size = New System.Drawing.Size(49, 45)
    Me.imgPos3Trophy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
    Me.imgPos3Trophy.TabIndex = 23
    Me.imgPos3Trophy.TabStop = False
    Me.imgPos3Trophy.Visible = False
    '
    'MainForm
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer), CType(CType(20, Byte), Integer))
    Me.ClientSize = New System.Drawing.Size(1605, 1013)
    Me.Controls.Add(Me.imgPos3Trophy)
    Me.Controls.Add(Me.imgPos2Trophy)
    Me.Controls.Add(Me.imgPos1Trophy)
    Me.Controls.Add(Me.lblPos3DriverName)
    Me.Controls.Add(Me.lblPos3Position)
    Me.Controls.Add(Me.imgPos3Driver)
    Me.Controls.Add(Me.lblPos2DriverName)
    Me.Controls.Add(Me.lblPos2Position)
    Me.Controls.Add(Me.imgPos2Driver)
    Me.Controls.Add(Me.lblPos1DriverName)
    Me.Controls.Add(Me.lblPos1Position)
    Me.Controls.Add(Me.imgPos1Driver)
    Me.Controls.Add(Me.imgTitle)
    Me.Controls.Add(Me.lblDescription)
    Me.Controls.Add(Me.lblTitle)
    Me.Controls.Add(Me.dtGridView)
    Me.Controls.Add(Me.mainMenu)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
    Me.MainMenuStrip = Me.mainMenu
    Me.Name = "MainForm"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Form1"
    Me.mainMenu.ResumeLayout(False)
    Me.mainMenu.PerformLayout()
    CType(Me.dtGridView, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.imgTitle, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.imgPos1Driver, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.imgPos2Driver, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.imgPos3Driver, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.imgPos1Trophy, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.imgPos2Trophy, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.imgPos3Trophy, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents mainMenu As System.Windows.Forms.MenuStrip
  Friend WithEvents mnuBtnMenu As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuBtnReiniciar As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuBtnSair As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuBtnEtapas As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuBtnEquipes As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuBtnPilotos As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuBtnMundialPilotos As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuBtnMundialConstrutores As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents dtGridView As System.Windows.Forms.DataGridView
  Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
  Friend WithEvents mnuBtnCalendario As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuBtnPilotosPorNome As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuBtnPilotosPorEquipe As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuBtnPilotosPorTitulos As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuBtnPilotosPorVitorias As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuBtnPilotosPorPoles As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuBtnPilotosPorIdade As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuMainMenu As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuReiniciar As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuSair As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuEquipes As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents PilotosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuEtapas As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuMundialPilotos As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuMundialConstrutores As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuPilotosPorNome As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuPilotosPorEquipe As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuPilotosPorPole As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuPilotosPorVitorias As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuPilotosPorTitulos As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuPilotosPorIdade As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents mnuCalendario As System.Windows.Forms.ToolStripMenuItem
  Friend WithEvents lblTitle As System.Windows.Forms.Label
  Friend WithEvents lblDescription As System.Windows.Forms.Label
  Friend WithEvents imgTitle As System.Windows.Forms.PictureBox
  Friend WithEvents imgPos1Driver As PictureBox
  Friend WithEvents lblPos1Position As Label
  Friend WithEvents lblPos1DriverName As Label
  Friend WithEvents lblPos2DriverName As Label
  Friend WithEvents lblPos2Position As Label
  Friend WithEvents imgPos2Driver As PictureBox
  Friend WithEvents lblPos3DriverName As Label
  Friend WithEvents lblPos3Position As Label
  Friend WithEvents imgPos3Driver As PictureBox
  Friend WithEvents imgPos1Trophy As PictureBox
  Friend WithEvents imgPos2Trophy As PictureBox
  Friend WithEvents imgPos3Trophy As PictureBox
End Class
