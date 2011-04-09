namespace SFT.Core.Domain
{
    public abstract class PersistentObject
    {
        public virtual int ID { get; set; }
        //public virtual string InsertedBy { get; set; }
        //public virtual DateTime InsertedOn { get; set; }
        //public virtual string LastModifiedBy { get; set; }
        //public virtual DateTime LastModifiedOn { get; set; }
    }
}