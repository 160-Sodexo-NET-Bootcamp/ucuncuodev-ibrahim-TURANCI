using AutoMapper;
using Data.DataModels;
using Data.UoW;
using Entity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace ibrahimTuranci_Odev2_GarbageCollector.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public VehicleController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var allVehicles = await unitOfWork.Vehicles.GetAll();
            return Ok(allVehicles);

        }
        [HttpGet("id/{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var vehicle = unitOfWork.Vehicles.Get(id);
            return Ok(vehicle);
        }




        [HttpGet]    //
        [Route("Containers")]
        public async Task<IActionResult> GetContainersOfVehicle([FromQuery] long Id)
        {

            var allContainers = await unitOfWork.Containers.GetAll();
            return Ok(allContainers.Where(x => x.VehicleId == Id));
        }
        [HttpPost]
        public IActionResult Post([FromBody] VehicleCreateEntity request)
        {
            if (request == null)
            {
                return BadRequest();
            }
            var vehicle = mapper.Map<VehicleCreateEntity, Vehicle>(request);
            unitOfWork.Vehicles.Add(vehicle);
            unitOfWork.Complete();
            return Ok();
        }
        [HttpPut]
        public IActionResult Put([FromBody] VehicleUpdateEntity request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            Vehicle oldvehicle = unitOfWork.Vehicles.Get(request.Id);
            mapper.Map(request, oldvehicle);
            unitOfWork.Vehicles.Update(oldvehicle);
            unitOfWork.Complete();
            return Ok();
        }
        [HttpDelete("{id}")]
        public int Delete(int id)
        {


            unitOfWork.Vehicles.Delete(id);
            unitOfWork.Complete();
            return id;
        }
    }

}
