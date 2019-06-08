﻿using Npgsql;
using StandardRepository;

using Translation.Data.Entities.Main;

namespace Translation.Data.Repositories.Contracts
{
    public interface IUserRepository : IStandardRepository<User, NpgsqlConnection>
    {
        
    }
}