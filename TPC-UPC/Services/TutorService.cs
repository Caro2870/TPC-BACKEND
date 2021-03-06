using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;
using TPC_UPC.Domain.Services.Communications;
using TPC_UPC.Domain.Services;
using TPC_UPC.Domain.Persistence.Repositories;

namespace TPC_UPC.Services
{
    public class TutorService : ITutorService
    {
        private readonly ITutorRepository _tutorRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAccountRepository _accountRepository;
        private readonly IFacultyRepository _facultyRepository;
        private readonly ILessonRepository _lessonRepository;
        private readonly ILessonStudentRepository _lessonStudentRepository;

        public TutorService(ITutorRepository object1, IFacultyRepository facultyRepository, IAccountRepository accountRepository, IUnitOfWork object2, ILessonRepository lessonRepository, ILessonStudentRepository lessonStudentRepository)
        {
            this._tutorRepository = object1;
            this._unitOfWork = object2;
            this._facultyRepository = facultyRepository;
            this._accountRepository = accountRepository;
            _lessonRepository = lessonRepository;
            _lessonStudentRepository = lessonStudentRepository;
        }

        public TutorService(ITutorRepository object1, IAccountRepository accountRepository, IFacultyRepository facultyRepository, IUnitOfWork object2)
        {
            this._tutorRepository = object1;
            this._unitOfWork = object2;
            this._facultyRepository = facultyRepository;
            this._accountRepository = accountRepository;
        }

        //CRUD
        public async Task<TutorResponse> SaveAsync(Tutor tutor) {

            if (_accountRepository.FindById(tutor.AccountId) != null)
            {
                if (_facultyRepository.FindById(tutor.FacultyId) != null)
                {
                    try
                    {
                        await _tutorRepository.AddAsync(tutor);
                        await _unitOfWork.CompleteAsync();
                        return new TutorResponse(tutor);
                    }
                    catch (Exception e)
                    {
                        return new TutorResponse($"An error ocurred while saving {e.Message}");
                    }
                }
                else
                {
                    return new TutorResponse($"The faculty with id {tutor.FacultyId}, doesn't exist");
                }
            }
            else
            {
                return new TutorResponse($"The account with id {tutor.AccountId}, doesn't exist");
            }

        }

        public async Task<TutorResponse> GetByIdAsync(int tutorId) {
            var existingTutor = await _tutorRepository.FindById(tutorId);

            if (existingTutor == null)
                return new TutorResponse("Tutor not found");
            return new TutorResponse(existingTutor);
        }

        public async Task<TutorResponse> UpdateAsync(int id, Tutor tutor) {
            var existingTutor = await _tutorRepository.FindById(id);

            if (existingTutor == null)
                return new TutorResponse("Tutor not found");

            existingTutor.FirstName = tutor.FirstName;
            existingTutor.LastName = tutor.LastName;
            existingTutor.PhoneNumber = tutor.PhoneNumber;

            try
            {
                _tutorRepository.Update(existingTutor);
                await _unitOfWork.CompleteAsync();

                return new TutorResponse(existingTutor);
            }
            catch (Exception ex)
            {
                return new TutorResponse($"An error ocurred while updating the tutor: {ex.Message}");
            }
        }

        public async Task<TutorResponse> DeleteAsync(int id) {
            var existingTutor = await _tutorRepository.FindById(id);

            if (existingTutor == null)
                return new TutorResponse("Tutor not found");

            try
            {
                _tutorRepository.Remove(existingTutor);
                await _unitOfWork.CompleteAsync();

                return new TutorResponse(existingTutor);
            }
            catch (Exception ex)
            {
                return new TutorResponse($"An error ocurred while deleting the tutor: {ex.Message}");
            }
        }

        //ADDED
        public async Task<IEnumerable<Tutor>> ListAsync() {
            return await _tutorRepository.ListAsync();
        }

        public double GetWorkshopsAverage(int tutorId, int courseId, int lessonTypeId)
        {
            double sum = 0;
            int quantity = 0;
            List<Lesson> lessons =  _lessonRepository.ListByTutorIdAndCourseIdAndLessonTypeIdAsync(tutorId, courseId, lessonTypeId).Result.ToList();
            if (lessons.Count == 0) return 0.0;

            List<LessonStudent> lessonStudents;
            foreach(Lesson lesson in lessons)
            {
                lessonStudents = _lessonStudentRepository.ListStudentsByLessonIdAsync(lesson.Id).Result.ToList();
                if (lessonStudents.Count != 0)
                {
                    foreach (LessonStudent lessonStudent in lessonStudents)
                    {
                        sum += lessonStudent.Qualification;
                        quantity += 1;
                    }
                }
                else
                {
                    continue;
                }
            }
            return (sum / quantity);
        }
    }
}
