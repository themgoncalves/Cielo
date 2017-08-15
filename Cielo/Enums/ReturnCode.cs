using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cielo.Enums
{
    public enum ReturnCode
    {
        [Description("")]
        Created = 0,
        [Description("")]
        InProgress = 1,
        [Description("")]
        Authenticated = 2,
        [Description("")]
        NotAuthenticated = 3,
        [Description("")]
        Authorized = 4,
        [Description("")]
        NotAuthorized = 5,
        [Description("")]
        Captured = 6,
        [Description("")]
        Canceled = 9,
        [Description("")]
        Authenticating = 10,
        [Description("")]
        Cancelling = 12
    }
}
