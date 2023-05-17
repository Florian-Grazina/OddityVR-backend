﻿using Backend_OddityVR.Domain.DTO;
using Backend_OddityVR.Domain.Repo;
using Backend_OddityVR.Model;

namespace Backend_OddityVR.Domain.AppService
{
    public class BatchAppService : IBatchAppService
    {
        // properties
        private readonly BatchRepo _batchRepo;


        // constructor
        public BatchAppService(BatchRepo batchRepo)
        {
            _batchRepo = batchRepo;
        }


        // create
        public void CreateNewBatch(CreateBatchCmd newBatch)
        {
            Batch batch = newBatch.ToModel();
            _batchRepo.CreateNewBatch(batch);
        }


        // get all
        public List<Batch> GetAllBatches()
        {
            return _batchRepo.GetAllBatches();
        }


        // get id
        public Batch GetBatchById(int id)
        {
            return _batchRepo.GetBatchById(id);
        }


        // update
        public void UpdateBatch(CreateBatchCmd updateBatch, int id)
        {
            Batch batch = updateBatch.ToModel(id);
            _batchRepo.UpdateBatch(batch);
        }


        // delete
        public void DeleteBatch(int id)
        {
            _batchRepo.DeleteBatch(id);
        }
    }
}
