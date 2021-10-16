﻿namespace MongoDataAccess.App.Models;

internal record InputOrder(
    string BuyerDBName,
    string SellerDBName,
    string ToyDBName,
    int? Quantity,
    decimal? Fee
);