﻿using HR_Management.Application.contracts.persistence;
using Microsoft.EntityFrameworkCore;

namespace HR_Management.Persistence.repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    #region Context

    private readonly LeaveManagementDbContext _context;

    public GenericRepository(LeaveManagementDbContext context)
    {
        _context = context;
    }

    #endregion

    public async Task<T> Get(int id)
    {
        return (await _context.Set<T>().FindAsync(id))!;
    }

    public async Task<IReadOnlyList<T>> GetAll()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public async Task<bool> Exist(int id)
    {
        var entity = await Get(id);
        return entity != null;

    }

    public async Task<T> Add(T entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task Update(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
        await _context.SaveChangesAsync();
    }
}