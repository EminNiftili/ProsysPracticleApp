using AutoMapper;

namespace ProsysTestApp.Core.AutoMapper
{
    public interface IBidirectionalMap<T>
    {
        void CreateMap(Profile profile)
            => profile.CreateMap(GetType(), typeof(T)).ReverseMap();
    }
}
