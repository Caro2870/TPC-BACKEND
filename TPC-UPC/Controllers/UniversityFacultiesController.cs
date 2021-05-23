﻿//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using AutoMapper;
//using Swashbuckle.AspNetCore.Annotations;
//using TPC_UPC.Domain.Services;
//using TPC_UPC.Resources;
//using TPC_UPC.Domain.Models;
//using TPC_UPC.API.Extensions;


//namespace TPC_UPC.Controllers
//{
//    [ApiController]
//    [Route("/api/universities/{categoryId}/products")]
//    public class UniversityFacultiesController : ControllerBase
//    {
//        private readonly IFacultyService _facultyService;
//        private readonly IMapper _mapper;
//        public UniversityFacultiesController(IFacultyService facultyService, IMapper mapper)
//        {
//            _facultyService = facultyService;
//            _mapper = mapper;
//        }

//        [SwaggerOperation(
//            Summary = "List all faculties",
//            Description = "List of faculties",
//            OperationId = "ListAllfaculties")]
//        [SwaggerResponse(200, "List of faculties", typeof(IEnumerable<FacultyResource>))]
//        [HttpGet]
//        [ProducesResponseType(typeof(IEnumerable<FacultyResource>), 200)]
//        public async Task<IEnumerable<FacultyResource>> GetAllAsync(int universityId)
//        {
//            //var faculties = await _facultyService.ListAsync();
//            //var resources = _mapper
//            //    .Map<IEnumerable<Faculty>, IEnumerable<FacultyResource>>(faculties);
//            //return resources;

//            var faculties = await _facultyService.ListByUniversityIdAsync(universityId);
//            var resources = _mapper
//                .Map<IEnumerable<Faculty>, IEnumerable<FacultyResource>>(faculties);
//            return resources;
//        }

//    }
//}
