using System;

namespace TCC.Models.TO
{
    public class ItemEvento
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string DescricaoSimples { get; set; }
        public string Img { get; set; }
        public double Valor { get; set; }
        public DateTime DataEvento { get; set; }
    }
}
