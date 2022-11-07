//using Autofac;
//using Microsoft.AspNetCore.Http.Extensions;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Filters;
//using Newtonsoft.Json;
//using System;
//using System.Collections.Concurrent;
//using System.Collections.Generic;
//using System.Configuration;
//using System.Linq;
//using System.Net.Http;
//using System.Text;
//using System.Text.RegularExpressions;

//namespace Core.Web.Api.Filters
//{
//    public class LoggingFilter : Attribute, IActionFilter {
//        private readonly IApiUsageLogRepository _apiUsageLogsRepository;

//        private string _logActionsConfig;
//        private string _notLogActionsConfig;
//        private string[] _notLogActions = new string[] { };
//        private string[] _logActions= new string[] { };

//        private ConcurrentDictionary<string, string> requests = new ConcurrentDictionary<string, string>();

//        public LoggingFilter() {
//            _apiUsageLogsRepository = IoC.Container.Resolve<IApiUsageLogRepository>();
//            _notLogActionsConfig = CoreConfigurationManager.AppSettings["NotLogActions"];
//            _logActionsConfig = CoreConfigurationManager.AppSettings["LogActions"];
//            if (!string.IsNullOrWhiteSpace(_notLogActionsConfig))
//                _notLogActions = _notLogActionsConfig.Split(',').ToArray();

//            if (!string.IsNullOrWhiteSpace(_logActionsConfig))
//                _logActions = _logActionsConfig.Split(',').ToArray();
//        }       

//        public void OnActionExecuting(ActionExecutingContext context) {
//            if (!SystemSettings.ApiLoggingFilterEnabled)
//                return;

//            try {
//                var actionDescriptor = context.ActionDescriptor;
//                var action = actionDescriptor.RouteValues["action"];

//                if (_notLogActions.Contains(action)) return;

//                if (!string.IsNullOrWhiteSpace(_logActionsConfig)) {
//                    if (!_logActions.Contains(action)) return;
//                }

//                StringBuilder sb = new StringBuilder();
//                if (context.ActionArguments != null && context.ActionArguments.Any()) {
//                    var requestBody = string.Join(",", context.ActionArguments.Select(arg => $"\"{arg.Key}\":{JsonConvert.SerializeObject(arg.Value)}"));
//                    requests.TryAdd(context.HttpContext.TraceIdentifier, $"{{{requestBody}}}");
//                }
//                else if (context.HttpContext.Request.Form != null && context.HttpContext.Request.Form != null && context.HttpContext.Request.Form.Keys.Any()) {
//                    var requestBody = string.Join(",", context.HttpContext.Request.Form.Select(arg => $"\"{arg.Key}\":{JsonConvert.SerializeObject(arg.Value)}"));
//                    requests.TryAdd(context.HttpContext.TraceIdentifier, $"{{{requestBody}}}");
//                }
//            }
//            catch (Exception error) {
//                //TODO: log the error
//            }
//        }

//        public void OnActionExecuted(ActionExecutedContext context) {
//            if (!SystemSettings.ApiLoggingFilterEnabled)
//                return;

//            string requestBody;
//            if (requests.TryGetValue(context.HttpContext.TraceIdentifier, out requestBody)) {
//                var controller = context.ActionDescriptor.RouteValues["controller"];
//                var url = context.HttpContext.Request.GetDisplayUrl();
//                var actionDescriptor = context.ActionDescriptor;
//                var action = actionDescriptor.RouteValues["action"];


//                if (string.IsNullOrWhiteSpace(requestBody)) {
//                    var result = context.HttpContext.Request.Headers["sendmailobj"];
//                    requestBody = result.FirstOrDefault();
//                }               

//                var resBytes = context.Result as ByteArrayContent;
//                var res = string.Empty;
//                if (context.Result is JsonResult json) {
//                    res = json.Value != null ? JsonConvert.SerializeObject(json.Value) : res;
//                }
//                else if (resBytes != null) {
//                    res = resBytes.ReadAsStringAsync().Result;
//                }

//                var request = context.HttpContext.Request;

//                string headersString = JsonConvert.SerializeObject(request.Headers.Keys.Select(k => new KeyValuePair<string, string>(k, request.Headers[k])));

//                // log using api
//                _apiUsageLogsRepository.Save(controller: controller, action: action, url: url, body: requestBody, callerIp: GetCallerIp(context), requestDate: DateTime.UtcNow, response: res, headers: headersString);
//            }

//            string req;
//            requests.Remove(context.HttpContext.TraceIdentifier, out req);
//        }

//        private string GetCallerIp(ActionExecutedContext context) {
//            var ip = context.HttpContext.Connection.RemoteIpAddress.ToString();
//            switch (ip) {
//                case "::1":
//                    return ip;//local
//                default: //online don't include port and the double ip address and proxies the ip is the first one client1, proxy1, proxy2, ...
//                    return Regex.Replace(ip, @"((\:.*)|(\,.*))", "", RegexOptions.IgnoreCase | RegexOptions.Singleline | RegexOptions.Compiled);
//            }
//        }
//    }
//}