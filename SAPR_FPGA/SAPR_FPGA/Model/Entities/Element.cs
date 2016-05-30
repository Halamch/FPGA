using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAPR_FPGA.Model.Entities;
namespace SAPR_FPGA
{
    class Element // элемент
    {
        public LogValue _logValue; // логическое значение элемента
        private int GorizontalIndex; // координата по горизонтали
        private int VerticalIndex; // координата по вертикали

        public Element(params object[] arguments)
        {
            switch (arguments[0].ToString().Trim()) // заполнение лог.элемента
            {
                case "INV":_logValue = LogValue.INV;break;
                case "AND": _logValue = LogValue.AND; break;
                case "OR": _logValue = LogValue.OR; break;
                case "XOR": _logValue = LogValue.XOR; break;
            }
            GorizontalIndex = arguments[1].ToString().Trim() == String.Empty ? 0: Convert.ToInt32(arguments[1].ToString().Trim());// заполнение координаты по горизонтали
            VerticalIndex = arguments[2].ToString().Trim() == String.Empty ? 0 : Convert.ToInt32(arguments[2].ToString().Trim());// заполнение координаты по вертикали
        }

    }
}
