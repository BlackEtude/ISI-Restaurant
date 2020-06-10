namespace ISI_Restaurant.Shared.Models
{
    public partial class DeliveryPoint
    {
        public string GetFormattedDetails() 
            => string.Join(", ", Address.Street, Address.City, Address.PostalCode) + $", otwarte: {OpeningHours.OpeningHour.Substring(0, 5)}-{OpeningHours.ClosingHour.Substring(0, 5)}";
    }
}
