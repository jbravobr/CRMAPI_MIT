using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using MITCRMApp;
using Prism.Services;

using Realms;

namespace MITCRMApp.ViewModels
{
    public class CadastraClientePageViewModel : BindableBase
    {
        readonly IRepositorioBase<Cliente> _repo;
        readonly IPageDialogService _pageDialogService;

        public string _nome { get; set; }
        public string _sobrenome { get; set; }

        public string _nomerua { get; set; }
        public string _numerorua { get; set; }
        public string _cep { get; set; }

        public DelegateCommand InserirCommand { get; set; }
        public DelegateCommand RetornarCommand { get; set; }

        public CadastraClientePageViewModel(IRepositorioBase<Cliente> repo
                                       , IPageDialogService pageDialogService)
        {
            _repo = repo;
            _pageDialogService = pageDialogService;

            InserirCommand = new DelegateCommand(Inserir);
            RetornarCommand = new DelegateCommand(Retornar);

            App.realm = Realm.GetInstance();

        }

        public Action Retornar
        {
            /*
            get
            {
                return new Action<Cliente>(async (Cliente c) =>
                {
                    try
                    {
                        var cliente = _repo.RetornarEntidadePorId(1);

                        if (cliente != null)
                            await _pageDialogService.DisplayAlertAsync
                                                    (string.Empty
                                                     , $"Nome: {cliente.Nome} , Rua: {cliente.Endereco.NomeRua}"
                                                    , "OK");
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                });
            }
            */

            get
            {
                return new Action(async () =>
                {
                    try
                    {
                        var cliente = App.realm.All<ClienteRealm>()
                                         .FirstOrDefault(x=>x.Id == 1);

                        if (cliente != null)
                            await _pageDialogService.DisplayAlertAsync
                                                    (string.Empty
                                                     , $"Nome: {cliente.Nome} , Rua: {cliente.Endereco.NomeRua}"
                                                    , "OK");
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                });
            }
        }

        public Action Inserir
        {
            /*
            get
            {
                return new Action<Cliente>((Cliente c) =>
                {
                    try
                    {
                        var cliente = new Cliente
                        {
                            Nome = _nome,
                            Sobrenome = _sobrenome,
                            Endereco = new Endereco
                            {
                                NomeRua = _nomerua,
                                NumeroRua = Convert.ToInt32(_numerorua)
                            }
                        };

                        _repo.Inserir(cliente);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                });
            }
            */

            get
            {
                return new Action(() =>
                {
                    try
                    {
                        App.realm.Write(() =>
                        {
                            var clienteRealm = App.realm.CreateObject<ClienteRealm>();
                            clienteRealm.Id = 1;
                            clienteRealm.Nome = _nome;
                            clienteRealm.SobreNome = _nome;
                            clienteRealm.Endereco = new EnderecoRealm
                            {
                                NomeRua = _nomerua,
                                NumeroRua = Convert.ToInt32(_numerorua)
                            };
                        });
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                });
            }
        }
    }
}
