using System;
using System.Collections.Generic;

using SQLiteNetExtensions.Attributes;

namespace MITCRMApp
{
    public class Cliente : EntidadeBase
    {
        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public DateTimeOffset DataNascimento { get; set; }

        [OneToOne(CascadeOperations = 
                  (CascadeOperation.CascadeRead | CascadeOperation.CascadeInsert))]
        public Endereco Endereco { get; set; }

        [OneToMany(CascadeOperations =
                  (CascadeOperation.CascadeRead | CascadeOperation.CascadeInsert))]
        public List<Telefone> Telefones { get; set; }
    }

    public class Endereco : EntidadeBase
    {
        public string NomeRua { get; set; }

        public int NumeroRua { get; set; }

        public string CEP { get; set; }

        [ForeignKey(typeof(Cliente))]
        public int ClienteId { get; set; }
    }

    public class Telefone : EntidadeBase
    {
        public int DDD { get; set; }

        public string Numero { get; set; }

        [ForeignKey(typeof(Cliente))]
        public int ClientId { get; set; }
    }

    public class EntidadeBase
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int Id { get; set; }
    }
}
