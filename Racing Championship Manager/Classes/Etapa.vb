Imports System.IO

Public Class Etapa
    Implements IComparer(Of Etapa)

    Private strNomeCircuito As String
    Private imgPais As Image
    Private intEtapa As Integer
    Private strTomada As String
    Private strVoltaRecorde As String
    Private intVoltas As Integer
    Private intConsumo As Integer
    Private intMassa As Integer
    Private intDanos As Integer
    Private intDesgaste As Integer
    Private listResultados As List(Of ResultadoEtapa)

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property NomeCircuito() As String
        Get
            Return strNomeCircuito
        End Get
        Set(value As String)
            strNomeCircuito = value
        End Set
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Pais() As Image
        Get
            Return imgPais
        End Get
        Set(value As Image)
            imgPais = value
        End Set
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Etapa() As Integer
        Get
            Return intEtapa
        End Get
        Set(value As Integer)
            intEtapa = value
        End Set
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Tomada() As String
        Get
            Return strTomada
        End Get
        Set(value As String)
            strTomada = value
        End Set
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property VoltaRecorde() As String
        Get
            Return strVoltaRecorde
        End Get
        Set(value As String)
            strVoltaRecorde = value
        End Set
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Voltas() As Integer
        Get
            Return intVoltas
        End Get
        Set(value As Integer)
            intVoltas = value
        End Set
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Consumo() As Integer
        Get
            Return intConsumo
        End Get
        Set(value As Integer)
            intConsumo = value
        End Set
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Desgaste() As Integer
        Get
            Return intDesgaste
        End Get
        Set(value As Integer)
            intDesgaste = value
        End Set
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Massa() As Integer
        Get
            Return intMassa
        End Get
        Set(value As Integer)
            intMassa = value
        End Set
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Danos() As Integer
        Get
            Return intDanos
        End Get
        Set(value As Integer)
            intDanos = value
        End Set
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Resultados() As List(Of ResultadoEtapa)
        Get
            Return listResultados
        End Get
        Set(value As List(Of ResultadoEtapa))
            listResultados = value
        End Set
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_NomeCircuito"></param>
    ''' <param name="_Pais"></param>
    ''' <param name="_Etapa"></param>
    ''' <param name="_Tomada"></param>
    ''' <param name="_Recorde"></param>
    ''' <param name="_Voltas"></param>
    ''' <param name="_Consumo"></param>
    ''' <param name="_Massa"></param>
    ''' <param name="_Danos"></param>
    ''' <param name="_Desgaste"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal _NomeCircuito As String, _
                   Optional ByRef _Pais As Image = Nothing, _
                   Optional ByVal _Etapa As Integer = -1, _
                   Optional ByVal _Tomada As String = "", _
                   Optional ByVal _Recorde As String = "", _
                   Optional ByVal _Voltas As Integer = -1, _
                   Optional ByVal _Consumo As Integer = -1, _
                   Optional ByVal _Massa As Integer = -1, _
                   Optional ByVal _Danos As Integer = -1, _
                   Optional ByVal _Desgaste As Integer = -1)
        NomeCircuito = _NomeCircuito
        Pais = _Pais
        Etapa = _Etapa
        Tomada = _Tomada
        VoltaRecorde = _Recorde
        Voltas = _Voltas
        Consumo = _Consumo
        Massa = _Massa
        Danos = _Danos
        Desgaste = _Desgaste
        Resultados = New List(Of ResultadoEtapa)
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="_CampeonatoPasta"></param>
    ''' <param name="_ListEtapas"></param>
    ''' <param name="_DicPaises"></param>
    ''' <param name="_DicEtapas"></param>
    ''' <remarks></remarks>
    Public Shared Sub Carregar(ByRef _CampeonatoPasta As DirectoryInfo, _
                               ByRef _ListEtapas As List(Of Etapa), _
                               ByRef _DicPaises As Dictionary(Of String, Image), _
                               ByRef _DicEtapas As Dictionary(Of String, Etapa), _
                               ByRef _ListPilotos As List(Of Piloto))
        Try
            _DicEtapas = New Dictionary(Of String, Etapa)
            _ListEtapas = New List(Of Etapa)
            _DicEtapas.Clear()
            _ListEtapas.Clear()

            Dim configDir As DirectoryInfo = New DirectoryInfo(_CampeonatoPasta.FullName & "\Etapas")
            For Each tmpEquipeTxtPath As FileInfo In configDir.GetFiles("Etapa.txt", SearchOption.AllDirectories)
                Dim dicOfParameters As New Dictionary(Of String, Object)
                Dim newReader As New StreamReader(tmpEquipeTxtPath.FullName, System.Text.Encoding.Default)
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

                Dim newEtapa As New Etapa(dicOfParameters("Circuito"), _
                                        _DicPaises(dicOfParameters("País")), _
                                        dicOfParameters("Etapa"), _
                                        dicOfParameters("Tomada"), _
                                        dicOfParameters("Pole"), _
                                        CInt(dicOfParameters("Voltas")), _
                                        CInt(dicOfParameters("Consumo")), _
                                        CInt(dicOfParameters("Massa")), _
                                        CInt(dicOfParameters("Danos")), _
                                        CInt(dicOfParameters("Desgaste")))

                For Each tmpPiloto As Piloto In _ListPilotos
                    newEtapa.Resultados.Add(New ResultadoEtapa(tmpPiloto, newEtapa, tmpPiloto.Equipe))
                Next

                _ListEtapas.Add(newEtapa)
                _DicEtapas.Add(newEtapa.NomeCircuito, newEtapa)
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Compila os resultados das etapas
    ''' </summary>
    ''' <param name="_CampeonatoPasta"></param>
    ''' <param name="_ListEtapas"></param>
    ''' <param name="_DicResultadosPilotos"></param>
    ''' <remarks></remarks>
    Public Shared Sub CompilarResultadosEtapas(ByRef _CampeonatoPasta As DirectoryInfo, _
                                         ByRef _ListEtapas As List(Of Etapa), _
                                         ByRef _DicResultadosPilotos As Dictionary(Of String, Piloto), _
                                         ByRef _DicPontos As Dictionary(Of String, Integer))

        For Each tmpEtapa As Etapa In _ListEtapas
            Dim configDirClassificacao As DirectoryInfo = New DirectoryInfo(_CampeonatoPasta.FullName & "\Etapas\Etapa " & tmpEtapa.Etapa.ToString("00") & "\Classificação")
            Dim configDirCorrida As DirectoryInfo = New DirectoryInfo(_CampeonatoPasta.FullName & "\Etapas\Etapa " & tmpEtapa.Etapa.ToString("00") & "\Corrida")

            'Primeiramente devemos ler os arquivos save da pasta e buscar os tempos de volta de cada piloto
            For Each tmpResultadosTxtPath As FileInfo In configDirClassificacao.GetFiles("*.txt")

                'Devemos ler o arquivo da classificação
                Dim dicParametrosClassificacao As New Dictionary(Of Integer, String)
                Dim newReader As New StreamReader(tmpResultadosTxtPath.FullName, System.Text.Encoding.Default)
                Dim curLine As Integer = 1
                Dim DLQEncontrado As Boolean = False
                Dim PenaltyEncontrado As Boolean = False

                While Not newReader.EndOfStream
                    Dim curSplitedLine() As String = Split(newReader.ReadLine(), " ")
                    If curLine = 7 Then
                        Dim parNo As Integer = 1
                        For Each tmpString As String In curSplitedLine
                            If String.IsNullOrEmpty(tmpString) Then
                                Continue For
                            End If

                            dicParametrosClassificacao.Add(parNo, tmpString)
                            parNo += 1
                        Next
                    End If

                    'DLQ
                    If curSplitedLine(0).Contains("DLQ=") Then
                        DLQEncontrado = True
                        curSplitedLine = Split(curSplitedLine(0), "=")
                        If curSplitedLine.Count = 2 Then
                            dicParametrosClassificacao.Add(dicParametrosClassificacao.Count + 1, CBool(curSplitedLine(1)))
                        End If
                    End If

                    'Penalty
                    If curSplitedLine(0).Contains("PenaltySeconds=") Then
                        PenaltyEncontrado = True
                        curSplitedLine = Split(curSplitedLine(0), "=")
                        If curSplitedLine.Count = 2 Then
                            dicParametrosClassificacao.Add(dicParametrosClassificacao.Count + 1, CInt(curSplitedLine(1)))
                        End If
                    End If

                    curLine += 1
                    newReader.Peek()
                End While
                newReader.Close()
                newReader = Nothing

                If Not DLQEncontrado Then
                    Dim newWriter As New StreamWriter(tmpResultadosTxtPath.FullName, True, System.Text.Encoding.UTF8)
                    newWriter.WriteLine("")
                    newWriter.WriteLine("DLQ=False")
                    newWriter.Close()
                End If

                If Not PenaltyEncontrado Then
                    Dim newWriter As New StreamWriter(tmpResultadosTxtPath.FullName, True, System.Text.Encoding.UTF8)
                    newWriter.WriteLine("")
                    newWriter.WriteLine("PenaltySeconds=0")
                    newWriter.Close()
                End If

                If dicParametrosClassificacao.Count = 0 OrElse Not _DicResultadosPilotos.ContainsKey(dicParametrosClassificacao(1)) Then
                    Continue For
                End If

                If dicParametrosClassificacao.Count <> 0 AndAlso Not _DicResultadosPilotos.ContainsKey(dicParametrosClassificacao(1)) Then
                    MessageBox.Show("Arquivo " & tmpResultadosTxtPath.Name & " de piloto desconhecido. Revisar nome do arquivo da Etapa " & tmpEtapa.Etapa.ToString("00"))
                End If

                Dim curPiloto As Piloto = _DicResultadosPilotos(dicParametrosClassificacao(1))
                For Each tmpResultado As ResultadoEtapa In tmpEtapa.Resultados
                    If tmpResultado.Piloto IsNot Nothing AndAlso tmpResultado.Piloto.Nome = curPiloto.Nome Then
                        If dicParametrosClassificacao.ContainsKey(11) AndAlso CBool(dicParametrosClassificacao(11)) = True Then
                            If _DicPontos.ContainsKey("DLQ") Then
                                tmpResultado.PontosDeadLine1 = _DicPontos("DLQ")
                            Else
                                tmpResultado.PontosDeadLine1 = 0
                            End If
                        Else
                            tmpResultado.PontosDeadLine1 = 0
                        End If

                        If dicParametrosClassificacao.ContainsKey(12) AndAlso IsNumeric(dicParametrosClassificacao(12)) Then
                            tmpResultado.PunicaoClassificacao = CInt(dicParametrosClassificacao(12))
                        Else
                            tmpResultado.PunicaoClassificacao = 0
                        End If

                        tmpResultado.MelhorVoltaClassificacao = FormataTempo(dicParametrosClassificacao(7), tmpResultado.PunicaoClassificacao)
                        Exit For
                    End If
                Next
            Next

            For Each tmpResultadosTxtPath As FileInfo In configDirCorrida.GetFiles("*.txt")
                'Devemos ler o arquivo da classificação
                Dim dicParametrosCorrida As New Dictionary(Of Integer, String)
                Dim newReader As New StreamReader(tmpResultadosTxtPath.FullName, System.Text.Encoding.Default)
                Dim curLine As Integer = 1
                Dim PenaltyEncontrado As Boolean = False

                While Not newReader.EndOfStream
                    Dim curSplitedLine() As String = Split(newReader.ReadLine(), " ")
                    If curLine = 7 Then
                        Dim parNo As Integer = 1
                        For Each tmpString As String In curSplitedLine
                            If String.IsNullOrEmpty(tmpString) Then
                                Continue For
                            End If

                            dicParametrosCorrida.Add(parNo, tmpString)
                            parNo += 1
                        Next
                    End If

                    'Penalty
                    If curSplitedLine(0).Contains("PenaltySeconds=") Then
                        PenaltyEncontrado = True
                        curSplitedLine = Split(curSplitedLine(0), "=")
                        If curSplitedLine.Count = 2 Then
                            dicParametrosCorrida.Add(dicParametrosCorrida.Count + 1, CInt(curSplitedLine(1)))
                        End If
                    End If

                    curLine += 1
                    newReader.Peek()
                End While
                newReader.Close()
                newReader = Nothing

                If Not PenaltyEncontrado Then
                    Dim newWriter As New StreamWriter(tmpResultadosTxtPath.FullName, True, System.Text.Encoding.UTF8)
                    newWriter.WriteLine("")
                    newWriter.WriteLine("PenaltySeconds=0")
                    newWriter.Close()
                End If

                If dicParametrosCorrida.Count = 0 OrElse Not _DicResultadosPilotos.ContainsKey(dicParametrosCorrida(1)) Then
                    Continue For
                End If

                If dicParametrosCorrida.Count <> 0 AndAlso Not _DicResultadosPilotos.ContainsKey(dicParametrosCorrida(1)) Then
                    MessageBox.Show("Arquivo " & tmpResultadosTxtPath.Name & " de piloto desconhecido. Revisar nome do arquivo da Etapa " & tmpEtapa.Etapa.ToString("00"))
                End If

                Dim curPiloto As Piloto = _DicResultadosPilotos(dicParametrosCorrida(1))
                For Each tmpResultado As ResultadoEtapa In tmpEtapa.Resultados
                    If tmpResultado.Piloto IsNot Nothing AndAlso tmpResultado.Piloto.Nome = curPiloto.Nome Then
                        If dicParametrosCorrida.ContainsKey(11) AndAlso IsNumeric(dicParametrosCorrida(11)) Then
                            tmpResultado.PunicaoCorrida = CInt(dicParametrosCorrida(11))
                        Else
                            tmpResultado.PunicaoCorrida = 0
                        End If

                        tmpResultado.MelhorVoltaCorrida = FormataTempo(dicParametrosCorrida(7), 0)
                        tmpResultado.Tomada = FormataTempo(dicParametrosCorrida(9), tmpResultado.PunicaoCorrida)
                        Exit For
                    End If
                Next
            Next

            'Agora devemos calcular o grid de largada
            Dim curPos As Integer = 1
            Dim curMelhorVolta As TimeSpan = Nothing
            For Each tmpResultadoEtapa As ResultadoEtapa In tmpEtapa.Resultados.OrderBy(Function(resultado) resultado.MelhorVoltaClassificacao).ToList()
                If tmpResultadoEtapa.MelhorVoltaClassificacao.Hours = 0 AndAlso tmpResultadoEtapa.MelhorVoltaClassificacao.Minutes = 0 AndAlso tmpResultadoEtapa.MelhorVoltaClassificacao.Seconds = 0 Then
                    tmpResultadoEtapa.PosicaoGrid = tmpEtapa.Resultados.Count
                    tmpResultadoEtapa.ClassificacaoEnviada = False
                    tmpResultadoEtapa.PontosDeadLine1 = -1
                    tmpResultadoEtapa.PontosGrid = 0
                    tmpResultadoEtapa.PontosAproximacao = 0
                    Continue For
                End If

                If curMelhorVolta = Nothing Then
                    curMelhorVolta = tmpResultadoEtapa.MelhorVoltaClassificacao
                Else
                    tmpResultadoEtapa.GapMelhorVolta = tmpResultadoEtapa.MelhorVoltaClassificacao - curMelhorVolta
                End If

                tmpResultadoEtapa.ClassificacaoEnviada = True
                tmpResultadoEtapa.PosicaoGrid = curPos
                curPos += 1

                'Calcula os pontos de classificacao
                Select Case tmpResultadoEtapa.PosicaoGrid
                    Case 1
                        If _DicPontos.ContainsKey("PG" & tmpResultadoEtapa.PosicaoGrid) Then
                            tmpResultadoEtapa.PontosGrid = _DicPontos("PG" & tmpResultadoEtapa.PosicaoGrid)
                        Else
                            tmpResultadoEtapa.PontosGrid = 0
                        End If
                        tmpResultadoEtapa.Piloto.Poles += 1
                    Case 2, 3
                        If _DicPontos.ContainsKey("PG" & tmpResultadoEtapa.PosicaoGrid) Then
                            tmpResultadoEtapa.PontosGrid = _DicPontos("PG" & tmpResultadoEtapa.PosicaoGrid)
                        Else
                            tmpResultadoEtapa.PontosGrid = 0
                        End If
                    Case Else
                        If _DicPontos.ContainsKey("PG" & tmpResultadoEtapa.PosicaoGrid) Then
                            tmpResultadoEtapa.PontosGrid = _DicPontos("PG" & tmpResultadoEtapa.PosicaoGrid)
                        Else
                            tmpResultadoEtapa.PontosGrid = 0
                        End If

                        If tmpResultadoEtapa.GapMelhorVolta.TotalSeconds <= 1 Then
                            If _DicPontos.ContainsKey("PGA") Then
                                tmpResultadoEtapa.PontosAproximacao = _DicPontos("PGA")
                            Else
                                tmpResultadoEtapa.PontosAproximacao = 0
                            End If
                        End If
                End Select
            Next

            'Agora devemos calcular o resultado final
            curPos = 1
            Dim curMelhorTomada As TimeSpan = Nothing
            Dim curTomadaFrente As TimeSpan = Nothing
            For Each tmpResultadoEtapa As ResultadoEtapa In tmpEtapa.Resultados.OrderBy(Function(resultado) resultado.Tomada).ToList()
                If tmpResultadoEtapa.Tomada.Hours = 0 AndAlso tmpResultadoEtapa.Tomada.Minutes = 0 AndAlso tmpResultadoEtapa.Tomada.Seconds = 0 Then
                    tmpResultadoEtapa.PosicaoEtapa = tmpEtapa.Resultados.Count
                    tmpResultadoEtapa.CorridaEnviada = False
                    Continue For
                End If

                If curMelhorTomada = Nothing Then
                    curMelhorTomada = tmpResultadoEtapa.Tomada
                Else
                    tmpResultadoEtapa.GapLider = tmpResultadoEtapa.Tomada - curMelhorTomada
                End If

                If curTomadaFrente <> Nothing Then
                    tmpResultadoEtapa.GapFrente = tmpResultadoEtapa.Tomada - curTomadaFrente
                End If
                curTomadaFrente = tmpResultadoEtapa.Tomada

                tmpResultadoEtapa.CorridaEnviada = True
                tmpResultadoEtapa.PosicaoEtapa = curPos
                curPos += 1

                'Calcula os pontos da etapa
                Select Case tmpResultadoEtapa.PosicaoEtapa
                    Case 1
                        If _DicPontos.ContainsKey("P" & tmpResultadoEtapa.PosicaoEtapa) Then
                            tmpResultadoEtapa.PontosPosicao = _DicPontos("P" & tmpResultadoEtapa.PosicaoEtapa)
                        Else
                            tmpResultadoEtapa.PontosPosicao = 0
                        End If
                        tmpResultadoEtapa.Piloto.Vitorias += 1
                    Case Else
                        If _DicPontos.ContainsKey("P" & tmpResultadoEtapa.PosicaoEtapa) Then
                            tmpResultadoEtapa.PontosPosicao = _DicPontos("P" & tmpResultadoEtapa.PosicaoEtapa)
                        Else
                            tmpResultadoEtapa.PontosPosicao = 0
                        End If
                End Select

                'Calcula os pontos totais da etapa
                tmpResultadoEtapa.PontosTotais = tmpResultadoEtapa.PontosAproximacao + tmpResultadoEtapa.PontosDeadLine1 + tmpResultadoEtapa.PontosGrid + tmpResultadoEtapa.PontosPosicao
            Next
        Next
    End Sub

    ''' <summary>
    ''' Função que monta o tempo do piloto com base no string do arquivo
    ''' </summary>
    ''' <param name="_tempoArquivo"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function FormataTempo(ByVal _tempoArquivo As String, ByVal _punicao As Integer) As TimeSpan
        Dim novoTempo As TimeSpan
        _tempoArquivo = _tempoArquivo.Replace(",", "|")
        _tempoArquivo = _tempoArquivo.Replace(":", "|")

        Dim intDays As Integer = 0
        Dim intHours As Integer = 0
        Dim intMinutes As Integer = 0
        Dim intSeconds As Integer = 0
        Dim intMiliSeconds As Integer = 0

        Dim strTempoSplited() As String = Split(_tempoArquivo, "|")
        If strTempoSplited.Count = 2 Then
            intSeconds = CInt(strTempoSplited(0)) + _punicao
            intMiliSeconds = CInt(strTempoSplited(1)) * 10
        End If

        If strTempoSplited.Count = 3 Then
            intMinutes = CInt(strTempoSplited(0))
            intSeconds = CInt(strTempoSplited(1)) + _punicao
            intMiliSeconds = CInt(strTempoSplited(2)) * 10
        End If

        novoTempo = New TimeSpan(intDays, intHours, intMinutes, intSeconds, intMiliSeconds)
        Return novoTempo
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="x"></param>
    ''' <param name="y"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function Compare(x As Etapa, y As Etapa) As Integer Implements IComparer(Of Etapa).Compare
        Return String.Compare(x.Etapa, y.Etapa)
    End Function

End Class
