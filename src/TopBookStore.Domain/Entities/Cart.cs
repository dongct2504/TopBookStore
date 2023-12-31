﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TopBookStore.Domain.Entities;

[Index("CustomerId", Name = "CARTCUSTOMERS_FK")]
public partial class Cart
{
    [Key]
    public int CartId { get; set; }

    public int CustomerId { get; set; }

    [Column(TypeName = "money")]
    public decimal TotalAmount { get; set; }

    [InverseProperty("Cart")]
    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    [ForeignKey("CustomerId")]
    [InverseProperty("Carts")]
    public virtual Customer Customer { get; set; } = null!;
}
