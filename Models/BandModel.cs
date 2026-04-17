namespace Band.Models
{
    public class BandModel
    {
        public BandModel(string name)
        {
            Name = name;
            Id = Guid.NewGuid();
        }
        public Guid Id { get; init; }
        public string Name { get; private set; }
        public Boolean IsActive { get; private set; }
        
        public void UpdateName(string name)
        {
            Name = name;
        }

        public void SetInactive()
        {
            IsActive = false;
        }
    }
}
