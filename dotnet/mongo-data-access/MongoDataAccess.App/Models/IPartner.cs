﻿internal interface IPartner: IBaseModel
{
    string Type { get; }
    string Phone { get; }
    string Address { get; }
    string Email { get; }
    string BankAccount { get; }
    float Ratings { get; }
    IEnumerable<string> Partners { get; }
}