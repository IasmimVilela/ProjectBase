using System;

namespace TaskB3.Application.AutoMapper
{
    public class AutoMapperConfig
    { 
        public static Type[] CreateMappings()
        {
            return new Type[]
            {
                typeof(DomainToViewModelMappingProfile),
                typeof(ViewModelToDomainMappingProfile)
            };
        }
    }
}
