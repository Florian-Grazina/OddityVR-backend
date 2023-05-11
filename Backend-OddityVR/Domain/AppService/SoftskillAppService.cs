using Backend_OddityVR.Domain.DTO;
using Backend_OddityVR.Model;
using BackOddityVR.Domain.Repo;

namespace Backend_OddityVR.Domain.AppService
{
    public class SoftskillAppService : ISoftskillAppService
    {
        // properties
        private readonly SoftskillRepo _softskillRepo;


        // constructor
        public SoftskillAppService()
        {
            _softskillRepo = new();
        }


        // create
        public void CreateNewSoftskill(CreateSoftskillCmd newSoftskill)
        {
            Softskill softskill = newSoftskill.ToModel();
            _softskillRepo.CreateNewSoftskill(softskill);
        }


        // get all
        public List<Softskill> GetAllSoftskills()
        {
            return _softskillRepo.GetAllSoftskills();
        }


        // get id
        public Softskill GetSoftskillById(int id)
        {
            return _softskillRepo.GetSoftskillById(id);
        }


        // update
        public void UpdateSoftskill(CreateSoftskillCmd updateSoftskill, int id)
        {
            Softskill Softskill = updateSoftskill.ToModel(id);
            _softskillRepo.UpdateSoftskill(Softskill);
        }


        // delete
        public void DeleteSoftskill(int id)
        {
            _softskillRepo.DeleteSoftskill(id);
        }
    }
}
