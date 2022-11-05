using Core.Common;
using RLV.Security.Lib;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;
using System;
using Core.Common.Settings;

namespace Core.Web.API.Controllers {
    public abstract class BaseApiController : ControllerBase {

        protected IActionResult JsonExt<T>(T content) {
            var jsonSerializerSettings = new Newtonsoft.Json.JsonSerializerSettings() {
                ContractResolver = new DefaultContractResolver {
                    NamingStrategy = new CamelCaseNamingStrategy { ProcessDictionaryKeys = true }
                }
            };
            return new JsonResult(content, jsonSerializerSettings);
        }


        protected BadRequestErrorMessageResult BadRequest(Exception error) {
            string message = "";
            var ex = error;
            while (ex != null) {
                message += string.Format("{0}: {1}\r\n", ex.ToString(), ex.Message);
                ex = ex.InnerException;
            }
            return new BadRequestErrorMessageResult(message);
        }

        protected string GetUserTokenFromHeader() {
            try {

                var token = Request.Headers["token"];
                //var symmetricSecretKey = CoreConfigurationManager.AppSettings["SymmetricSecretKey"];
                var symmetricSecretKey = GlobalSettings.SymmetricSecretKey;
                var decryptedToken = JwtSecurityService.Decrypt(symmetricSecretKey, token);
                if (!string.IsNullOrWhiteSpace(decryptedToken)) {
                    var userToken = JwtSecurityService.Decode(decryptedToken);
                    return userToken;
                }
                return token;
            } catch (Exception) {

                return null;
            }
        }

        protected string GetJwtTokenFromHeader() {
            var token = Request.Headers["token"];
            return token;
        }
    }

    public class BadRequestErrorMessageResult : BadRequestResult {
        public BadRequestErrorMessageResult(string message) {
            Message = message;
        }
        public string Message { get; set; }
    }
}
