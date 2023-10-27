using AutoMapper;
using MarketPlace.Bussiness.Abstract;
using MarketPlace.Bussiness.GenericRepository;
using MarketPlace.Bussiness.UnitOfWorks;
using MarketPlace.Common.Resources;
using MarketPlace.DataAccess.Models.CustomMarketPlaceModels;
using MarketPlace.DataTransfer.Dtos.Company;
using MarketPlace.DataTransfer.Dtos.Workplace;
using MarketPlace.DataTransfer.ServiceResults;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Bussiness.Concrete
{
    public class WorkplaceManager : IWorkplaceService
    {
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<WorkPlace> _workplaceRepository;
        public WorkplaceManager(IUnitOfWorks unitOfWorks, IMapper mapper)
        {
            _unitOfWorks = unitOfWorks;
            _mapper = mapper;
            _workplaceRepository = _unitOfWorks.GetGenericRepository<WorkPlace>();

        }
        public async Task<ServiceResult> CreateWorkPlace(WorkplaceDto dto)
        {
            if (dto != null)
            {

                if (dto.Id == 0) //added
                {
                    var workplace = _mapper.Map<WorkPlace>(dto);
                    await _workplaceRepository.Add(workplace);
                }
                else //updated
                {
                    var workplace = await _workplaceRepository.Get(dto.Id);
                    workplace.Name = dto.Name;
                    workplace.VKN = dto.VKN;
                    workplace.Code = dto.Code;
                    await _workplaceRepository.Update(workplace);
                }

                return await _unitOfWorks.SaveChanges();
            }

            return Result.Fail("", 500);
        }

        public async Task<ServiceResult> DeleteWorkPlace(DeleteWorkplaceDto dto)
        {
            var workplaces = (await _workplaceRepository.GetAll(x => !x.IsDeleted && dto.WorkplaceIds.Contains(x.Id))).ToList();

            await _workplaceRepository.DeleteRange(workplaces);
            return await _unitOfWorks.SaveChanges();
        }

        public async Task<ServiceResult> GetWorkPlace(int workplaceId)
        {
            var workplace = (await _workplaceRepository.Get(workplaceId));
            var mapDto = _mapper.Map<WorkplaceDto>(workplace);
            return Result.Success("", 200, 0, mapDto);
        }

        public async Task<ServiceResult> GetActiveWorkPlaces(int companyId)
        {
            var workPlaces = ((await _workplaceRepository.GetAll(x => !x.IsDeleted && x.CompanyId == companyId))).ToList();
            List<WorkplaceDto> mapDtos = _mapper.Map<List<WorkplaceDto>>(workPlaces);
            return Result.Success("", 200, 0, mapDtos);
        }
    }
}
