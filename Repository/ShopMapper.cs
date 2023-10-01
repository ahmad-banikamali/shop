using Application.CategoryService.GetCategories;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ShopMapper : Profile
    {
        public ShopMapper()
        {
            CreateMap<GetCategoryItemResponse, Category>().ReverseMap(); 
        }
    }
}
