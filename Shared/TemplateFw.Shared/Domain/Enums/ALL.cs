namespace TemplateFwExample.Shared.Domain.Enums
{
    public enum OperationResult
    {
        ActiveItem = -3,
        HasRelatedItems = -2,
        AlreadyExist = -1,
        NoChanges = 0,
        ExecutionDone = 1
    }

    public enum OperationTypes
    {
        Unknown = 0,
        Add = 1,
        GetList = 2,
        Update = 3,
        Delete = 4,
        Activate = 5,
        Deactivate = 6,
        Publish = 7,
        Unpublish = 8,
        GetOne = 9,
        Save = 10,
        Reject = 11,
        Reply = 12,
        GetContent = 13,
        GetData = 14,
        Upload = 15,
        Download = 16,
        Validate = 17,
        SendOtp = 18,
        Registration = 19
    }
    public enum ResponseTypes
    {
        Html,
        Json
    }

    public enum ErrorCodes
    {
        BadRequest = 400,
        Unauthorized = 401,
        Forbidden = 403,
        AlreadyExists = 409,
        NotFound = 404,
        InternalServerError = 500,
    }

    public enum EnumLanguage
    {
        Arabic = 1,
        English = 2
    }

    public enum EmailTemplate
    {
        ComplaintResponse,
        AddNewAdmin,
        ActivateFoundationAccount,
        DeactivateFoundationAccount,
        ActivateUserAccount,
        RejectUserAccount,
        DeactivateUserAccount,
        FoundationCreated,
        OTP
    }




}
