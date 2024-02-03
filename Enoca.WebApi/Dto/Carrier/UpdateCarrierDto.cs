namespace Enoca.WebApi.Dto.Carrier
{
    public class UpdateCarrierDto
    {
        public int CarrierId { get; set; }
        public string CarrierName { get; set; } = null!;
        public bool CarrierIsActive { get; set; }
        public int CarrierPlusDesiCost { get; set; }
    }
}
