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
        public int count;

        public Lista()
        {
            this.primeiro = new Elemento();
            this.ultimo = primeiro;
            count = 0;
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
        /// Insere um paciente encapsulado no final da classe Lista.
        /// </summary>
        /// <param name="elemento"></param>
        public void Inserir(Paciente paciente)
        {
            Elemento elemento = new Elemento(paciente);
            if (Vazia())
            {
                this.primeiro.Proximo = elemento;
                this.ultimo = this.primeiro.Proximo;
            }
            else
            {
                this.ultimo.Proximo = elemento;
                this.ultimo = elemento;
            }
            count++;
        }

        /// <summary>
        /// Retira o primeiro elemento da lista.
        /// </summary>
        /// <returns></returns>
        public Paciente Retirar()
        {
            if(!Vazia())
            {
                Elemento aux = new Elemento(this.primeiro.Proximo);
                this.primeiro.Proximo = this.primeiro.Proximo.Proximo;
                return aux.Dado();
            }
            return null;
        }               

        /// <summary>
        /// Retira o maior prioritário da lista
        /// </summary>
        /// <returns></returns>
        public Paciente RetiraMaiorPrioritario()
        {
            Elemento percorre = new Elemento(primeiro.Proximo);
            Elemento aux = null;

            while (percorre.Proximo != null)
            {
                if (percorre.Proximo.Dado().GetEstado() == 1 && aux == null)
                {
                    aux = percorre;
                }
                else if (percorre.Proximo.Dado().GetEstado() > aux.Dado().GetEstado())
                {
                    aux = percorre;
                }                
                percorre = percorre.Proximo;
            }
            aux.Proximo.Proximo = aux.Proximo.Proximo.Proximo;

            return aux.Proximo.Dado();
        }

        /// <summary>
        /// Retira baseado no estado do paciente fornecido como parâmetro
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Paciente RetiraPPrioridade(int i)
        {
            Elemento percorre = new Elemento(primeiro.Proximo);
            Elemento aux = null;

            while (percorre != null)
            {
                if (percorre.Proximo.Dado().GetEstado() == i)
                {
                    aux = percorre.Proximo;
                }
                
                percorre = percorre.Proximo;
            }
            aux.Proximo.Proximo = aux.Proximo.Proximo.Proximo;

            return aux.Proximo.Dado();
        }

        /// <summary>
        /// Busca recursiva baseado no parâmetro.
        /// </summary>
        /// <param name="busca"></param>
        /// <returns></returns>
        public bool Busca(int busca, Elemento aux)
        {            
            if (aux.Dado().GetEstado() == busca)
                return true;
            else
                return Busca(busca, aux.Proximo);
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
