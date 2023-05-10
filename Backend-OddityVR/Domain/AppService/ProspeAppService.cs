using Backend_OddityVR.Domain.DTO;
using Backend_OddityVR.Domain.Repo;

namespace Backend_OddityVR.Domain.AppService
{
    public class ProspeAppService
    {
        // properties
        private readonly ProspeRepo _prospeRepo;


        // constructor
        public ProspeAppService()
        {
            _prospeRepo = new();
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
