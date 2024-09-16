using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagosysWeb.Core.DTO.DtoInput;
using TagosysWeb.Core.DTO.DtoOutput;
using TagosysWeb.Core.Models;

namespace TagosysWeb.Service.interfaces
{
    public interface ITeamService
    {
         Task<ApiResponseModels<TeamOutput>> addUpdateTeam(TeamInput model);
         Task<ApiResponseModels<TeamOutput>> editTeam(int id);
         Task<ApiResponseModels<List<TeamOutput>>> teamList();
         Task<ApiResponseModels<List<TeamOutput>>> getTeamList();

         Task<ApiResponseModels<bool>> teamDeleteById(int id);
         Task<ApiResponseModels<bool>> activeInActive(int id);
    }
}
