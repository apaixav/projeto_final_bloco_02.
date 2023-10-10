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
                
                .ToListAsync();
        }

        public async Task<Produto> GetById(long id)
        {
            try
            {
                var ProdutoUpdate = await _context.Produtos
                    
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
                .Where(p => p.nome.Contains(nome)).ToListAsync();
            return Produtos;
        }

        public async Task<Produto?> Create(Produto Produto)
        {
    
                await _context.Produtos.AddAsync(Produto);
                await _context.SaveChangesAsync();

                return Produto;
        }

        public async Task<Produto?> Update(Produto produto)
        {
                var ProdutoUpdate = await _context.Produtos.FindAsync(produto.id);

                if (ProdutoUpdate is null)
                    return null;               

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
