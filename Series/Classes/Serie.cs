using Series.Enuns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Series.Classes
{
    public class Serie : EntidadeBase
    {
        private Genero Genero {get;set;}
        private string Titulo { get; set; }
        private String Descricao { get; set; }
        private int Ano {get; set; }
        private Boolean Excluido { get; set; }

        public Serie(int Id, Genero Genero, string Titulo, String Descricao, int Ano) 
        {
            this.Id        = Id;
            this.Genero    = Genero;
            this.Titulo    = Titulo;
            this.Descricao = Descricao;
            this.Ano       = Ano;
            this.Excluido  = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Título: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Início: " + this.Ano;
            retorno += "Excluido" + this.Excluido;
            return retorno;
        }

        public string RetornaTitulo() 
        {
            return this.Titulo;
        }

        public int RetornaId() 
        {
            return this.Id;
        }

        public bool RetornaExcluido() 
        {
            return this.Excluido;
        }

        public void Exclui() 
        {
          this.Excluido = true; 
        }
    }
}
