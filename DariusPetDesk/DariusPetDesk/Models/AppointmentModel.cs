using System.Text.Json.Serialization;

namespace Darius_PetDesk.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<IEnumerable<Root>>(myJsonResponse);
    public class Root
    {
        public int? appointmentId { get; set; }
        public string? appointmentType { get; set; }
        public DateTime? createDateTime { get; set; }
        public DateTime? requestedDateTimeOffset { get; set; }
        public int? user_UserId { get; set; }
        public User? user { get; set; }
        public int? animal_AnimalId { get; set; }
        public Animal? animal { get; set; }

    }

    public class Animal
    {
        public int? animalId { get; set; }
        public string? firstName { get; set; }
        public string? species { get; set; }
        public string? breed { get; set; }
    }



    public class User
    {
        public int? userId { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? vetDataId { get; set; }
    }



}
