using MongoDataAccess.App.Database;
using MongoDataAccess.App.Models;
using MongoDB.Driver;

namespace MongoDataAccess.App.Services;
public interface IDataAccessService<T>
{
    string IndexFieldName { get; }
    public CollectionNamespace DBCollectionNamespace { get; }
    Task<T> Get(string indexField, IViewOption? options = null);
    Task<IEnumerable<T>> Get(FilterDefinition<T> condition, IViewOption? options = null);
    // Base Add() methods no longer exist because of the problem in generic C# 9 record identification.
    Task<CUDMessage> Update(string indexField, UpdateDefinition<T> token);
    Task<CUDMessage> Update(FilterDefinition<T> condition, UpdateDefinition<T> token);
    Task<CUDMessage> Drop(string indexFieldValue);
    Task<CUDMessage> Drop(FilterDefinition<T> condition);
    Task<CUDMessage> Delete(string indexField);
    Task<CUDMessage> Delete(FilterDefinition<T> condition);
    Task<TJoint> LeftJoinAndGet<TJoint>(string indexFieldValue, ILeftJoinOption joinOptions, IViewOption? viewOption = null);
    Task<IEnumerable<TJoint>> LeftJoinAndGet<TJoint>(FilterDefinition<TJoint> condition, ILeftJoinOption joinOptions, FilterDefinition<T>? limitCondition, IViewOption? viewOption = null);
    Task<CUDMessage> AddItemToList(string instanceArrayFieldName, string arrayIndexFieldValue, string instanceIndexFieldValue);
    Task<CUDMessage> AddItemToList(string instanceArrayFieldName, IEnumerable<string> arrayIndexFieldValues, string instanceIndexFieldValue);
    Task<CUDMessage> RemoveItemFromList(string instanceArrayFieldName, string arrayIndexFieldValue, string instanceIndexFieldValue);
    Task<CUDMessage> RemoveItemFromList(string instanceArrayFieldName, IEnumerable<string> arrayIndexFieldValues, string instanceIndexFieldValue);
}

