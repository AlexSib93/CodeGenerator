
namespace CodeGenerator.Metadata
{
    public class Settings
    {
        /// <summary>
        /// Database connection string
        /// </summary>
        public string ConnectionString { get; set; }
        /// <summary>
        /// Gen WebApi project files
        /// </summary>
        public bool GenWebApiProject { get; set; }
        /// <summary>
        /// Gen react project files
        /// </summary>
        public bool GenReactProject { get; set; }
        /// <summary>
        /// Gen BuisinessLogicLayer project files
        /// </summary>
        public bool GenBllProject { get; set; }
        /// <summary>
        /// Gen DataAccessLayer project files
        /// </summary>
        public bool GenDalProject { get; set; }
        /// <summary>
        /// Gen WinDraw DocumentScript project files
        /// </summary>
        public bool GenWdScriptProject { get; set; }
        public static Settings DefaultDevSettings => GetDefaultDevSettings();

        public static string TemplatesPath => "Templates";

        private static Settings GetDefaultDevSettings()
        {
            return new Settings
            {
                ConnectionString = "",
                GenBllProject = true,
                GenDalProject = true,
                GenReactProject = true,
                GenWdScriptProject = true,
                GenWebApiProject = true
            };
        }
    }
}