using System;

namespace OnlineShop.Application.Helpers.SecurityHelper
{
    public static class EmailActivationLinkGenerator
    {
        public static string CodeGenerator()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
