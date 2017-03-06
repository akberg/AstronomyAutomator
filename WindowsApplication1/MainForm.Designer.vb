<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AstroAutoMainForm
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AstroAutoMainForm))
        Me.btnChoose = New System.Windows.Forms.Button()
        Me.labLST = New System.Windows.Forms.Label()
        Me.btnConnect = New System.Windows.Forms.Button()
        Me.tbLST = New System.Windows.Forms.TextBox()
        Me.labRA = New System.Windows.Forms.Label()
        Me.tbDEC = New System.Windows.Forms.TextBox()
        Me.tbRA = New System.Windows.Forms.TextBox()
        Me.labDec = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.tbFilePath = New System.Windows.Forms.TextBox()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.labBrowse = New System.Windows.Forms.Label()
        Me.btnExpose = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbCFormat = New System.Windows.Forms.ComboBox()
        Me.labExposeStatus = New System.Windows.Forms.Label()
        Me.tbExposeStatus = New System.Windows.Forms.TextBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.labSavePath = New System.Windows.Forms.Label()
        Me.tbSavePath = New System.Windows.Forms.TextBox()
        Me.btnBrowseSP = New System.Windows.Forms.Button()
        Me.labExpTime = New System.Windows.Forms.Label()
        Me.labFilter = New System.Windows.Forms.Label()
        Me.tbExpTime = New System.Windows.Forms.TextBox()
        Me.btnOpenMaxim = New System.Windows.Forms.Button()
        Me.tbTelescope = New System.Windows.Forms.TextBox()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.btnAbort = New System.Windows.Forms.Button()
        Me.bwSlew = New System.ComponentModel.BackgroundWorker()
        Me.lbReps = New System.Windows.Forms.Label()
        Me.tbReps = New System.Windows.Forms.TextBox()
        Me.cbRepeatType = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpLimit = New System.Windows.Forms.DateTimePicker()
        Me.tbFilters = New System.Windows.Forms.TextBox()
        Me.btnFilterHelp = New System.Windows.Forms.Button()
        Me.lbRunUntil = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnChoose
        '
        Me.btnChoose.Location = New System.Drawing.Point(325, 10)
        Me.btnChoose.Name = "btnChoose"
        Me.btnChoose.Size = New System.Drawing.Size(75, 23)
        Me.btnChoose.TabIndex = 1
        Me.btnChoose.Text = "Choose"
        Me.btnChoose.UseVisualStyleBackColor = True
        '
        'labLST
        '
        Me.labLST.AutoSize = True
        Me.labLST.Location = New System.Drawing.Point(12, 93)
        Me.labLST.Name = "labLST"
        Me.labLST.Size = New System.Drawing.Size(30, 13)
        Me.labLST.TabIndex = 4
        Me.labLST.Text = "LST:"
        '
        'btnConnect
        '
        Me.btnConnect.Location = New System.Drawing.Point(406, 10)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(75, 23)
        Me.btnConnect.TabIndex = 5
        Me.btnConnect.Text = "Connect"
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'tbLST
        '
        Me.tbLST.Location = New System.Drawing.Point(48, 90)
        Me.tbLST.Name = "tbLST"
        Me.tbLST.ReadOnly = True
        Me.tbLST.Size = New System.Drawing.Size(143, 20)
        Me.tbLST.TabIndex = 7
        '
        'labRA
        '
        Me.labRA.AutoSize = True
        Me.labRA.Location = New System.Drawing.Point(197, 93)
        Me.labRA.Name = "labRA"
        Me.labRA.Size = New System.Drawing.Size(25, 13)
        Me.labRA.TabIndex = 9
        Me.labRA.Text = "RA:"
        '
        'tbDEC
        '
        Me.tbDEC.Location = New System.Drawing.Point(235, 113)
        Me.tbDEC.Name = "tbDEC"
        Me.tbDEC.ReadOnly = True
        Me.tbDEC.Size = New System.Drawing.Size(120, 20)
        Me.tbDEC.TabIndex = 10
        '
        'tbRA
        '
        Me.tbRA.Location = New System.Drawing.Point(235, 90)
        Me.tbRA.Name = "tbRA"
        Me.tbRA.ReadOnly = True
        Me.tbRA.Size = New System.Drawing.Size(120, 20)
        Me.tbRA.TabIndex = 11
        '
        'labDec
        '
        Me.labDec.AutoSize = True
        Me.labDec.Location = New System.Drawing.Point(197, 116)
        Me.labDec.Name = "labDec"
        Me.labDec.Size = New System.Drawing.Size(32, 13)
        Me.labDec.TabIndex = 12
        Me.labDec.Text = "DEC:"
        '
        'Timer1
        '
        '
        'tbFilePath
        '
        Me.tbFilePath.Location = New System.Drawing.Point(13, 175)
        Me.tbFilePath.Name = "tbFilePath"
        Me.tbFilePath.Size = New System.Drawing.Size(366, 20)
        Me.tbFilePath.TabIndex = 13
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(385, 173)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(96, 23)
        Me.btnBrowse.TabIndex = 14
        Me.btnBrowse.Text = "Browse..."
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'labBrowse
        '
        Me.labBrowse.AutoSize = True
        Me.labBrowse.Location = New System.Drawing.Point(13, 156)
        Me.labBrowse.Name = "labBrowse"
        Me.labBrowse.Size = New System.Drawing.Size(77, 13)
        Me.labBrowse.TabIndex = 15
        Me.labBrowse.Text = "Coordinate file:"
        '
        'btnExpose
        '
        Me.btnExpose.Location = New System.Drawing.Point(15, 267)
        Me.btnExpose.Name = "btnExpose"
        Me.btnExpose.Size = New System.Drawing.Size(214, 23)
        Me.btnExpose.TabIndex = 16
        Me.btnExpose.Text = "Take pictures"
        Me.btnExpose.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 201)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 13)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Coordinate format:"
        '
        'cbCFormat
        '
        Me.cbCFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCFormat.FormattingEnabled = True
        Me.cbCFormat.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.cbCFormat.Items.AddRange(New Object() {"decimals", "hours/degrees"})
        Me.cbCFormat.Location = New System.Drawing.Point(111, 198)
        Me.cbCFormat.Name = "cbCFormat"
        Me.cbCFormat.Size = New System.Drawing.Size(118, 21)
        Me.cbCFormat.TabIndex = 18
        '
        'labExposeStatus
        '
        Me.labExposeStatus.AutoSize = True
        Me.labExposeStatus.Location = New System.Drawing.Point(232, 402)
        Me.labExposeStatus.Name = "labExposeStatus"
        Me.labExposeStatus.Size = New System.Drawing.Size(40, 13)
        Me.labExposeStatus.TabIndex = 22
        Me.labExposeStatus.Text = "Status:"
        '
        'tbExposeStatus
        '
        Me.tbExposeStatus.Location = New System.Drawing.Point(278, 399)
        Me.tbExposeStatus.Name = "tbExposeStatus"
        Me.tbExposeStatus.ReadOnly = True
        Me.tbExposeStatus.Size = New System.Drawing.Size(168, 20)
        Me.tbExposeStatus.TabIndex = 23
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(12, 397)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(77, 23)
        Me.btnExit.TabIndex = 24
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'labSavePath
        '
        Me.labSavePath.AutoSize = True
        Me.labSavePath.Location = New System.Drawing.Point(13, 225)
        Me.labSavePath.Name = "labSavePath"
        Me.labSavePath.Size = New System.Drawing.Size(59, 13)
        Me.labSavePath.TabIndex = 25
        Me.labSavePath.Text = "Save path:"
        '
        'tbSavePath
        '
        Me.tbSavePath.Location = New System.Drawing.Point(12, 241)
        Me.tbSavePath.Name = "tbSavePath"
        Me.tbSavePath.Size = New System.Drawing.Size(363, 20)
        Me.tbSavePath.TabIndex = 26
        '
        'btnBrowseSP
        '
        Me.btnBrowseSP.Location = New System.Drawing.Point(385, 239)
        Me.btnBrowseSP.Name = "btnBrowseSP"
        Me.btnBrowseSP.Size = New System.Drawing.Size(96, 23)
        Me.btnBrowseSP.TabIndex = 27
        Me.btnBrowseSP.Text = "Browse..."
        Me.btnBrowseSP.UseVisualStyleBackColor = True
        '
        'labExpTime
        '
        Me.labExpTime.AutoSize = True
        Me.labExpTime.Location = New System.Drawing.Point(252, 272)
        Me.labExpTime.Name = "labExpTime"
        Me.labExpTime.Size = New System.Drawing.Size(88, 13)
        Me.labExpTime.TabIndex = 28
        Me.labExpTime.Text = "Exposures (sec.):"
        '
        'labFilter
        '
        Me.labFilter.AutoSize = True
        Me.labFilter.Location = New System.Drawing.Point(303, 353)
        Me.labFilter.Name = "labFilter"
        Me.labFilter.Size = New System.Drawing.Size(37, 13)
        Me.labFilter.TabIndex = 29
        Me.labFilter.Text = "Filters:"
        '
        'tbExpTime
        '
        Me.tbExpTime.Location = New System.Drawing.Point(346, 270)
        Me.tbExpTime.Name = "tbExpTime"
        Me.tbExpTime.Size = New System.Drawing.Size(100, 20)
        Me.tbExpTime.TabIndex = 30
        Me.tbExpTime.Text = "10"
        '
        'btnOpenMaxim
        '
        Me.btnOpenMaxim.Location = New System.Drawing.Point(325, 39)
        Me.btnOpenMaxim.Name = "btnOpenMaxim"
        Me.btnOpenMaxim.Size = New System.Drawing.Size(156, 23)
        Me.btnOpenMaxim.TabIndex = 33
        Me.btnOpenMaxim.Text = "Open MaximDL5"
        Me.btnOpenMaxim.UseVisualStyleBackColor = True
        '
        'tbTelescope
        '
        Me.tbTelescope.DataBindings.Add(New System.Windows.Forms.Binding("Text", Global.AstronomyAutomator.My.MySettings.Default, "Telescope", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.tbTelescope.Location = New System.Drawing.Point(13, 13)
        Me.tbTelescope.Name = "tbTelescope"
        Me.tbTelescope.Size = New System.Drawing.Size(306, 20)
        Me.tbTelescope.TabIndex = 0
        Me.tbTelescope.Text = Global.AstronomyAutomator.My.MySettings.Default.Telescope
        '
        'Timer2
        '
        Me.Timer2.Interval = 50
        '
        'btnAbort
        '
        Me.btnAbort.Location = New System.Drawing.Point(95, 397)
        Me.btnAbort.Name = "btnAbort"
        Me.btnAbort.Size = New System.Drawing.Size(126, 23)
        Me.btnAbort.TabIndex = 34
        Me.btnAbort.Text = "Abort exposure"
        Me.btnAbort.UseVisualStyleBackColor = True
        '
        'bwSlew
        '
        '
        'lbReps
        '
        Me.lbReps.AutoSize = True
        Me.lbReps.Location = New System.Drawing.Point(277, 300)
        Me.lbReps.Name = "lbReps"
        Me.lbReps.Size = New System.Drawing.Size(63, 13)
        Me.lbReps.TabIndex = 35
        Me.lbReps.Text = "Repetitions:"
        '
        'tbReps
        '
        Me.tbReps.Location = New System.Drawing.Point(346, 297)
        Me.tbReps.Name = "tbReps"
        Me.tbReps.Size = New System.Drawing.Size(100, 20)
        Me.tbReps.TabIndex = 36
        Me.tbReps.Text = "1"
        '
        'cbRepeatType
        '
        Me.cbRepeatType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbRepeatType.FormattingEnabled = True
        Me.cbRepeatType.Items.AddRange(New Object() {"Repetitions", "Run until"})
        Me.cbRepeatType.Location = New System.Drawing.Point(108, 297)
        Me.cbRepeatType.Name = "cbRepeatType"
        Me.cbRepeatType.Size = New System.Drawing.Size(121, 21)
        Me.cbRepeatType.TabIndex = 37
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 300)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 38
        Me.Label2.Text = "Repeat type:"
        '
        'dtpLimit
        '
        Me.dtpLimit.CustomFormat = "HH:mm"
        Me.dtpLimit.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpLimit.Location = New System.Drawing.Point(346, 324)
        Me.dtpLimit.Name = "dtpLimit"
        Me.dtpLimit.Size = New System.Drawing.Size(100, 20)
        Me.dtpLimit.TabIndex = 39
        '
        'tbFilters
        '
        Me.tbFilters.Location = New System.Drawing.Point(346, 350)
        Me.tbFilters.Name = "tbFilters"
        Me.tbFilters.Size = New System.Drawing.Size(100, 20)
        Me.tbFilters.TabIndex = 40
        Me.tbFilters.Text = "0"
        '
        'btnFilterHelp
        '
        Me.btnFilterHelp.Location = New System.Drawing.Point(452, 350)
        Me.btnFilterHelp.Name = "btnFilterHelp"
        Me.btnFilterHelp.Size = New System.Drawing.Size(29, 23)
        Me.btnFilterHelp.TabIndex = 41
        Me.btnFilterHelp.Text = "?"
        Me.btnFilterHelp.UseVisualStyleBackColor = True
        '
        'lbRunUntil
        '
        Me.lbRunUntil.AutoSize = True
        Me.lbRunUntil.Location = New System.Drawing.Point(288, 327)
        Me.lbRunUntil.Name = "lbRunUntil"
        Me.lbRunUntil.Size = New System.Drawing.Size(52, 13)
        Me.lbRunUntil.TabIndex = 42
        Me.lbRunUntil.Text = "Run until:"
        '
        'AstroAutoMainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(493, 432)
        Me.Controls.Add(Me.lbRunUntil)
        Me.Controls.Add(Me.btnFilterHelp)
        Me.Controls.Add(Me.tbFilters)
        Me.Controls.Add(Me.dtpLimit)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cbRepeatType)
        Me.Controls.Add(Me.tbReps)
        Me.Controls.Add(Me.lbReps)
        Me.Controls.Add(Me.btnAbort)
        Me.Controls.Add(Me.btnOpenMaxim)
        Me.Controls.Add(Me.tbExpTime)
        Me.Controls.Add(Me.labFilter)
        Me.Controls.Add(Me.labExpTime)
        Me.Controls.Add(Me.btnBrowseSP)
        Me.Controls.Add(Me.tbSavePath)
        Me.Controls.Add(Me.labSavePath)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.tbExposeStatus)
        Me.Controls.Add(Me.labExposeStatus)
        Me.Controls.Add(Me.cbCFormat)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnExpose)
        Me.Controls.Add(Me.labBrowse)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.tbFilePath)
        Me.Controls.Add(Me.labDec)
        Me.Controls.Add(Me.tbRA)
        Me.Controls.Add(Me.tbDEC)
        Me.Controls.Add(Me.labRA)
        Me.Controls.Add(Me.tbLST)
        Me.Controls.Add(Me.btnConnect)
        Me.Controls.Add(Me.labLST)
        Me.Controls.Add(Me.btnChoose)
        Me.Controls.Add(Me.tbTelescope)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "AstroAutoMainForm"
        Me.Text = "AstronomyAutomator v1.0"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tbTelescope As TextBox
    Friend WithEvents btnChoose As Button
    Friend WithEvents labLST As Label
    Friend WithEvents btnConnect As Button
    Friend WithEvents tbLST As TextBox
    Friend WithEvents labRA As Label
    Friend WithEvents tbDEC As TextBox
    Friend WithEvents tbRA As TextBox
    Friend WithEvents labDec As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents tbFilePath As TextBox
    Friend WithEvents btnBrowse As Button
    Friend WithEvents labBrowse As Label
    Friend WithEvents btnExpose As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents cbCFormat As ComboBox
    Friend WithEvents labExposeStatus As Label
    Friend WithEvents tbExposeStatus As TextBox
    Friend WithEvents btnExit As Button
    Friend WithEvents labSavePath As Label
    Friend WithEvents tbSavePath As TextBox
    Friend WithEvents btnBrowseSP As Button
    Friend WithEvents labExpTime As Label
    Friend WithEvents labFilter As Label
    Friend WithEvents tbExpTime As TextBox
    Friend WithEvents btnOpenMaxim As Button
    Friend WithEvents Timer2 As Timer
    Friend WithEvents btnAbort As Button
    Friend WithEvents bwSlew As System.ComponentModel.BackgroundWorker
    Friend WithEvents lbReps As Label
    Friend WithEvents tbReps As TextBox
    Friend WithEvents cbRepeatType As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents dtpLimit As DateTimePicker
    Friend WithEvents tbFilters As TextBox
    Friend WithEvents btnFilterHelp As Button
    Friend WithEvents lbRunUntil As Label
End Class
