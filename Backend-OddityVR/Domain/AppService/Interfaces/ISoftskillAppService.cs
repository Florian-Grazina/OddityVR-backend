using Backend_OddityVR.Domain.DTO;
using Backend_OddityVR.Model;

namespace Backend_OddityVR.Domain.AppService
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
