using System;
using System.ComponentModel.DataAnnotations;

public class TransactionDetail
{
    [Key]
    public int Id { get; set; }

    public string TransactionData { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now; // Default to current date and time
}
