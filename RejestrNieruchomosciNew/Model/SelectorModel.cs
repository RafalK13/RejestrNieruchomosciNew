using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RejestrNieruchomosciNew.Model
{
    public interface ISelectorModel
    {
        IChangeViewModel selectedModel { get; set; }
    }

    public class SelectorModel : ISelectorModel
    {
        public IChangeViewModel selectedModel { get; set; }
    }
}
