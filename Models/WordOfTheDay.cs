using System.ComponentModel.DataAnnotations;

namespace VerdonSale.Models
{
    public class WordOfTheDay
    {
        [Key]
        public Guid WordOfTheDayId { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Stamp { get; set; }

        public WordOfTheDay()
        {
            Stamp = DateTime.Now;
        }

    }
}
