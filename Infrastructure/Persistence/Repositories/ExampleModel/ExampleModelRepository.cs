using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using TemplateFwExample.Domain.Models;
using TemplateFwExample.Dtos.Common;
using TemplateFwExample.Dtos;
using TemplateFwExample.Shared.Domain.Enums;
using TemplateFwExample.Shared.Dtos.Collections;
using Adoler.AdoExtension.Extensions;
using TemplateFwExample.Persistence.IRepositories;

namespace TemplateFwExample.Persistence.Repositories
{
    public class ExampleModelRepository : IExampleModelRepository
    {
        readonly IDbHelper dbHelper;
        public ExampleModelRepository(IDbHelper dbHelper)
        {
            this.dbHelper = dbHelper;
        }

        #region InsertAsync
        public async Task<bool> CreateAsync(ExampleModelDto dto)
        {
            List<SqlParameter> plist = dto.ConvertToParametersExcept(e => e.ExampleModelId, e => e.CreationDate, e => e.ModifiedBy, e => e.ModifiedDate, e => e.IsAvailable);
            var exampleModelId = plist.AddOutputParameterInteger("ExampleModelId");
            int affectedRows = await dbHelper.SqlHelperWrite.ExecuteNonQueryAsync("[dbo].[ExampleModel_Create]", plist);
            return (affectedRows > 0);
        }
        #endregion

        #region UpdateAsync
        public async Task<bool> UpdateAsync(ExampleModelDto dto)
        {
            List<SqlParameter> plist = dto.ConvertToParametersExcept(e => e.CreatedBy, e => e.CreationDate, e => e.ModifiedDate, e => e.IsAvailable);
            int affectedRows = await dbHelper.SqlHelperWrite.ExecuteNonQueryAsync("[dbo].[ExampleModel_Update]", plist);
            return (affectedRows > 0);
        }

        #endregion

        #region DeleteVirtuallyAsync
        public async Task<bool> DeleteVirtuallyAsync(int id, string user)
        {
            dynamic parameters = new ExpandoObject();
            parameters.ExampleModelId = id;
            parameters.ModifiedBy = user;
            int affectedRows = await dbHelper.SqlHelperWrite.ExecuteNonQueryAsync("[dbo].[ExampleModel_DeleteVirtually]", parameters);
            return (affectedRows > 0);
        }
        #endregion

        #region DeletePermanentlyAsync
        public async Task<bool> DeletePermanentlyAsync(int id)
        {
            dynamic parameters = new ExpandoObject();
            parameters.ExampleModelId = id;
            int affectedRows = await dbHelper.SqlHelperWrite.ExecuteNonQueryAsync("[dbo].[ExampleModel_DeletePermanently]", parameters);
            return (affectedRows > 0);
        }
        #endregion

        #region GetInfoByIdAsync
        public async Task<ExampleModelInfoDto> GetInfoByIdAsync(int id, EnumLanguage lang = EnumLanguage.Arabic)
        {
            dynamic parameters = new ExpandoObject();
            parameters.LanguageId = (int)lang;
            parameters.ExampleModelId = id;
            ExampleModelInfoDto item =await dbHelper.SqlHelperRead.GetSingleRecordAsync<ExampleModelInfoDto>("[dbo].[ExampleModel_GetOneInfo]", parameters);
            return item;
        }
        #endregion

        #region GetAllAsync
        public async Task<List<ExampleModelInfoDto>> GetAllAsync(ExampleModelFilter filter)
        {
            var parameters = filter.ConvertToParametersExcept(e => e.PageNumber, e => e.PageSize);
            List<ExampleModelInfoDto> list = await dbHelper.SqlHelperRead.GetRecordListAsync<ExampleModelInfoDto>("[dbo].[ExampleModel_GetAllInfo]", parameters);
            return list;
        }
        #endregion

        #region GetPagedListAsync
        public async Task<PagedList<ExampleModelInfoDto>> GetAllInfoPagedAsync(ExampleModelFilter filter)
        {
            var parameters = filter.ConvertToParameters();
            var count = parameters.AddOutputTotalCountOutput();
            List<ExampleModelInfoDto> list = await dbHelper.SqlHelperRead.GetRecordListAsync<ExampleModelInfoDto>("[dbo].[ExampleModel_GetAllInfoPaged]", parameters);
            var pagedList = new PagedList<ExampleModelInfoDto>(list, filter.PageNumber, filter.PageSize, (int)count.Value);
            return pagedList;
        }
        #endregion

        #region GetOneByIdAsync
        public async Task<ExampleModelDto> GetOneByIdAsync(int id)
        {
            dynamic parameters = new ExpandoObject();
            parameters.ExampleModelId = id;
            ExampleModelDto item = await dbHelper.SqlHelperRead.GetSingleRecordAsync<ExampleModelDto>("[dbo].[ExampleModel_GetOneById]", parameters);
            return item;
        }
        #endregion

    }
}
