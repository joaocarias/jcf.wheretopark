﻿using System.Security.Claims;
using Jcf.WhereToPark.Api.Applications.User.Entities;

namespace Jcf.WhereToPark.Api.Core.Services.IServices
{
    public interface ITokenService
    {
        ClaimsIdentity GeneratorClaims(User user);
        string NewToken(User user);
    }
}
