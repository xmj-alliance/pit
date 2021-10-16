namespace MongoDataAccess.App.Models;

internal record Order(
    string ID,
    DateTime UpdateDate,
    DateTime DeleteDate,

    string BuyerDBName,
    string SellerDBName,
    string ToyDBName,
    int Quantity,
    decimal Fee
) : IBaseAssociation;