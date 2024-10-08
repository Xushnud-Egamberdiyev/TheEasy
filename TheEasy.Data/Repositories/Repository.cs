﻿using Microsoft.EntityFrameworkCore;
using TheEasy.Data.DbContexs;
using TheEasy.Data.IRepositories;
using TheEasy.Domain.Commans;

namespace TheEasy.Data.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Auditable
{
    private readonly AppDbContext appDbContext;
    private readonly DbSet<TEntity> dbSet;

    public Repository(AppDbContext appDbContext)
    {
        this.appDbContext = appDbContext;
        this.dbSet = this.appDbContext.Set<TEntity>();
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var entity = await this.dbSet.FirstOrDefaultAsync(e => e.Id == id);
        this.dbSet.Remove(entity);
        return true;
    }

    public async Task<TEntity> InsertAsync(TEntity entity)
    {
        var model = (await this.dbSet.AddAsync(entity)).Entity;
        return model;
    }

    public async Task<bool> SacheChangAsync()
    {
        return await this.appDbContext.SaveChangesAsync() > 0;
    }

    public IQueryable<TEntity> SelectAll() =>
        this.dbSet;

    public async Task<TEntity> SelectByIdAsync(long id)
    {
        return await this.dbSet.FirstOrDefaultAsync(e => e.Id == id);

    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        var model = this.dbSet.Update(entity);
        return model.Entity;

    }
}
