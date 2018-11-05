namespace dataModel.Repositories
{
    public interface IDbContextFactory
    {
        MgDataContext Create();
        MgDataContext CreateNoTracking();
    }
}
