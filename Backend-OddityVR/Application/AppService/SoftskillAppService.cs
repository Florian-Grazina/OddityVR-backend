using Backend_OddityVR.Application.AppService.Interfaces;
using Backend_OddityVR.Application.DTO;
using Backend_OddityVR.Domain.Model;
using Backend_OddityVR.Infrastructure.Repo;

namespace Backend_OddityVR.Application.AppService
{
    public class SoftskillAppService : ISoftskillAppService
    {
        // properties
        private readonly SoftskillRepo _softskillRepo;


        // constructor
        public SoftskillAppService(SoftskillRepo softskillRepo)
        {
            _softskillRepo = softskillRepo;
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
