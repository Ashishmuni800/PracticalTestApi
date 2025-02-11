﻿using Application.DTO;
using Application.ViewModel;
using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ServiceInterface
{
    public interface IPrasonalDetailsService
    {
        Task<bool> EditPrasonalDetailsAsync(PrasonalDetailsDTO PrasonalDetails);
        Task<bool> AddPrasonalDetailsAsync(PrasonalDetailsDTO PrasonalDetails);
        Task<IEnumerable<PrasonalDetailsViewModel>> GetPrasonalDetailsAsync();
        Task<PrasonalDetailsViewModel> GetPrasonalDetailsByIdAsync(int Id);
        Task<bool> DeletedAsync(int Id);
    }
}
