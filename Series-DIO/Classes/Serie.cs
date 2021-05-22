using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Series_DIO.Enums;

namespace Series_DIO.Classes
{
    class Serie : EntidadeBase
    {
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Excluido { get; set; }

        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }

        public override string ToString()
        {
            return $" Gênero: {this.Genero}\n Título: {this.Titulo}\n Descrição: {this.Descricao}\n Ano de início: {this.Ano}\n Ecluído: {this.Excluido}";
        }

        public string retornaTitulo()
        {
            return this.Titulo;
        }

        public int retornaId()
        {
            return this.Id;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }

    }
}
