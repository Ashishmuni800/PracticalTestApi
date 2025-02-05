﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ApiHttpClient
{
    public interface IHttpClients
    {
        Task<string> GetAsync(string url);
        Task<string> PostAsync(string url, object data);
        Task<bool> DeleteAsync(string url, string id);
    }
}
