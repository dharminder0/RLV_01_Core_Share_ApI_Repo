using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.Entites.Utils {
    public static class StaticUtils {
        public static string ExtractInnerException(this Exception ex) {
            string errorMessage = String.Empty;
            if (ex.Message != null) {
                errorMessage = $"/Msg/-{ex.Message}{Environment.NewLine}";
                if (ex.Source != null) {
                    errorMessage += $"/Src/-{ex.Source}{Environment.NewLine}";
                }
                if (ex.StackTrace != null) {
                    errorMessage += $"/Stack/-{ex.StackTrace}{Environment.NewLine}";
                }
            }
            return errorMessage;
        }
    }
}
