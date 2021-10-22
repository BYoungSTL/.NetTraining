namespace NET01.Interfaces
{
    public interface IVersionable
    {
        public byte[] GetVersion();
        public void SetVersion(byte[] version);
    }
}