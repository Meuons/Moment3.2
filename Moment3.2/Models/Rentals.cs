using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Moment3._2.Models
{
    public class Rentals
    {

        public int RentalsId { get; set; }
        public string? Date { get; set; }
        public int UsersId { get; set; }
        public virtual Users? Users { get; set; }
        public int AlbumsId { get; set; }

        public virtual Albums? Albums { get; set; }


    }


}
