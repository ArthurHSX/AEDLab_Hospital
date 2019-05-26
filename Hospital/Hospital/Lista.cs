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
            this.primeiro = new Elemento();
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
                this.ultimo = this.ultimo.Proximo;
            }
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
        /// Retira baseado no estado do paciente fornecido como parâmetro
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Paciente RetiraPPrioridade(int i)
        {
            if (this.Vazia()) return null;

            Elemento percorre = this.primeiro;
            Elemento aux = null;

            while (percorre.Proximo != null)
            {
                if (percorre.Proximo.Dado().GetEstado() == i)
                {
                    aux = percorre.Proximo;
                    break;
                }                
                percorre = percorre.Proximo;
            }
            if (percorre.Proximo == this.ultimo)
            {
                this.ultimo = this.primeiro; percorre.Proximo = aux.Proximo;
            }
            else
            {
                percorre.Proximo = aux.Proximo;
            }
            return aux.Dado();
        }

        /// <summary>
        /// Busca recursiva baseado no parâmetro.
        /// </summary>
        /// <param name="busca"></param>
        /// <returns></returns>
        public bool Busca(int busca, Elemento aux)
        {
            if (aux == null)
                return false;
            if (aux.Dado().GetEstado() == busca)
                return true;            
            else
                return Busca(busca, aux.Proximo);
        }

        public int Count()
        {
            if (this.Vazia()) return 0;
            int cont = 0;
            Elemento percorre = this.primeiro;

            while (percorre.Proximo != null)
            {
                cont = cont + 1;
                percorre = percorre.Proximo;
            }
            return cont;
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
