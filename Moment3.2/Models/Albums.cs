using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Moment3._2.Models
{
    public class Albums
    {

        public int AlbumsId { get; set; }


        public string? Title { get; set; }

        public string? Artist { get; set; }

        public int? GenresId { get; set; }

        public bool Rented { get; set; } = false;

        public string? Year { get; set; }

        public virtual Genres? Genres { get; set; }

        public Rentals? RentaslId { get; set; }

    }


}
