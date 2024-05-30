using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exoticamp.Application.Exceptions
{
    public class BannerLinkAlreadyExistsException : ApplicationException
    {
        public BannerLinkAlreadyExistsException(string link)
            : base($"This '{link}' already exists in database, Cannot have dublicate values.")
        {
        }
    }
}
