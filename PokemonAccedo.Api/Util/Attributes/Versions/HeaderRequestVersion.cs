using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace PokemonAccedo.Api.Util.Attributes.Versions
{
    public class HeaderRequestVersion : Attribute, IActionConstraint
    {
        private readonly string header;
        private readonly string version;

        public HeaderRequestVersion(string Header, string Version)
        {
            header = Header;
            version = Version;
        }

        public int Order => 0;

        public bool Accept(ActionConstraintContext context)
        {
            var headers = context.RouteContext.HttpContext.Request.Headers;
            if (!headers.ContainsKey(header))
                return false;


            return string.Equals(headers[header], version, StringComparison.OrdinalIgnoreCase);
        }
    }
}
