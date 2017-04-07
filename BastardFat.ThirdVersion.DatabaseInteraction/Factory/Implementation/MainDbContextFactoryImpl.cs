using BastardFat.ThirdVersion.DatabaseInteraction.Context;
using BastardFat.ThirdVersion.DatabaseInteraction.Factory.Base;
using BastardFat.ThirdVersion.DatabaseInteraction.Factory.Interface;

namespace BastardFat.ThirdVersion.DatabaseInteraction.Factory.Implementation
{
    public class MainDbContextFactoryImpl :
        DbContextFactoryBase<MainDbContext>, IMainDbContextFactory
    {
        
    }
}