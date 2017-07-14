<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChampionshipSelectForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboCampeonatos = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbEtapas = New System.Windows.Forms.TextBox()
        Me.tbInicio = New System.Windows.Forms.TextBox()
        Me.tbEquipes = New System.Windows.Forms.TextBox()
        Me.tbPilotos = New System.Windows.Forms.TextBox()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.btnVoltar = New System.Windows.Forms.Button()
        Me.PaisBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.btnCancelar = New System.Windows.Forms.Button()
        CType(Me.PaisBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Calibri", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(723, 79)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Escolha seu campeonato:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cboCampeonatos
        '
        Me.cboCampeonatos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCampeonatos.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cboCampeonatos.Font = New System.Drawing.Font("Calibri", 26.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCampeonatos.FormattingEnabled = True
        Me.cboCampeonatos.Location = New System.Drawing.Point(12, 91)
        Me.cboCampeonatos.Name = "cboCampeonatos"
        Me.cboCampeonatos.Size = New System.Drawing.Size(723, 50)
        Me.cboCampeonatos.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Calibri", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 151)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(170, 48)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Etapas:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Calibri", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 199)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(170, 48)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Início:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Calibri", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 247)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(170, 48)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Equipes:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Calibri", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 295)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(170, 48)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Pilotos:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbEtapas
        '
        Me.tbEtapas.Font = New System.Drawing.Font("Calibri", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbEtapas.Location = New System.Drawing.Point(226, 159)
        Me.tbEtapas.Name = "tbEtapas"
        Me.tbEtapas.ReadOnly = True
        Me.tbEtapas.Size = New System.Drawing.Size(509, 40)
        Me.tbEtapas.TabIndex = 9
        Me.tbEtapas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbInicio
        '
        Me.tbInicio.Font = New System.Drawing.Font("Calibri", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbInicio.Location = New System.Drawing.Point(226, 207)
        Me.tbInicio.Name = "tbInicio"
        Me.tbInicio.ReadOnly = True
        Me.tbInicio.Size = New System.Drawing.Size(509, 40)
        Me.tbInicio.TabIndex = 10
        Me.tbInicio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbEquipes
        '
        Me.tbEquipes.Font = New System.Drawing.Font("Calibri", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbEquipes.Location = New System.Drawing.Point(226, 255)
        Me.tbEquipes.Name = "tbEquipes"
        Me.tbEquipes.ReadOnly = True
        Me.tbEquipes.Size = New System.Drawing.Size(509, 40)
        Me.tbEquipes.TabIndex = 11
        Me.tbEquipes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'tbPilotos
        '
        Me.tbPilotos.Font = New System.Drawing.Font("Calibri", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbPilotos.Location = New System.Drawing.Point(226, 303)
        Me.tbPilotos.Name = "tbPilotos"
        Me.tbPilotos.ReadOnly = True
        Me.tbPilotos.Size = New System.Drawing.Size(509, 40)
        Me.tbPilotos.TabIndex = 12
        Me.tbPilotos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnOk
        '
        Me.btnOk.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnOk.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnOk.FlatAppearance.BorderSize = 4
        Me.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOk.Font = New System.Drawing.Font("Calibri", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.ForeColor = System.Drawing.Color.DimGray
        Me.btnOk.Location = New System.Drawing.Point(226, 352)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(163, 73)
        Me.btnOk.TabIndex = 13
        Me.btnOk.Text = "Ok"
        Me.btnOk.UseVisualStyleBackColor = False
        '
        'btnVoltar
        '
        Me.btnVoltar.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnVoltar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnVoltar.FlatAppearance.BorderSize = 4
        Me.btnVoltar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnVoltar.Font = New System.Drawing.Font("Calibri", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVoltar.ForeColor = System.Drawing.Color.DimGray
        Me.btnVoltar.Location = New System.Drawing.Point(399, 352)
        Me.btnVoltar.Name = "btnVoltar"
        Me.btnVoltar.Size = New System.Drawing.Size(163, 73)
        Me.btnVoltar.TabIndex = 14
        Me.btnVoltar.Text = "Voltar"
        Me.btnVoltar.UseVisualStyleBackColor = False
        '
        'PaisBindingSource
        '
        Me.PaisBindingSource.DataSource = GetType(Racing_Championship_Manager.Pais)
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnCancelar.FlatAppearance.BorderSize = 4
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancelar.Font = New System.Drawing.Font("Calibri", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.ForeColor = System.Drawing.Color.DimGray
        Me.btnCancelar.Location = New System.Drawing.Point(572, 352)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(163, 73)
        Me.btnCancelar.TabIndex = 15
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'ChampionshipSelectForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(747, 438)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnVoltar)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.tbPilotos)
        Me.Controls.Add(Me.tbEquipes)
        Me.Controls.Add(Me.tbInicio)
        Me.Controls.Add(Me.tbEtapas)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboCampeonatos)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ChampionshipSelectForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ChampionshipSelectForm"
        CType(Me.PaisBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboCampeonatos As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents tbEtapas As System.Windows.Forms.TextBox
    Friend WithEvents tbInicio As System.Windows.Forms.TextBox
    Friend WithEvents tbEquipes As System.Windows.Forms.TextBox
    Friend WithEvents tbPilotos As System.Windows.Forms.TextBox
    Friend WithEvents PaisBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents btnVoltar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
End Class
