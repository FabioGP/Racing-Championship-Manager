Imports System.IO

Public Class ChampionshipSelectForm
    Public dirCampeonatoPasta As DirectoryInfo = Nothing
    Public dirCampeonatoEquipes As DirectoryInfo = Nothing
    Public dirCampeonatoPilotos As DirectoryInfo = Nothing
    Public dirCampeonatoEtapas As DirectoryInfo = Nothing

    Public strCampeonatoNome As String = ""
    Public strCampeonatoTemporada As String = ""
    Public strCampeonatoInicio As String = ""

    Private Sub ChampionshipSelectForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim pastaCampeonatos As DirectoryInfo = New DirectoryInfo(Application.StartupPath & "\Campeonatos")
        If Not pastaCampeonatos.Exists Then
            pastaCampeonatos.Create()
        End If

        cboCampeonatos.DataSource = pastaCampeonatos.GetDirectories()
        cboCampeonatos.ValueMember = "Name"
        cboCampeonatos.DisplayMember = "Name"
    End Sub

    Private Sub cboCampeonatos_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCampeonatos.SelectedIndexChanged
        Try
            If Not String.IsNullOrEmpty(cboCampeonatos.Text) Then

                'Busca o diretório do campeonato
                dirCampeonatoPasta = New DirectoryInfo(Application.StartupPath & "\Campeonatos\" & cboCampeonatos.Text)

                'Busca o diretório das equipes do campeonato
                dirCampeonatoEquipes = New DirectoryInfo(dirCampeonatoPasta.FullName & "\Equipes")
                If dirCampeonatoEquipes Is Nothing Then
                    dirCampeonatoEquipes.Create()
                End If
                tbEquipes.Text = dirCampeonatoEquipes.GetFiles("*.txt").Count

                'Busca o diretório dos pilotos do campeonato
                dirCampeonatoPilotos = New DirectoryInfo(dirCampeonatoPasta.FullName & "\Pilotos")
                If dirCampeonatoPilotos Is Nothing Then
                    dirCampeonatoPilotos.Create()
                End If
                tbPilotos.Text = dirCampeonatoPilotos.GetFiles("*.txt").Count

                'Busca o diretório das etapas do campeonato
                dirCampeonatoEtapas = New DirectoryInfo(dirCampeonatoPasta.FullName & "\Etapas")
                If dirCampeonatoEtapas Is Nothing Then
                    dirCampeonatoEtapas.Create()
                End If
                tbEtapas.Text = dirCampeonatoEtapas.GetDirectories().Count

                'Busca as informações do campeonato no arquivo "Campeonato.txt"
                Dim newReader As New StreamReader(dirCampeonatoPasta.FullName & "\Campeonato.txt", System.Text.Encoding.Default)
                While Not newReader.EndOfStream
                    Dim curLine() As String = Split(newReader.ReadLine(), "=")
                    If curLine.Length = 2 Then
                        Select Case curLine(0)
                            Case "Nome"
                                strCampeonatoNome = curLine(1)
                            Case "Temporada"
                                strCampeonatoTemporada = curLine(1)
                            Case "Início"
                                strCampeonatoInicio = curLine(1)
                        End Select
                    End If
                    curLine = Nothing
                    newReader.Peek()
                End While
                newReader.Close()
                newReader = Nothing

                'Mostramos a data início do campeonato
                tbInicio.Text = strCampeonatoInicio

                'Habilitamos o botão OK
                btnOk.Enabled = True
            Else
                tbEquipes.Text = ""
                tbEtapas.Text = ""
                tbInicio.Text = ""
                tbPilotos.Text = ""
                btnOk.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnCriarCampeonato_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Me.Close()
    End Sub

    Private Sub btnVoltar_Click(sender As Object, e As EventArgs) Handles btnVoltar.Click
        Application.Restart()
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Application.Exit()
    End Sub
End Class