﻿using System;
using AcklenAvenue.Commands;
using Unicron.Users.Domain.Application.Commands;
using Unicron.Users.Domain.DomainEvents;
using Unicron.Users.Domain.Entities;
using Unicron.Users.Domain.Services;

namespace Unicron.Users.Domain.Application.CommandHandlers
{
    public class UserRolAdder : ICommandHandler<AddRoleToUser>
    {
        private readonly IWriteableRepository _writeableRepository;
        private readonly IReadOnlyRepository _readOnlyRepository;
        private readonly IIdentityGenerator<Guid> _identityGenerator;

        public UserRolAdder(IWriteableRepository writeableRepository, IReadOnlyRepository readOnlyRepository, IIdentityGenerator<Guid> identityGenerator)
        {
            _writeableRepository = writeableRepository;
            _readOnlyRepository = readOnlyRepository;
            _identityGenerator = identityGenerator;
        }

        public void Handle(IUserSession userIssuingCommand, AddRoleToUser command)
        {

            var user = _readOnlyRepository.GetById<User>(command.UserId);
            var role = _readOnlyRepository.GetById<Role>(command.RolId);

            user.AddRol(role);

            _writeableRepository.Update(user);
            NotifyObservers(new UserRoleAdded(user.Id, role.Id));


        }

        public event DomainEvent NotifyObservers;
    }
}