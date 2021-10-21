namespace NET01.Entities
{
    public interface IVersionable
    {
        public byte[] GetVersion();
        public void SetVersion(byte[] version);
    }
}