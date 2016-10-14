using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MITCRMApp
{
    public interface IRepositorioBase<T> where T: EntidadeBase
    {
        void Inserir(T TEntity);

        void Deletar(T TEntity);

        void DeletarPorId(int Id);

        void Update(T TEntity);

        T RetornarEntidade(Expression<Func<T,bool>> filtro);

        T RetornarEntidadePorId(int id);

        List<T> RetornarColecao(Expression<Func<T, bool>> filtro);
    }
}
