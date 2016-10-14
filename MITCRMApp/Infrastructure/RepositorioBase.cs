using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using SQLiteNetExtensions.Extensions;

namespace MITCRMApp
{
    public class RepositorioBase<T> : IRepositorioBase<T> where T : EntidadeBase, new()
    {
        object _lock = new object();

        public RepositorioBase()
        {
            if (App.Conn != null)
                return;

            App.Conn = Xamarin.Forms.DependencyService
                .Get<ISQLite>(Xamarin.Forms.DependencyFetchTarget.GlobalInstance)
                .RetornaConexao();

            CriarTabelas();
        }

        void CriarTabelas()
        {
            lock (_lock)
            {
                try
                {
                    App.Conn.CreateTable<Cliente>(SQLite.CreateFlags.None);
                    App.Conn.CreateTable<Endereco>(SQLite.CreateFlags.None);
                    App.Conn.CreateTable<Telefone>(SQLite.CreateFlags.None);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void Deletar(T TEntity)
        {
            lock (_lock)
            {
                App.Conn.Delete(TEntity, recursive: true);
            }
        }

        public void DeletarPorId(int Id)
        {
            lock (_lock)
            {
                var entity = RetornarEntidadePorId(Id);
                App.Conn.Delete(entity);
            }
        }

        public void Inserir(T TEntity)
        {
            lock (_lock)
            {
                App.Conn.InsertOrReplaceWithChildren(TEntity, recursive: true);
            }
        }

        public List<T> RetornarColecao(Expression<Func<T, bool>> filtro)
        {
            lock (_lock)
            {
                return App.Conn.GetAllWithChildren<T>(filtro, recursive: true);
            }
        }

        public T RetornarEntidade(Expression<Func<T, bool>> filtro)
        {
            lock (_lock)
            {
                return App.Conn.Table<T>().FirstOrDefault(filtro);
            }
        }

        public T RetornarEntidadePorId(int id)
        {
            return App.Conn.GetWithChildren<T>(id);
        }

        public void Update(T TEntity)
        {
            lock (_lock)
            {
                App.Conn.UpdateWithChildren(TEntity);
            }
        }
    }
}
