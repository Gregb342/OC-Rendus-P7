using Dot.Net.WebApi.Domain;
using P7CreateRestApi.ViewsModels.CurvePoints;

namespace P7CreateRestApi.Services.Interfaces
{
    public interface ICurvePointService
    {
        Task AddCurvePoint(CurvePoint curvePoint);
        Task<GetCurvePointViewModel> GetCurvePointByIdAsync(int id);
        Task<List<GetCurvePointViewModel>> GetAllCurvePoints();
        Task<GetCurvePointViewModel> UpdateCurvePoint(UpdateCurvePointViewModel model);
        Task RemoveCurvePoint(int id);
    }
}
