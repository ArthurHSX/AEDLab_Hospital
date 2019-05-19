using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    class Elemento
    {
        private Elemento proximo;
        private Paciente paciente;

        public Elemento()
        {
            this.proximo = null;
            this.paciente = null;
        }
        public Elemento(Paciente paciente)
        {
            this.proximo = null;
            this.paciente = paciente;
        }
        public Elemento(Elemento elemento)
        {
            this.proximo = elemento.proximo;
            this.paciente = elemento.paciente;
        }      

        public Elemento Proximo { get => proximo; set => proximo = value; }

        /// <summary>
        /// Retorna o objeto paciente da classe Paciente;
        /// </summary>
        /// <returns></returns>
        public Paciente Dado()
        {
            return this.paciente;
        }
    }
}
