using Microsoft.EntityFrameworkCore;
using MinhaApiTreino.Data;
using MinhaApiTreino.Model;
using MinhaApiTreino.Repositorios.Interfaces;

namespace MinhaApiTreino.Repositorios
{
    public class UsuarioRepositorio : IUsuarioReposiorio
    {
        private readonly SistemaTarefasDBContex _dbContex;
        public UsuarioRepositorio(SistemaTarefasDBContex sistemaTarefasDBContex)
        {
            _dbContex = sistemaTarefasDBContex;
        }

        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            return await _dbContex.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbContex.Usuarios.ToListAsync();
        }
        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
           await _dbContex.Usuarios.AddAsync(usuario);
            await _dbContex.SaveChangesAsync();

            return usuario;
        }
        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            //tenho que buscar o usuário e colocar em uma variável
            UsuarioModel usuarioPorId = await BuscarPorId(id);

            //fazer uma verificação de ele existe
            if(usuarioPorId == null)
            {
                throw new Exception($"Usuario para o id: {id} nao encontrado.");
            }

            usuarioPorId.Nome = usuario.Nome;
            usuarioPorId.Email = usuario.Email;

            _dbContex.Usuarios.Update(usuarioPorId);
            await _dbContex.SaveChangesAsync();

            return usuarioPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            //novamente buscar o usuário e colocar em uma variável
            UsuarioModel usuarioPorId = await BuscarPorId(id);

            //verificação
            if (usuarioPorId == null)
            {
                throw new Exception($"Usuario para o id: {id} nao encontrado.");
            }

            _dbContex.Usuarios.Remove(usuarioPorId);
            await _dbContex.SaveChangesAsync();

            return true;
        }
    }
}
