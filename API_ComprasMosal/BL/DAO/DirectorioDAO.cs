using API_Delivery.BL.Models;
using System.Collections.Generic;

namespace API_Delivery.BL.DAO
{
    public interface DirectorioDAO : CRUD<Directorio>
    {
        List<Directorio> GetAllActive();
    }
}
