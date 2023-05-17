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
    public class ExampleCategoryRepository : IExampleCategoryRepository
    {
        readonly IDbHelper dbHelper;
        public ExampleCategoryRepository(IDbHelper dbHelper)
        {
            this.dbHelper = dbHelper;
        }

        #region InsertAsync
        public async Task<bool> CreateAsync(ExampleCategoryDto dto)
        {
            List<SqlParameter> plist = dto.ConvertToParametersExcept(e => e.ExampleCategoryId, e => e.CreationDate, e => e.ModifiedBy, e => e.ModifiedDate, e => e.IsAvailable);
            var exampleCategoryId = plist.AddOutputParameterInteger("ExampleCategoryId");
            int affectedRows = await dbHelper.SqlHelperWrite.ExecuteNonQueryAsync("[dbo].[ExampleCategory_Create]", plist);
            return (affectedRows > 0);
        }
        #endregion

        #region UpdateAsync
        public async Task<bool> UpdateAsync(ExampleCategoryDto dto)
        {
            List<SqlParameter> plist = dto.ConvertToParametersExcept(e => e.CreatedBy, e => e.CreationDate, e => e.ModifiedDate, e => e.IsAvailable);
            int affectedRows = await dbHelper.SqlHelperWrite.ExecuteNonQueryAsync("[dbo].[ExampleCategory_Update]", plist);
            return (affectedRows > 0);
        }

        #endregion

        #region DeleteVirtuallyAsync
        public async Task<bool> DeleteVirtuallyAsync(int id, string user)
        {
            dynamic parameters = new ExpandoObject();
            parameters.ExampleCategoryId = id;
            parameters.ModifiedBy = user;
            int affectedRows = await dbHelper.SqlHelperWrite.ExecuteNonQueryAsync("[dbo].[ExampleCategory_DeleteVirtually]", parameters);
            return (affectedRows > 0);
        }
        #endregion

        #region DeletePermanentlyAsync
        public async Task<bool> DeletePermanentlyAsync(int id)
        {
            dynamic parameters = new ExpandoObject();
            parameters.ExampleCategoryId = id;
            int affectedRows = await dbHelper.SqlHelperWrite.ExecuteNonQueryAsync("[dbo].[ExampleCategory_DeletePermanently]", parameters);
            return (affectedRows > 0);
        }
        #endregion

        #region GetInfoByIdAsync
        public async Task<ExampleCategoryInfoDto> GetInfoByIdAsync(int id, EnumLanguage lang = EnumLanguage.Arabic)
        {
            dynamic parameters = new ExpandoObject();
            parameters.LanguageId = (int)lang;
            parameters.ExampleCategoryId = id;
            ExampleCategoryInfoDto item =await dbHelper.SqlHelperRead.GetSingleRecordAsync<ExampleCategoryInfoDto>("[dbo].[ExampleCategory_GetOneInfo]", parameters);
            return item;
        }
        #endregion

        #region GetAllAsync
        public async Task<List<ExampleCategoryInfoDto>> GetAllAsync(ExampleCategoryFilter filter)
        {
            var parameters = filter.ConvertToParametersExcept(e => e.PageNumber, e => e.PageSize);
            List<ExampleCategoryInfoDto> list = await dbHelper.SqlHelperRead.GetRecordListAsync<ExampleCategoryInfoDto>("[dbo].[ExampleCategory_GetAllInfo]", parameters);
            return list;
        }
        #endregion

        #region GetPagedListAsync
        public async Task<PagedList<ExampleCategoryInfoDto>> GetAllInfoPagedAsync(ExampleCategoryFilter filter)
        {
            var parameters = filter.ConvertToParameters();
            var count = parameters.AddOutputTotalCountOutput();
            List<ExampleCategoryInfoDto> list = await dbHelper.SqlHelperRead.GetRecordListAsync<ExampleCategoryInfoDto>("[dbo].[ExampleCategory_GetAllInfoPaged]", parameters);
            var pagedList = new PagedList<ExampleCategoryInfoDto>(list, filter.PageNumber, filter.PageSize, (int)count.Value);
            return pagedList;
        }
        #endregion

        #region GetOneByIdAsync
        public async Task<ExampleCategoryDto> GetOneByIdAsync(int id)
        {
            dynamic parameters = new ExpandoObject();
            parameters.ExampleCategoryId = id;
            ExampleCategoryDto item = await dbHelper.SqlHelperRead.GetSingleRecordAsync<ExampleCategoryDto>("[dbo].[ExampleCategory_GetOneById]", parameters);
            return item;
        }
        #endregion

    }
}
