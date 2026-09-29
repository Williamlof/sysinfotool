namespace SysInfoTool
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // One instance per user session, so a logon launch plus a manual start
            // doesn't leave two tray icons.
            using var mutex = new Mutex(true, @"Local\SysInfoToolV3", out bool createdNew);
            if (!createdNew)
                return;

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // Start in the tray only: the form is created but not shown until the user
            // opens it from the tray icon. The message loop runs until Exit is chosen.
            using var form = new Form1();
            Application.Run();
        }
    }
}
