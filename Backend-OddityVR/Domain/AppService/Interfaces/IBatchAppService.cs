using Backend_OddityVR.Domain.DTO;
using Backend_OddityVR.Model;

namespace Backend_OddityVR.Domain.AppService
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
