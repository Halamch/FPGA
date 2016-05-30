using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAPR_FPGA.Model;
namespace SAPR_FPGA
{
    class Element // элемент
    {
        private LogValue _Value; // логическое значение
        private int GorizontalIndex; // координата х
        private int VerticalIndex; // координата у

        public Element(params object[] arguments)
        {
            try
            {
                switch (arguments[0].ToString().Trim()) // логическое значение
                {
                    case "INV": _Value = LogValue.Invertor; break;
                    case "OR": _Value = LogValue.OR; break;
                    case "AND": _Value = LogValue.AND; break;
                    case "XOR": _Value = LogValue.XOR; break;
                }
                GorizontalIndex = arguments[1].ToString().Trim() == String.Empty ? 0 : Convert.ToInt32(arguments[1].ToString().Trim()); // координата по горизонтали
                VerticalIndex = arguments[2].ToString().Trim() == String.Empty ? 0 : Convert.ToInt32(arguments[2].ToString().Trim()); // координата по вертикали
            }
            catch
            {
                

            }
      

        }
    }
}
