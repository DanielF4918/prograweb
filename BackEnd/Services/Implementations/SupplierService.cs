using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class SupplierService : ISupplierService
    {
        IUnidadDeTrabajo _unidadDeTrabajo;
        public SupplierService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        SupplierDTO Convertir(Supplier supplier)
        {
            return new SupplierDTO
            {
                SupplierId = supplier.SupplierId,
                CompanyName = supplier.CompanyName
            };
        }

        Supplier Convertir(SupplierDTO supplier)
        {
            return new Supplier
            {
                SupplierId = supplier.SupplierId,
                CompanyName = supplier.CompanyName
            };
        }

        public SupplierDTO Add(SupplierDTO supplierDTO)
        {
            throw new NotImplementedException();
        }

        public SupplierDTO Delete(int id)
        {
            throw new NotImplementedException();
        }

        public SupplierDTO Get(int id)
        {
            var supplier = _unidadDeTrabajo.SupplierDAL.Get(id);
            return Convertir(supplier);
        }

        public List<SupplierDTO> GetAll()
        {
            var suppliers = _unidadDeTrabajo.SupplierDAL.GetAll();
            List<SupplierDTO> suppliersDTO = new List<SupplierDTO>();
            foreach (var supplier in suppliers)
            {
                suppliersDTO.Add(Convertir(supplier));
            }
            return suppliersDTO;
        }

        public SupplierDTO Update(SupplierDTO supplierDTO)
        {
            throw new NotImplementedException();
        }
    }
}