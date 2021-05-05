using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPC_UPC.Domain.Services;

namespace TPC_UPC.Services
{
    public class LessonStudentService : ILessonStudentService
    {
        private readonly ILessonStudentRepository _lessonStudentRepository;
        private IUnitOfWork _unitOfWork;
        public CoordinatorService(ILessonStudentRepository object1, IUnitOfWork object2)
        {
            this._lessonStudentRepository = object1;
            this._unitOfWork = object2;
        }

        Task<IEnumerable<LessonService>> ListStudentAssistantsByLessonIdAsync(int lessonId)
        {
            return await _lessonStudentRepository.ListStudentAssistantsByLessonIdAsync(lessonId);
        }
    }
}
