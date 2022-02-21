using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Moment3._2.Models
{
    public class Genres
    {





        public int? GenresId { get; set; }
        public string? Name { get; set; }

        public List<Albums>? Albums { get; set; }



    }
}