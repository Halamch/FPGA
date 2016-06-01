using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPR_FPGA
{
    class FPGA
    {
        public string Model;
        public int CountCLB;
        public int ChannelWidth;
        public DRP[,] FPGADRP; // описывает связи и расположение элементов на ПЛИС
    }

    internal class DRP
    {
        private List<Track> tracks; // список трасс входящих или выходящих из КЛБ и КБ(коммутационный блок)
        private int NumFreeMagistrals; // количество свободных магистралей входящих в блок
        private int x, y; // координаты расположения центра элемента (используется для масштабирования сцены)
        public DRP(int ChannelWidth)
        {
            tracks  = new List<Track>();
            NumFreeMagistrals = ChannelWidth*4;

        }
            
    }
}
