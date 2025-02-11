﻿using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTO
{
    public class StateDTO : CommanFieldDTO
    {
        public string? StateName { get; set; }
        public string? CountryId { get; set; }
        public Country? Country { get; set; }
    }
}
