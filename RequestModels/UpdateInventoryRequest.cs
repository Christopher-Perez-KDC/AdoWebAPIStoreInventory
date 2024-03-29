namespace AdoWebAPIStoreInventory.RequestModels;

public class UpdateInventoryRequest
{
    public int InventoryId { get; set; }
    public string Item {  get; set; }
    public string BrandName {  get; set; }
    public int CountOnHand { get; set; }
    public string Location { get; set; }
    public decimal Cost {  get; set; }

}
