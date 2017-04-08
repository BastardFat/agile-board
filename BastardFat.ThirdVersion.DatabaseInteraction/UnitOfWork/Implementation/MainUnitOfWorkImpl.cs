using BastardFat.ThirdVersion.DatabaseInteraction.Context;
using BastardFat.ThirdVersion.DatabaseInteraction.Factory.Interface;
using BastardFat.ThirdVersion.DatabaseInteraction.UnitOfWork.Base;
using BastardFat.ThirdVersion.DatabaseInteraction.UnitOfWork.Interface;

namespace BastardFat.ThirdVersion.DatabaseInteraction.UnitOfWork.Implementation
{
    public class MainUnitOfWorkImpl : UnitOfWorkBase<MainDbContext, IMainDbContextFactory>, IMainUnitOfWork
    {
        public MainUnitOfWorkImpl(IMainDbContextFactory dbContextFactory) : base(dbContextFactory)
        {
        }
    }
}