namespace Joao.Desafio.Dominio.IRepositorio
{
    public interface IRepositorioBase<T> where T : class
    {
        List<T>? ObteTodos();
        T? Obter(Guid id);
        bool Adicionar(T entity);
        bool Atualizar(T entity);
        bool Apagar(T entity);
    }
}
