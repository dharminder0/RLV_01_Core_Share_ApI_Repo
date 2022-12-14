using Core.Common.Extensions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Core.Common.Web {
    public class HttpService {
        public HttpContext CurrentHttpContext;
        private string _userName;
        private string _password;
        private Dictionary<string, string> _headers = new Dictionary<string, string>();
        private JsonSerializerSettings _jsonSerializerSettings;

        public string RootUrl { get; set; }

        public HttpService(string url, string userName = null, string password = null) {
            RootUrl = url;
            _userName = userName;
            _password = password;
            _jsonSerializerSettings = new JsonSerializerSettings {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }
        public object Get(string route) {
            var url = $"{RootUrl.TrimEnd('/')}/{route}".TrimEnd('/');
            var client = GetClient();
            var response = client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode && response.Content != null) {
                var data = response.Content.ReadAsStringAsync().Result;
                try {
                    return JsonConvert.DeserializeObject(data, _jsonSerializerSettings);
                } catch {
                    return data;
                }
            } else {
                if (response.Content != null) {
                    var result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception(result);
                }
                throw new Exception("Unknown error");
            }
        }

        public async Task<object> GetAsync(string route) {
            var url = $"{RootUrl.TrimEnd('/')}/{route}".TrimEnd('/');
            var client = GetClient();
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode && response.Content != null) {
                var data = response.Content.ReadAsStringAsync().Result;
                try {
                    return JsonConvert.DeserializeObject(data, _jsonSerializerSettings);
                } catch {
                    return data;
                }
            } else {
                if (response.Content != null) {
                    var result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception(result);
                }
                throw new Exception("Unknown error");
            }
        }
        public T Get<T>(string route) {
            var url = $"{RootUrl.TrimEnd('/')}/{route}".TrimEnd('/');
            var client = GetClient();
            var response = client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode && response.Content != null) {
                var data = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<T>(data, _jsonSerializerSettings);
            } else {
                if (response.Content != null) {
                    var result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception(result);
                }
                throw new Exception("Unknown error");
            }
        }

        //public async Task<T> GetAsync<T>(string route) {
        //    var url = $"{RootUrl.TrimEnd('/')}/{route}".TrimEnd('/');
        //    var client = GetClient();
        //    var response = await client.GetAsync(url);

        //    if (response.IsSuccessStatusCode && response.Content != null) {
        //        var data = response.Content.ReadAsStringAsync().Result;
        //        return JsonConvert.DeserializeObject<T>(data, _jsonSerializerSettings);
        //    } else {
        //        if (response.Content != null) {
        //            var result = response.Content.ReadAsStringAsync().Result;
        //            throw new Exception(result);
        //        }
        //        throw new Exception("Unknown error");
        //    }
        //}

        public async Task<T> GetAsync<T>(string route) {
            var url = string.Format("{0}/{1}", RootUrl.TrimEnd('/'), route);
            var client = GetClient();
            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode && response.Content != null) {
                var data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(data, _jsonSerializerSettings);
            } else {
                if (response.Content != null) {
                    var result = await response.Content.ReadAsStringAsync();
                    throw new Exception(result);
                }
                throw new Exception("Unknown error");
            }
        }

        public object Post(string route, object body) {
            var url = $"{RootUrl.TrimEnd('/')}/{route}".TrimEnd('/');
            var client = GetClient();
            var dataAsString = JsonConvert.SerializeObject(body);
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = client.PostAsync(url, content).Result;
            if (response.IsSuccessStatusCode && response.Content != null) {
                var data = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject(data, _jsonSerializerSettings);
            } else {
                if (response.Content != null) {
                    var result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception(result);
                }
                throw new Exception("Unknown error");
            }
        }

        public async Task<T> PostAsync<T>(string route, object body) {
            var url = $"{RootUrl.TrimEnd('/')}/{route}";
            var client = GetClient();
            var dataAsString = JsonConvert.SerializeObject(body, new JsonSerializerSettings {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await client.PostAsync(url, content);

            if (response.IsSuccessStatusCode && response.Content != null) {
                var data = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<T>(data, _jsonSerializerSettings);
            } else {
                if (response.Content != null) {
                    var result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception(result);
                    //var resultDetails = new {Error = result.SerializeObjectWithoutNull(), Body  = body.SerializeObjectWithoutNull(), Request = route };
                    //throw new Exception(resultDetails.SerializeObjectWithoutNull());
                }

                throw new Exception("Unknown error");
            }
        }

        //public async Task<T> PostAsync<T>(string route, object body, string contentType = null) {
        //    var url = string.Format("{0}/{1}", RootUrl.TrimEnd('/'), route);
        //    if (!string.IsNullOrWhiteSpace(contentType)) {
        //        AddHeader("Content-Type", contentType);
        //    }
        //    var client = GetClient();
        //    var response = await client.PostAsJsonAsync(url, body);
        //    if (response.IsSuccessStatusCode && response.Content != null) {
        //        var data = await response.Content.ReadAsStringAsync();
        //        return JsonConvert.DeserializeObject<T>(data, _jsonSerializerSettings);
        //    } else {
        //        if (response.Content != null) {
        //            var result = await response.Content.ReadAsStringAsync();
        //            throw new Exception(result);
        //        }
        //        throw new Exception("Unknown error");
        //    }
        //}

        public T Post<T>(string route, object body) {
            var url = $"{RootUrl.TrimEnd('/')}/{route}";
            var client = GetClient();
            var dataAsString = JsonConvert.SerializeObject(body, new JsonSerializerSettings {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = client.PostAsync(url, content);
            if (response.Result.IsSuccessStatusCode && response.Result.Content != null) {
                var data = response.Result.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<T>(data, _jsonSerializerSettings);
            } else {
                if (response.Result.Content != null) {
                    var result = response.Result.Content.ReadAsStringAsync().Result;
                    throw new Exception(result);
                    //var resultDetails = new {Error = result.SerializeObjectWithoutNull(), Body  = body.SerializeObjectWithoutNull(), Request = route };
                    //throw new Exception(resultDetails.SerializeObjectWithoutNull());
                }

                throw new Exception("Unknown error");
            }
        }

        //public T PostOld<T>(string route, object body)
        //{
        //    var url = $"{RootUrl.TrimEnd('/')}/{route}".TrimEnd('/');
        //    var client = GetClient();
        //    var response = client.PostAsJsonAsync(url, body).Result;
        //    if (response.IsSuccessStatusCode && response.Content != null)
        //    {
        //        var data = response.Content.ReadAsStringAsync().Result;
        //        return JsonConvert.DeserializeObject<T>(data, _jsonSerializerSettings);
        //    }
        //    else
        //    {
        //        if (response.Content != null)
        //        {
        //            var result = response.Content.ReadAsStringAsync().Result;
        //            var resultDetails = $@"{url}####{JsonConvert.SerializeObject(body)}###{result}";

        //            throw new Exception(resultDetails);
        //        }
        //        throw new Exception("Unknown error");
        //    }
        //}

        public T PostAsHttpContent<T>(string route, HttpContent body) {
            var url = $"{RootUrl.TrimEnd('/')}/{route}".TrimEnd('/');
            var client = GetClient();
            var response = client.PostAsync(url, body).Result;
            if (response.IsSuccessStatusCode && response.Content != null) {
                var data = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<T>(data, _jsonSerializerSettings);
            } else {
                if (response.Content != null) {
                    var result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception(result);
                }
                throw new Exception("Unknown error");
            }
        }

        public object Put(string route, object body) {
            var url = $"{RootUrl.TrimEnd('/')}/{route}".TrimEnd('/');
            var client = GetClient();
            var dataAsString = JsonConvert.SerializeObject(body, new JsonSerializerSettings {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
            var content = new StringContent(dataAsString);
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = client.PutAsync(url, content).Result;
            if (response.IsSuccessStatusCode && response.Content != null) {
                var data = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject(data, _jsonSerializerSettings);
            } else {
                if (response.Content != null) {
                    var result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception(result);
                }
                throw new Exception("Unknown error");
            }
        }

        //public T Put<T>(string route, object body)
        //{
        //    var url = $"{RootUrl.TrimEnd('/')}/{route}".TrimEnd('/');
        //    var client = GetClient();
        //    var response = client.PutAsJsonAsync(url, body).Result;
        //    if (response.IsSuccessStatusCode && response.Content != null)
        //    {
        //        var data = response.Content.ReadAsStringAsync().Result;
        //        return JsonConvert.DeserializeObject<T>(data, _jsonSerializerSettings);
        //    }
        //    else
        //    {
        //        if (response.Content != null)
        //        {
        //            var result = response.Content.ReadAsStringAsync().Result;
        //            throw new Exception(result);
        //        }
        //        throw new Exception("Unknown error");
        //    }
        //}

        public T Patch<T>(string route, object body) {
            var url = $"{RootUrl.TrimEnd('/')}/{route}";
            var client = GetClient();
            var response = client.PatchAsync(url, body).Result;
            if (response.IsSuccessStatusCode && response.Content != null) {
                var data = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<T>(data);
            } else {
                if (response.Content != null) {
                    var result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception(result);
                }
                throw new Exception("Unknown error");
            }
        }

        public object Delete(string route) {
            var url = $"{RootUrl.TrimEnd('/')}/{route}".TrimEnd('/');
            var client = GetClient();
            var response = client.DeleteAsync(url).Result;
            if (response.IsSuccessStatusCode && response.Content != null) {
                var data = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject(data);
            } else {
                if (response.Content != null) {
                    var result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception(result);
                }
                throw new Exception("Unknown error");
            }
        }

        public T Delete<T>(string route) {
            var url = $"{RootUrl.TrimEnd('/')}/{route}".TrimEnd('/');
            var client = GetClient();
            var response = client.DeleteAsync(url).Result;
            if (response.IsSuccessStatusCode && response.Content != null) {
                var data = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<T>(data);
            } else {
                if (response.Content != null) {
                    var result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception(result);
                }
                throw new Exception("Unknown error");
            }
        }
        //public async Task<T> DeleteAsync<T>(string route) {
        //    var url = $"{RootUrl.TrimEnd('/')}/{route}".TrimEnd('/');
        //    var client = GetClient();
        //    var response = await client.DeleteAsync(url);
        //    if (response.IsSuccessStatusCode && response.Content != null) {
        //        var data = response.Content.ReadAsStringAsync().Result;
        //        return JsonConvert.DeserializeObject<T>(data);
        //    } else {
        //        if (response.Content != null) {
        //            var result = response.Content.ReadAsStringAsync().Result;
        //            throw new Exception(result);
        //        }
        //        throw new Exception("Unknown error");
        //    }
        //}

        public async Task<T> DeleteAsync<T>(string route) {
            var url = string.Format("{0}/{1}", RootUrl.TrimEnd('/'), route);
            var client = GetClient();
            var response = await client.DeleteAsync(url);
            if (response.IsSuccessStatusCode && response.Content != null) {
                var data = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(data);
            } else {
                if (response.Content != null) {
                    var result = await response.Content.ReadAsStringAsync();
                    throw new Exception(result);
                }
                throw new Exception("Unknown error");
            }
        }


        public void AddHeader(string key, string value) {
            if (_headers.ContainsKey(key))
                _headers[key] = value;
            else
                _headers.Add(key, value);
        }

        private HttpClient GetClient() {
            var httpClient = new HttpClient();
            if (!string.IsNullOrWhiteSpace(_userName) && !string.IsNullOrWhiteSpace(_password)) {
                var basicParams = $"{_userName}:{_password}";
                var basicAuthorization = $"Basic {Base64Encode(basicParams)}";
                httpClient.DefaultRequestHeaders.Add("Authorization", basicAuthorization);
            }
            foreach (var header in _headers) {
                httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);
            }
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return httpClient;
        }

        private static string Base64Encode(string plainText) {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        //private HttpClient GetFilledHttpClient(string apiUrl = "")
        //{
        //    var client = new HttpClient();
        //    var proxyEnabled = bool.Parse(ConfigurationManager.AppSettings["ProxyEnabled"]);
        //    if (proxyEnabled)
        //    {
        //        // Proxy Server Info
        //        var proxyHost = CoreConfigurationManager.AppSettings["ProxyHost"];
        //        var proxyPort = !string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings["ProxyPort"])
        //            ? int.Parse(ConfigurationManager.AppSettings["ProxyPort"])
        //            : 8080;
        //        var proxyUserName = CoreConfigurationManager.AppSettings["ProxyUserName"];
        //        var proxyPassword = CoreConfigurationManager.AppSettings["ProxyPassword"];

        //        var proxyServer = new WebProxy(proxyHost, proxyPort);
        //        proxyServer.Credentials = new NetworkCredential { UserName = proxyUserName, Password = proxyPassword };
        //        //client.Proxy = proxyServer;

        //        var httpClientHandler = new HttpClientHandler()
        //        {
        //            Proxy = proxyServer,
        //            PreAuthenticate = true,
        //            UseDefaultCredentials = false,
        //            Credentials = new NetworkCredential { UserName = proxyUserName, Password = proxyPassword }
        //        };
        //        client = new HttpClient(httpClientHandler);

        //    }

        //var bearerKey = !string.IsNullOrWhiteSpace(apiUrl) ? CoreConfigurationManager.AppSettings["ProductionApiBearer"] : CoreConfigurationManager.AppSettings["ApiBearer"];
        //client.DefaultRequestHeaders.Add("Authorization", bearerKey);
        //if (HttpContext.Current != null)
        //{
        //    CurrentHttpContext = HttpContext.Current;
        //}

        //return client;
        // }
    }
}
