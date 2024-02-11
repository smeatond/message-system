using MessageWeb.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MessageWeb.Services;

public class MessageService
{
    private readonly IMongoCollection<Message> _messagesCollection;

    public MessageService(
        IOptions<MessageDatabaseSettings> messageDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            messageDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            messageDatabaseSettings.Value.DatabaseName);

        _messagesCollection = mongoDatabase.GetCollection<Message>(
            messageDatabaseSettings.Value.MessageCollectionName);
    }

    public async Task<List<Message>> GetAsync() =>
        await _messagesCollection.Find(_ => true).ToListAsync(); 

    public async Task CreateAsync(Message newMsg) =>
        await _messagesCollection.InsertOneAsync(newMsg);
}