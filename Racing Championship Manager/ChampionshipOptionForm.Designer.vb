<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChampionshipOptionForm
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
        Me.btnCarregarCampeonato = New System.Windows.Forms.Button()
        Me.btnCriarCampeonato = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnCarregarCampeonato
        '
        Me.btnCarregarCampeonato.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnCarregarCampeonato.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnCarregarCampeonato.FlatAppearance.BorderSize = 4
        Me.btnCarregarCampeonato.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCarregarCampeonato.Font = New System.Drawing.Font("Calibri", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCarregarCampeonato.ForeColor = System.Drawing.Color.DimGray
        Me.btnCarregarCampeonato.Location = New System.Drawing.Point(381, 91)
        Me.btnCarregarCampeonato.Name = "btnCarregarCampeonato"
        Me.btnCarregarCampeonato.Size = New System.Drawing.Size(354, 335)
        Me.btnCarregarCampeonato.TabIndex = 1
        Me.btnCarregarCampeonato.Text = "Carregar um Campeonato"
        Me.btnCarregarCampeonato.UseVisualStyleBackColor = False
        '
        'btnCriarCampeonato
        '
        Me.btnCriarCampeonato.BackColor = System.Drawing.Color.Gray
        Me.btnCriarCampeonato.Enabled = False
        Me.btnCriarCampeonato.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnCriarCampeonato.FlatAppearance.BorderSize = 4
        Me.btnCriarCampeonato.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCriarCampeonato.Font = New System.Drawing.Font("Calibri", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCriarCampeonato.ForeColor = System.Drawing.Color.DimGray
        Me.btnCriarCampeonato.Location = New System.Drawing.Point(12, 91)
        Me.btnCriarCampeonato.Name = "btnCriarCampeonato"
        Me.btnCriarCampeonato.Size = New System.Drawing.Size(354, 335)
        Me.btnCriarCampeonato.TabIndex = 2
        Me.btnCriarCampeonato.Text = "Criar um Campeonato"
        Me.btnCriarCampeonato.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Calibri", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(723, 79)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "O que deseja fazer?"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ChampionshipOptionForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(747, 438)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCriarCampeonato)
        Me.Controls.Add(Me.btnCarregarCampeonato)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "ChampionshipOptionForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ChampionshipSelectForm"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCarregarCampeonato As System.Windows.Forms.Button
    Friend WithEvents btnCriarCampeonato As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
