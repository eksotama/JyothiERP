﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.34209
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Namespace My
    
    <Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0"),  _
     Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
    Partial Public NotInheritable Class MySettings
        Inherits Global.System.Configuration.ApplicationSettingsBase
        
        Private Shared defaultInstance As MySettings = CType(Global.System.Configuration.ApplicationSettingsBase.Synchronized(New MySettings()),MySettings)
        
#Region "My.Settings Auto-Save Functionality"
#If _MyType = "WindowsForms" Then
    Private Shared addedHandler As Boolean

    Private Shared addedHandlerLockObject As New Object

    <Global.System.Diagnostics.DebuggerNonUserCodeAttribute(), Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)> _
    Private Shared Sub AutoSaveSettings(ByVal sender As Global.System.Object, ByVal e As Global.System.EventArgs)
        If My.Application.SaveMySettingsOnExit Then
            My.Settings.Save()
        End If
    End Sub
#End If
#End Region
        
        Public Shared ReadOnly Property [Default]() As MySettings
            Get
                
#If _MyType = "WindowsForms" Then
               If Not addedHandler Then
                    SyncLock addedHandlerLockObject
                        If Not addedHandler Then
                            AddHandler My.Application.Shutdown, AddressOf AutoSaveSettings
                            addedHandler = True
                        End If
                    End SyncLock
                End If
#End If
                Return defaultInstance
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Data Source=SOFTWARE-E88806\SQLEXPRESS;Integrated Security=True")>  _
        Public ReadOnly Property ConnectionString() As String
            Get
                Return CType(Me("ConnectionString"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Data Source=JYOTHISURESH-PC\SQLEXPRESS;Initial Catalog=JVSKINVDB100;Integrated Se"& _ 
            "curity=True")>  _
        Public ReadOnly Property JVSKINVDB100ConnectionString() As String
            Get
                Return CType(Me("JVSKINVDB100ConnectionString"),String)
            End Get
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property DefPrinterName() As String
            Get
                Return CType(Me("DefPrinterName"),String)
            End Get
            Set
                Me("DefPrinterName") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Yes")>  _
        Public Property PrintonA5() As String
            Get
                Return CType(Me("PrintonA5"),String)
            End Get
            Set
                Me("PrintonA5") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("*All")>  _
        Public Property pospricelist() As String
            Get
                Return CType(Me("pospricelist"),String)
            End Get
            Set
                Me("pospricelist") = value
            End Set
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Data Source=JYOTHISURESH-PC\SQLEXPRESS;Initial Catalog=JVSKINVDB103;Integrated Se"& _ 
            "curity=True")>  _
        Public ReadOnly Property JVSKINVDB103ConnectionString() As String
            Get
                Return CType(Me("JVSKINVDB103ConnectionString"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Data Source=JYOTHISURESH-PC\sqlexpress;Initial Catalog=JVSKRestorAccDBF;Integrate"& _ 
            "d Security=True")>  _
        Public ReadOnly Property JVSKRestorAccDBFConnectionString() As String
            Get
                Return CType(Me("JVSKRestorAccDBFConnectionString"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Data Source=JYOTHISURESH-PC\sqlexpress;Initial Catalog=JyothipharmaDB100;Integrat"& _ 
            "ed Security=True")>  _
        Public ReadOnly Property JyothipharmaDB100ConnectionString() As String
            Get
                Return CType(Me("JyothipharmaDB100ConnectionString"),String)
            End Get
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property keycode() As String
            Get
                Return CType(Me("keycode"),String)
            End Get
            Set
                Me("keycode") = value
            End Set
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Data Source=JYOTHISURESH-PC\sqlexpress;Initial Catalog=JyothipharmaerpDB100;Integ"& _ 
            "rated Security=True")>  _
        Public ReadOnly Property JyothipharmaerpDB100ConnectionString() As String
            Get
                Return CType(Me("JyothipharmaerpDB100ConnectionString"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Data Source=JYOTHISURESH-PC\sqlexpress;Initial Catalog=JyothiERPDB100;Integrated "& _ 
            "Security=True")>  _
        Public ReadOnly Property JyothiERPDB100ConnectionString() As String
            Get
                Return CType(Me("JyothiERPDB100ConnectionString"),String)
            End Get
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property networkdbname() As String
            Get
                Return CType(Me("networkdbname"),String)
            End Get
            Set
                Me("networkdbname") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property printernametoexport() As String
            Get
                Return CType(Me("printernametoexport"),String)
            End Get
            Set
                Me("printernametoexport") = value
            End Set
        End Property
        
        <Global.System.Configuration.UserScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.DefaultSettingValueAttribute("")>  _
        Public Property filetypetoexport() As String
            Get
                Return CType(Me("filetypetoexport"),String)
            End Get
            Set
                Me("filetypetoexport") = value
            End Set
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Data Source=JYOTHISURESH-PC\sqlexpress;Initial Catalog=MESWERPDBDD100;Integrated "& _ 
            "Security=True")>  _
        Public ReadOnly Property MESWERPDBDD100ConnectionString() As String
            Get
                Return CType(Me("MESWERPDBDD100ConnectionString"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Data Source=SURESHJYOTHI-PC\SQLEXPRESS;Initial Catalog=MESWERPDBDD109;Integrated "& _ 
            "Security=True")>  _
        Public ReadOnly Property MESWERPDBDD109ConnectionString() As String
            Get
                Return CType(Me("MESWERPDBDD109ConnectionString"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Data Source=SEVER\SQLEXPRESS;Initial Catalog=MESWERPDBDD100;User ID=SA;Password=j"& _ 
            "yothierp")>  _
        Public ReadOnly Property MESWERPDBDD100ConnectionString1() As String
            Get
                Return CType(Me("MESWERPDBDD100ConnectionString1"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Data Source=SURESHJYOTHI-PC\sqlexpress;Initial Catalog=MESWERPDBDD118;Integrated "& _ 
            "Security=True")>  _
        Public ReadOnly Property MESWERPDBDD118ConnectionString() As String
            Get
                Return CType(Me("MESWERPDBDD118ConnectionString"),String)
            End Get
        End Property
        
        <Global.System.Configuration.ApplicationScopedSettingAttribute(),  _
         Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
         Global.System.Configuration.SpecialSettingAttribute(Global.System.Configuration.SpecialSetting.ConnectionString),  _
         Global.System.Configuration.DefaultSettingValueAttribute("Data Source=SURESHJYOTHI-PC\SQLEXPRESS;Initial Catalog=MESWERPDBDD116;Integrated "& _ 
            "Security=True")>  _
        Public ReadOnly Property MESWERPDBDD116ConnectionString() As String
            Get
                Return CType(Me("MESWERPDBDD116ConnectionString"),String)
            End Get
        End Property
    End Class
End Namespace

Namespace My
    
    <Global.Microsoft.VisualBasic.HideModuleNameAttribute(),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute()>  _
    Friend Module MySettingsProperty
        
        <Global.System.ComponentModel.Design.HelpKeywordAttribute("My.Settings")>  _
        Friend ReadOnly Property Settings() As Global.JyothiPharmaERPSystem3.My.MySettings
            Get
                Return Global.JyothiPharmaERPSystem3.My.MySettings.Default
            End Get
        End Property
    End Module
End Namespace
