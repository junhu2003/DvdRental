﻿using DvdRental.Library.Models;
using FluentValidation;

namespace DvdRental.Library.Validators
{
    public class StaffValidator : AbstractValidator<Staff>
    {
        public StaffValidator() { }
    }
}