Public Class AstroAutoMainForm
    Private objTelescope As ASCOM.DriverAccess.Telescope

    Private RA As Double = 0
    Private DEC As Double = 0

    Private Sub btnChoose_Click(sender As Object, e As EventArgs) Handles btnChoose.Click
        Dim obj As New ASCOM.Utilities.Chooser
        obj.DeviceType = "Telescope"
        My.Settings.Telescope = obj.Choose(My.Settings.Telescope)
    End Sub

    Private Sub btnConnect_Click(sender As Object, e As EventArgs) Handles btnConnect.Click
        Try
            objTelescope = New ASCOM.DriverAccess.Telescope(My.Settings.Telescope)
        Catch
            MsgBox("No telescope chosen, please select a telescope to connect.")
            Exit Sub
        End Try
        objTelescope.Connected = True
        sender.enabled = False
        Timer1.Start()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tbExposeStatus.Text = "Idle..."
        cbCFormat.SelectedIndex = 0
        cbRepeatType.SelectedIndex = 0

        If Not My.Computer.FileSystem.FileExists("C:\Windows\assembly\GAC_MSIL\ASCOM.DriverAccess\6.0.0.0__565de7938946fba7\ASCOM.DriverAccess.dll") Then
            MsgBox("Could not find the required ASCOM drivers." & vbNewLine & "Download from http://www.ascom_standards.com")
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            tbRA.Text = objTelescope.RightAscension
        Catch
            Timer1.Stop()
            MsgBox("Telescope disconnected, please reconnect!")
            btnConnect.Enabled = True
            Exit Sub
        End Try

        tbDEC.Text = objTelescope.Declination
        tbLST.Text = objTelescope.SiderealTime
    End Sub

    Private Sub btnPark_Click(sender As Object, e As EventArgs)
        Try
            If objTelescope.AtPark Then
                objTelescope.Unpark()
            Else
                objTelescope.Park()
            End If
        Catch
        End Try
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Using ofd As New OpenFileDialog()
            If ofd.ShowDialog() = DialogResult.OK Then
                tbFilePath.Text = ofd.FileName
            End If
        End Using
    End Sub

    Private Sub btnExpose_Click(sender As Object, e As EventArgs) Handles btnExpose.Click
        If tbReps.Enabled = True Then                                                                    'CASE repetitions
            Dim repetitions As Integer = Val(tbReps.Text)
            Dim index_rep As Integer = 0
            While index_rep <> repetitions
                If Open(Now, 0) = -1 Then
                    Exit Sub
                End If
                index_rep = index_rep + 1
            End While
            repetitions = 0

        ElseIf tbReps.Enabled = False Then                                                               'CASE time limit
            Dim d As Date = Format(Me.dtpLimit.Value, "HH:mm")

            Dim buff As Long = 10
            While d <> Format(Now, "HH:mm")
                Dim d2 As Date = Format(Now, "HH:mm")
                DateDiff(DateInterval.Minute, d, d2)
                If d < d2 And DateDiff(DateInterval.Minute, d, d2) < buff Then
                    Exit While
                End If
                If Open(d, buff) = -1 Then
                    Exit Sub
                End If
            End While
        End If
        MsgBox("Exposure done!")
    End Sub

    Function Open(d As Date, buff As Long) As Integer

        Dim DoExpose As Boolean = True
        Try
            objTelescope.Tracking = True
        Catch
        End Try

        Dim line As Integer = 1

        If cbCFormat.Text = "hours/degrees" Then                                        'Checks the chosen type of input
            Try
                FileOpen(1, tbFilePath.Text, OpenMode.Input, OpenAccess.Read)           'Opens the .txt file
            Catch
                MsgBox("No file found.")
                Return -1
                Exit Function
            End Try
            tbExposeStatus.Text = "Running sequence..."

            Dim stLine As String                                                        'Current line
            Dim RAstr, DECstr As String                                                 'RA and DEC as strings
            Dim char_1, char_2, char_temp, char_DECsign As Char                         'Temp variables for reading characters from line
            Dim char_RAminsec, char_RAmsec, char_DECminsec, char_DECmsec As String      'Variables for minutes and seconds of coordinates

            Dim i As Integer                                                            'Index for loop

            While Not EOF(1)
                char_RAminsec = ""                                                      'Initializing variables for next line
                char_DECminsec = ""                                                     'minsec = String variable for minutes and seconds
                char_RAmsec = ""                                                        'msec = String variable for milliseconds
                char_DECmsec = ""                                                       'Used an own variable for msec because of its implementation
                RA = 0
                DEC = 0

                stLine = LineInput(1)                                                   'Reads line from file

                If stLine.Length < 1 Then
                    Continue While
                End If

                'Reading the RA coordinate
                char_1 = GetChar(stLine, 1)                                             'Reads the two first characters of the RA coordinate
                If char_1 = "'" Then
                    Continue While
                ElseIf char_1 = "#" Then                                                'If a line begins with "#" the telescope will slew to it, but not expose
                    DoExpose = False
                    char_1 = GetChar(stLine, 2)
                    char_2 = GetChar(stLine, 3)
                    i = 5                                                               'Initializing index variable
                Else
                    char_2 = GetChar(stLine, 2)
                    i = 4
                End If

                RAstr = char_1 & char_2
                RA = Val(RAstr)

                char_1 = GetChar(stLine, i)                                             'Reads minutes from RA coordinate
                i = i + 1
                char_2 = GetChar(stLine, i)
                char_RAminsec = char_1 & char_2
                RA = RA + (Val(char_RAminsec) / 60)
                i = i + 2

                char_1 = GetChar(stLine, i)                                             'Reads seconds from RA coordinate
                i = i + 1
                char_2 = GetChar(stLine, i)
                char_RAminsec = char_1 & char_2
                RA = RA + (Val(char_RAminsec) / 3600)
                i = i + 2

                'While GetChar(stLine, i) <> " "                                         'Reads milliseconds from RA coordinate
                'char_temp = GetChar(stLine, i)
                'char_RAmsec = char_RAmsec & char_temp
                'i = i + 1
                'End While

                'RA = RA + (Val(char_RAmsec) / 360000)                                   'Adds the milliseconds to complete the RA coordinate

                'i = i + 2                                                               'Increments index to reach DEC coordinate sign

                'Reading the DEC coordinate
                char_DECsign = GetChar(stLine, i)                                       'Reads the DEC coordinate sign
                i = i + 1

                char_1 = GetChar(stLine, i)                                             'Reads the degrees of the DEC coordinates
                i = i + 1
                char_2 = GetChar(stLine, i)
                DECstr = char_DECsign & char_1 & char_2
                DEC = Val(DECstr)
                i = i + 2

                char_1 = GetChar(stLine, i)                                             'Reads the minutes of the DEC coordinate
                i = i + 1
                char_2 = GetChar(stLine, i)
                char_DECminsec = char_1 & char_2
                DEC = DEC + (Val(char_DECminsec) / 60)
                i = i + 2

                char_1 = GetChar(stLine, i)                                             'Reads the seconds of the DEC coordinate
                i = i + 1
                char_2 = GetChar(stLine, i)
                char_DECminsec = char_1 & char_2
                DEC = DEC + (Val(char_DECminsec) / 3600)
                i = i + 2

                While i < (stLine.Length + 1)
                    char_temp = GetChar(stLine, i)
                    char_DECmsec = char_DECmsec & char_temp
                    i = i + 1
                End While
                DEC = DEC + (Val(char_DECmsec) / 360000)

                Try                                                                     'Moves the telescope to the coordinates
                    objTelescope.SlewToCoordinates(RA, DEC)
                Catch                                                                   'If the telescope can't be moved, it will be unparked
                    MsgBox("Unable to move telescope.")
                    Return -1
                    Exit Function
                End Try

                Try
                    tbRA.Text = objTelescope.RightAscension
                Catch
                    MsgBox("Telescope disconnected, please reconnect!")
                    btnConnect.Enabled = True
                    Return -1
                    Exit Function
                End Try

                tbDEC.Text = objTelescope.Declination
                tbLST.Text = objTelescope.SiderealTime

                Dim t As Integer = 0

                While Math.Round(objTelescope.Declination, 2) <> Math.Round(DEC, 2) Or Math.Round(objTelescope.RightAscension, 2) <> Math.Round(RA, 2) And t <= 300
                    System.Threading.Thread.Sleep(100)
                    t = t + 1
                End While

                If t >= 300 Then
                    If Math.Round(objTelescope.Declination, 1) <> Math.Round(DEC, 1) Or Math.Round(objTelescope.RightAscension, 1) <> Math.Round(RA, 1) Then
                        Return -1
                        Exit Function
                    End If
                End If

                Dim exposureTimes As Integer() = GetExposureTime(line)                  'Get exposure times for current coordinate
                Dim filters As Integer() = GetFilters(line)

                tbExposeStatus.Text = "Exposing..."
                If DoExpose Then
                    If expose(exposureTimes, filters, line, d, buff) = -1 Then          'Expose on current coordinate
                        Return -1
                        Exit Function
                    End If
                    line = line + 1
                End If
                DoExpose = True
                tbExposeStatus.Text = "Running sequence..."
                System.Threading.Thread.Sleep(1000)
            End While
            FileClose(1)

        ElseIf cbCFormat.Text = "decimals" Then                                         'For decimal input
            Try
                FileOpen(1, tbFilePath.Text, OpenMode.Input, OpenAccess.Read)           'Opens the .txt-file
            Catch
                MsgBox("No file found.")
                Return -1
                Exit Function
            End Try
            tbExposeStatus.Text = "Running sequence..."

            Dim stLine As String                                                        'Current line of the file
            Dim RAstr, DECstr As String                                                 'RA and DEC as strings
            Dim char_RAdecimal, char_DECdecimal As String                               'Strings containing the decimals for RA and DEC

            Dim DECdecimals As Double                                                   'Temporary variable used to store decimals of DEC coordinate

            Dim char_1, char_2, char_DECSign, char_temp As Char                         'Different variables used to read the coordinates

            Dim i, j, exponent As Integer                                               'Variables used in loops and for correcting decimals

            While Not EOF(1)                                                            'Loops until EOF

                char_RAdecimal = ""                                                     'Initializing the strings and variables
                char_DECdecimal = ""
                RA = 0
                DEC = 0
                DECdecimals = 0

                stLine = LineInput(1)                                                   'Reads current line into stLine

                If stLine.Length < 1 Then
                    Continue While
                End If

                'Reading the RA coordinate
                char_1 = GetChar(stLine, 1)                                             'Reads the two first characters of the RA coordinate
                If char_1 = "'" Then
                    Continue While
                ElseIf char_1 = "#" Then                                                'If a line begins with "#" the telescope will slew to it, but not expose
                    DoExpose = False
                    char_1 = GetChar(stLine, 2)
                    char_2 = GetChar(stLine, 3)
                    i = 5                                                               'Initializing loop variables
                    j = 5
                Else
                    char_2 = GetChar(stLine, 2)
                    i = 4
                    j = 4
                End If

                RAstr = char_1 & char_2                                                 'Puts the two characters together, and converts the string to double
                RA = Val(RAstr)

                While GetChar(stLine, i) <> " "                                         'Reads the decimals of the RA coordinate into char_RAdecimal
                    char_temp = GetChar(stLine, i)
                    char_RAdecimal = char_RAdecimal & char_temp
                    i = i + 1
                End While

                exponent = i - j
                RA = RA + (Val(char_RAdecimal) / (10 ^ exponent))                       'Adds the RA coordinate together

                'Reading the DEC coordinate
                i = i + 1                                                               'Skips the blank space between coordinates

                char_DECSign = GetChar(stLine, i)                                       'Reads the DEC sign (+/-), and the two first characters of the DEC coordinate
                char_1 = GetChar(stLine, i + 1)
                char_2 = GetChar(stLine, i + 2)

                DECstr = char_DECSign & char_1 & char_2                                 'Puts the sign and the two characters together, and converts the string to double
                DEC = Val(DECstr)

                i = i + 4                                                               'Initializing the variables for the DEC decimal loop
                j = i

                While i < stLine.Length + 1                                             'Reads the decimals of the DEC coordinate into char_DECdecimal
                    char_temp = GetChar(stLine, i)
                    char_DECdecimal = char_DECdecimal & char_temp
                    i = i + 1
                End While

                exponent = i - j
                DECdecimals = Val(char_DECdecimal) / (10 ^ exponent)                    'Adds the DEC coordinate together
                If DEC < 0 Then
                    DEC = DEC - DECdecimals
                ElseIf DEC > 0 Then
                    DEC = DEC + DECdecimals
                End If

                Try                                                                     'Moves the telescope to the coordinates
                    objTelescope.SlewToCoordinates(RA, DEC)
                Catch                                                                   'If the telescope can't be moved, it will be unparked
                    MsgBox("Unable to move telescope.")
                    Return -1
                    Exit Function
                End Try



                Try
                    tbRA.Text = objTelescope.RightAscension
                Catch
                    MsgBox("Telescope disconnected, please reconnect!")
                    btnConnect.Enabled = True
                    Return -1
                    Exit Function
                End Try

                tbDEC.Text = objTelescope.Declination
                tbLST.Text = objTelescope.SiderealTime

                Dim t As Integer = 0

                While Math.Round(objTelescope.Declination, 2) <> Math.Round(DEC, 2) Or Math.Round(objTelescope.RightAscension, 2) <> Math.Round(RA, 2) And t <= 300
                    System.Threading.Thread.Sleep(100)
                    t = t + 1
                End While

                If t >= 300 Then
                    If Math.Round(objTelescope.Declination, 1) <> Math.Round(DEC, 1) Or Math.Round(objTelescope.RightAscension, 1) <> Math.Round(RA, 1) Then
                        Return -1
                        Exit Function
                    End If
                End If

                Dim exposureTimes As Integer() = GetExposureTime(line)                  'Get exposure times for current coordinate
                Dim filters As Integer() = GetFilters(line)

                tbExposeStatus.Text = "Exposing..."
                If DoExpose Then
                    If expose(exposureTimes, filters, line, d, buff) = -1 Then          'Expose on current coordinate
                        Return -1
                        Exit Function
                    End If
                    line = line + 1
                End If
                DoExpose = True
                tbExposeStatus.Text = "Runnning sequence..."
            End While
            FileClose(1)
        Else
            MsgBox("Please choose coordinate format.")
        End If
        tbExposeStatus.Text = "Idle..."
        Return 0
    End Function

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        If MsgBox("Exit application?", vbQuestion + vbYesNo) = vbYes Then
            If MsgBox("Are you sure you want to exit?", vbQuestion + vbYesNo) = vbYes Then
                End
            End If
        End If
    End Sub

    Private Sub btnBrowseSP_Click(sender As Object, e As EventArgs) Handles btnBrowseSP.Click
        Using sp As New FolderBrowserDialog()
            If sp.ShowDialog() = DialogResult.OK Then
                tbSavePath.Text = sp.SelectedPath
            End If
        End Using
    End Sub

    Function expose(exptime() As Integer, filters() As Integer, line As Integer, d As Date, buff As Long)
        Dim d2 As Date = Format(Now, "HH:mm")
        DateDiff(DateInterval.Minute, d, d2)
        If d < d2 And DateDiff(DateInterval.Minute, d, d2) < buff And tbReps.Enabled = False Then
            Return 0
            Exit Function
        End If

        Dim objCamera As New MaxIm.CCDCamera
        Dim FilePath As String
        Dim exposureTime, filter As Double

        FilePath = tbSavePath.Text
        objCamera.LinkEnabled = True

        FilePath = FilePath & "\" & line

        If Not My.Computer.FileSystem.DirectoryExists(FilePath) Then
            My.Computer.FileSystem.CreateDirectory(FilePath)
        End If

        If Not objCamera.LinkEnabled Then
            MsgBox("Failed to start camera.")
            Return -1
            Exit Function
        End If

        For f_index = 1 To filters.Length
            Filter = filters(f_index - 1)
            For e_index = 1 To exptime.Length
                exposureTime = exptime(e_index - 1)

                objCamera.Expose(exposureTime, 1, filter)

                System.Threading.Thread.Sleep(exposureTime * 1000)

                Dim t As Integer = 0

                Do While Not objCamera.ImageReady And t < 30
                    System.Threading.Thread.Sleep(500)
                    t = t + 1
                Loop

                If t >= 100 Then
                    MsgBox("MaxIm DL timed out.")
                    tbExposeStatus.Text = "Idle..."
                    Return -1
                    Exit Function
                End If

                objCamera.SaveImage(FilePath & "\" & Today & " " & Hour(Now) & "." & Minute(Now) & "." &
                                    Second(Now) & " _ " & exposureTime & " seconds" & " _ filter " & filter & ".fit")
            Next
        Next

        Return 0
    End Function

    Private Sub btnOpenMaxim_Click(sender As Object, e As EventArgs) Handles btnOpenMaxim.Click
        Try
            System.Diagnostics.Process.Start("Maxim_DL.exe")
        Catch
            MsgBox("Could not find a valid Maxim DL install." & vbNewLine & "")
        End Try
    End Sub

    Private Sub btnAbort_Click(sender As Object, e As EventArgs) Handles btnAbort.Click
        objTelescope.AbortSlew()
        MsgBox("Sequence cancelled.")
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

    End Sub

    Function GetExposureTime(line As Integer) As Integer()                                                                      'get exposure times as array of integers
        Dim o, p As Integer
        Dim exposureTimes = New Integer() {10}                                                                  'Returns 10 sec as default if input is incorrect or missing
        o = 1
        p = 0

        Dim c As Char
        Dim sec As String = ""
        While True
            If o = tbExpTime.Text.Length Then                                                                   'Exit if o has reached the end of the input text
                c = GetChar(tbExpTime.Text, o)
                sec = sec & c
                If p = 0 Then                                                                                   'Overrides default value on first loop
                    exposureTimes(p) = Val(sec)
                Else                                                                                            'Preserves existing values
                    ReDim Preserve exposureTimes(p)
                    exposureTimes(p) = Val(sec)
                End If
                exposureTimes(p) = Val(sec)
                Exit While
            ElseIf o > tbExpTime.Text.Length Then
                Exit While
            End If
            c = GetChar(tbExpTime.Text, o)
            If c = "," Then
                If Not sec = "" Then
                    If p = 0 Then
                        exposureTimes(p) = Val(sec)
                    Else
                        ReDim Preserve exposureTimes(p)
                        exposureTimes(p) = Val(sec)
                    End If
                    sec = ""                                                                                        'Empty buffer
                    p = p + 1
                End If
                o = o + 1
            ElseIf 47 < Decimal.op_Implicit(c) And Decimal.op_Implicit(c) < 58 Then                                 'Using decimal value to check if c is a number
                'ElseIf c = "0" Or c = "1" Or c = "2" Or c = "3" Or c = "4" Or                                      'Update sec buffer if input is a number
                '    c = "5" Or c = "6" Or c = "7" Or c = "8" Or c = "9" Then
                sec = sec & c
            ElseIf c = ":" Then
                o = o + 1
                c = GetChar(tbExpTime.Text, o)
                If Val(c) = line Then
                    If p = 0 Then
                        exposureTimes(p) = Val(sec)
                    Else
                        ReDim Preserve exposureTimes(p)
                        exposureTimes(p) = Val(sec)
                    End If
                    sec = ""
                    p = p + 1
                    o = o + 1
                Else
                    sec = ""                                                                                        'Empty buffer
                    o = o + 2
                End If
            ElseIf c = " " Then
                o = o
            Else
                Exit While
            End If
            o = o + 1
        End While
        Return exposureTimes
    End Function

    Private Sub bwSlew_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bwSlew.DoWork
        objTelescope.SlewToCoordinates(RA, DEC)
    End Sub

    Function GetFilters(line As Integer) As Integer()
        Dim o, p As Integer
        Dim filters = New Integer() {1}
        o = 1
        p = 0

        Dim c As Char
        Dim buf As String = ""

        While True
            If o = tbFilters.Text.Length Then                                                                   'Exit if o has reached the end of the input text
                c = GetChar(tbFilters.Text, o)
                buf = buf & c
                If p = 0 Then                                                                                   'Overrides default value on first loop
                    filters(p) = Val(buf)
                Else                                                                                            'Preserves existing values
                    ReDim Preserve filters(p)
                    filters(p) = Val(buf)
                End If
                filters(p) = Val(buf)
                Exit While
            ElseIf o > tbFilters.Text.Length Then
                Exit While
            End If
            c = GetChar(tbFilters.Text, o)
            If c = "," Then
                If Not buf = "" Then
                    If p = 0 Then
                        filters(p) = Val(buf)
                    Else
                        ReDim Preserve filters(p)
                        filters(p) = Val(buf)
                    End If
                    buf = ""                                                                                    'Empty buffer
                    p = p + 1
                End If
                o = o + 1
            ElseIf 47 < Decimal.op_Implicit(c) And Decimal.op_Implicit(c) < 58 Then                             'Using decimal value to check if c is a number
                'ElseIf c = "0" Or c = "1" Or c = "2" Or c = "3" Or c = "4" Or                                  'Update sec buffer if input is a number
                '    c = "5" Or c = "6" Or c = "7" Or c = "8" Or c = "9" Then
                buf = buf & c
            ElseIf c = ":" Then
                o = o + 1
                c = GetChar(tbFilters.Text, o)
                If Val(c) = line Then
                    If p = 0 Then
                        filters(p) = Val(buf)
                    Else
                        ReDim Preserve filters(p)
                        filters(p) = Val(buf)
                    End If
                    buf = ""
                    p = p + 1
                    o = o + 1
                Else
                    buf = ""                                                                                        'Empty buffer
                    o = o + 2
                End If
            ElseIf c = " " Then
                o = o
            Else
                Exit While
            End If
            o = o + 1
        End While
        Return filters
    End Function

    Private Sub cbRepeatType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbRepeatType.SelectedIndexChanged
        If cbRepeatType.SelectedIndex = 0 Then
            tbReps.Enabled = True
            dtpLimit.Enabled = False
        ElseIf cbRepeatType.SelectedIndex = 1 Then
            tbReps.Enabled = False
            dtpLimit.Enabled = True
        End If
    End Sub

    Private Sub btnFilterHelp_Click(sender As Object, e As EventArgs) Handles btnFilterHelp.Click
        MsgBox("Use the filter index (first = 0) according to the wheel in use.")
    End Sub
End Class

'boi