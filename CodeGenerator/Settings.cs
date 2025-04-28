
namespace CodeGenerator
{
    public class Settings
    {
        /// <summary>
        /// Database connection string
        /// </summary>
        public string ConnectionString { get; set; }
        /// <summary>
        /// Gen Tests project files
        /// </summary>
        public bool GenTestsProject { get; set; }
        /// <summary>
        /// Gen Solution files
        /// </summary>
        public bool GenSolution { get; set; }
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
        /// <summary>
        /// Gen SqlCommand project files
        /// </summary>
        public bool GenSqlCommandProject { get; set; }

        public static string TemplatesPath { get; set; } = @"..\..\..\Templates";

        public static Settings DefaultDevSettings => GetDefaultDevSettings();
        private static Settings GetDefaultDevSettings()
        {
            return new Settings
            {
                ConnectionString = "",
                GenSolution = true,
                GenBllProject = true,
                GenDalProject = true,
                GenReactProject = true,
                GenWdScriptProject = true,
                GenWebApiProject = true,
                GenTestsProject = true,
                GenSqlCommandProject = true,
            };
        }
    }
}