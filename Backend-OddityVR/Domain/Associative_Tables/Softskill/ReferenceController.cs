using Microsoft.AspNetCore.Mvc;

namespace Backend_OddityVR.Domain.Associative_Tables.Softskill
{
    [Route("api/reference")]
    [ApiController]
    public class ReferenceController
    {
        // properties
        private readonly ReferenceAppService _referenceService;


        // constructor
        public ReferenceController(ReferenceAppService referenceAppService)
        {
            _referenceService = referenceAppService;
        }


        // methods
        [Route("create")]
        [HttpPost]
        public void CreateNewReference(Reference reference)
        {
            _referenceService.CreateNewReference(reference);
        }


        [Route("get_all")]
        [HttpGet]
        public List<Reference> GetAllReferences()
        {
            return _referenceService.GetAllReferences();
        }


        [Route("get_article/{id:int}")]
        [HttpGet]
        public List<Reference> GetReferenceByTestId(int id)
        {
            return _referenceService.GetReferenceByTestId(id);
        }


        [Route("get_user/{id:int}")]
        [HttpGet]
        public List<Reference> GetReferenceBySoftskillId(int id)
        {
            return _referenceService.GetReferenceBySoftskillId(id);
        }


        [Route("update/{testId:int},{softskillId:int}")]
        [HttpPut]
        public void UpdateReference(Reference reference, int testId, int softskillId)
        {
            _referenceService.UpdateReference(reference, testId, softskillId);
        }


        [Route("delete_user/{id:int}")]
        [HttpDelete]
        public void DeleteReferenceByTestId(int id)
        {
            _referenceService.DeleteReferenceByTestId(id);
        }


        [Route("delete_article/{id:int}")]
        [HttpDelete]
        public void DeleteReferenceBySoftskillId(int id)
        {
            _referenceService.DeleteReferenceBySoftskillId(id);
        }
    }
}
