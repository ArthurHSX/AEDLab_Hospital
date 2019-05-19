using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    class Lista
    {
        private Elemento primeiro;      // primeiro é o sentinela.
        private Elemento ultimo;

        public Lista()
        {
            this.primeiro = null;
            this.ultimo = primeiro;
        }

        public Elemento Primeiro { get => primeiro; set => primeiro = value; }
        public Elemento Ultimo { get => ultimo; set => ultimo = value; }

        /// <summary>
        /// Insere um elemento no final da classe Lista.
        /// </summary>
        /// <param name="elemento"></param>
        public void Inserir(Elemento elemento)
        {
            if(Vazia())
            {
                this.primeiro.Proximo = elemento;
                this.ultimo = this.primeiro.Proximo;
            }
            else
            {
                this.ultimo.Proximo = elemento;
                this.ultimo = elemento;
            }
        }

        /// <summary>
        /// Retira o ultimo elemento da lista.
        /// </summary>
        /// <returns></returns>
        public Paciente Retirar()
        {
            if(!Vazia())
            {
                Elemento aux = new Elemento(Busca(ultimo));
                this.ultimo = aux;
                return aux.Dado();
            }
            return null;
        }

        /// <summary>
        /// Retira o elemento baseado no parâmetro.
        /// </summary>
        /// <param name="retira"></param>
        /// <returns></returns>
        public Paciente Retirar(Elemento retira)
        {
            if(!Vazia())
            {
                Elemento aux = new Elemento(Busca(retira));
                aux.Proximo = aux.Proximo.Proximo;
                return aux.Dado();
            }
            return null;
        }

        /// <summary>
        /// Busca recursiva baseado no parâmetro.
        /// </summary>
        /// <param name="busca"></param>
        /// <returns></returns>
        public Paciente Busca(Elemento busca)
        {
            Elemento aux = new Elemento(primeiro);

            if (aux.Proximo == busca)
                return aux.Dado();
            else
                return Busca(aux.Proximo);
        }

        /// <summary>
        /// Método que verifica se a lista está vazia. True => Lista vazia, False => Lista possui elementos.
        /// </summary>
        /// <returns></returns>
        public bool Vazia()
        {
            return (this.primeiro == this.ultimo);
        }

    }
}
