﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCore.Models;

namespace WebApiCore.Infra.Authentication.Interfaces
{
    public interface ITokenService
    {
        string GenerateJSONWebToken(Users users);
    }
}
