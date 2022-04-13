public interface IPersistent
{
    string Id { get; }

    void Save();
    void Load();
}
