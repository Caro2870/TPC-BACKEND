using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPC_UPC.Domain.Models;
using TPC_UPC.Domain.Services;
using TPC_UPC.Domain.Services.Communications;
using TPC_UPC.Resources;

namespace TPC_UPC.Controllers
{
    [ApiController]
    [Route("/api/lessons/{lessonId}/students")]
    public class LessonStudentController : ControllerBase
    {
        private readonly ILessonStudentService _lessonStudentService;
        private readonly IMapper _mapper;
        private readonly IStudentService _studentService;



        [HttpGet]
        public async Task<IEnumerable<StudentResource>> GetAllStudentsAssistanceByLessonId(int id)
        {
            var students = await _lessonStudentService.ListStudentAssistantsByLessonIdAsync(id);
            var resources = _mapper.Map<IEnumerable<Student>, IEnumerable<StudentResource>>(students);
            return resources;
        }
    }
}
