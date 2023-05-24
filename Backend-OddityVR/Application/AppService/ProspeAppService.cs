using Backend_OddityVR.Application.AppService.Interfaces;
using Backend_OddityVR.Application.DTO;
using Backend_OddityVR.Domain.Model;
using Backend_OddityVR.Infrastructure.Repo;

namespace Backend_OddityVR.Application.AppService
{
    public class ProspeAppService : IProspeAppService
    {
        // properties
        private readonly ProspeRepo _prospeRepo;


        // constructor
        public ProspeAppService(ProspeRepo prospeRepo)
        {
            _prospeRepo = prospeRepo;
        }


        // create
        public void CreateNewProspe(CreateProspeCmd newProspe)
        {
            Prospe prospe = newProspe.ToModel();
            _prospeRepo.CreateNewProspe(prospe);
        }


        // get all
        public List<Prospe> GetAllProspes()
        {
            return _prospeRepo.GetAllProspe();
        }


        // get id
        public Prospe GetProspeById(int id)
        {
            return _prospeRepo.GetProspeById(id);
        }


        // delete
        public void DeleteProspe(int id)
        {
            _prospeRepo.DeleteProspe(id);
        }
    }
}
