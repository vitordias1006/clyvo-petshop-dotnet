using PetshopApi.Application.DTOs;
using PetshopApi.Application.Services;
using PetshopApi.Infrastructure.Persistence;

namespace PetshopApi.Infrastructure;

public sealed class QueryRepository(PetShopContext context) : IQueryRepository
{
    public IReadOnlyList<QueryResponse> GetAll()
    {
        return context.Queries
            .OrderBy(q => q.Time)
            .Select(QueryResponse.FromDomain)
            .ToList();
    }

    public IReadOnlyList<QueryResponse> GetByPetId(Guid petId)
    {
        return context.Queries
            .Where(q => q.PetId == petId)
            .Select(QueryResponse.FromDomain)
            .ToList();
    }

    public IReadOnlyList<QueryResponse> GetByStatus(string status)
    {
        return context.Queries
            .Where(q => q.Status == status)
            .Select(QueryResponse.FromDomain)
            .ToList();
    }

    public QueryResponse? GetById(Guid id)
    {
        var query = context.Queries.FirstOrDefault(q => q.Id == id);
        return query is null ? null : QueryResponse.FromDomain(query);
    }

    public QueryResponse Create(QueryRequest request)
    {
        if (request is null)
            throw new ArgumentNullException(nameof(request));

        if (string.IsNullOrWhiteSpace(request.Status))
            throw new InvalidOperationException("O status da consulta é obrigatório");

        var query = request.ToDomain();
        context.Queries.Add(query);
        context.SaveChanges();

        return QueryResponse.FromDomain(query);
    }

    public bool ExistsById(Guid id)
    {
        return context.Queries.Any(q => q.Id == id);
    }

    public bool Delete(Guid id)
    {
        var query = context.Queries.FirstOrDefault(q => q.Id == id);
        if (query is null)
            return false;

        context.Queries.Remove(query);
        context.SaveChanges();
        return true;
    }
}