using Backend_OddityVR.Domain.DTO;

namespace Backend_OddityVR.Domain.AppService
{
    public interface IProspeAppService
    {
        public void CreateNewProspe(CreateProspeCmd newProspe);
        public List<Prospe> GetAllProspes();
        public Prospe GetProspeById(int id);
        public void DeleteProspe(int id);
    }
}
