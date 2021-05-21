using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proj2Aalst_G3.Models.Domain
{
    public class Blogpost : IEquatable<Blogpost>
    {
        #region Properties

        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Titel")]
        public string Title { get; set; }
        [DisplayName("Publicatiedatum")]
        public DateTime PublicationTime { get; set; }
        [Required]
        [DisplayName("Bericht")]
        public string Text { get; set; }

        #endregion

        #region Constructors

        public Blogpost()
        {
        }

        public Blogpost(string title, string text)
        {
            this.Title = title;
            this.Text = text;
            this.PublicationTime = DateTime.Now;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Blogpost);
        }

        public bool Equals(Blogpost other)
        {
            return other != null &&
                   Id == other.Id &&
                   Title == other.Title &&
                   PublicationTime == other.PublicationTime &&
                   Text == other.Text;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Title, PublicationTime, Text);
        }



        #endregion

        #region Methods



        #endregion
    }
}