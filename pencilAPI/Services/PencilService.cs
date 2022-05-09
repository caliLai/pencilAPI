using pencilAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace pencilAPI.Services;

public class PencilService
{
    private readonly IMongoCollection<Pencil> _pencilCollection;

    public PencilService(
        IOptions<PencilDB> pencilDB)
    {
        var mongoClient = new MongoClient(
            pencilDB.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            pencilDB.Value.DatabaseName);

        _pencilCollection = mongoDatabase.GetCollection<Pencil>(
            pencilDB.Value.PencilCollection);
    }

    public async Task<List<Pencil>> GetAsync() =>
        await _pencilCollection.Find(_ => true).ToListAsync();

    public async Task<Pencil?> GetAsync(string id) =>
        await _pencilCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Pencil newPencil) =>
        await _pencilCollection.InsertOneAsync(newPencil);

    public async Task UpdateAsync(string id, Pencil updatedPencil) =>
        await _pencilCollection.ReplaceOneAsync(x => x.Id == id, updatedPencil);

    public async Task RemoveAsync(string id) =>
        await _pencilCollection.DeleteOneAsync(x => x.Id == id);
}