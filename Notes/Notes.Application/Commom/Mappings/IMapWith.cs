using AutoMapper;

namespace Notes.Application.Commom.Mappings
{
    public interface IMapWith<T>
    {
        void Mapping(Profile profile)=>
            profile.CreateMap(typeof(T), typeof(T));
    }
}
