using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAPR_FPGA
{
    public class ProjectExploler // обзорщик проектов
    {
        private int _numProject; // номер проекта
        private string _nameProject; // имя проекта
        private string FPGAModel; // модель ПЛИС
        private string _nameScheme; // Наименование схемы
        private bool _placed; // факт размещения
        private bool _tracing; // факт трассировки

        public ProjectExploler(params object[] InfProjects)
        {
            try
            {
                _numProject = int.Parse(InfProjects[0].ToString());
                _nameProject = InfProjects[1].ToString();
                FPGAModel = InfProjects[2].ToString();
                _nameScheme = InfProjects[3].ToString();
                _placed = InfProjects[4].ToString() == "1" ? true : false; // если размещен, то true иначе false
                _tracing = InfProjects[5].ToString() == "1" ? true : false; // если трассирован, то true иначе false

            }
            catch
            {
                
            }
            
        }

        public int NumProject
        {
            get { return _numProject; }
        }

        public string NameProject
        {
            get { return _nameProject; }
        }

        public string FpgaModel
        {
            get { return FPGAModel; }
        }

        public string NameScheme
        {
            get { return _nameScheme; }
        }

        public bool Placed
        {
            get { return _placed; }
        }

        public bool Tracing
        {
            get { return _tracing; }
        }
    }
}
