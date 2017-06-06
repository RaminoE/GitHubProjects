using AutoMapper;
using Organisation.Domian.Model.Models;
using Organisation.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Organisation.Web.Mappings
{

    public class DomainToViewModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToViewModelMappings"; }
        }

        protected override void Configure()
        {

            Mapper.CreateMap<Group, GroupViewModel>()
                .ForMember(g => g.Team, map => map.MapFrom(vm => vm.Team))
                .ForMember(g => g.TeamMember, map => map.MapFrom(vm => vm.TeamMember))
                .ForMember(g => g.Id, map => map.MapFrom(vm => vm.Id))
                .ForMember(g => g.Name, map => map.MapFrom(vm => vm.Name));

            Mapper.CreateMap<Team, TeamViewModel>()
                .ForMember(g => g.TeamMembers, map => map.MapFrom(vm => vm.TeamMember))
                 .ForMember(g => g.Name, map => map.MapFrom(vm => vm.Name))
                 .ForMember(g => g.Id, map => map.MapFrom(vm => vm.Id))
                 .ForMember(g => g.GroupID, map => map.MapFrom(vm => vm.GroupId));
            Mapper.CreateMap<TeamMember, TeamMemberViewModel>()
            .ForMember(g => g.TeamId, map => map.MapFrom(vm => vm.TeamId))
                 .ForMember(g => g.Name, map => map.MapFrom(vm => vm.Name))
                 .ForMember(g => g.Id, map => map.MapFrom(vm => vm.Id))
                 .ForMember(g => g.Image, map => map.MapFrom(vm => vm.Image))
                 .ForMember(g => g.IsTeanLead, map => map.MapFrom(vm => vm.IsTeanLead));



            Mapper.CreateMap<GroupViewModel, Group>()
                 .ForMember(g => g.Team, map => map.MapFrom(vm => vm.Team))
                 .ForMember(g => g.TeamMember, map => map.MapFrom(vm => vm.TeamMember))
                 .ForMember(g => g.Id, map => map.MapFrom(vm => vm.Id))
                 .ForMember(g => g.Name, map => map.MapFrom(vm => vm.Name));

            Mapper.CreateMap<TeamViewModel, Team>()
                .ForMember(g => g.TeamMember, map => map.MapFrom(vm => vm.TeamMembers))
                 .ForMember(g => g.Name, map => map.MapFrom(vm => vm.Name))
                 .ForMember(g => g.Id, map => map.MapFrom(vm => vm.Id))
                 .ForMember(g => g.GroupId, map => map.MapFrom(vm => vm.GroupID));
            Mapper.CreateMap<TeamMemberViewModel, TeamMember>()
            .ForMember(g => g.TeamId, map => map.MapFrom(vm => vm.TeamId))
                 .ForMember(g => g.Name, map => map.MapFrom(vm => vm.Name))
                 .ForMember(g => g.Id, map => map.MapFrom(vm => vm.Id))
                 .ForMember(g => g.Image, map => map.MapFrom(vm => vm.Image))
                 .ForMember(g => g.IsTeanLead, map => map.MapFrom(vm => vm.IsTeanLead));

        }
    }


}