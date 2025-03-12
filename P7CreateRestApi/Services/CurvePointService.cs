using Dot.Net.WebApi.Domain;
using P7CreateRestApi.Repositories.Interfaces;
using P7CreateRestApi.Services.Interfaces;
using P7CreateRestApi.ViewsModels.CurvePoints;

namespace P7CreateRestApi.Services
{
    public class CurvePointService : ICurvePointService
    {
        private readonly ICurvePointRepository _curvePointRepository;

        public CurvePointService(ICurvePointRepository curvePointRepository)
        {
            _curvePointRepository = curvePointRepository;
        }

        public async Task AddCurvePoint(CurvePoint curvePoint)
        {
            await _curvePointRepository.AddAsync(curvePoint);
        }

        public async Task<List<GetCurvePointViewModel>> GetAllCurvePoints()
        {
            var allCurvePoints = await _curvePointRepository.GetAllAsync();

            return allCurvePoints.Select(cp => new GetCurvePointViewModel
            {
                Id = cp.Id,
                CurveId = cp.CurveId,
                AsOfDate = cp.AsOfDate,
                Term = cp.Term,
                CurvePointValue = cp.CurvePointValue,
                CreationDate = cp.CreationDate
            }).ToList();
        }

        public async Task<GetCurvePointViewModel> GetCurvePointByIdAsync(int id)
        {
            var cp = await _curvePointRepository.GetByIdAsync(id)
                     ?? throw new KeyNotFoundException($"Le CurvePoint avec l'ID {id} n'existe pas.");

            return new GetCurvePointViewModel
            {
                Id = cp.Id,
                CurveId = cp.CurveId,
                AsOfDate = cp.AsOfDate,
                Term = cp.Term,
                CurvePointValue = cp.CurvePointValue,
                CreationDate = cp.CreationDate
            };
        }

        public async Task<GetCurvePointViewModel> UpdateCurvePoint(UpdateCurvePointViewModel model)
        {
            var cp = await _curvePointRepository.GetByIdAsync(model.Id)
                     ?? throw new KeyNotFoundException($"Le CurvePoint avec l'ID {model.Id} n'existe pas.");


            cp.CurveId = model.CurveId;
            cp.AsOfDate = model.AsOfDate;
            cp.Term = model.Term;
            cp.CurvePointValue = model.CurvePointValue;
            cp.CreationDate = model.CreationDate;

            await _curvePointRepository.UpdateAsync(cp);

            return new GetCurvePointViewModel
            {
                Id = cp.Id,
                CurveId = cp.CurveId,
                AsOfDate = cp.AsOfDate,
                Term = cp.Term,
                CurvePointValue = cp.CurvePointValue,
                CreationDate = cp.CreationDate
            };
        }

        public async Task RemoveCurvePoint(int id)
        {
            var cp = await _curvePointRepository.GetByIdAsync(id)
                     ?? throw new KeyNotFoundException($"Le CurvePoint avec l'ID {id} n'existe pas.");

            await _curvePointRepository.DeleteAsync(cp.Id);
        }
    }
}
