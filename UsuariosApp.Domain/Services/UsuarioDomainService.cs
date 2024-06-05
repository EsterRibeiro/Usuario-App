using UsuariosApp.Domain.Entities;
using UsuariosApp.Domain.Helpers;
using UsuariosApp.Domain.Interfaces.Producers;
using UsuariosApp.Domain.Interfaces.Repositories;
using UsuariosApp.Domain.Interfaces.Services;
using UsuariosApp.Domain.Models;

namespace UsuariosApp.Domain.Services;
public class UsuarioDomainService : IUsuarioDomainService
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IPerfilRepository _perfilRepository;
    private readonly IMessageProducer _messageProducer;

    public UsuarioDomainService(IUsuarioRepository usuarioRepository, IPerfilRepository perfilRepository, IMessageProducer messageProducer)
    {
        _usuarioRepository = usuarioRepository;
        _perfilRepository = perfilRepository;
        _messageProducer = messageProducer;
    }

    public Usuario Autenticar(string email, string senha)
    {
        #region Buscar o usuário no BD através do email e senha

        var usuario = _usuarioRepository.GetByEmailAndPassword(email, SHA256CryptoHelper.ComputeHash(senha));
        #endregion

        #region Verificar se o usuário foi encontrado

        if (usuario is not null)
            return usuario;
        else
            throw new ApplicationException("Acesso negado. Usuário não encontrado");

        #endregion
    }

    public void Criar(Usuario usuario)
    {
        #region Verificar se o e-mail do usuário já está cadastrado no sistema

        if (_usuarioRepository.GetByEmail(usuario.Email) != null)
            throw new ApplicationException("O email informado já está cadastrado para outro usuário.");


        #endregion


        #region Criptografar a senha do usuário

        usuario.Senha = SHA256CryptoHelper.ComputeHash(usuario.Senha);
        #endregion

        //_usuarioRepository.Add(usuario);

        #region Associar o novo usuário ao perfil default
        var perfil = _perfilRepository.GetByNome("DEFAULT");
        usuario.PerfilId = perfil.Id;

        #endregion

        _usuarioRepository.Add(usuario);

        #region Escrevendo e enviando mensagem para o usuário

        var emailModel = new NotificacaoEmailModel()
        {
            EmailDestinatario = usuario.Email,
            Assunto = "Criação de conta de usuário realizada com sucesso - COTI Informática",
            Texto = @$"
                <strong> Olá {usuario.Nome}!</br>
                Sua conta de usuário foi criada, seja bem vindo ao sistema.</br>
                Para quaisquer dúvidas entre em contato com o suporte.</br>
                </br>
                Att,</br>
                Equipe COTI Informática
                </strong>
            "
        };
        _messageProducer.EnviarMensagem(emailModel);

        #endregion
    }

    public Usuario ObterDados(Guid id)
    {
        #region Consultando os dados do usuário através do ID

        var usuario = _usuarioRepository.GetById(id);
        #endregion

        #region Verificar se o usuário foi encontrado

        if (usuario != null)
            return usuario;
        else throw new ApplicationException("Usuário não encontrado");

        #endregion
    }
}
