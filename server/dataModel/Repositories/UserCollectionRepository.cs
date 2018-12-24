﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace dataModel.Repositories
{
    public class UserCollectionRepository : BaseRepository, IUserCollectionRepository
    {
        public UserCollectionRepository(IDbContextFactory dbContextFactory) : base(dbContextFactory) { }

        public async Task<UserCollection> AddAsync(UserCollection userCollection)
        {
            using(var db = _dbContextFactory.Create())
            {
                await db.UserCollections.AddAsync(userCollection);
                await db.SaveChangesAsync();
                return userCollection;
            }
        }

        public async Task<IEnumerable<UserCollection>> GetUserCollectionsAsync(string userId)
        {
            using (var db = _dbContextFactory.Create())
            {
                return await (from uc in db.UserCollections
                        where uc.UserId == userId
                        select uc).ToListAsync<UserCollection>();
            }
        }

        public async Task<IEnumerable<UserCollection>> SearchAsync(string searchString)
        {
            using (var db = _dbContextFactory.Create())
            {
                return await(from uc in db.UserCollections
                             where uc.Name.Contains(searchString) || uc.Description.Contains(searchString)
                             select uc).ToListAsync<UserCollection>();
            }
        }
    }
}
