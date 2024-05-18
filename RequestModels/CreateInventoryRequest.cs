namespace AdoWebAPIStoreInventory.RequestModels;

public class CreateInventoryRequest
{
    public string Item { get; set; }
    public string Brand { get; set; }
    public int CountOnHand { get; set; }
    public string Location { get; set; }
    public decimal Cost { get; set; }
}
