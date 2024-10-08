﻿using Ticket.Domain.Entities.Common;
using Ticket.Domain.Entities.Users;

namespace Ticket.Domain.Entities.Financial
{
    /// <summary>
    /// شماره کارت های اعتباری شخص برای برداشت از کیف پول
    /// </summary>
    public class CartNumbers : BaseEntitySimple
    {
        public User User { get; set; }
        public long UserId { get; set; }

        public string CardNumber { get; set; }

        public Bank Bank { get; set; }
        public long BankId { get; set; }
    }
}
