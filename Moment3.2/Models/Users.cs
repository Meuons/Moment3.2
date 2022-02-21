using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Moment3._2.Models
{
    public class Users
    {
        public int? UsersId { get; set; }
        public string? Name { get; set; }
        public List<Rentals>? Rentals { get; set; }

    }
}