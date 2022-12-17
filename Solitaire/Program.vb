Friend Module Program

    <STAThread()>
    Friend Sub Main(args As String())
        ' Application.SetHighDpiMode(HighDpiMode.SystemAware)
        Application.EnableVisualStyles()
        Application.DoEvents()
        ' Application.SetCompatibleTextRenderingDefault(False)
        Application.Run(New Solitaire)
    End Sub

End Module
