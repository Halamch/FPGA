using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPR_FPGA
{
    class Route // Маршрут
    {
        public Element Source; // Элемент источник сигнала
        public Element Receiver; // Элемент приемник сигнала
        public List<Path> paths; // список путей входящих в маршрут
        public int length; // длина маршрута
        public Route(Element Source, Element Receiver,int length)
        {
            this.Source = Source;
            this.Receiver = Receiver;
            this.length = length;
        }
    }
}
