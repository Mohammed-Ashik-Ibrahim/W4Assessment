﻿using Microsoft.AspNetCore.Http;

        }
            // TODO: Authenticate Admin with Database
            // If not authenticate return 401 Unauthorized
            // Else continue with below flow

            //var Claims = new List<Claim>
            //{
            //    new Claim("type", "Admin"),
            //};

            //Claims,

            if (!UsersRecords.Any(x => x.Key == User.Username && x.Value == User.Password))

            var token = new JwtSecurityToken(
                "https://fbi-demo.com",
                "https://fbi-demo.com",
                expires: DateTime.Now.AddDays(30.0),
                signingCredentials: new SigningCredentials(Key, SecurityAlgorithms.HmacSha256)
            );