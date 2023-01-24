using AutoMapper;
using Database.Entities.FarmArea;
using Database.Entities.Tree;
using Domain.ModelInterfaces.BaseTree;
using Domain.ModelInterfaces.FarmArea;
using Repository.BusinessModels;

namespace Repository.Mappers
{
    public sealed class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<IBaseTree, TreeDb>();

            CreateMap<TreeDb, TreeModel>();

            CreateMap <IFarmArea,FarmAreaDb>();

            CreateMap<FarmAreaDb,FarmModel>();
        }
    }
}
