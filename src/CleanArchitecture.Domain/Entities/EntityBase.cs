using MongoDB.Bson.Serialization.Attributes;

namespace CleanArchitecture.Domain.Entities;
public class EntityBase<Tkey>
{
    [BsonId]
    [BsonElement("_id")]
    public Tkey? Id { get; set; }
}
