﻿using italk.BL.Dots;

namespace italk.BL.Managers.AccManager
{
    public interface IAccManager
    {
        Task<RegisterResultDto> InstructorRegister(InstructorRegisterDto instructorRegisterDto);
        Task<TokenDto> Login(LoginDto loginDto);
        Task<RegisterResultDto> StudentRegister(StudentRegisterDto studentRegisterDto);
    }
}