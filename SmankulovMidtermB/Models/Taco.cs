namespace SmankulovMidtermB.Models
{
    public class Taco
    {
       public int Id { get; set; }

       public string? Size { get; set; }
       public string? Filling { get; set; }

       public string? FirstName { get; set; }
       public string? LastName { get; set; }
       public string? Phone { get; set; }
       public DateTime DateRequested { get; set; }

       public double Total { get; set; }



    }
}
