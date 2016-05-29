using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPR_FPGA
{
    class ProjectExploler // обзорщик проектов
    {
        private int NumProject; // номер проекта
        private string NameProject; // имя проекта
        private string FPGAModel; // модель ПЛИС
        private string NameScheme; // Наименование схемы
        private bool Placed; // факт размещения
        private bool Tracing; // факт трассировки

        public ProjectExploler(params object[] InfProjects)
        {
            try
            {
                NumProject = int.Parse(InfProjects[0].ToString());
                NameProject = InfProjects[1].ToString();
                FPGAModel = InfProjects[2].ToString();
                NameScheme = InfProjects[3].ToString();
                Placed = InfProjects[4].ToString() == "1" ? true : false; // если размещен, то true иначе false
                Tracing = InfProjects[5].ToString() == "1" ? true : false; // если трассирован, то true иначе false

            }
            catch
            {
                
            }
            
        }
    }
}
