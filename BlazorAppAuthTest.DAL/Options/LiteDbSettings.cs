using System.ComponentModel.DataAnnotations;

namespace BlazorAppAuthTest.DAL.Options
{
    public class LiteDbSettings
    {
        public static readonly string SectionName = nameof(LiteDbSettings);

        [Required]
        public string DbFilePath { get; set; }
    }
}
