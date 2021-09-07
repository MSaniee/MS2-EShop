using MS2EShop.Domain.Core.DILifeTimesType;

namespace MS2EShop.Application.Interfaces.DataInitializer
{
    public interface IDataInitializer : IScopedDependency
    {
        void InitializeData();
    }
}
