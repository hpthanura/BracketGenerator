using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketGenerator.Services.Interfaces
{
    public interface ILogService
    {
        public void WriteLine(string message);
        public void Write(string message);
        public void WriteBlank();
    }
}
