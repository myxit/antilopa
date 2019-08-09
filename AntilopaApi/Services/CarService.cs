

using System;
using System.Threading.Tasks;
using AntilopaApi.Data;
using AntilopaApi.Models;

namespace AntilopaApi.Services {

    public class CarService {
        private readonly Data.ApplicationDbContext _context;

        public CarService(Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<Car>> MakeForUpdate(int id, CarInputModel inputModel) {            
            var res = await this._context.Cars.FindAsync(id);
            if (res == null) {
                return ServiceResponse<Car>.BadInput();
            }

            res.Nickname = inputModel.Nickname;
            res.RegistrationNr = inputModel.RegistrationNr;
            res.Model = inputModel.Model;
            res.PicUrl = inputModel.PicUrl;
            res.UpdatedAt = new DateTime();
            return ServiceResponse<Car>.Success(res);
        }
    }
}