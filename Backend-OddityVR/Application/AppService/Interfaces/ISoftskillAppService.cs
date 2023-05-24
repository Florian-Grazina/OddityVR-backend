using Backend_OddityVR.Application.DTO;
using Backend_OddityVR.Domain.Model;

namespace Backend_OddityVR.Application.AppService.Interfaces
{
    public interface ISoftskillAppService
    {
        public void CreateNewSoftskill(CreateSoftskillCmd newSoftskill);
        public List<Softskill> GetAllSoftskills();
        public Softskill GetSoftskillById(int id);
        public void UpdateSoftskill(CreateSoftskillCmd updateSoftskill, int id);
        public void DeleteSoftskill(int id);
    }
}
