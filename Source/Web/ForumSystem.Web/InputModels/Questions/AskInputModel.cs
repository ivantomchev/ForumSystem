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
        public string Title { get; set; }

        [AllowHtml]
        [DataType("tinymce_full")]
        public string Content { get; set; }

        public string Tags { get; set; }
    }
}