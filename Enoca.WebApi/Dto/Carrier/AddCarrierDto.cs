namespace Enoca.WebApi.Dto.Carrier
{
    public class AddCarrierDto
    {
        public string CarrierName { get; set; } = null!;
        public bool CarrierIsActive { get; set; }
        public int CarrierPlusDesiCost { get; set; }
    }
}
