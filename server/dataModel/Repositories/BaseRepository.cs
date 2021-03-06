﻿namespace dataModel.Repositories
{
    public class BaseRepository
    {
        protected readonly IDbContextFactory _dbContextFactory;

        public BaseRepository(IDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
    }
}
