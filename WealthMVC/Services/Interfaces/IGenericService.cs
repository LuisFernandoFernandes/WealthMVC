namespace WealthMVC.Services.Interfaces
{
    public interface IGenericService<T>
    {
        public string ValidaId(string id);
        public string GeraId();

    }
}
