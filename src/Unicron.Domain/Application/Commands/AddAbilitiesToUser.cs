﻿using System;
using System.Collections.Generic;

namespace Unicron.Users.Domain.Application.Commands
{
    public class AddAbilitiesToUser
    {
        public Guid UserId { get; protected set; }

 
        public IEnumerable<Guid> AbilitiesID { get; protected set; }

        protected AddAbilitiesToUser()
        {
            
        }

        public AddAbilitiesToUser(Guid userId, IEnumerable<Guid> abilities )
        {
            UserId = userId;
            this.AbilitiesID = abilities;
        }
    }
}
