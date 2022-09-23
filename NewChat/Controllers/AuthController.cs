using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NewChat.BLL;
using NewChat.DAL.Entities;
using NewChat.ViewModels;

namespace NewChat.Controllers;

public class AuthController : Controller
{
    private readonly IAccountService _accountService;

    public AuthController(IAccountService accountService)
    {
        _accountService = accountService;
    }
    
    
}