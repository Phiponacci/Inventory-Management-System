﻿namespace ims.Data.Entity;

public class TransactionDetail
{
    public int ProductId { get; set; }
    public int TransactionId { get; set; }
    public decimal Amount { get; set; }
    public virtual Product Product { get; set; }
    public virtual Transaction Transaction { get; set; }
}
