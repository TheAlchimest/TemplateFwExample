using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using TemplateFwExample.Dtos;
using TemplateFwExample.Shared.Domain.Enums;
using TemplateFwExample.Shared.Dtos.Collections;
using Adoler.AdoExtension.Extensions;
using TemplateFwExample.Persistence.IRepositories;

namespace TemplateFwExample.Persistence.Repositories
{
    public class ExampleStatusRepository : IExampleStatusRepository
    {
        readonly IDbHelper dbHelper;
        public ExampleStatusRepository(IDbHelper dbHelper)
        {
            this.dbHelper = dbHelper;
        }

        #region InsertAsync
        public async Task<bool> CreateAsync(ExampleStatusDto dto)
        {
            List<SqlParameter> plist = dto.ConvertToParametersExcept(e => e.CreationDate, e => e.ModifiedBy, e => e.ModifiedDate, e => e.IsAvailable);
            int affectedRows = await dbHelper.SqlHelperWrite.ExecuteNonQueryAsync("[dbo].[ExampleStatus_Create]", plist);
            return (affectedRows > 0);
        }
        #endregion

        #region UpdateAsync
        public async Task<bool> UpdateAsync(ExampleStatusDto dto)
        {
            List<SqlParameter> plist = dto.ConvertToParametersExcept(e => e.CreatedBy, e => e.CreationDate, e => e.ModifiedDate, e => e.IsAvailable);
            int affectedRows = await dbHelper.SqlHelperWrite.ExecuteNonQueryAsync("[dbo].[ExampleStatus_Update]", plist);
            return (affectedRows > 0);
        }

        #endregion

        #region DeleteVirtuallyAsync
        public async Task<bool> DeleteVirtuallyAsync(int id, string user)
        {
            dynamic parameters = new ExpandoObject();
            parameters.ExampleStatusId = id;
            parameters.ModifiedBy = user;
            int affectedRows = await dbHelper.SqlHelperWrite.ExecuteNonQueryAsync("[dbo].[ExampleStatus_DeleteVirtually]", parameters);
            return (affectedRows > 0);
        }
        #endregion

        #region DeletePermanentlyAsync
        public async Task<bool> DeletePermanentlyAsync(int id)
        {
            dynamic parameters = new ExpandoObject();
            parameters.ExampleStatusId = id;
            int affectedRows = await dbHelper.SqlHelperWrite.ExecuteNonQueryAsync("[dbo].[ExampleStatus_DeletePermanently]", parameters);
            return (affectedRows > 0);
        }
        #endregion

        #region GetInfoByIdAsync
        public async Task<ExampleStatusInfoDto> GetInfoByIdAsync(int id, EnumLanguage lang = EnumLanguage.Arabic)
        {
            dynamic parameters = new ExpandoObject();
            parameters.LanguageId = (int)lang;
            parameters.ExampleStatusId = id;
            ExampleStatusInfoDto item =await dbHelper.SqlHelperRead.GetSingleRecordAsync<ExampleStatusInfoDto>("[dbo].[ExampleStatus_GetOneInfo]", parameters);
            return item;
        }
        #endregion

        #region GetAllAsync
        public async Task<List<ExampleStatusInfoDto>> GetAllAsync(ExampleStatusFilter filter)
        {
            var parameters = filter.ConvertToParametersExcept(e => e.PageNumber, e => e.PageSize);
            List<ExampleStatusInfoDto> list = await dbHelper.SqlHelperRead.GetRecordListAsync<ExampleStatusInfoDto>("[dbo].[ExampleStatus_GetAllInfo]", parameters);
            return list;
        }
        #endregion

        #region GetPagedListAsync
        public async Task<PagedList<ExampleStatusInfoDto>> GetAllInfoPagedAsync(ExampleStatusFilter filter)
        {
            var parameters = filter.ConvertToParameters();
            var count = parameters.AddOutputTotalCountOutput();
            List<ExampleStatusInfoDto> list = await dbHelper.SqlHelperRead.GetRecordListAsync<ExampleStatusInfoDto>("[dbo].[ExampleStatus_GetAllInfoPaged]", parameters);
            var pagedList = new PagedList<ExampleStatusInfoDto>(list, filter.PageNumber, filter.PageSize, (int)count.Value);
            return pagedList;
        }
        #endregion

        #region GetOneByIdAsync
        public async Task<ExampleStatusDto> GetOneByIdAsync(int id)
        {
            dynamic parameters = new ExpandoObject();
            parameters.ExampleStatusId = id;
            ExampleStatusDto item = await dbHelper.SqlHelperRead.GetSingleRecordAsync<ExampleStatusDto>("[dbo].[ExampleStatus_GetOneById]", parameters);
            return item;
        }
        #endregion

    }
}
