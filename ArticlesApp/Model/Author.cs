using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ArticlesApp.Model
{
    public class Author
    {
        public int Id { get; set; }
        [Required, StringLength(255, MinimumLength = 6)]
        public string Login { get; set; }
        [Required, DataType(DataType.Password), StringLength(255, MinimumLength = 6)]
        public string Password { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}
