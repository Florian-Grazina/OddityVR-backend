using Backend_OddityVR.Application.DTO;
using Backend_OddityVR.Domain.Model;

namespace Backend_OddityVR.Application.AppService.Interfaces
{
    public interface IBatchAppService
    {
        public void CreateNewBatch(CreateBatchCmd newBatch);
        public List<Batch> GetAllBatches();
        public Batch GetBatchById(int id);
        public void UpdateBatch(CreateBatchCmd updateBatch, int id);
        public void DeleteBatch(int id);
    }
}
