using ApiTienda.Helpers;
using ApiTienda.Models;
using ApiTienda.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ApiTienda.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        RepositoryUsuario repo;
        HelperToken helperToken;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="helperToken"></param>
        public AuthController(RepositoryUsuario repo
            , HelperToken helperToken)
        {
            this.repo = repo;
            this.helperToken = helperToken;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]        
        public IActionResult Login(LoginApi usuario)
        {
            String usuariosjson = JsonConvert.SerializeObject(usuario);
            Claim[] claims = new[]
            {
                new Claim("UserData",usuariosjson)
            };
            Usuario user = this.repo.ExisteUsuario(usuario.UserName
                , int.Parse(usuario.Password));
            if(user == null)
            {
                return Unauthorized();
            }
            else
            {
                JwtSecurityToken token = new JwtSecurityToken(
                    issuer: this.helperToken.Issuer,
                    audience: this.helperToken.Audience,
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(10),
                    notBefore: DateTime.UtcNow,
                    signingCredentials: new SigningCredentials
                    (this.helperToken.GetKeyToken(), SecurityAlgorithms.HmacSha256));
                return Ok(new
                {
                    response = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public ActionResult<List<Usuario>> GetUsuarios()
        {
            List<Claim> claims = HttpContext.User.Claims.ToList();
            String jsonusuarios = claims.SingleOrDefault(
                x => x.Type == "UserData").Value;
            return this.repo.GetUsuarios();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        [Authorize]
        public ActionResult<Usuario> BuscarUsuario(int id)
        {

            return this.repo.BuscarUsuario(id);
        }

    }
}
