using Newtonsoft.Json;
using System.Collections.Generic;

namespace Core.Common.Extensions {
    public static class JsonSerializeDeserialize {

        public static string SerializeObjectWithoutNull(this object objectDetails) {
            if (objectDetails == null) {
                return null;
            }

            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.NullValueHandling = NullValueHandling.Ignore;
            try {

                if (objectDetails.GetType().Name.Contains("Dictionary")) {
                    Dictionary<string, object> exObj;
                    exObj = (Dictionary<string, object>)(objectDetails);

                    foreach (var exObjProp in exObj) {
                        if (exObjProp.Value == null) {
                            exObj.Remove(exObjProp.Key);
                        }
                    }
                    return JsonConvert.SerializeObject(exObj, settings);
                }

            } catch {
            }


            return JsonConvert.SerializeObject(objectDetails, settings);

        }
        public static string SerializeObjectWithNull(this object objectDetails) {
            if (objectDetails == null) {
                return null;
            }

            return JsonConvert.SerializeObject(objectDetails);
        }

        public static T DeserializeObjectWithoutNull<T>(this object objectDetails) {
            if (objectDetails == null) {
                return (T)objectDetails;
            }
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.NullValueHandling = NullValueHandling.Ignore;
            return JsonConvert.DeserializeObject<T>(objectDetails.ToString(), settings);
        }

        public static T DeserializeObjectWithNull<T>(this object objectDetails) {
            return JsonConvert.DeserializeObject<T>(objectDetails.ToString());
        }

    }
}
