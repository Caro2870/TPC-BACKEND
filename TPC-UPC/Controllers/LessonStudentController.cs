using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPC_UPC.Domain.Services;
using TPC_UPC.Resources;
using TPC_UPC.Domain.Models;

namespace TPC_UPC.Controllers
{
    [ApiController]
    [Route("api/lessons/{lessonId}/students")]
    public class LessonStudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly ILessonStudentService  _lessonStudentService;
        private readonly IMapper _mapper;

        public LessonStudentController(IStudentService studentService, ILessonStudentService lessonStudentService, IMapper mapper)
        {
            _studentService = studentService;
            _lessonStudentService = lessonStudentService;
            _mapper = mapper;
        }

       


        [HttpGet]
        [Route("missing")]
        public async Task<IEnumerable<StudentResource>> GetAllMissingsByLessonIdAsync(int lessonId)
        {
            var tags = await _studentService.ListMissingStudentByLessonIdAsync(lessonId);
            var resources = _mapper.Map<IEnumerable<Student>, IEnumerable<StudentResource>>(tags);
            return resources;
        }
    }
}