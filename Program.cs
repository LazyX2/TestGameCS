namespace TestGameCS
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// 
        public static Game game;
        public static Menu menu;
        public static LevelEditor level_editor;
        [STAThread]
        static void Main() {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            menu = new Menu();
            Application.Run(menu);
        }
    }
}