Imports System.Runtime.InteropServices

Public Class WebcamImage
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents picCapture As System.Windows.Forms.PictureBox
    Friend WithEvents lstDevices As System.Windows.Forms.ListBox
    Friend WithEvents lblDevice As System.Windows.Forms.Label
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnStop As System.Windows.Forms.Button
    Friend WithEvents sfdImage As System.Windows.Forms.SaveFileDialog
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.picCapture = New System.Windows.Forms.PictureBox()
        Me.lstDevices = New System.Windows.Forms.ListBox()
        Me.lblDevice = New System.Windows.Forms.Label()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.sfdImage = New System.Windows.Forms.SaveFileDialog()
        CType(Me.picCapture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picCapture
        '
        Me.picCapture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picCapture.Location = New System.Drawing.Point(208, 24)
        Me.picCapture.Name = "picCapture"
        Me.picCapture.Size = New System.Drawing.Size(256, 272)
        Me.picCapture.TabIndex = 0
        Me.picCapture.TabStop = False
        '
        'lstDevices
        '
        Me.lstDevices.Location = New System.Drawing.Point(8, 55)
        Me.lstDevices.Name = "lstDevices"
        Me.lstDevices.Size = New System.Drawing.Size(184, 238)
        Me.lstDevices.TabIndex = 1
        '
        'lblDevice
        '
        Me.lblDevice.Location = New System.Drawing.Point(8, 32)
        Me.lblDevice.Name = "lblDevice"
        Me.lblDevice.Size = New System.Drawing.Size(184, 16)
        Me.lblDevice.TabIndex = 2
        Me.lblDevice.Text = "Available Devices"
        Me.lblDevice.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(20, 320)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(112, 32)
        Me.btnStart.TabIndex = 3
        Me.btnStart.Text = "Start Preview"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(348, 320)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(112, 32)
        Me.btnSave.TabIndex = 4
        Me.btnSave.Text = "Save Image"
        '
        'btnStop
        '
        Me.btnStop.Location = New System.Drawing.Point(184, 320)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(112, 32)
        Me.btnStop.TabIndex = 5
        Me.btnStop.Text = "Stop Preview"
        '
        'sfdImage
        '
        Me.sfdImage.FileName = "Webcam1"
        Me.sfdImage.Filter = "Bitmap|*.bmp"
        '
        'WebcamImage
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(480, 382)
        Me.Controls.Add(Me.btnStop)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.lblDevice)
        Me.Controls.Add(Me.lstDevices)
        Me.Controls.Add(Me.picCapture)
        Me.Name = "WebcamImage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Image Capture From WebCam"
        CType(Me.picCapture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Const WM_CAP As Short = &H400S

    Const WM_CAP_DRIVER_CONNECT As Integer = WM_CAP + 10
    Const WM_CAP_DRIVER_DISCONNECT As Integer = WM_CAP + 11
    Const WM_CAP_EDIT_COPY As Integer = WM_CAP + 30

    Const WM_CAP_SET_PREVIEW As Integer = WM_CAP + 50
    Const WM_CAP_SET_PREVIEWRATE As Integer = WM_CAP + 52
    Const WM_CAP_SET_SCALE As Integer = WM_CAP + 53
    Const WS_CHILD As Integer = &H40000000
    Const WS_VISIBLE As Integer = &H10000000
    Const SWP_NOMOVE As Short = &H2S
    Const SWP_NOSIZE As Short = 1
    Const SWP_NOZORDER As Short = &H4S
    Const HWND_BOTTOM As Short = 1

    Dim iDevice As Integer = 0 ' Current device ID
    Dim hHwnd As Integer ' Handle to preview window

    Declare Function SendMessage Lib "user32" Alias "SendMessageA" _
        (ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, _
        <MarshalAs(UnmanagedType.AsAny)> ByVal lParam As Object) As Integer

    Declare Function SetWindowPos Lib "user32" Alias "SetWindowPos" (ByVal hwnd As Integer, _
        ByVal hWndInsertAfter As Integer, ByVal x As Integer, ByVal y As Integer, _
        ByVal cx As Integer, ByVal cy As Integer, ByVal wFlags As Integer) As Integer

    Declare Function DestroyWindow Lib "user32" (ByVal hndw As Integer) As Boolean

    Declare Function capCreateCaptureWindowA Lib "avicap32.dll" _
        (ByVal lpszWindowName As String, ByVal dwStyle As Integer, _
        ByVal x As Integer, ByVal y As Integer, ByVal nWidth As Integer, _
        ByVal nHeight As Short, ByVal hWndParent As Integer, _
        ByVal nID As Integer) As Integer

    Declare Function capGetDriverDescriptionA Lib "avicap32.dll" (ByVal wDriver As Short, _
        ByVal lpszName As String, ByVal cbName As Integer, ByVal lpszVer As String, _
        ByVal cbVer As Integer) As Boolean

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ERPInitializeObjects(Me)
        LoadDeviceList()
        TempFileNames2 = ""
        If lstDevices.Items.Count > 0 Then
            btnStart.Enabled = True
            btnStart.Enabled = True
            btnSave.Enabled = True
            lstDevices.SelectedIndex = 0
        Else
            lstDevices.Items.Add("No Capture Device")
            btnStart.Enabled = False
            btnStop.Enabled = False
            btnSave.Enabled = False
        End If

        btnSave.Enabled = True
        picCapture.SizeMode = PictureBoxSizeMode.StretchImage
    End Sub

    Private Sub LoadDeviceList()
        Dim strName As String = Space(100)
        Dim strVer As String = Space(100)
        Dim bReturn As Boolean
        Dim x As Integer = 0

        ' 
        ' Load name of all avialable devices into the lstDevices
        '

        Do
            '
            '   Get Driver name and version
            '
            bReturn = capGetDriverDescriptionA(x, strName, 100, strVer, 100)

            '
            ' If there was a device add device name to the list
            '
            If bReturn Then lstDevices.Items.Add(strName.Trim)
            x += 1
        Loop Until bReturn = False
    End Sub

    Private Sub OpenPreviewWindow()
        Try
            Dim iHeight As Integer = picCapture.Height
            Dim iWidth As Integer = picCapture.Width

            '
            ' Open Preview window in picturebox
            '
            hHwnd = capCreateCaptureWindowA(iDevice, WS_VISIBLE Or WS_CHILD, 0, 0, 640, _
                480, picCapture.Handle.ToInt32, 0)
            ' MsgBox(SendMessage(hHwnd, WM_CAP_DRIVER_CONNECT, iDevice, 0))
            '
            ' Connect to device
            '
            If SendMessage(hHwnd, WM_CAP_DRIVER_CONNECT, iDevice, 0) Then
                '
                'Set the preview scale
                '
                SendMessage(hHwnd, WM_CAP_SET_SCALE, True, 0)

                '
                'Set the preview rate in milliseconds
                '
                SendMessage(hHwnd, WM_CAP_SET_PREVIEWRATE, 66, 0)

                '
                'Start previewing the image from the camera
                '
                SendMessage(hHwnd, WM_CAP_SET_PREVIEW, True, 0)

                '
                ' Resize window to fit in picturebox
                '
                SetWindowPos(hHwnd, HWND_BOTTOM, 0, 0, picCapture.Width, picCapture.Height, _
                        SWP_NOMOVE Or SWP_NOZORDER)

                btnSave.Enabled = True
                btnStop.Enabled = True
                btnStart.Enabled = False
            Else
                '
                ' Error connecting to device close window
                ' 
                DestroyWindow(hHwnd)

                btnSave.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        btnStart.Enabled = True
        btnSave.Enabled = True
        iDevice = lstDevices.SelectedIndex
        OpenPreviewWindow()
    End Sub

    Private Sub ClosePreviewWindow()
        Try
            '
            ' Disconnect from device
            '
            SendMessage(hHwnd, WM_CAP_DRIVER_DISCONNECT, iDevice, 0)

            '
            ' close window
            '

            DestroyWindow(hHwnd)
        Catch ex As Exception

        End Try
      
    End Sub

    Private Sub btnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop.Click
        ClosePreviewWindow()
        btnSave.Enabled = False
        btnStart.Enabled = True
        btnStop.Enabled = False
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim data As IDataObject
        Dim bmap As Image

        '
        ' Copy image to clipboard
        '
        SendMessage(hHwnd, WM_CAP_EDIT_COPY, 0, 0)

        '
        ' Get image from clipboard and convert it to a bitmap
        '
        data = Clipboard.GetDataObject()
        If data.GetDataPresent(GetType(System.Drawing.Bitmap)) Then
            bmap = CType(data.GetData(GetType(System.Drawing.Bitmap)), Image)
            picCapture.Image = bmap
            ClosePreviewWindow()
            btnSave.Enabled = False
            btnStop.Enabled = False
            btnStart.Enabled = True
            Dim sTempFileName As String = System.IO.Path.GetTempFileName()

            bmap.Save(sTempFileName, Imaging.ImageFormat.Jpeg)
            TempFileNames2 = sTempFileName
            Me.Close()
        End If
    End Sub

    Private Sub Form1_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If btnStop.Enabled Then
            ClosePreviewWindow()
        End If
    End Sub

    Private Sub lstDevices_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstDevices.SelectedIndexChanged
        ClosePreviewWindow()
        btnStart.Enabled = True
        btnSave.Enabled = True
        iDevice = lstDevices.SelectedIndex
        OpenPreviewWindow()
    End Sub
End Class
