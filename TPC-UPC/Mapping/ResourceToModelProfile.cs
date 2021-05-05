using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPC_UPC.Resources;
using TPC_UPC.Domain.Models;
namespace TPC_UPC.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveUniversityResource, University>();
            CreateMap<SaveAccountResource, Account>();
            CreateMap<SaveUserResource, User>();
            CreateMap<SaveNotificationUserResource, NotificationUser>();
            CreateMap<SaveNotificationResource, Notification>();
            CreateMap<SaveNotificationTypeResource, NotificationType>();
            CreateMap<SaveSuggestionResource, Suggestion>();
            CreateMap<SaveUserCourseResource, UserCourse>();
            CreateMap<SaveCourseResource, Course>();
            CreateMap<SaceCoordinatorResource, CoordinatorResource>();
            CreateMap<SaveMailMessageResource, MailMessage>();
            CreateMap<SaveStudentResource, Student>();
            CreateMap<SaveFacultyResource, Faculty>();
            CreateMap<SaveTutorResource, Tutor>();
            CreateMap<SaveLessonResource, Lesson>();
            CreateMap<SaveLessonStudentResource, LessonStudent>();
            CreateMap<SaveLessonTypeResource, LessonType>();
            CreateMap<SaveMeetingResource, Meeting>();
            CreateMap<SaveScheduleResource, Schedule>();
            CreateMap<SaveTrainningResource, Training>();
            CreateMap<SaveTrainningTutorResource, TrainingTutor>();
        }
    }
}
