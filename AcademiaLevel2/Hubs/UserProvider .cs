﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AcademiaLevel2.Hubs
{
    public class UserProvider : IUserIdProvider
    {
        public string GetUserId(IRequest request)
        {
            if (request.User == null)
            {
                return null;
            }

            return request.User.Identity.GetUserId();
        }
    }

}