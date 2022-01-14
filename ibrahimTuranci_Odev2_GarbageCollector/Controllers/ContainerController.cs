using AutoMapper;
using Data.DataModels;
using Data.UoW;
using Entity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ibrahimTuranci_Odev2_GarbageCollector.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContainerController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ContainerController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }



        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allContainers = await unitOfWork.Containers.GetAll();
            var responseEntities = mapper.Map<IEnumerable<Container>, List<ContainerResponseEntity>>(allContainers);
            return Ok(responseEntities);
        }


        [HttpPost]
        public IActionResult Post([FromBody] ContainerCreateEntity request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            var container = mapper.Map<ContainerCreateEntity, Container>(request);
            unitOfWork.Containers.Add(container);
            unitOfWork.Complete();
            return Ok();
        }


        [HttpPut]
        public IActionResult Put([FromBody] ContainerUpdateEntity request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            Container oldcontainer = unitOfWork.Containers.Get(request.Id);
            mapper.Map(request, oldcontainer);
            unitOfWork.Containers.Update(oldcontainer);
            unitOfWork.Complete();
            return Ok();
        }



        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {


            unitOfWork.Containers.Delete(id);
            unitOfWork.Complete();
            return Ok(id);
        }
    }
}
