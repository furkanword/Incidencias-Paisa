using Aplicacion.Repository;
using Dominio.Interfaces;
using Persistencia;

namespace Aplicacion.UnitOfWork
{

    public class UnitOfWork : IUnitOfWork, IDisposable
    {

        public  UnitOfWork(ApiIncidenciasContext _context) {context  = _context;}

        private readonly ApiIncidenciasContext context;

        private  PaisRepository ? _paises;

        public IPaisRepository Paises => _paises  ??= new PaisRepository(context);

        public int Save(){
            return context.SaveChanges();
        }

        public async Task<int> SaveAsync(){
            return await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}