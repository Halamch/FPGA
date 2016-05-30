using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPR_FPGA
{
    class Path // путь
    {
        public Element Start; // элемент начало
        public Element End; // элемент конец
        public int length; // длина пути

        public Path(Element Start, Element End,int length)
        {
            this.Start = Start;
            this.End = End;
            this.length = length;
        }

        public Path()
        {

        }
    }
}
