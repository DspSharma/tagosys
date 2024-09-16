using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagosysWeb.Core.DTO.DtoInput;
using TagosysWeb.Core.DTO.DtoOutput;
using TagosysWeb.Core.Models;
using TagosysWeb.Data.Entities;

namespace TagosysWeb.Core.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile() 
        {
            CreateMap<SystemsettingInput, Systemsetting>();
            CreateMap<SystemsettingOutput, Systemsetting>();
            CreateMap<Systemsetting,SystemsettingOutput>();

            CreateMap<UserLoginInput, User>();
            CreateMap<LoggedInUserModels, User>();
            CreateMap<User, LoggedInUserModels>();

            CreateMap<ClientInput, Client>();
            CreateMap<ClientOutput, Client>();
            CreateMap<Client,ClientOutput>();

            CreateMap<UserInput, User>();
            CreateMap<UserOutput, User>();
            CreateMap<User, UserOutput>();

            CreateMap<ProjectInput, Project>();
            CreateMap<ProjectOutput, Project>();
            CreateMap<Project, ProjectOutput>();

            CreateMap<TeamInput, Team>();
            CreateMap<TeamOutput,Team>();
            CreateMap<Team, TeamOutput>();

            CreateMap<ImagekitfileInput, Imagekitfile>();
            CreateMap<ImagekitfileOutput, Imagekitfile>();
            CreateMap<Imagekitfile, ImagekitfileOutput>();

            CreateMap<ContactInput, Contact>();
            CreateMap<ContactOutput, Contact>();
            CreateMap<Contact, ContactOutput>();

            CreateMap<PageInput, Page>();
            CreateMap<PageOutput,Page>();
            CreateMap<Page,PageOutput>();

            CreateMap<PostInput, Post>();
            CreateMap<PostOutput, Post>();
            CreateMap<Post, PostOutput>();

            CreateMap<PostdescriptionInput, Postdescription>();
            CreateMap<PostdescriptionOutput, Postdescription>();
            CreateMap<Postdescription, PostdescriptionOutput>();
        }
    }
}
