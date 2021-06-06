using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;
using TPC_UPC.Resources;

namespace TPC_UPC.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Account, AccountResource>();
            CreateMap<Career, CareerResource>();
            CreateMap<Coordinator, CoordinatorResource>();
            CreateMap<Course, CourseResource>();
            CreateMap<Faculty, FacultyResource>();
            CreateMap<Lesson, LessonResource>();
            CreateMap<LessonStudent, LessonStudentResource>();
            CreateMap<LessonType, LessonTypeResource>();
            CreateMap<MailMessage, MailMessageResource>();
            CreateMap<Meeting, MeetingResource>();
            CreateMap<Notification, NotificationResource>();
            CreateMap<NotificationType, NotificationTypeResource>();
            CreateMap<NotificationUser, NotificationUserResource>();
            CreateMap<Student, StudentResource>();
            CreateMap<Suggestion, SuggestionResource>();
            CreateMap<Training, TrainingResource>();
            CreateMap<TrainingTutor, TrainingTutorResource>();
            CreateMap<Tutor, TutorResource>();
            CreateMap<University, UniversityResource>();
            CreateMap<User, UserResource>();
            CreateMap<UserCourse, UserCourseResource>();
            CreateMap<CareerCourse, CareerCourseResource>();
        }
    }
}
