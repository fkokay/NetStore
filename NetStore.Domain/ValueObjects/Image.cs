using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetStore.Domain.ValueObjects
{
    public sealed class Image
    {
        public string Url { get; }

        public Image(string url)
        {
            Url = url ?? throw new ArgumentNullException(nameof(url));
        }
    }
}
