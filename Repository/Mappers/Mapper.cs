using AutoMapper;
using Database.Entities.FarmArea;
using Database.Entities.Sort;
using Database.Entities.Tree;
using Database.Entities.Type;
using Domain.ModelInterfaces.BaseTree;
using Domain.ModelInterfaces.FarmArea;
using Domain.ModelInterfaces.TreeSort;
using Domain.ModelInterfaces.TreeType;
using Repository.BusinessModels;

namespace Repository.Mappers
{
    public sealed class Mapper : Profile
    {
        public Mapper()
        {
            // Configuration of tree mapping.
            CreateMap<IBaseTree, TreeDb>();
            CreateMap<TreeDb, TreeBusinessModel>();

            // Configuration of area mapping.
            CreateMap<IFarmArea,FarmAreaDb>();
            CreateMap<FarmAreaDb,FarmModel>();

            // Configuration of tree sort mapping.
            CreateMap<ITreeSort, TreeSortDb>();
            CreateMap<TreeSortDb, TreeSort>();

            // Configruation of tree type mapping.
            CreateMap<ITreeType, TreeTypeDb>();
            CreateMap<TreeTypeDb, TreeType>();
        }
    }
}
