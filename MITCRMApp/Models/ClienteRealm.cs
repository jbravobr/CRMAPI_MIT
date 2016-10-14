using System;
using Realms;

namespace MITCRMApp
{
    public class ClienteRealm : RealmObject
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }

        public EnderecoRealm Endereco { get; set; }
    }

    public class EnderecoRealm : RealmObject
    {
        public int Id { get; set; }
        public string NomeRua { get; set; }
        public int NumeroRua { get; set; }
    }
}
