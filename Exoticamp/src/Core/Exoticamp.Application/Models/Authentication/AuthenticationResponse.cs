﻿using System;

namespace Exoticamp.Application.Models.Authentication
{
    public class AuthenticationResponse
    {
        public string Name { get; set; }
        public string Message { get; set; }
        public bool IsAuthenticated { get; set; }
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
         public string Role { get; set; }

        public Guid LocationId { get; set; }
        public DateTime? RefreshTokenExpiration { get; set; }
    }
}
