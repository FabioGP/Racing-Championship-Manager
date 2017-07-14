Public Class ChampionshipOptionForm
    Public boolCreate As Boolean = False
    Public boolLoad As Boolean = False

    Private Sub btnCriarCampeonato_Click(sender As Object, e As EventArgs) Handles btnCriarCampeonato.Click
        boolCreate = True
        boolLoad = False
        Me.Close()
    End Sub

    Private Sub btnCarregarCampeonato_Click(sender As Object, e As EventArgs) Handles btnCarregarCampeonato.Click
        boolCreate = False
        boolLoad = True
        Me.Close()
    End Sub
End Class