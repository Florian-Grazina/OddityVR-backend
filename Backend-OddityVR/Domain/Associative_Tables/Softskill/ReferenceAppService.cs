namespace Backend_OddityVR.Domain.Associative_Tables.Softskill
{
    public class ReferenceAppService
    {
        // properties
        private readonly ReferenceRepo _referenceRepo;


        // constructor
        public ReferenceAppService(ReferenceRepo referenceRepo)
        {
            _referenceRepo = referenceRepo;
        }


        // create
        public void CreateNewReference(Reference Reference)
        {
            _referenceRepo.CreateNewReference(Reference);
        }


        // get all
        public List<Reference> GetAllReferences()
        {
            return _referenceRepo.GetAllReferences();
        }


        // get id
        public List<Reference> GetReferenceByTestId(int id)
        {
            return _referenceRepo.GetReferenceByTestId(id);
        }


        public List<Reference> GetReferenceBySoftskillId(int id)
        {
            return _referenceRepo.GetReferenceBySoftskillId(id);
        }


        // update
        public void UpdateReference(Reference updateReference, int testId, int softskillId)
        {
            _referenceRepo.UpdateReference(updateReference, testId, softskillId);
        }


        // delete
        public void DeleteReferenceByTestId(int id)
        {
            _referenceRepo.DeleteReferenceByTestId(id);
        }


        public void DeleteReferenceBySoftskillId(int id)
        {
            _referenceRepo.DeleteReferenceBySoftskillId(id);
        }
    }
}
