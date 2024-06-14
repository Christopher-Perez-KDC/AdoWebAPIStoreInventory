namespace AdoWebAPIStoreInventory.RequestModels
{
    public class CreateFoodMarketRequest
    {
        public string FoodName { get; set; }
        public string FoodDescription { get; set; }
        public int Quantity { get; set; }
        public DateOnly ExpirationDate { get; set; }
    }
}
