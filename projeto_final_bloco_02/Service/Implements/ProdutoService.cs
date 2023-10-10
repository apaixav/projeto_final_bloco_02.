using Microsoft.EntityFrameworkCore;
using projeto_final_bloco_02.Data;
using projeto_final_bloco_02.Model;

namespace projeto_final_bloco_02.Service.Implements
{
    public class ProdutoService : IProdutoService
    {
        private readonly AppDbContext _context;

        public ProdutoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Produto>> GetAll()
        {
            return await _context.Produtos
                .Include(p => p.Categoria)
                .ToListAsync();
        }

        public async Task<Produto> GetById(long id)
        {
            try
            {
                var ProdutoUpdate = await _context.Produtos
                    .Include(p => p.Categoria)
                    .FirstAsync(i => i.id == id);

                return ProdutoUpdate;
            }
            catch
            {
                return null;
            }
        }

        public async Task<IEnumerable<Produto>> GetByNome(string nome)
        {

            var Produtos = await _context.Produtos
                 .Include(p => p.Categoria)
                .Where(p => p.nome.Contains(nome)).ToListAsync();
            return Produtos;
        }

        public async Task<Produto?> Create(Produto produto)
        {
            if (produto.Categoria is not null)
            {
                var BuscaCategoria = await _context.Categorias.FindAsync(produto.Categoria.id);

                if (BuscaCategoria is null)
                    return null;
            }
            produto.Categoria = produto.Categoria is not null ? _context.Categorias.FirstOrDefault(t => t.id == produto.Categoria.id) : null;

            await _context.Produtos.AddAsync(produto);
            await _context.SaveChangesAsync();

            return produto;
        }

        public async Task<Produto?> Update(Produto produto)
        {
            var ProdutoUpdate = await _context.Produtos.FindAsync(produto.id);

            if (ProdutoUpdate is null)
                return null;

            produto.Categoria = produto.Categoria is not null ? _context.Categorias.FirstOrDefault(t => t.id == produto.Categoria.id) : null;

            _context.Entry(ProdutoUpdate).State = EntityState.Detached;
            _context.Entry(produto).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return produto;
        }

    public async Task Delete(Produto produto)
        {
                _context.Remove(produto);
                await _context.SaveChangesAsync();
        }
        
    }
}
