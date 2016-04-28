Public Class SHORTCUTKEYFRM

    Private Sub SHORTCUTKEYFRM_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Try
            WebBrowser1.Navigate("file:///" & Application.StartupPath & "\shortcutshelp.htm")

        Catch ex As Exception
            WebBrowser1.DocumentText = "<html> <head> <meta http-equiv=Content-Type content=""text/html; charset=windows-1252""> <meta name=Generator content=""Microsoft Word 12 (filtered)""> <style><!-- /* Font Definitions */ @font-face	{font-family:""Cambria Math"";	panose-1:2 4 5 3 5 4 6 3 2 4;}@font-face	{font-family:Calibri;	panose-1:2 15 5 2 2 2 4 3 2 4;} /* Style Definitions */ p.MsoNormal, li.MsoNormal, div.MsoNormal	{margin-top:0in;	margin-right:0in;	margin-bottom:10.0pt;	margin-left:0in;	line-height:115%;	font-size:11.0pt;	font-family:""Calibri"",""sans-serif"";}p.MsoNoSpacing, li.MsoNoSpacing, div.MsoNoSpacing	{margin:0in;	margin-bottom:.0001pt;	font-size:11.0pt;	font-family:""Calibri"",""sans-serif"";}.MsoPapDefault	{margin-bottom:10.0pt;	line-height:115%;}@page Section1	{size:595.3pt 841.9pt;	margin:1.0in 1.0in 1.0in 1.0in;}div.Section1	{page:Section1;}--></style></head><body lang=EN-IN><div class=Section1>" _
         & " <p class=MsoNoSpacing><b><u>FORM SHORT CUTS</u></b></p><p class=MsoNoSpacing>SAVE                             : Ctrl+S</p><p class=MsoNoSpacing>NEW                              : Ctrl+N</p><p class=MsoNoSpacing>OPEN/EDIT                 : Ctrl+O / Ctrl+E</p><p class=MsoNoSpacing>DELETE                          : Ctrl+D</p><p class=MsoNoSpacing>EDIT                               : Ctrl+E</p><p class=MsoNoSpacing>CLOSE                           : Ctrl+W</p><p class=MsoNoSpacing>RELOAD/REFRESS     :Ctrl+F5</p><p class=MsoNoSpacing>&nbsp;</p><p class=MsoNoSpacing><b><u>POS </u></b></p><p class=MsoNoSpacing>SAVE                             : F2</p><p class=MsoNoSpacing>Open                             : F3</p><p class=MsoNoSpacing>&nbsp;</p><p class=MsoNoSpacing><b>VOUCHERS</b></p> " _
         & " <p class=MsoNoSpacing>CONTRA                       :F4</p><p class=MsoNoSpacing>PAYMENT                    :F5</p><p class=MsoNoSpacing>RECEIPT                        :F6</p><p class=MsoNoSpacing>JOURNAL                     :F7</p><p class=MsoNoSpacing>SALES                            :F8</p><p class=MsoNoSpacing>CREDIT NOTE             :CTRL+F8</p><p class=MsoNoSpacing>PURCHASE                  :F9</p><p class=MsoNoSpacing>DEBIT NOTE                :CTRL+F9</p><p class=MsoNoSpacing>SALES INVOICE          :F10</p><p class=MsoNoSpacing>PURCHASE INVOICE        : F11</p><p class=MsoNoSpacing>POS                                :112</p><p class=MsoNoSpacing>&nbsp;</p><p class=MsoNoSpacing><b>CREATE MASTERS    : ALT+C</b></p><p class=MsoNoSpacing>&nbsp;</p><p class=MsoNoSpacing>&nbsp;</p><p class=MsoNoSpacing>&nbsp;</p><p class=MsoNoSpacing>&nbsp;</p><p class=MsoNoSpacing>&nbsp;</p></div> " _
         & " </body></html> "

        End Try

     
    End Sub
End Class