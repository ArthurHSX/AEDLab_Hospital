using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    class Paciente
    {
        //Estado é definido entre 1 e 4, sendo 4 o mais grave CTI
        private int estado;
        private string nome;

        public Paciente()
        {
            this.estado = -1;
        }
        public Paciente(Paciente paciente)
        {
            this.estado = paciente.estado;
            this.nome = paciente.nome;
        }

        /// <summary>
        /// Retorna o estado do paciente.
        /// </summary>
        /// <returns></returns>
        public int GetEstado()
        {
            return this.estado;
        }

        /// <summary>
        /// Retorna o nome do paciente
        /// </summary>
        /// <returns></returns>
        public string GetNome()
        {
            return this.nome;
        }
    }
}
