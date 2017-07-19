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
  Private boolConcluida As Integer
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
  ''' Define se a etapa foi concluída ou não
  ''' </summary>
  ''' <returns></returns>
  Public Property Concluida As Boolean
    Get
      Return boolConcluida
    End Get
    Set(value As Boolean)
      boolConcluida = value
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
  Public Sub New(ByVal _NomeCircuito As String,
                 Optional ByRef _Pais As Image = Nothing,
                 Optional ByVal _Etapa As Integer = -1,
                 Optional ByVal _Tomada As String = "",
                 Optional ByVal _Recorde As String = "",
                 Optional ByVal _Voltas As Integer = -1,
                 Optional ByVal _Consumo As Integer = -1,
                 Optional ByVal _Massa As Integer = -1,
                 Optional ByVal _Danos As Integer = -1,
                 Optional ByVal _Desgaste As Integer = -1,
                 Optional ByVal _Concluida As Boolean = False)
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
    Concluida = _Concluida
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
  Public Shared Sub Carregar(ByRef _CampeonatoPasta As DirectoryInfo,
                             ByRef _ListEtapas As List(Of Etapa),
                             ByRef _DicPaises As Dictionary(Of String, Image),
                             ByRef _DicEtapas As Dictionary(Of String, Etapa),
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

        Dim newEtapa As New Etapa(dicOfParameters("Circuito"),
                                _DicPaises(dicOfParameters("País")),
                                dicOfParameters("Etapa"),
                                dicOfParameters("Tomada"),
                                dicOfParameters("Pole"),
                                CInt(dicOfParameters("Voltas")),
                                CInt(dicOfParameters("Consumo")),
                                CInt(dicOfParameters("Massa")),
                                CInt(dicOfParameters("Danos")),
                                CInt(dicOfParameters("Desgaste")),
                                CBool(dicOfParameters("Concluida")))

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
  Public Shared Sub CompilarResultadosEtapas(ByRef _CampeonatoPasta As DirectoryInfo,
                                       ByRef _ListEtapas As List(Of Etapa),
                                       ByRef _DicResultadosPilotos As Dictionary(Of String, Piloto),
                                       ByRef _DicPontos As Dictionary(Of String, Integer),
                                       ByRef _DicPontosAproximacaoClassificacao As Dictionary(Of TimeSpan, Integer))

    For Each tmpEtapa As Etapa In _ListEtapas
      Dim configDirClassificacao As DirectoryInfo = New DirectoryInfo(_CampeonatoPasta.FullName & "\Etapas\Etapa " & tmpEtapa.Etapa.ToString("00") & "\Classificação")
      Dim configDirCorrida As DirectoryInfo = New DirectoryInfo(_CampeonatoPasta.FullName & "\Etapas\Etapa " & tmpEtapa.Etapa.ToString("00") & "\Corrida")

      'Primeiramente devemos ler os arquivos save da pasta e buscar os tempos de volta de cada piloto
      For Each tmpResultadosTxtPath As FileInfo In configDirClassificacao.GetFiles("*.txt")

        'Devemos ler o arquivo da classificação
        Dim dicParametrosClassificacao As New Dictionary(Of String, String)
        Dim newReader As New StreamReader(tmpResultadosTxtPath.FullName, System.Text.Encoding.Default)
        Dim curLine As Integer = 1
        Dim PenaltyEncontrado As Boolean = False
        Dim CriterioUsuarioEncontrado As Boolean = False

        While Not newReader.EndOfStream
          Dim rawLine As String = newReader.ReadLine()
          Dim curSplitedLine() As String = Split(rawLine, " ")

          'RESULTADOS DO PILOTO
          If curLine = 7 Then
            Dim parNo As Integer = 1
            For Each tmpString As String In curSplitedLine
              If String.IsNullOrEmpty(tmpString) Then
                Continue For
              End If

              Select Case parNo
                Case 1
                  dicParametrosClassificacao.Add("DLQ_DRIVER", tmpString)
                Case 2
                  dicParametrosClassificacao.Add("DLQ_DRIVERTYPE", tmpString)
                Case 3
                  dicParametrosClassificacao.Add("DLQ_CAR", tmpString)
                Case 4
                  dicParametrosClassificacao.Add("DLQ_POSITION", tmpString)
                Case 5
                  dicParametrosClassificacao.Add("DLQ_POINTS", tmpString)
                Case 6
                  dicParametrosClassificacao.Add("DLQ_FINISH", tmpString)
                Case 7
                  dicParametrosClassificacao.Add("DLQ_FASTESTLAP", tmpString)
                Case 8
                  dicParametrosClassificacao.Add("DLQ_KMPH", tmpString)
                Case 9
                  dicParametrosClassificacao.Add("DLQ_TOTALTIME", tmpString)
                Case 10
                  dicParametrosClassificacao.Add("DLQ_GAP", tmpString)
              End Select

              parNo += 1
            Next
          End If

          'Penalty
          If curSplitedLine(0).Contains("Penalty=") Then
            PenaltyEncontrado = True
            curSplitedLine = Split(curSplitedLine(0), "=")
            If curSplitedLine.Count = 2 Then
              dicParametrosClassificacao.Add("DLQ_PENALTY", curSplitedLine(1))
            End If
          End If

          'Criterio Usuário
          If curSplitedLine(0).Contains("Criterio=") Then
            CriterioUsuarioEncontrado = True
            curSplitedLine = Split(curSplitedLine(0), "=")
            If curSplitedLine.Count = 2 Then
              dicParametrosClassificacao.Add("DLQ_CRITERIA", curSplitedLine(1))
            End If
          End If

          'CONFIGURAÇÕES DO CARRO
          If curLine = 9 OrElse curLine = 10 OrElse curLine = 11 OrElse curLine = 12 OrElse curLine = 13 Then
            Dim configSplitedLine() As String = Split(rawLine, ":")
            If configSplitedLine.Count = 2 Then
              configSplitedLine(1) = LTrim(configSplitedLine(1))
              Select Case curLine
                Case 9
                  dicParametrosClassificacao.Add("DLQ_LAPS", Replace(configSplitedLine(1), " laps", ""))
                Case 10
                  dicParametrosClassificacao.Add("DLQ_TYRESCONSUMPTION", Replace(configSplitedLine(1), " %", ""))
                Case 11
                  dicParametrosClassificacao.Add("DLQ_FUELCONSUMPTION", Replace(configSplitedLine(1), " %", ""))
                Case 12
                  dicParametrosClassificacao.Add("DLQ_FUELMASS", Replace(configSplitedLine(1), " kg", ""))
                Case 13
                  dicParametrosClassificacao.Add("DLQ_DAMAGEFACTOR", Replace(configSplitedLine(1), " %", ""))
              End Select
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
          newWriter.WriteLine("Penalty=00:00,00")
          newWriter.Close()
        End If

        If Not CriterioUsuarioEncontrado Then
          Dim newWriter As New StreamWriter(tmpResultadosTxtPath.FullName, True, System.Text.Encoding.UTF8)
          newWriter.WriteLine("")
          newWriter.WriteLine("Criterio=0")
          newWriter.Close()
        End If

        If dicParametrosClassificacao.Count = 0 OrElse Not _DicResultadosPilotos.ContainsKey(dicParametrosClassificacao("DLQ_DRIVER")) Then
          Continue For
        End If

        If dicParametrosClassificacao.Count <> 0 AndAlso Not _DicResultadosPilotos.ContainsKey(dicParametrosClassificacao("DLQ_DRIVER")) Then
          MessageBox.Show("Arquivo " & tmpResultadosTxtPath.Name & " de piloto desconhecido. Revisar nome do arquivo da Etapa " & tmpEtapa.Etapa.ToString("00"))
        End If

        Dim curPiloto As Piloto = _DicResultadosPilotos(dicParametrosClassificacao("DLQ_DRIVER"))
        For Each tmpResultado As ResultadoEtapa In tmpEtapa.Resultados
          If tmpResultado.Piloto IsNot Nothing AndAlso tmpResultado.Piloto.Nome = curPiloto.Nome Then
            If _DicPontos.ContainsKey("DLQ") Then
              tmpResultado.PontosDeadLine1 = _DicPontos("DLQ")
            Else
              tmpResultado.PontosDeadLine1 = 0
            End If

            If dicParametrosClassificacao.ContainsKey("DLQ_PENALTY") Then
              tmpResultado.PunicaoClassificacao = FormataTempo(dicParametrosClassificacao("DLQ_PENALTY"), New TimeSpan())
            Else
              tmpResultado.PunicaoClassificacao = New TimeSpan()
            End If

            If dicParametrosClassificacao.ContainsKey("DLQ_CRITERIA") AndAlso IsNumeric(dicParametrosClassificacao("DLQ_CRITERIA")) Then
              tmpResultado.CriterioUsuarioClassificacao = CInt(dicParametrosClassificacao("DLQ_CRITERIA"))
            Else
              tmpResultado.CriterioUsuarioClassificacao = 0
            End If

            If dicParametrosClassificacao.ContainsKey("DLQ_FASTESTLAP") Then
              tmpResultado.MelhorVoltaClassificacao = FormataTempo(dicParametrosClassificacao("DLQ_FASTESTLAP"), tmpResultado.PunicaoClassificacao)
            End If

            If dicParametrosClassificacao.ContainsKey("DLQ_TOTALTIME") Then
              tmpResultado.TomadaClassificacao = FormataTempo(dicParametrosClassificacao("DLQ_TOTALTIME"), tmpResultado.PunicaoClassificacao)
            End If

            If dicParametrosClassificacao.ContainsKey("DLQ_LAPS") AndAlso IsNumeric(dicParametrosClassificacao("DLQ_LAPS")) Then
              tmpResultado.ClassificacaoTyresConsumption = CInt(dicParametrosClassificacao("DLQ_LAPS"))
            End If

            If dicParametrosClassificacao.ContainsKey("DLQ_TYRESCONSUMPTION") AndAlso IsNumeric(dicParametrosClassificacao("DLQ_TYRESCONSUMPTION")) Then
              tmpResultado.ClassificacaoTyresConsumption = CInt(dicParametrosClassificacao("DLQ_TYRESCONSUMPTION"))
            End If

            If dicParametrosClassificacao.ContainsKey("DLQ_FUELCONSUMPTION") AndAlso IsNumeric(dicParametrosClassificacao("DLQ_FUELCONSUMPTION")) Then
              tmpResultado.ClassificacaoFuelConsumption = CInt(dicParametrosClassificacao("DLQ_FUELCONSUMPTION"))
            End If

            If dicParametrosClassificacao.ContainsKey("DLQ_FUELMASS") AndAlso IsNumeric(dicParametrosClassificacao("DLQ_FUELMASS")) Then
              tmpResultado.ClassificacaoFuelMass = CInt(dicParametrosClassificacao("DLQ_FUELMASS"))
            End If

            If dicParametrosClassificacao.ContainsKey("DLQ_DAMAGEFACTOR") AndAlso IsNumeric(dicParametrosClassificacao("DLQ_DAMAGEFACTOR")) Then
              tmpResultado.ClassificacaoDamageFactor = CInt(dicParametrosClassificacao("DLQ_DAMAGEFACTOR"))
            End If

            Exit For
          End If
        Next
      Next

      For Each tmpResultadosTxtPath As FileInfo In configDirCorrida.GetFiles("*.txt")
        'Devemos ler o arquivo da classificação
        Dim dicParametrosCorrida As New Dictionary(Of String, String)
        Dim newReader As New StreamReader(tmpResultadosTxtPath.FullName, System.Text.Encoding.Default)
        Dim curLine As Integer = 1
        Dim PenaltyEncontrado As Boolean = False
        Dim CriterioUsuarioEncontrado As Boolean = False

        While Not newReader.EndOfStream
          Dim rawLine As String = newReader.ReadLine()
          Dim curSplitedLine() As String = Split(rawLine, " ")
          If curLine = 7 Then
            Dim parNo As Integer = 1
            For Each tmpString As String In curSplitedLine
              If String.IsNullOrEmpty(tmpString) Then
                Continue For
              End If

              'RESULTADOS DO PILOTO
              Select Case parNo
                Case 1
                  dicParametrosCorrida.Add("RAC_DRIVER", tmpString)
                Case 2
                  dicParametrosCorrida.Add("RAC_DRIVERTYPE", tmpString)
                Case 3
                  dicParametrosCorrida.Add("RAC_CAR", tmpString)
                Case 4
                  dicParametrosCorrida.Add("RAC_POSITION", tmpString)
                Case 5
                  dicParametrosCorrida.Add("RAC_POINTS", tmpString)
                Case 6
                  dicParametrosCorrida.Add("RAC_FINISH", tmpString)
                Case 7
                  dicParametrosCorrida.Add("RAC_FASTESTLAP", tmpString)
                Case 8
                  dicParametrosCorrida.Add("RAC_KMPH", tmpString)
                Case 9
                  dicParametrosCorrida.Add("RAC_TOTALTIME", tmpString)
                Case 10
                  dicParametrosCorrida.Add("RAC_GAP", tmpString)
              End Select
              parNo += 1
            Next
          End If

          'PENALTY
          If curSplitedLine(0).Contains("Penalty=") Then
            PenaltyEncontrado = True
            curSplitedLine = Split(curSplitedLine(0), "=")
            If curSplitedLine.Count = 2 Then
              dicParametrosCorrida.Add("RAC_PENALTY", curSplitedLine(1))
            End If
          End If

          'Criterio Usuário
          If curSplitedLine(0).Contains("Criterio=") Then
            CriterioUsuarioEncontrado = True
            curSplitedLine = Split(curSplitedLine(0), "=")
            If curSplitedLine.Count = 2 Then
              dicParametrosCorrida.Add("RAC_CRITERIA", curSplitedLine(1))
            End If
          End If

          'CONFIGURAÇÕES DO CARRO
          If curLine = 9 OrElse curLine = 10 OrElse curLine = 11 OrElse curLine = 12 OrElse curLine = 13 Then
            Dim configSplitedLine() As String = Split(rawLine, ":")
            If configSplitedLine.Count = 2 Then
              configSplitedLine(1) = LTrim(configSplitedLine(1))
              Select Case curLine
                Case 9
                  dicParametrosCorrida.Add("RAC_LAPS", Replace(configSplitedLine(1), " laps", ""))
                Case 10
                  dicParametrosCorrida.Add("RAC_TYRESCONSUMPTION", Replace(configSplitedLine(1), " %", ""))
                Case 11
                  dicParametrosCorrida.Add("RAC_FUELCONSUMPTION", Replace(configSplitedLine(1), " %", ""))
                Case 12
                  dicParametrosCorrida.Add("RAC_FUELMASS", Replace(configSplitedLine(1), " kg", ""))
                Case 13
                  dicParametrosCorrida.Add("RAC_DAMAGEFACTOR", Replace(configSplitedLine(1), " %", ""))
              End Select
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
          newWriter.WriteLine("Penalty=00:00,00")
          newWriter.Close()
        End If

        If Not CriterioUsuarioEncontrado Then
          Dim newWriter As New StreamWriter(tmpResultadosTxtPath.FullName, True, System.Text.Encoding.UTF8)
          newWriter.WriteLine("")
          newWriter.WriteLine("Criterio=0")
          newWriter.Close()
        End If

        If dicParametrosCorrida.Count = 0 OrElse Not _DicResultadosPilotos.ContainsKey(dicParametrosCorrida("RAC_DRIVER")) Then
          Continue For
        End If

        If dicParametrosCorrida.Count <> 0 AndAlso Not _DicResultadosPilotos.ContainsKey(dicParametrosCorrida("RAC_DRIVER")) Then
          MessageBox.Show("Arquivo " & tmpResultadosTxtPath.Name & " de piloto desconhecido. Revisar nome do arquivo da Etapa " & tmpEtapa.Etapa.ToString("00"))
        End If

        Dim curPiloto As Piloto = _DicResultadosPilotos(dicParametrosCorrida("RAC_DRIVER"))
        For Each tmpResultado As ResultadoEtapa In tmpEtapa.Resultados
          If tmpResultado.Piloto IsNot Nothing AndAlso tmpResultado.Piloto.Nome = curPiloto.Nome Then
            If dicParametrosCorrida.ContainsKey("RAC_PENALTY") Then
              tmpResultado.PunicaoCorrida = FormataTempo(dicParametrosCorrida("RAC_PENALTY"), New TimeSpan())
            Else
              tmpResultado.PunicaoCorrida = New TimeSpan()
            End If

            If dicParametrosCorrida.ContainsKey("RAC_CRITERIA") AndAlso IsNumeric(dicParametrosCorrida("RAC_CRITERIA")) Then
              tmpResultado.CriterioUsuarioCorrida = CInt(dicParametrosCorrida("RAC_CRITERIA"))
            Else
              tmpResultado.CriterioUsuarioCorrida = 0
            End If

            If dicParametrosCorrida.ContainsKey("RAC_FASTESTLAP") Then
              tmpResultado.MelhorVoltaCorrida = FormataTempo(dicParametrosCorrida("RAC_FASTESTLAP"), tmpResultado.PunicaoCorrida)
            End If

            If dicParametrosCorrida.ContainsKey("RAC_TOTALTIME") Then
              tmpResultado.TomadaCorrida = FormataTempo(dicParametrosCorrida("RAC_TOTALTIME"), tmpResultado.PunicaoCorrida)
            End If

            If dicParametrosCorrida.ContainsKey("RAC_LAPS") AndAlso IsNumeric(dicParametrosCorrida("RAC_LAPS")) Then
              tmpResultado.CorridaTyresConsumption = CInt(dicParametrosCorrida("RAC_LAPS"))
            End If

            If dicParametrosCorrida.ContainsKey("RAC_TYRESCONSUMPTION") AndAlso IsNumeric(dicParametrosCorrida("RAC_TYRESCONSUMPTION")) Then
              tmpResultado.CorridaTyresConsumption = CInt(dicParametrosCorrida("RAC_TYRESCONSUMPTION"))
            End If

            If dicParametrosCorrida.ContainsKey("RAC_FUELCONSUMPTION") AndAlso IsNumeric(dicParametrosCorrida("RAC_FUELCONSUMPTION")) Then
              tmpResultado.CorridaFuelConsumption = CInt(dicParametrosCorrida("RAC_FUELCONSUMPTION"))
            End If

            If dicParametrosCorrida.ContainsKey("RAC_FUELMASS") AndAlso IsNumeric(dicParametrosCorrida("RAC_FUELMASS")) Then
              tmpResultado.CorridaFuelMass = CInt(dicParametrosCorrida("RAC_FUELMASS"))
            End If

            If dicParametrosCorrida.ContainsKey("RAC_DAMAGEFACTOR") AndAlso IsNumeric(dicParametrosCorrida("RAC_DAMAGEFACTOR")) Then
              tmpResultado.CorridaDamageFactor = CInt(dicParametrosCorrida("RAC_DAMAGEFACTOR"))
            End If

            Exit For
          End If
        Next
      Next

      'Agora devemos calcular o grid de largada
      Dim curPos As Integer = 1
      Dim curMelhorVolta As TimeSpan = Nothing
      For Each tmpResultadoEtapa As ResultadoEtapa In tmpEtapa.Resultados.OrderBy(Function(resultado) resultado.MelhorVoltaClassificacao).ThenBy(Function(resultado) resultado.TomadaClassificacao).ThenBy(Function(resultado) resultado.ClassificacaoLaps).ThenBy(Function(resultado) resultado.CriterioUsuarioClassificacao).ToList()
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
        tmpResultadoEtapa.PontosDeadLine1 = 1
        curPos += 1

        'Soma uma pole caso o resultado tenha sido a pole
        If tmpResultadoEtapa.PosicaoGrid = 1 Then
          tmpResultadoEtapa.Piloto.Poles += 1
          tmpResultadoEtapa.Equipe.Poles += 1
        Else
          tmpResultadoEtapa.PontosAproximacao = 0
          For Each tmpDiferenca As KeyValuePair(Of TimeSpan, Integer) In _DicPontosAproximacaoClassificacao
            If tmpResultadoEtapa.GapMelhorVolta <= tmpDiferenca.Key Then
              tmpResultadoEtapa.PontosAproximacao = tmpDiferenca.Value
              Exit For
            End If
          Next
        End If

        'Calcula os pontos de classificacao
        If _DicPontos.ContainsKey("PG" & tmpResultadoEtapa.PosicaoGrid) Then
          tmpResultadoEtapa.PontosGrid = _DicPontos("PG" & tmpResultadoEtapa.PosicaoGrid)
        Else
          tmpResultadoEtapa.PontosGrid = 0
        End If
      Next

      'Agora devemos calcular o resultado final
      curPos = 1
      Dim curMelhorTomada As TimeSpan = Nothing
      Dim curTomadaFrente As TimeSpan = Nothing
      For Each tmpResultadoEtapa As ResultadoEtapa In tmpEtapa.Resultados.OrderBy(Function(resultado) resultado.TomadaCorrida).ThenBy(Function(resultado) resultado.CriterioUsuarioCorrida).ThenBy(Function(resultado) resultado.MelhorVoltaCorrida).ToList()
        If tmpResultadoEtapa.TomadaCorrida.Hours = 0 AndAlso tmpResultadoEtapa.TomadaCorrida.Minutes = 0 AndAlso tmpResultadoEtapa.TomadaCorrida.Seconds = 0 Then
          tmpResultadoEtapa.PosicaoEtapa = tmpEtapa.Resultados.Count
          tmpResultadoEtapa.CorridaEnviada = False
          Continue For
        End If

        If curMelhorTomada = Nothing Then
          curMelhorTomada = tmpResultadoEtapa.TomadaCorrida
        Else
          tmpResultadoEtapa.GapLider = tmpResultadoEtapa.TomadaCorrida - curMelhorTomada
        End If

        If curTomadaFrente <> Nothing Then
          tmpResultadoEtapa.GapFrente = tmpResultadoEtapa.TomadaCorrida - curTomadaFrente
        End If
        curTomadaFrente = tmpResultadoEtapa.TomadaCorrida

        tmpResultadoEtapa.CorridaEnviada = True
        tmpResultadoEtapa.PosicaoEtapa = curPos
        curPos += 1

        'Calcula os pontos da etapa
        If tmpResultadoEtapa.PosicaoEtapa = 1 Then
          tmpResultadoEtapa.Piloto.Vitorias += 1
          tmpResultadoEtapa.Equipe.Vitorias += 1
        End If

        If _DicPontos.ContainsKey("P" & tmpResultadoEtapa.PosicaoEtapa) Then
          tmpResultadoEtapa.PontosPosicao = _DicPontos("P" & tmpResultadoEtapa.PosicaoEtapa)
        Else
          tmpResultadoEtapa.PontosPosicao = 0
        End If
      Next
    Next
  End Sub

  ''' <summary>
  ''' Função que monta o tempo do piloto com base no string do arquivo
  ''' </summary>
  ''' <param name="_tempoArquivo"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Public Shared Function FormataTempo(ByVal _tempoArquivo As String, ByVal _punicao As TimeSpan) As TimeSpan
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
      intSeconds = CInt(strTempoSplited(0))
      intMiliSeconds = CInt(strTempoSplited(1)) * 10
    End If

    If strTempoSplited.Count = 3 Then
      intMinutes = CInt(strTempoSplited(0))
      intSeconds = CInt(strTempoSplited(1))
      intMiliSeconds = CInt(strTempoSplited(2)) * 10
    End If

    novoTempo = New TimeSpan(intDays, intHours, intMinutes, intSeconds, intMiliSeconds) + _punicao
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
