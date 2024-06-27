namespace Dinet.Domain
{
    public abstract class BaseDomainModel
    {
        public int Id { get; set; }
        public DateTime? CreationDate { get; set; }
    }
}
