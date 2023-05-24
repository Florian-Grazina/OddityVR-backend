using Backend_OddityVR.Application.DTO;
using Backend_OddityVR.Domain.Model;

namespace Backend_OddityVR.Application.AppService.Interfaces
{
    public interface IProspeAppService
    {
        public void CreateNewProspe(CreateProspeCmd newProspe);
        public List<Prospe> GetAllProspes();
        public Prospe GetProspeById(int id);
        public void DeleteProspe(int id);
    }
}
