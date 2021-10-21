namespace MongoDataAccess.App.Models;

public record InputOrder(
    string BuyerDBName,
    string SellerDBName,
    string ToyDBName,
    int? Quantity = null,
    decimal? Fee = null
);