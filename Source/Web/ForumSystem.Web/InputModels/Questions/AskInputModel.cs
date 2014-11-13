namespace ForumSystem.Web.IntupModels.Questions
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class AskInputModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        [AllowHtml]
        [DataType("tinymce_full")]
        public string Content { get; set; }

        [Required]
        public string Tags { get; set; }
    }
}