using System.Collections.Generic;

namespace TCC.Models.TO
{
    public class RecomendacoesCadastroEvento
    {
        public IList<string> Tags { get; set; }
        public IList<string> SugestaoPublicoAlvo { get; set; }
        public IList<string> SugestaoLocal { get; set; }
    }
}
