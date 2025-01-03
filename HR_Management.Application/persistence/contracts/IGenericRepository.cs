﻿namespace HR_Management.Application.persistence.contracts;

public interface IGenericRepository<T> where T : class
{
    Task<T> Get(int id);
    Task<IReadOnlyList<T>> GetAll();
    Task<bool> Exist(int id);
    Task<T> Add(T entity);
    Task<T> Update(T entity);
    Task<T> Delete(T entity);
}