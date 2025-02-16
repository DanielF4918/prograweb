using BackEnd.DTO;
using DAL.Implementations;

namespace BackEnd.Services.Interfaces
{
    public interface ISupplierService
    {
        SupplierDTO Get(int id);
        List<SupplierDTO> GetAll();

        SupplierDTO Add(SupplierDTO supplierDTO);
        SupplierDTO Update(SupplierDTO supplierDTO);
        SupplierDTO Delete(int id);



    }
}