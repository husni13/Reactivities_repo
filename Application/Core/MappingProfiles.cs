using Application.Activities;
using Application.Comments;
using AutoMapper;
using Domain;

namespace Application.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            string currentUserName = null;
            CreateMap<Activity, Activity>();

            CreateMap<Activity, ActivityDTO>()
                .ForMember(d => d.HostUserName, o => 
                    o.MapFrom(s => s.Attendees.FirstOrDefault(x => 
                        x.IsHost).AppUser.UserName));

            CreateMap<ActivityAttendee, AttendeeDTO>()
                .ForMember(d => d.DisplayName, o => o.MapFrom(s => s.AppUser.DisplayName))
                .ForMember(d => d.UserName, o => o.MapFrom(s => s.AppUser.UserName))
                .ForMember(d => d.Bio, o => o.MapFrom(s => s.AppUser.Bio))
                .ForMember(d => d.Image, o => o.MapFrom(s => s.AppUser.Photos.FirstOrDefault(x => x.IsMain).Url))
                .ForMember(d => d.FollowersCount, o => o.MapFrom(x => x.AppUser.Followers.Count))
                .ForMember(d => d.FollowingCount, o => o.MapFrom(x => x.AppUser.Followings.Count))
                .ForMember(d => d.Following,
                    o => o.MapFrom(x => x.AppUser.Followers.Any(j => j.Observer.UserName == currentUserName)));

            CreateMap<AppUser, Profiles.Profile>()
            .ForMember(d => d.Image, o => 
                o.MapFrom(s => 
                    s.Photos.FirstOrDefault(x => x.IsMain).Url))
            .ForMember(d => d.FollowersCount, o => o.MapFrom(x => x.Followers.Count))
            .ForMember(d => d.FollowingCount, o => o.MapFrom(x => x.Followings.Count))
            .ForMember(d => d.Following, 
                o => o.MapFrom(x => x.Followers.Any(j => j.Observer.UserName == currentUserName)));
            
            CreateMap<Comment, CommentDTO>()
                .ForMember(d => d.DisplayName, a => a.MapFrom(c => c.Author.DisplayName))
                .ForMember(d => d.Image, x => x.MapFrom(z => z.Author.Photos.FirstOrDefault(f => f.IsMain).Url))
                .ForMember(a => a.UserName, t => t.MapFrom(o => o.Author.UserName));
        }
    }
}