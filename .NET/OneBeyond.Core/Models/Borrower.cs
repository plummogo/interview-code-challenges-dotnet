﻿using OneBeyond.Core.Models;

namespace OneBeyondApi.Model
{
    public class Borrower
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public ICollection<Fine> Fines { get; set; } = new List<Fine>();
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
