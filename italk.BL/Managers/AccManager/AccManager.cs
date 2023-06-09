﻿using AutoMapper;
using italk.BL.Dots;
using italk.BL.Dtos.LevelDto;
using italk.BL.Dtos.UserDto;
using italk.DAL.Data.Models;
using italk.DAL.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static italk.BL.Dots.InstructorRegisterDto;

namespace italk.BL.Managers.AccManager
{
    public class AccManager : IAccManager
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<BaseModel> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AccManager(IConfiguration configuration,
            UserManager<BaseModel> userManager, IUnitOfWork unitOfWork , IMapper mapper
            )
        {
            _configuration = configuration;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<TokenDto> Login(LoginDto loginDto)
        {
            BaseModel? baseModel = await _userManager.FindByEmailAsync(loginDto.Email);
            if (baseModel == null)
            {

                return new TokenDto(TokenResult.wrong_user_name);
            }

            bool isPasswordCorrect = await _userManager.CheckPasswordAsync(baseModel, loginDto.Password);
            if (!isPasswordCorrect)
            {

                return new TokenDto(TokenResult.wrong_password);
            }

            var claimsList = await _userManager.GetClaimsAsync(baseModel);

            return GenerateToken(claimsList);
        }

        public async Task<RegisterResultDto> StudentRegister(StudentRegisterDto studentRegisterDto)
        {
            var newStudent = _mapper.Map<Student>(studentRegisterDto);

            var creationResult = await _userManager.CreateAsync(newStudent,
                studentRegisterDto.Password);
            if (!creationResult.Succeeded)
            {
                return new RegisterResultDto(false, creationResult.Errors);
            }

            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, newStudent.Id.ToString()),
            new Claim(ClaimTypes.Role, "student"),
        };

            await _userManager.AddClaimsAsync(newStudent, claims);

            return new RegisterResultDto(true);
        }

        public async Task<RegisterResultDto> InstructorRegister(InstructorRegisterDto instructorRegisterDto)
        {
            var newInstructor = _mapper.Map<Instructor>(instructorRegisterDto);
            var creationResult = await _userManager.CreateAsync(newInstructor,
                instructorRegisterDto.Password);
            if (!creationResult.Succeeded)
            {
                return new RegisterResultDto(false, creationResult.Errors);
            }

            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, newInstructor.Id.ToString()),
            new Claim(ClaimTypes.Role, "instructor"),
        };

            await _userManager.AddClaimsAsync(newInstructor, claims);

            return new RegisterResultDto(true);
        }

        public async Task<StudentRegisterDto> UpdateStudent(int id, StudentRegisterDto studentDto)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user == null)
            {
                return null!; 
            }

            _mapper.Map(studentDto, user);

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return studentDto;
            }
            else
            {
                return null!;
            }
        }

        public async Task<InstructorRegisterDto> UpdateInstructor(int id, InstructorRegisterDto instructorDto)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user == null)
            {
                return null!;
            }

            _mapper.Map(instructorDto, user);

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return instructorDto;
            }
            else
            {
                return null!;
            }
        }

        public async Task<LevelDto> UpdateStudentLevel(int id, LevelDto levelDto)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user == null)
            {
                return null!;
            }

            _mapper.Map(levelDto, user);
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return levelDto;
            }
            else
            {
                return null!;
            }
        }


        public async Task<InstructorRegisterDto> GetInstructorById(int id)
        {
            var instructor = await _userManager.FindByIdAsync(id.ToString());
            return _mapper.Map<InstructorRegisterDto>(instructor);
        }

        public async Task<StudentRegisterDto> GetStudentById(int id)
        {
            var student = await _userManager.FindByIdAsync(id.ToString());
            return _mapper.Map<StudentRegisterDto>(student);
        }

        #region token
        private TokenDto GenerateToken(IList<Claim> claimsList)
        {
            string keyString = _configuration.GetValue<string>("SecretKey") ?? string.Empty;

            var keyInBytes = Encoding.ASCII.GetBytes(keyString);
            var key = new SymmetricSecurityKey(keyInBytes);

            var signingCredentials = new SigningCredentials(key,
                SecurityAlgorithms.HmacSha256Signature);

            var expiry = DateTime.Now.AddMinutes(60);

            var jwt = new JwtSecurityToken(
                    expires: expiry,
                    claims: claimsList,
                    signingCredentials: signingCredentials);

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenString = tokenHandler.WriteToken(jwt);

            return new TokenDto
            (TokenResult.success,
                 tokenString,
                 expiry
            );
        }
        #endregion
    }
}
